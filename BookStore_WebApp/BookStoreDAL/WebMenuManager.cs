using BookStoreModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDAL
{
    public class WebMenuManager
    {
        /// <summary>
        /// 全查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllWebMenu()
        {
            string sql = " SELECT * FROM WebMenu ";
            return SqlHelper.Query(sql, null);
        }
    }
}
