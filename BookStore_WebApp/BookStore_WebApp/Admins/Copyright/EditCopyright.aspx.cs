using BookStore.BLL;
using BookStore.WebApp.Tools;
using System;
using System.Web;

namespace BookStore.WebApp.Admins.Copyright
{
    public partial class EditCopyright : System.Web.UI.Page
    {
        public string imgSrc1, imgSrc2;

        private CopyrightService copyrightSvc = new CopyrightService();
        private UploadImages upload = new UploadImages();
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
                int id = Convert.ToInt32(Request.Params["action"]);
                var model = copyrightSvc.GetCopyright(id);
                if (model != null)
                {
                    this.txtId.Text = model.Id.ToString();
                    this.txtTitle.Text = model.Title;
                    this.txtContent.Text = model.Content;
                    this.txtAddress.Text = model.Address;
                    this.txtEmail.Text = model.Email;
                    this.txtQQNumber1.Text = model.QQ1;
                    this.txtQQNumber2.Text = model.QQ2;
                    this.txtTel1.Text = model.Tel1;
                    this.txtTel2.Text = model.Tel2;
                    this.txtWechat.Text = model.Wechat;
                    imgSrc1 = model.Logo;
                    imgSrc2 = model.Images;

                }

            }
        }

        protected void btnSumbit_Click(object sender, EventArgs e)
        {
            //这个地方我们需要判断什么时候执行的是新增功能,什么时候执行的是修改功能
            if (this.txtId.Text == "") //当我们id的文本框为空的时候,我们要执行的是新增功能
            {
                int res = copyrightSvc.Add(new Model.Copyright
                {
                    Title = this.txtTitle.Text,
                    Content = this.txtContent.Text,
                    Address = this.txtAddress.Text,
                    Email = this.txtEmail.Text,
                    QQ1 = this.txtQQNumber1.Text,
                    QQ2 = this.txtQQNumber2.Text,
                    Tel1 = this.txtTel1.Text,
                    Tel2 = this.txtTel2.Text,
                    Wechat = this.txtWechat.Text,
                    Logo = upload.UpFileName(FileUpload1, "../../upload/copyright/"),
                    Images = upload.UpFileName(FileUpload2, "../../upload/copyright/")

                });
                if (res > 0)
                {
                    Response.Write("<script>alert('新增成功');location.href='EditCopyright.aspx?action=1'</script>");
                }
                else 
                {
                    Response.Write("<script>alert('新增失败');location.href='EditCopyright.aspx?action=1</script>");
                }
            }
            else //当我们id的文本框不为空的时候,我们要执行的是修改功能
            {
                //修改的时候我们不能直接去修改,我们需要先查一遍,之后根据查询出来的内容进行修改
                var data = copyrightSvc.GetCopyright(1);
                data.Title = this.txtTitle.Text;
                data.Content = this.txtContent.Text;
                data.Address = this.txtAddress.Text;
                data.Email = this.txtEmail.Text;
                data.QQ1 = this.txtQQNumber1.Text;
                data.QQ2 = this.txtQQNumber2.Text;
                data.Tel1 = this.txtTel1.Text;
                data.Tel2 = this.txtTel2.Text;
                data.Wechat = this.txtWechat.Text;

                if (upload.UpFileName(FileUpload1, "../../upload/copyright/") != "")  //这个地方代表我们更改了上传图片内容
                {
                    data.Logo = upload.UpFileName(FileUpload1, "../../upload/copyright/");
                }

                if (upload.UpFileName(FileUpload2, "../../upload/copyright/") != "")  //这个地方代表我们更改了上传图片内容
                {
                    data.Images = upload.UpFileName(FileUpload2, "../../upload/copyright/");
                }

                int res = copyrightSvc.Edit(data);

                if (res > 0)
                {
                    Response.Write("<script>alert('编辑成功');location.href='EditCopyright.aspx?action=1'</script>");
                }
                else
                {
                    Response.Write("<script>alert('编辑失败');location.href='EditCopyright.aspx?action=1</script>");
                }

            }

        }
    }
}