using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model
{
    public class SystemMenu //系统菜单表,后台侧面导航栏
    {
        public int Id { get; set; }
        public string Title { get; set; }   //名称
        public string Link { get; set; }    //链接地址
        public int ParentId { get; set; }   //菜单等级
    }
}
