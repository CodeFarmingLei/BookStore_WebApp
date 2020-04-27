using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.BLL;
using Wuqi.Webdiyer;
namespace BookStore.WebApp.Admins.SystemMenu
{
    public partial class SystemMenuList : System.Web.UI.Page
    {
        private SystemMenuService menuSvc = new SystemMenuService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            MyBind("");

        }

        protected void ibtnGetSubmit_OnClick(object sender, ImageClickEventArgs e)
        {
            MyBind(this.txtKeyWords.Text);
        }

        protected void ibtnDelAll_OnClick(object sender, ImageClickEventArgs e)
        {

        }

        protected void AspNetPager1_OnPageChanging(object src, PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            MyBind(this.txtKeyWords.Text);
        }

        public void MyBind(string key)
        {
            var list = menuSvc.GetSystemMenusListByTitle(key);
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = list;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;
            AspNetPager1.RecordCount = list.Count;
            this.RepSystemMenuList.DataSource = pds;
            this.RepSystemMenuList.DataBind();
        }


        public string GetSystemMenuTitle(int pid)
        {
            if (pid == 0)
                return "一级菜单";
            var data = menuSvc.GetSystemMenuById(pid);
            return data.Title;
        }

        /// <summary>
        /// 这个是Repeater控件嵌套的时候,外层Repeater必须带有的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">我们能找到Repeater控件当中所有的服务器控件</param>
        protected void RepSystemMenuList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //这个事件是每一次执行到内层repeater时,都会进入到这个当中,做第二次的查询
           // (1) 先去找到带有parentid的那个label控件并且获取 它的一个文本值
            //Label lbl = (Label)e.Item.FindControl("lblparentid");
            ////(2) 找到内层的repeater控件
            //Repeater rep = (Repeater)e.Item.FindControl("repparenttitle");
            ////(3) 实现内层repeater的绑定
            //int id = int.Parse(lbl.Text);
            //if (id != 0)
            //{
            //    var list = new List<Model.SystemMenu>();
            //    var data = menuSvc.GetSystemMenuById(id);
            //    list.Add(data);
            //    rep.DataSource = list;
            //    rep.DataBind();
            //}
        }
    }
}