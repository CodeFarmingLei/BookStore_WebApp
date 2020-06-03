using System.Collections.Generic;
using BookStore.DAL;
using BookStore.Model;

namespace BookStore.BLL
{
    public class AuditService
    {
        private AuditManager dal = new AuditManager();

        public List<Audit> GetAll()
        {
            return dal.GetAll();
        }

        public Audit GetAudit(int id)
        {
            return dal.GetAudit(id);
        }
    }
}