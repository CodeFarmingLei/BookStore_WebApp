using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model
{
    public class UsersPermission    //权限分配表
    {
        public int Id { get; set; }
        public int RolesId { get; set; }    //权限编号
        public int SystemMenuId { get; set; }   // 系统菜单编号
    }
}
