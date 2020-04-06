using BookStoreModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDAL
{
    public class SeoManager
    {
        /// <summary>
        /// 全查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllSeo()
        {
            string sql = " SELECT * FROM Seo ";
            return SqlHelper.Query(sql, null);
        }
    }
}
