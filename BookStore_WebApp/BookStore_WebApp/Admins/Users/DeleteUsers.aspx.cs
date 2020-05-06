using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.BLL;

namespace BookStore.WebApp.Admins.Users
{
    public partial class DeleteUsers : System.Web.UI.Page
    {
        private UsersService usersSvc = new UsersService();
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
                string id = Request.Params["action"];
                if (id == null)
                {
                    Response.Write("<script>alert('参数传递失败');location.href='UsersList.aspx'</script>");
                }
                else
                {
                    var data = usersSvc.GetUsersById(int.Parse(id));
                    if (data == null)
                    {
                        Response.Write("<script>alert('要删除的用户不存在');location.href='UsersList.aspx'</script>");
                    }
                    else
                    {
                        int rs = usersSvc.Delete(data);
                        if (rs > 0)
                        {
                            Response.Write("<script>alert('删除成功');location.href='UsersList.aspx'</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('删除失败');location.href='UsersList.aspx'</script>");
                        }
                    }
                }
            }
                
        }
    }
}