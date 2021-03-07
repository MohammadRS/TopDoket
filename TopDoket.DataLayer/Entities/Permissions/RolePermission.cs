using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TopDoket.DataLayer.Entities.User;

namespace TopDoket.DataLayer.Entities.Permissions
{
    public class RolePermission
    {
        [Key]
        public int RP_Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        public Role Role { get; set; }
        public Permission Permission { get; set; }

    }
}
