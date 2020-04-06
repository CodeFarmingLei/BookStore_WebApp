using BookStoreModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDAL
{
    public class SystemMenuManager
    {
        /// <summary>
        /// 全查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllSystemMenu()
        {
            string sql = " SELECT * FROM SystemMenu ";
            return SqlHelper.Query(sql, null);
        }
    }
}
