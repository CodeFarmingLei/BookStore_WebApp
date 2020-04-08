using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BookStore.Model
{
    public static class SqlHelper
    {
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

        /// <summary>
        /// 增删改公用方法
        /// </summary>
        /// <param name="sql">要执行的T-SQL语句</param>
        /// <param name="param">传递的数据值</param>
        /// <returns>受影响行数</returns>
        public static int ExecuteNonQuery(string sql, SqlParameter[] param)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (param != null)
                        cmd.Parameters.AddRange(param);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 查询公用方法
        /// </summary>
        /// <param name="sql">要执行的T-SQL语句</param>
        /// <param name="param">传递的数据值</param>
        /// <returns>系统虚表</returns>
        public static DataTable Query(string sql, SqlParameter[] param)
        {
            using (SqlDataAdapter sda = new SqlDataAdapter(sql, conStr))
            {
                if (param != null)
                    sda.SelectCommand.Parameters.AddRange(param);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// 返回单一值的公用方法
        /// </summary>
        /// <param name="sql">要执行的T-SQL语句</param>
        /// <param name="param">传递的数据值</param>
        /// <returns>单一值</returns>
        public static object ExecuteSaclar(string sql, SqlParameter[] param)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (param != null)
                        cmd.Parameters.AddRange(param);
                    return cmd.ExecuteScalar();
                }
            }
        }

    }
}
