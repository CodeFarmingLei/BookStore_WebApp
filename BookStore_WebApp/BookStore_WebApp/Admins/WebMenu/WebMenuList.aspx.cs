using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.BLL;
using Wuqi.Webdiyer;

namespace BookStore.WebApp.Admins.WebMenu
{
    public partial class WebMenuList : System.Web.UI.Page
    {
        private WebMenuService webMenuSvc = new WebMenuService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            
            //登入验证处理,未登入的跳回到原来的login界面 session cookie
            HttpCookie u_cookie = Request.Cookies["LoginOk"];
            HttpCookie r_cookie = Request.Cookies["RolesId"];

            if ((Session["LoginOk"] == null || Session["RolesId"] == null) && (u_cookie == null || r_cookie == null))
            {
                Response.Write("<script>alert('账号信息过期,请重新登入');location.href='../Login.aspx'</script>");
            }
            else
            {
                //当我们登入了,就得进行Repeater控件
                MyBind("");
            }


        }

        protected void ibtnGetSubmit_OnClick(object sender, ImageClickEventArgs e)
        {
            MyBind(this.txtKeyWords.Text);
        }



        protected void AspNetPager1_OnPageChanging(object src, PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            MyBind(this.txtKeyWords.Text);
        }


        public string GetWebMenuTitle(int parentId)
        {
            if (parentId == 0)
            {
                return "一级菜单";
            }
            else
            {
                var data = webMenuSvc.GetWebMenuById(parentId); //通过传递过来的父级菜单id,
                //进行id查询,如果查出数据了,这个数据的名称就是我们要返回标题名
                return data.Title;
            }

        }

        /// <summary>
        /// 绑定事件
        /// </summary>
        /// <param name="search"></param>
        public void MyBind(string search)
        {
            var list = webMenuSvc.GetWebMenusListByTitle(search);
            PagedDataSource pds = new PagedDataSource(); //这个是分页的数据源
            pds.DataSource = list;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;
            AspNetPager1.RecordCount = list.Count;
            this.RepWebMenuList.DataSource = pds;
            this.RepWebMenuList.DataBind();
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnDelAll_OnClick(object sender, ImageClickEventArgs e)
        {
            
        }
    }
}