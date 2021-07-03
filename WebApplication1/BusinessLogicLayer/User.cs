using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.BusinessLogicLayer
{
    public class User 
    {
        readonly CRUD.DataAccessLayer.User userDAL = new CRUD.DataAccessLayer.User();
        public async Task<IList<CRUD.Models.User>> GetAllUsers()
        {
            return await Task.Run(() => userDAL.GetAllUsers()); 
        }

        public async Task<bool> InsertUser(CRUD.Models.User user)
        {
            return await Task.Run(() => userDAL.InsertUser(user));
        }

        public async Task<bool> UpdateUser(CRUD.Models.User user)
        {
            return await Task.Run(() => userDAL.UpdateUser(user));
        }

        public async Task<bool> DeleteUser(CRUD.Models.User user)
        {
            return await Task.Run(() => userDAL.DeleteUser(user));
        }
    }
}
