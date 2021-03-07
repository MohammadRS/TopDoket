using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDoket.Core.DTOs.Order;
using TopDoket.Core.Services.Interfaces;
using TopDoket.DataLayer.Context;
using TopDoket.DataLayer.Entities.Course;
using TopDoket.DataLayer.Entities.Order;
using TopDoket.DataLayer.Entities.User;
using TopDoket.DataLayer.Entities.Wallet;

namespace TopDoket.Core.Services
{
    public class OrderService : IOrderService
    {
        private TopContext _context;
        private IUserService _userService;

        public OrderService(TopContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public int AddOrder(string userName, int courseId)
        {
            int userId = _userService.GetUserIdByUserName(userName);
            Order order = _context.Orders
                .FirstOrDefault(order => order.UserId == userId && !order.IsFinaly);

            var course = _context.Courses.Find(courseId);

            if(order == null)
            {
                order = new Order()
                {
                    UserId = userId,
                    IsFinaly = false,
                    CreateDate = DateTime.Now,
                    OrderSum = course.CoursePrice,
                    OrderDetails = new List<OrderDetail>()
                    {
                        new OrderDetail()
                        {
                            CourseId = courseId,
                            Count = 1,
                            Price = course.CoursePrice
                        }
                    }
                };
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
            else
            {
                OrderDetail detail = _context.OrderDetails
                    .FirstOrDefault(d => d.OrderId == order.OrderId && d.CourseId == courseId);
                if(detail != null)
                {
                    detail.Count += 1;
                    _context.OrderDetails.Update(detail);
                }
                else
                {
                    detail = new OrderDetail()
                    {
                        OrderId = order.OrderId,
                        Count = 1,
                        CourseId = courseId,
                        Price = course.CoursePrice,
                    };
                    _context.OrderDetails.Add(detail);
                }
                _context.SaveChanges();
                UpdatePriceOrder(order.OrderId);
            }

            return order.OrderId;

        }

        public void UpdatePriceOrder(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            order.OrderSum = _context.OrderDetails.Where(d => d.OrderId == orderId).Sum(d => d.Price);
            _context.Orders.Update(order);
            _context.SaveChanges();
        }


        public bool FinalyOrder(string userName, int orderId)
        {
            int userId = _userService.GetUserIdByUserName(userName);
            var order = _context.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Course)
                .FirstOrDefault(o => o.OrderId == orderId && o.UserId == userId);

            if (order == null || order.IsFinaly)
            {
                return false;
            }
            if (_userService.BalanceUserWallet(userName) >= order.OrderSum)
            {
                order.IsFinaly = true;
                _userService.AddWallet(new Wallet()
                {
                    Amount = order.OrderSum,
                    CreateDate = DateTime.Now,
                    IsPay = true,
                    Description = "فاکتور شما #" + order.OrderId,
                    UserId = userId,
                    TypeId = 2
                });
                _context.Orders.Update(order);

                foreach (var detail in order.OrderDetails)
                {
                    _context.UserCourses.Add(new UserCourse()
                    {
                        CourseId = detail.CourseId,
                        UserId = userId
                    });
                }

                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public Order GetOrderForUserPanel(string userName, int orderId)
        {
            int userId = _userService.GetUserIdByUserName(userName);

            return _context.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Course)
                .FirstOrDefault(o => o.UserId == userId && o.OrderId == orderId);
        }

        public Order GetOrderById(int orderId)
        {
            return _context.Orders.Find(orderId);
        }

        public List<Order> GetUserOrders(string userName)
        {
            int userId = _userService.GetUserIdByUserName(userName);

            return _context.Orders.Where(o => o.UserId == userId).ToList();
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public DiscountUseType UseDiscount(int orderId, string code)
        {
            var discount = _context.Discounts.SingleOrDefault(d => d.DiscountCode == code);

            if (discount == null)
                return DiscountUseType.NotFound;

            if (discount.StartDate != null && DateTime.Now > discount.StartDate )
                return DiscountUseType.ExpierDate;

            if (discount.UsableCount != null && DateTime.Now > discount.EndDate)
                return DiscountUseType.ExpierDate;

            if (discount.UsableCount != null && discount.UsableCount < 1)
                return DiscountUseType.Finished;

            var order = GetOrderById(orderId);

            if (_context.UserDiscountCodes.Any(d => d.UserId == order.UserId && d.DiscountId == discount.DiscountId))
                return DiscountUseType.UserUsed;

            int percent = (order.OrderSum * discount.DiscountPercent) / 100;
            order.OrderSum = order.OrderSum - percent;

            UpdateOrder(order);

            if(discount.UsableCount != null)
            {
                discount.UsableCount -= 1;
            }

            _context.Discounts.Update(discount);
            _context.UserDiscountCodes.Add(new UserDiscountCode()
            {
                UserId = order.UserId,
                DiscountId = discount.DiscountId
            });
            _context.SaveChanges();


            return DiscountUseType.Success;
        }

        public void AddDiscount(Discount discount)
        {
            _context.Discounts.Add(discount);
            _context.SaveChanges();
        }

        public List<Discount> GetAllDiscounts()
        {
            return _context.Discounts.ToList();
        }

        public Discount GetDiscountById(int discountId)
        {
            return _context.Discounts.Find(discountId);
        }

        public void UpdateDiscount(Discount discount)
        {
            _context.Discounts.Update(discount);
            _context.SaveChanges();
        }

        public bool IsUserInCourse(string userName, int courseId)
        {
            int userId = _userService.GetUserIdByUserName(userName);

            return _context.UserCourses.Any(c => c.UserId == userId && c.CourseId == courseId);
        }

        public bool IsExistCode(string code)
        {
            return _context.Discounts.Any(d => d.DiscountCode == code);
        }
    }
}
