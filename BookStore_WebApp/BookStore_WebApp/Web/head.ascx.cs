using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.BLL;
using BookStore.Model;

namespace BookStore.WebApp.Web
{
    public partial class head : System.Web.UI.UserControl
    {
        private WebMenuService webMenuSvc = new WebMenuService();
        private AuditService auditService = new AuditService();
        private AppointmentService appService = new AppointmentService();
        //这个是当前用户控件的页面加载效果
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
                return;

            #region 网站菜单绑定

            this.RepNavi.DataSource = webMenuSvc.GetMenusByIsShow(1); //这个地方是我们要绑定到导航栏所以查看能够展示的内容
            this.RepNavi.DataBind();
            #endregion
        }

        /// <summary>
        /// 立即预约的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnSubmit_OnClick(object sender, ImageClickEventArgs e)
        //{
        //    var name = this.txtName.Text;
        //    var tel = this.txtTel.Text;
        //    var price = this.txtAmount.Text;
        //    if (name == "" || tel == "" || price == "")
        //    {
        //        Response.Write("<script>alert('立即预约信息不能为空');</script>");
        //    }
        //    else
        //    {
        //        int aid = 0;
        //        var alist = auditService.GetAll();
        //        if (alist.Count > 0)
        //        {
        //            aid = alist[0].Id;
        //        }

        //        Model.Appointment model = new Appointment
        //        {
        //            RealName =  name,
        //            Telephone = tel,
        //            Amount = int.Parse(price),
        //            AuditId = aid
        //        };

        //        int rs = appService.Add(model);
        //        if (rs > 0)
        //        {
        //            Response.Write("<script>alert('预约成功,稍后客服会与您电话联系');location.href='index.aspx'</script>");
        //        }
        //        else
        //        {
        //            Response.Write("<script>alert('预约失败');location.href='index.aspx'</script>");
        //        }
        //    }
        //}
    }
}