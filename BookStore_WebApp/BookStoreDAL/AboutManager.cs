using System.Data.SqlClient;
using BookStore.Model;

namespace BookStore.DAL
{
    public class AboutManager
    {
        public int Add(About model)
        {
            string sql = "insert into About(Title,Content,Images,CreateTime,UpdateTime) " +
                         "values(@Title,@Content,@Images,@CreateTime,@UpdateTime)";

            SqlParameter[] param =
            {
                new SqlParameter("@Title",model.Title),
                new SqlParameter("@Content",model.Content),
                new SqlParameter("@Images",model.Images),
                new SqlParameter("@CreateTime",model.CreateTime),
                new SqlParameter("@UpdateTime",model.UpdateTime)
            };
            return SqlHelper.ExecuteNonQuery(sql, param);
        }


        public int Edit(About model)
        {
            string sql = "update About set Title=@Title,Content=@Content,Images=@Images,UpdateTime=@UpdateTime where Id=@Id";

            SqlParameter[] param =
            {
                new SqlParameter("@Title",model.Title),
                new SqlParameter("@Content",model.Content),
                new SqlParameter("@Images",model.Images),
                new SqlParameter("@UpdateTime",model.UpdateTime),
                new SqlParameter("@Id",model.Id)
            };
            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        public About GetAboutById(int id)
        {
            string sql = "select * from About where Id=@Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Id",id) 
            };
            var dt = SqlHelper.Query(sql, param);

            if (dt.Rows.Count > 0)
            {
                return new About()
                {
                    Id = int.Parse(dt.Rows[0]["Id"].ToString()),
                    Title = dt.Rows[0]["Title"].ToString(),
                    Content = dt.Rows[0]["Content"].ToString(),
                    Images = dt.Rows[0]["Images"].ToString()
                };
            }
            else
            {
                return new About();
            }

        }
    }
}