using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.BLL;

namespace BookStore.WebApp.Admins.Appointment
{
    public partial class EditAppointment : System.Web.UI.Page
    {
        private AppointmentService appointmentSvc = new AppointmentService();
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
                //1. 我们需要通过url上传递过来的id值进行id查询
                int id = Request.Params["action"] != null ? int.Parse(Request.Params["action"]) : 0;
                //2.进行id查询,得到对应的对象
                var data = appointmentSvc.GetAppointment(id);
                if (data != null)
                {
                    //有值
                    //把这个对象的值,绑定到对应的位置上
                    this.txtId.Text = data.Id.ToString();
                    this.txtName.Text = data.RealName;
                    this.txtTel.Text = data.Telephone;
                    this.txtAmount.Text = data.Amount.ToString();
                    //下拉列表绑定,把预约状态全部绑定进去
                    this.txtStatus.DataSource = auditSvc.GetAll();
                    this.txtStatus.DataTextField = "Title";
                    this.txtStatus.DataValueField = "Id";
                    this.txtStatus.DataBind();
                    //设定当前下拉列表选中的是我们这个对象所存储的值
                    this.txtStatus.SelectedValue = data.AuditId.ToString(); 

                }
                else
                {
                    Response.Write("<script>alert('数据传递丢失,请稍后再试');location.href='AppointmentList.aspx'</script>");
                }
            }

        }

        //提交按钮点击事件
        protected void btnSumbit_OnClick(object sender, EventArgs e)
        {
            //通过文本id里面的值进行查询,得到当前对象当中所有的数据
            var data = appointmentSvc.GetAppointment(int.Parse(this.txtId.Text));
            //因为这次的修改我们只需要更改2个值,其余的值是不修改的
            data.AuditId = int.Parse(this.txtStatus.SelectedValue);
            data.UpdateTime = DateTime.Now;

            var rs = appointmentSvc.Edit(data);
            if (rs > 0)
            {
                Response.Write("<script>alert('提交成功');location.href='AppointmentList.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('提交失败');location.href='AppointmentList.aspx'</script>");
            }
        }
    }
}