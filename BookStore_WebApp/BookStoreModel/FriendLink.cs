using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model
{
    public class FriendLink //友情链接表
    {
        public int Id { get; set; }
        public string Title { get; set; }    //标题
        public string Link { get; set; }    //链接
        public bool IsShow { get; set; }    //是否展示
    }
}
