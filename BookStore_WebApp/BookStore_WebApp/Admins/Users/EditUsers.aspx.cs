using BookStore.BLL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore_WebApp.Admins.Users
{
    public partial class EditUsers : System.Web.UI.Page
    {
        private UsersService bll = new UsersService();

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
                //获取ID值
                var id = Request.Params["action"];
                if (id == null)
                {
                    Response.Write("<script>alert('传输数据丢失,请稍后再试');location.href='UsersList.aspx'</script>");
                }
                else
                {
                    var users = bll.GetUsersById(int.Parse(id));
                    if (users == null)
                    {
                        Response.Write("<script>alert('该角色信息不存在');location.href='UsersList.aspx'</script>");
                    }
                    else
                    {
                        this.UsersId.Text = users.Id.ToString();
                        this.UsersEmail.Text = users.Email;
                        this.UsersPwd.Text = users.Password;
                        this.UsersNikeName.Text = users.NickName;
                        this.UsersPhoto.Text = users.Photo;
                        this.UsersCreateTime.Text = users.CreateTime.ToString();
                        this.UsersRolesId.Text = users.RolesId.ToString();
                    }
                }
            }

        }

        /// <summary>
        /// 上传头像文件验证事件
        /// </summary>
        /// <returns></returns>
        public bool FileTitleCheck()
        {
            // 设置上传文件保存的路径  ~代表的是根目录下
            string path = Server.MapPath("~/~/Upload/Users/");
            // 判断文件名是否为空
            if (this.FileUploadTitle.FileName != null || !("".Equals(FileUploadTitle.FileName)))
            {
                var hzm = FileUploadTitle.FileName.Substring(FileUploadTitle.FileName.LastIndexOf('.'));    //获取文件的扩展名
                //文件后缀名满足条件时进行上传
                if (".jpg".Equals(hzm) || ".png".Equals(hzm) || ".gif".Equals(hzm))
                {
                    FileUploadTitle.PostedFile.SaveAs(path + FileUploadTitle.FileName);     //把选择的图片保存到对应的文件夹当中
                    return true;
                }
                else
                {
                    //上传的内容格式不正确
                    //Response.Write("<script>alert('上传控件文件格式不正确');</script>");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        protected void btnSumbit_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.UsersId.Text);
            var Email = this.UsersEmail.Text;
            var Password = this.UsersPwd.Text;
            var NickName = this.UsersEmail.Text;
            var Photo = this.UsersEmail.Text;
            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "yyyy/MM/dd";
            DateTime CreateTime = DateTime.Parse(this.UsersEmail.Text, dtFormat);
            int RolesId = int.Parse(this.UsersEmail.Text);
            int rs = bll.Edit(new BookStore.Model.Users()
            {
                Id = id,
                Email = Email,
                Password = Password,
                NickName = NickName,
                Photo = Photo,
                CreateTime = CreateTime,
                RolesId = RolesId,
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

        protected void FileUploadTitle_DataBinding(object sender, EventArgs e)
        {

        }
    }
}