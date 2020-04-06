using BookStoreModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDAL
{
    public class UsersPermissionManager
    {
        /// <summary>
        /// 全查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllUsersPermission()
        {
            string sql = " SELECT * FROM UsersPermission ";
            return SqlHelper.Query(sql, null);
        }
    }
}
