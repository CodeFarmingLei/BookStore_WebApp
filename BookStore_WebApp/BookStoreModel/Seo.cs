using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModel
{
    public class Seo    //Seo前台数据优化信息表
    {
        public int Id { get; set; }
        public int Title { get; set; }  //名称
        public int Keyword { get; set; }    //关键字
        public int Descriptions { get; set; }   //网站描述信息
        public int WebMenuId { get; set; }  //与网站菜单表关联外键ID
    }
}
