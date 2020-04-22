using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.BLL;

namespace BookStore.WebApp.Admins.Roles
{
    public partial class DeleteRoles : System.Web.UI.Page
    {
        private RolesService bll = new RolesService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            var id = Request.Params["action"];
            if (id == null)
            {
                Response.Write("<script>alert('传输数据丢失,请稍后再试');location.href='RolesList.aspx'</script>");
            }
            else
            {
                var roles = bll.GetRoles(int.Parse(id));
                if (roles == null)
                {
                    Response.Write("<script>alert('该角色信息不存在');location.href='RolesList.aspx'</script>");
                }
                else
                {
                    int rs = bll.Delete(roles);
                    if (rs > 0)
                    {
                        Response.Write("<script>alert('删除成功');location.href='RolesList.aspx'</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('删除失败');location.href='RolesList.aspx'</script>");
                    }
                }
            }
        }
    }
}