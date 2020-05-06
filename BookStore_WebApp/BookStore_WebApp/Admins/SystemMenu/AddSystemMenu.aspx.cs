using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.BLL;
namespace BookStore.WebApp.Admins.SystemMenu
{
    public partial class AddSystemMenu : System.Web.UI.Page
    {
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
            }
        }

        /// <summary>
        /// 第一个下拉列表的改变事件,用于设定后面的选择项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlLevel.SelectedValue == "0")
            {
                this.ddlParentTitle.Visible = false;
                this.ddlSonTitle.Visible = false;
            }
            else if (this.ddlLevel.SelectedValue == "1")
            {
                this.ddlParentTitle.Visible = true;
                ParentListBind();
                this.ddlSonTitle.Visible = false;
            }
            else if (this.ddlLevel.SelectedValue == "2")
            {
                this.ddlParentTitle.Visible = true;
                this.ddlSonTitle.Visible = true;
                ParentListBind();
                SonTitleBind();
            }
        }
        /// <summary>
        /// 保存按钮的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSumbit_Click(object sender, EventArgs e)
        {
            //父级菜单id在存值之前,我们需要对它进行判断
            int pid;
            if (this.ddlLevel.SelectedValue == "0")
            {
                pid = 0;
            }
            else if (this.ddlLevel.SelectedValue == "1")
            {
                pid = int.Parse(this.ddlParentTitle.SelectedValue);
            }
            else 
            {
                pid = int.Parse(this.ddlSonTitle.SelectedValue);
            }

            Model.SystemMenu model = new Model.SystemMenu
            {
                Title = this.MenuTitle.Text,
                Link = this.MenuLink.Text,
                ParentId = pid
            };

            int rs = menuSvc.Add(model);
            if (rs > 0)
            {
                Response.Write("<script>alert('添加成功');location.href='SystemMenuList.aspx'</script>");
            }
            else 
            {
                Response.Write("<script>alert('添加失败');location.href='SystemMenuList.aspx'</script>");
            }
        }

        public void ParentListBind() 
        {
            this.ddlParentTitle.DataSource = menuSvc.GetSystemMenusListByParentId(0);
            this.ddlParentTitle.DataTextField = "Title";
            this.ddlParentTitle.DataValueField = "Id";
            this.ddlParentTitle.DataBind();
        }

        public void SonTitleBind() 
        {
            int id = int.Parse(this.ddlParentTitle.SelectedValue);
            this.ddlSonTitle.DataSource = menuSvc.GetSystemMenusListByParentId(id);
            this.ddlSonTitle.DataTextField = "Title";
            this.ddlSonTitle.DataValueField = "Id";
            this.ddlSonTitle.DataBind();
        }
        /// <summary>
        /// 二级菜单改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlParentTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            SonTitleBind();
        }
    }
}