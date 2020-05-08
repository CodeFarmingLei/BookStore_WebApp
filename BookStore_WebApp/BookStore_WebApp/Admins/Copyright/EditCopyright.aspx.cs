using BookStore.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.WebApp.Admins.Copyright
{
    public partial class EditCopyright : System.Web.UI.Page
    {
        public string imgSrc1, imgSrc2;

        private CopyrightService copyrightSvc = new CopyrightService();
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
        }
    }
}