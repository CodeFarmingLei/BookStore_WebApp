using BookStoreDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBLL
{
    public class SeoService
    {
        SeoManager sm = new SeoManager();

        /// <summary>
        /// 全查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllSeo()
        {
            return sm.GetAllSeo();
        }
    }
}
