using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.BLL;

namespace BookStore.WebApp.Admins.WebMenu
{
    public partial class AddWebMenu : System.Web.UI.Page
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
                
               
            }
        }
        /// <summary>
        /// 第一个下拉列表(一级菜单选项的那个下拉列表)索引改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlLevel_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlLevel.SelectedValue == "0")
            {
                this.ddlParentTitle.Visible = false;
                this.ddlSonTitle.Visible = false;
            }
            else if (this.ddlLevel.SelectedValue == "1")
            {
                this.ddlParentTitle.Visible = true;
                //这个地方需要进行查询父级菜单内容
                ParentListBind();
                this.ddlSonTitle.Visible = false;
            }
            else if (this.ddlLevel.SelectedValue == "2")
            {
                this.ddlParentTitle.Visible = true;
                this.ddlSonTitle.Visible = true;
                ParentListBind();
                SonListBind();
            }
        }

        protected void ddlParentTitle_OnSelectedIndexChanged(object sender, EventArgs e)
        {
           SonListBind();
        }

        protected void btnSumbit_OnClick(object sender, EventArgs e)
        {
            int pid = 0,show = 0; //设定父级菜单id的
            if (this.ddlLevel.SelectedValue == "0")
            {
                pid = 0;
            }
            else if (this.ddlLevel.SelectedValue == "1") //二级菜单
            {
                pid = int.Parse(this.ddlParentTitle.SelectedValue);
            }
            else if (this.ddlLevel.SelectedValue == "2") //三级菜单
            {
                pid = int.Parse(this.ddlSonTitle.SelectedValue);
            }

            if (this.RdoShow.Checked)
            {
                show = 1;
            }
            else
            {
                show = 0;
            }

            Model.WebMenu model = new Model.WebMenu()
            {
                Title =  this.MenuTitle.Text,
                Link = this.MenuLink.Text,
                ParentId = pid,
                IsShow = show
            };
            int rs = webMenuSvc.Add(model);
            if (rs > 0)
            {
                Response.Write("<script>alert('添加成功');location.href='WebMenuList.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败');location.href='WebMenuList.aspx'</script>");
            }

        }


        public void ParentListBind()
        {
            this.ddlParentTitle.DataSource = webMenuSvc.GetWebMenusListByParentId(0);
            this.ddlParentTitle.DataTextField = "Title";
            this.ddlParentTitle.DataValueField = "Id";
            this.ddlParentTitle.DataBind();
        }


        public void SonListBind()
        {
            int pid = int.Parse(this.ddlParentTitle.SelectedValue);
            this.ddlSonTitle.DataSource = webMenuSvc.GetWebMenusListByParentId(pid);
            this.ddlSonTitle.DataTextField = "Title";
            this.ddlSonTitle.DataValueField = "Id";
            this.ddlSonTitle.DataBind();
        }
    }
}