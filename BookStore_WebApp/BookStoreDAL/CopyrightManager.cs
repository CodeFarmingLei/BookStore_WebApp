using BookStoreModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDAL
{
    public class CopyrightManager
    {
        /// <summary>
        /// 全查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllCopyright()
        {
            string sql = " SELECT * FROM Copyright ";
            return SqlHelper.Query(sql, null);
        }
    }
}
