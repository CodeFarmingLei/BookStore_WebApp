using BookStore.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using BookStore.Model;

namespace BookStore.WebApp.Admins.main
{
    public partial class Left : System.Web.UI.Page
    {

        private UsersPermissionService permissionSvc = new UsersPermissionService();
        private SystemMenuService menuSvc = new SystemMenuService();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            HttpCookie u_cookie = Request.Cookies["LoginOk"];
            HttpCookie r_cookie = Request.Cookies["RolesId"];
            if ((Session["LoginOk"] == null || Session["RolesId"] == null) && (u_cookie == null || r_cookie == null))
            {
                Response.Write("<script>alert('账号信息过期,请重新登入');location.href='../Login.aspx'</script>");
            }
            else 
            {

                var list = MyBind();
                //下面的内容,我们需要对查询出来的数据进行筛选,筛选其中parentId == 0 , 
                //Linq语句,它的写法类似于T-SQL语句 select * from list where parentId = 0
                //var parentList = from list
                //                 where 
                //1. 语言顺序的不一样 Linq 需要先写 从什么集合当中进行查看,筛选
                var parentList = from menu in list   //这个相当于我们写的foreach(var item in list)
                                 where menu.ParentId == 0
                                 select menu;
                this.RepLeftMenu.DataSource = parentList;
                this.RepLeftMenu.DataBind();

            }
        }

        protected void RepLeftMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label lbl = (Label)e.Item.FindControl("lbl_ParentId");
            Repeater rep = (Repeater)e.Item.FindControl("RepSonMenu");
            var list = MyBind();

            var sonMenu = from menu in list
                          where menu.ParentId == int.Parse(lbl.Text)
                          select menu;

            rep.DataSource = sonMenu;
            rep.DataBind();
        }


        public List<Model.SystemMenu> MyBind() 
        {
            var rid = Session["RolesId"];
            if (rid == null)
            {
                rid = Request.Cookies["RolesId"];
            }
            //我们需要绑定外层的Repeater
            var data = permissionSvc.GetUsersPermissionsByRolesId(int.Parse(rid.ToString()));
            //获取到当前权限下所有的菜单id
            string idList = "";
            for (int i = 0; i < data.Count; i++)
            {
                idList += data[i].SystemMenuId.ToString();
                if (i < data.Count - 1)
                {
                    idList += ",";
                }
            }

            return menuSvc.GetMenusListOwn(idList);
        }
    }
}