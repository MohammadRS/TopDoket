﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopDoket.Core.Services.Interfaces;
using TopDoket.DataLayer.Context;
using TopDoket.DataLayer.Entities.Permissions;
using TopDoket.DataLayer.Entities.User;

namespace TopDoket.Core.Services
{
    public class PermissionService : IPermissionService
    {
        private TopContext _context;

        public PermissionService(TopContext context)
        {
            _context = context;
        }
        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public void AddRolesToUser(List<int> roleIds, int userId)
        {
            foreach (int roleId in roleIds)
            {
                _context.UserRoles.Add(new UserRole()
                {
                    RoleId = roleId,
                    UserId = userId
                });
            }

            _context.SaveChanges();
        }

        public void EditRolesUser(int userId, List<int> rolesId)
        {
            //Delete All Roles User
            _context.UserRoles.Where(r => r.UserId == userId).ToList().ForEach(r => _context.UserRoles.Remove(r));

            //Add New Roles
            AddRolesToUser(rolesId, userId);
        }

        public int AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role.RoleId;
        }

        public Role GetRoleById(int roleId)
        {
            return _context.Roles.Find(roleId);
        }

        public void UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
        }

        public void DeleteRole(Role role)
        {
            role.IsDelete = true;
            UpdateRole(role);
        }

        public List<Permission> GetAllPermission()
        {
            return _context.Permission.ToList();
        }

        public void AddPermissionsToRole(int roleId, List<int> permission)
        {
            foreach (var p in permission)
            {
                _context.RolePermission.Add(new RolePermission()
                {
                    PermissionId = p,
                    RoleId = roleId
                });
            }

            _context.SaveChanges();
        }

        public List<int> PermissionsRole(int roleId)
        {
            return _context.RolePermission
                .Where(r => r.RoleId == roleId)
                .Select(r => r.PermissionId).ToList();
        }

        public void UpdatePermissionsRole(int roleId, List<int> permissions)
        {
            _context.RolePermission.Where(p => p.RoleId == roleId)
                .ToList().ForEach(p => _context.RolePermission.Remove(p));

            AddPermissionsToRole(roleId, permissions);
        }

        public bool CheckPermission(int permissionId, string userName)
        {
            int userId = _context.Users.Single(u => u.UserName == userName).UserId;

            List<int> UserRoles = _context.UserRoles
                .Where(r => r.UserId == userId).Select(r => r.RoleId).ToList();

            if (!UserRoles.Any())
                return false;

            List<int> RolesPermission = _context.RolePermission
                .Where(p => p.PermissionId == permissionId)
                .Select(p => p.RoleId).ToList();

            return RolesPermission.Any(p => UserRoles.Contains(p));

        }
    }
}

