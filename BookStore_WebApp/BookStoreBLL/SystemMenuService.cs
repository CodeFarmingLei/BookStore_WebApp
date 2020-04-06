using BookStoreDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBLL
{
    public class SystemMenuService
    {
        SystemMenuManager smm = new SystemMenuManager();

        /// <summary>
        /// 全查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllSystemMenu()
        {
            return smm.GetAllSystemMenu();
        }
    }
}
