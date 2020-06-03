using System.Collections.Generic;
using System.Data.SqlClient;
using BookStore.DAL;
using BookStore.Model;

namespace BookStore.BLL
{
    public class AppointmentService
    {
        private AppointmentManager dal = new AppointmentManager();
        public int Add(Appointment model)
        {
            return dal.Add(model);
        }

        public int Edit(Appointment model)
        {
            return dal.Edit(model);
        }


        public List<Appointment> GetAll()
        {
            return dal.GetAll();
        }

        public List<Appointment> GetAllByRealName(string name)
        {
            return dal.GetAllByRealName(name);
        }

        public Appointment GetAppointment(int id)
        {
            return dal.GetAppointment(id);
        }

        public List<Appointment> GetAllByAuditId(int auditId)
        {
            return dal.GetAllByAuditId(auditId);
        }

        public int GetCountByAuditId(int auditId)
        {
            return dal.GetCountByAuditId(auditId);
        }
    }
}