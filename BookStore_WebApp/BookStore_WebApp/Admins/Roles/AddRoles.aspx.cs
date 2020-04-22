using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.BLL;

namespace BookStore.WebApp.Admins.Roles
{
    public partial class AddRoles : System.Web.UI.Page
    {
        private RolesService bll = new RolesService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 保存按钮的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSumbit_OnClick(object sender, EventArgs e)
        {
            var title = this.RolesTitle.Text.Trim();
            int rs = bll.Add(new Model.Roles()
                    {
                        Title =  title
                    });

            if (rs > 0)
            {
                //添加成功
                Response.Write("<script>alert('添加成功');location.href='RolesList.aspx'</script>");
            }
            else
            {
                //添加失败
                Response.Write("<script>alert('添加失败');</script>");
            }
        }
    }
}