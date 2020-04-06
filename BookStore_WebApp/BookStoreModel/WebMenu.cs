using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModel
{
    public class WebMenu //网站菜单表，前台界面的导航栏信息
    {
        public int Id { get; set; }
        public string Title { get; set; }   //标题名称
        public string Link { get; set; }    //链接地址
        public int ParentId { get; set; }   //菜单等级
    }
}
