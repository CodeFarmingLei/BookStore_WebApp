using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BookStore.Model;

namespace BookStore.DAL
{
    public class AuditManager
    {
        public List<Audit> GetAll()
        {
            string sql = "select * from Audit";
            var dt = SqlHelper.Query(sql, null);
            return FillData(dt);
        }


        public Audit GetAudit(int id)
        {
            string sql = "select * from Audit where Id =@Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Id",id) 
            };
            var dt = SqlHelper.Query(sql, param);
            var list = FillData(dt);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }


        public List<Audit> FillData(DataTable dt)
        {
            List<Audit> list = new List<Audit>();
            foreach (DataRow dr in dt.Rows)
            {
                Audit a = new Audit()
                {
                    Id = int.Parse(dr["Id"].ToString()),
                    Title = dr["Title"].ToString(),
                    CreateTime = DateTime.Parse(dr["CreateTime"].ToString()),
                    UpdateTime = DateTime.Parse(dr["UpdateTime"].ToString())
                };
                list.Add(a);
            }

            return list;
        }
    }
}