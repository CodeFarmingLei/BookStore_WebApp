using BookStoreModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDAL
{
    public class FriendLinkManager
    {
        /// <summary>
        /// 全查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllFriendLink()
        {
            string sql = " SELECT * FROM FriendLink ";
            return SqlHelper.Query(sql, null);
        }
    }
}
