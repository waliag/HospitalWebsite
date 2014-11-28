using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HospitalWebsite
{
    public class DBAccess
    {
        public int AuthenticateUser(String userName, String password)
        {
            int userId = 0;
            string constr = ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString;
             using (SqlConnection con = new SqlConnection(constr))
             {
                 using (SqlCommand cmd = new SqlCommand("sp_Validate_User"))
                 {
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@Username", userName);
                     cmd.Parameters.AddWithValue("@Password", password);
                     cmd.Connection = con;
                     con.Open();
                     userId = Convert.ToInt32(cmd.ExecuteScalar());
                     userId = 1;
                     con.Close();
                 }
             }
            return userId;
        }
        public void CreateUserAccount(String userName, String email, String password)
        {
            string constr = ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CreateAccount"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", userName);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Connection = con;
                    con.Open();
                    con.Close();
                }
            }
        }
    }
}