using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopDoket.Core.Services.Interfaces;

namespace TopDoket.Web.Pages.Admin.Discount
{
    public class IndexModel : PageModel
    {
        private IOrderService _orderService;

        public IndexModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public List<DataLayer.Entities.Order.Discount> Discounts { get; set; }
        public void OnGet()
        {
            Discounts = _orderService.GetAllDiscounts();
        }
    }
}