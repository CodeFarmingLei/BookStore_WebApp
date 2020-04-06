using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModel
{
    public class Copyright  //版权信息表
    {
        public int Id { get; set; }
        public string Title { get; set; }               //标题名称
        public string Content { get; set; }         //详细信息
        public string Address { get; set; }         //地址
        public string Tel1 { get; set; }              //电话1
        public string Tel2 { get; set; }              //电话2
        public string QQ1 { get; set; }              //QQ号码1
        public string QQ2 { get; set; }              //QQ号码2
        public string Wechat { get; set; }         //微信号码
        public string Email { get; set; }            //邮箱
        public string Logo { get; set; }            //Logo图片
        public string Images { get; set; }        //其他图片
    }
}
