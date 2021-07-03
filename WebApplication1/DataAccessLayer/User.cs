using CRUD.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.DataAccessLayer
{
    public class User
    {
        readonly string connectionString = "Data Source=USERS;Initial Catalog = dbo.Users; Integrated Security = False; User ID = ppuralasetti; Password=Test@123;MultipleActiveResultSets=True";
        public IList<CRUD.Models.User> GetAllUsers()
        {
            List<CRUD.Models.User> users = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sQuery = "SELECT * FROM USERS(NOLOCK)";
                conn.Open();
                users = conn.Query<CRUD.Models.User>(sQuery).ToList();
                conn.Close();
                return users;
            }
        }

        public bool InsertUser(CRUD.Models.User user)
        {
            bool result = false;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand objSqlCommand = new SqlCommand("Insert into Users values ('" + user.UserName + "')", con);
                int i = objSqlCommand.ExecuteNonQuery();
                if (i > 0)
                    result = true;
                con.Close();
            }
            return result;
        }

        public bool UpdateUser(CRUD.Models.User user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Update Users set Username = " + user.UserName + " where UserId = " + user.UserId;
                var res = con.Execute(query);
                con.Close();
                if (res > 0)
                    return true;
                else
                    return false;                
            }            
        }

        public bool DeleteUser(CRUD.Models.User user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM USERS where UserId = " + user.UserId;
                var res = con.Execute(query);
                con.Close();
                if (res > 0)
                    return true;
                else
                    return false;                
            }
        }
    }
}
