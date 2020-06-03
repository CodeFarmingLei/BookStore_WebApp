using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BookStore.Model;

namespace BookStore.DAL
{
    public class AppointmentManager
    {
       
        public int Add(Appointment model)
        {
            string sql = "insert into Appointment(RealName,Telephone,Amount,AuditId,CreateTime,UpdateTime) " +
                         "values(@RealName,@Telephone,@Amount,@AuditId,@CreateTime,@UpdateTime)";
            SqlParameter[] param =
            {
                new SqlParameter("@RealName",model.RealName),
                new SqlParameter("@Telephone",model.Telephone),
                new SqlParameter("@Amount",model.Amount),
                new SqlParameter("@AuditId",model.AuditId),
                new SqlParameter("@CreateTime",model.CreateTime),
                new SqlParameter("@UpdateTime",model.UpdateTime)
            };

            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        //这个修改比较特殊,后台是无法更改客户预约内容,后台只能更改审核状态
        public int Edit(Appointment model)
        {
            string sql = "update Appointment set AuditId=@AuditId,UpdateTime=@UpdateTime where Id=@Id";
            SqlParameter[] param =
            {
                new SqlParameter("@AuditId",model.AuditId),
                new SqlParameter("@UpdateTime",model.UpdateTime),
                new SqlParameter("@Id",model.Id)
            };
            return SqlHelper.ExecuteNonQuery(sql,param);
        }

        //当我们这边正在审核数据过多的时候,我们还需要根据创建时间来进行排序倒叙

        public List<Appointment> GetAll()
        {
            string sql = "select * from Appointment";
            var dt = SqlHelper.Query(sql, null);
            return FillData(dt);
        }

        public List<Appointment> GetAllByRealName(string name)
        {
            string sql = "select * from Appointment where RealName like '%"+name+"%' order by AuditId asc,CreateTime desc";
      
            var dt = SqlHelper.Query(sql, null);
            return FillData(dt);
        }

        public Appointment GetAppointment(int id)
        {
            string sql = "select * from Appointment where Id=@Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Id",id) 
            };
            var dt = SqlHelper.Query(sql, param);
            var data = FillData(dt);
            if (data.Count > 0)
            {
                return data[0];
            }
            else
            {
                return null;
            }
        }

        public List<Appointment> GetAllByAuditId(int auditId)
        {
            string sql = "select * from Appointment where AuditId=@AuditId";
            SqlParameter[] param =
            {
                new SqlParameter("@AuditId",auditId) 
            };
            var dt = SqlHelper.Query(sql, param);
            return FillData(dt);
        }


        public List<Appointment> FillData(DataTable dt)
        {
            var list = new List<Appointment>();

            foreach (DataRow dr in dt.Rows)
            {
                Appointment model = new Appointment
                {
                    Id = int.Parse(dr["Id"].ToString()),
                    RealName = dr["RealName"].ToString(),
                    Telephone = dr["Telephone"].ToString(),
                    Amount = int.Parse(dr["Amount"].ToString()),
                    AuditId = int.Parse(dr["AuditId"].ToString()),
                    CreateTime = DateTime.Parse(dr["CreateTime"].ToString()),
                    UpdateTime = DateTime.Parse(dr["UpdateTime"].ToString())
                };

                list.Add(model);
            }

            return list;
        }


        public int GetCountByAuditId(int auditId)
        {
            string sql = "select count(*) from Appointment where AuditId = @AuditId";
            SqlParameter[] param =
            {
                new SqlParameter("@AuditId",auditId) 
            };

            object ob = SqlHelper.ExecuteSaclar(sql, param);

            return ob != null ? int.Parse(ob.ToString()) : 0;
        }
    }
}