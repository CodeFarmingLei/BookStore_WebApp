using BookStoreDAL;
using BookStoreModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBLL
{
    public class UsersService
    {
        UsersManager um = new UsersManager();

        /// <summary>
        /// 判断电子邮件是否存在的
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsExist(string email)
        {
            return um.IsExist(email);
        }


        public int Add(Users u)
        {
            return um.Add(u);
        }


        public int Edit(Users u)
        {
            return um.Edit(u);
        }

        public int Delete(Users u)
        {
            return um.Delete(u);
        }

        public List<Users> GetUsersList()
        {
            return um.GetUsersList();
        }

        public List<Users> GetUsersListByNickName(string nickname)
        {
            return um.GetUsersListByNickName(nickname);
        }

        public Users GetUsersById(int id)
        {
            return um.GetUsersById(id);
        }

        public Users Login(string email, string pwd)
        {
            return um.Login(email,pwd);
        }

        /// <summary>
        /// 根据权限编号进行查询
        /// </summary>
        /// <param name="rolesId"></param>
        /// <returns></returns>
        public List<Users> GetUsersByRolesId(int rolesId)
        {
            return um.GetUsersByRolesId(rolesId);
        }
        /// <summary>
        /// 全查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllUsers()
        {
            return um.GetAllUsers();
        }
    }
}
