using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.BLL;

namespace BookStore.WebApp.Admins.Roles
{
    public partial class EditRoles : System.Web.UI.Page
    {
        private RolesService bll = new RolesService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
                return;
            HttpCookie u_cookie = Request.Cookies["LoginOk"];
            HttpCookie r_cookie = Request.Cookies["RolesId"];
            if ((Session["LoginOk"] == null || Session["RolesId"] == null) && (u_cookie == null || r_cookie == null))
            {
                Response.Write("<script>alert('账号信息过期,请重新登入');location.href='../Login.aspx'</script>");
            }
            else
            {
                //修改要做的 :
                //1. 页面绑定
                // (1) 先去获取到我们从连接当中传递过来的id值
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
                        this.RolesId.Text = roles.Id.ToString();
                        this.RolesTitle.Text = roles.Title;
                    }
                }
            }

        }

        protected void btnSumbit_OnClick(object sender, EventArgs e)
        {
            int id = int.Parse(this.RolesId.Text);
            var title = this.RolesTitle.Text;
            int rs = bll.Edit(new Model.Roles()
            {
                Id = id,
                Title = title
            });
            if (rs > 0)
            {
                Response.Write("<script>alert('修改成功');location.href='RolesList.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败');</script>");
            }
        }
    }
}