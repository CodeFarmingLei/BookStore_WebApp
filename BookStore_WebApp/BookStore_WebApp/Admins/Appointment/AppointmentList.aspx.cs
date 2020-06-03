using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.BLL;
using Wuqi.Webdiyer;

namespace BookStore.WebApp.Admins.Appointment
{
    public partial class AppointmentList : System.Web.UI.Page
    {
        private AppointmentService appointSvc = new AppointmentService();
        private AuditService auditSvc = new AuditService();

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
                Bind("");
            }
        }

        protected void AspNetPager1_OnPageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            Bind(this.txtKeyWords.Text);
        }

        protected void ibtnGetSubmit_OnClick(object sender, ImageClickEventArgs e)
        {
           Bind(this.txtKeyWords.Text);
        }


        public void Bind(string keyword)
        {
            var data = appointSvc.GetAllByRealName(keyword);
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = data;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;
            this.RepAppointmentList.DataSource = pds;
            this.RepAppointmentList.DataBind();
        }


        public string getType(int id)
        {
            var data = auditSvc.GetAudit(id);
            if (data != null)
                return data.Title;
            return "";
        }

    }
}