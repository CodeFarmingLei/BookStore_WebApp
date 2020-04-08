using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.BLL;

namespace BookStore.WebApp.Admins
{
    public partial class Login : System.Web.UI.Page
    {
        private UsersService bll = new UsersService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 登录按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            //获取账号,密码文本框的值
            string ac = this.txtAccount.Text.Trim();
            string pwd = this.txtPassword.Text.Trim();
            var user = bll.Login(ac, pwd);
            if (user == null)
            {
                Response.Write("<script>alert('账号或密码错误，请重试');location.href='Login.aspx';</script>");
            }
            else
            {
                if (ckbRememberMe.Checked)  //记住密码使用 Cookie
                {
                    //创建Cookie
                    HttpCookie userEmail_cookie = new HttpCookie("LoginOk", user.Id.ToString());
                    //设置过期时间,从当前开始计算,有效时间为7天
                    userEmail_cookie.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(userEmail_cookie);     //生成Cookie

                    //记录登入用户的信息及权限信息
                    HttpCookie rolesId_cookie = new HttpCookie("RolesId", user.RolesId.ToString());
                    rolesId_cookie.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(rolesId_cookie);       //生成Cookie
                }
                else    //不记住则使用Session
                {
                    Session["LoginOk"] = user.Id;
                    Session["RolesId"] = user.RolesId;
                }
                Response.Write("<script>alert('用户登录成功!!');location.href='main/Main.aspx'</script>");
            }
        }
    }
}