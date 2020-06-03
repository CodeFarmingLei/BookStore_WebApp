using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.BLL;
using BookStore.Model;

namespace BookStore.WebApp.Hanlder
{
    /// <summary>
    /// AddAppointmentHandler 的摘要说明
    /// </summary>
    public class AddAppointmentHandler : IHttpHandler
    {
        private AppointmentService appointmentSvc = new AppointmentService();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //1. 如何获取从页面上传递过来的数据 
            var name = context.Request.Params["name"];
            var tel = context.Request.Params["tel"];
            var amount =context.Request.Params["amount"];
            Appointment model = new Appointment
            {
                RealName = name,
                Telephone = tel,
                Amount = int.Parse(amount),
                AuditId = 2
            };
            var rs = appointmentSvc.Add(model) > 0;
            context.Response.Write(rs);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}