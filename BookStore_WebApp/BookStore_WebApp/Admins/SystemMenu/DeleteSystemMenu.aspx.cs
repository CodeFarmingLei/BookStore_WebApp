using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.BLL;

namespace BookStore.WebApp.Admins.SystemMenu
{
    public partial class DeleteSystemMenu : System.Web.UI.Page
    {
        private SystemMenuService menuSvc = new SystemMenuService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            int id = Request.Params["action"] == null ? 0 : int.Parse(Request.Params["action"]);

            var data = menuSvc.GetSystemMenuById(id);
            if (data == null)
            {
                Response.Write("<script>alert('查询的对象不存在');location.href='SystemMenuList.aspx'</script>");
            }
            else
            {
                int rs = menuSvc.Delete(data);
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