﻿using BookStore.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.WebApp.Admins.main
{
    public partial class Top : System.Web.UI.Page
    {
        private UsersService usersSvc = new UsersService();
        public string NickName;
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
                int uid = 0;

                if (u_cookie == null)
                {
                    //Session
                    uid = int.Parse(Session["LoginOk"].ToString());
                }
                else 
                {
                    uid = int.Parse(u_cookie.Value);
                }

                var user = usersSvc.GetUsersById(uid); //通过上面得到的用户编号,进行查询得到对应的值
                if (user != null) 
                {
                    NickName = user.NickName;
                }
            }
        }
    }
}