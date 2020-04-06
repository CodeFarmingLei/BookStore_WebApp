using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModel
{
    public class Users  //用户表
    {
        public int Id { get; set; }
        public string Password { get; set; }    //密码
        public string Email { get; set; }           //邮箱
        public string NickName { get; set; }    //昵称
        public string Photo { get; set; }           //头像
        public DateTime CreateTime { get; set; }  //创建时间
        public int RolesId { get; set; }            //关联权限ID
    }
}
