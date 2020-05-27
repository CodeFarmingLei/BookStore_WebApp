using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.BLL;
using BookStore.WebApp.Tools;

namespace BookStore.WebApp.Admins.About
{
    public partial class EditAbout : System.Web.UI.Page
    {
        private AboutService aboutSvc = new AboutService();
        private UploadImages upload = new UploadImages();
        public string imgSrc = "";
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
                //我们需要在这个地方进行查询(按照id查询)
                int id = Request.Params["action"] == null ? 0 : int.Parse(Request.Params["action"]);
                var data = aboutSvc.GetAboutById(id);

                this.txtId.Text = id.ToString();
                this.txtTitle.Text = data.Title;
                this.txtContent.Value = data.Content;

                if (data.Images == "" || data.Images == null)
                {
                    this.imgAbout.Attributes.Add("style","display:none");
                }
                else
                {
                    this.imgAbout.Attributes.Add("style", "display:inline-block");
                    imgSrc = data.Images;
                }

            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            int rs = 0;

            var data = aboutSvc.GetAboutById(int.Parse(this.txtId.Text));
            if (data.Title == null)
            {
                //这种是我们执行新增
                Model.About about = new Model.About()
                {
                    Title = this.txtTitle.Text,
                    Content = this.txtContent.Value,
                    Images = upload.UpFileName(FileUpload1,"../../upload/about")
                };
                rs = aboutSvc.Add(about);
            }
            else
            {
                //执行修改
                data.Title = this.txtTitle.Text;
                data.Content = this.txtContent.Value;
                data.UpdateTime = DateTime.Now;
                var imgSrc = upload.UpFileName(FileUpload1, "../../upload/about");
                if (imgSrc != "")
                    data.Images = imgSrc;
                rs = aboutSvc.Edit(data);
            }


            if (rs > 0)
            {
                //提示编辑成功
                Response.Write("<script>alert('编辑成功');location.href='EditAbout.aspx?action=1'</script>");
            }
            else
            {
                //编辑失败
                Response.Write("<script>alert('编辑失败');location.href='EditAbout.aspx?action=1'</script>");
            }
        }
    }
}