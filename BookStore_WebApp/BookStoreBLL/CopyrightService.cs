using BookStoreDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBLL
{
    public class CopyrightService
    {
        CopyrightManager cm = new CopyrightManager();

        /// <summary>
        /// 全查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllCopyright()
        {
            return cm.GetAllCopyright();
        }
    }
}
