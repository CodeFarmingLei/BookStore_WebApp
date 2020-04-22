using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.BLL;
using BookStore.WebApp.Tools;

namespace BookStore.WebApp.Admins.Users
{
    public partial class AddUsers : System.Web.UI.Page
    {
        private RolesService rolesSvc = new RolesService();
        private UsersService usersSvc = new UsersService();
        private UploadImages upload = new UploadImages();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            #region 权限下拉列表的绑定

            this.RolesList.DataSource = rolesSvc.GetRolesList();
            this.RolesList.DataValueField = "Id";
            this.RolesList.DataTextField = "Title";
            this.RolesList.DataBind();

            #endregion

        }

        protected void btnSumbit_OnClick(object sender, EventArgs e)
        {
            Model.Users u = new Model.Users
            {
                Email =  this.Email.Text,
                Password = this.Password.Text,
                NickName = this.NickName.Text,
                RolesId = int.Parse(this.RolesList.SelectedValue),
                Photo = upload.UpFileName(FileUpload1,"../../upload/users/"),
                CreateTime = DateTime.Now
            };

            int rs = usersSvc.Add(u);
            if (rs > 0)
            {
                Response.Write("<script>alert('添加成功');location.href='UsersList.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败');location.href='AddUsers.aspx'</script>");
            }
        }
    }
}