using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.BLL;

namespace BookStore.WebApp.Admins.WebMenu
{
    public partial class DeleteWebMenu : System.Web.UI.Page
    {
        private WebMenuService webMenuSvc = new WebMenuService();
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

                int id = Request.Params["action"] == null ? 0 : int.Parse(Request.Params["action"]);

                var data = webMenuSvc.GetWebMenuById(id);
                if (data == null)
                {
                    Response.Write("<script>alert('查询的对象不存在');location.href='SystemMenuList.aspx'</script>");
                }
                else
                {
                    int rs = webMenuSvc.Delete(data);
                    if (rs > 0)
                    {
                        Response.Write("<script>alert('删除成功');location.href='SystemMenuList.aspx'</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('删除失败');location.href='SystemMenuList.aspx'</script>");
                    }
                }
            }
        }
    }
}