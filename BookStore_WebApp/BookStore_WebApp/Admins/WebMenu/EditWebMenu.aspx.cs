using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.BLL;

namespace BookStore.WebApp.Admins.WebMenu
{
    public partial class EditWebMenu : System.Web.UI.Page
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

                ParentTitleBind();
                //下面我们开始做页面内容绑定
                int id = Request.Params["action"] == null ? 0 : int.Parse(Request.Params["action"]);

                var model = webMenuSvc.GetWebMenuById(id);
                if (model == null)
                {
                    Response.Write("<script>alert('查询的对象不存在');location.href='SystemMenuList.aspx'</script>");
                }
                else
                {
                    this.MenuId.Text = model.Id.ToString();
                    this.MenuTitle.Text = model.Title;
                    this.MenuLink.Text = model.Link;
                    //下拉列表怎么做啊
                    if (model.ParentId == 0) //这种情况是一级菜单
                    {
                        this.ddlLevel.SelectedIndex = 0;
                        this.ddlParentTitle.Visible = false;
                        this.ddlSonTitle.Visible = false;
                    }
                    else //这个里面指定的是不是一级菜单的情况
                    {
                        var parent = webMenuSvc.GetWebMenuById(model.ParentId);
                        if (parent.ParentId == 0) //这种情况是指二级菜单
                        {
                            this.ddlLevel.SelectedIndex = 1;
                            this.ddlParentTitle.Visible = true;
                            this.ddlParentTitle.SelectedValue = parent.Id.ToString();
                            this.ddlSonTitle.Visible = false;
                        }
                        else //这种情况指三级菜单
                        {
                            this.ddlLevel.SelectedIndex = 2;
                            this.ddlParentTitle.Visible = true;
                            this.ddlSonTitle.Visible = true;
                            this.ddlParentTitle.SelectedValue = parent.ParentId.ToString();

                            SonTitleBind(parent.ParentId);

                            this.ddlSonTitle.SelectedValue = parent.Id.ToString();

                        }
                    }

                    if (model.IsShow == 1)
                    {
                        this.RdoShow.Checked = true;
                    }
                    else
                    {
                        this.RdoHidden.Checked = true;
                    }

                }
            }
        }

        protected void btnSumbit_OnClick(object sender, EventArgs e)
        {
            int pid,show;
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

            if (this.RdoShow.Checked)
            {
                show = 1;
            }
            else
            {
                show = 0;
            }

            Model.WebMenu model = new Model.WebMenu
            {
                Id = int.Parse(this.MenuId.Text),
                Title = this.MenuTitle.Text,
                Link = this.MenuLink.Text,
                ParentId = pid,
                IsShow = show
            };
            int rs = webMenuSvc.Edit(model);
            if (rs > 0)
            {
                Response.Write("<script>alert('编辑成功');location.href='SystemMenuList.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('编辑失败');location.href='SystemMenuList.aspx'</script>");
            }
        }

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
                this.ddlSonTitle.Visible = false;
            }
            else if (this.ddlLevel.SelectedValue == "2")
            {
                this.ddlParentTitle.Visible = true;
                this.ddlSonTitle.Visible = true;
                SonTitleBind(int.Parse(this.ddlParentTitle.SelectedValue));
            }
        }

        protected void ddlParentTitle_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SonTitleBind(int.Parse(this.ddlParentTitle.SelectedValue));
        }


        /// <summary>
        /// 父级菜单的绑定(一级菜单内容)
        /// </summary>
        public void ParentTitleBind()
        {
            this.ddlParentTitle.DataSource = webMenuSvc.GetWebMenusListByParentId(0);
            this.ddlParentTitle.DataValueField = "Id";
            this.ddlParentTitle.DataTextField = "Title";
            this.ddlParentTitle.DataBind();
        }

        /// <summary>
        /// 子级菜单的绑定(二级菜单内容)
        /// </summary>
        public void SonTitleBind(int pid)
        {
            this.ddlSonTitle.DataSource = webMenuSvc.GetWebMenusListByParentId(pid);
            this.ddlSonTitle.DataValueField = "Id";
            this.ddlSonTitle.DataTextField = "Title";
            this.ddlSonTitle.DataBind();
        }
    }
}