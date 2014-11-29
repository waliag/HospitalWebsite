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
        static string connectionString = ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        public int AuthenticateUser(String userName, String password)
        {
            int userId = 0;
            string constr = ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString;
                 using (SqlCommand cmd = new SqlCommand("sp_ValidateUser"))
                 {
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@Username", userName);
                     cmd.Parameters.AddWithValue("@Password", password);
                     cmd.Connection = connection;
                     connection.Open();
                     userId = Convert.ToInt32(cmd.ExecuteScalar());

                     connection.Close();
                 }
             
            return userId;
        }
        public bool CreateUserAccount(String userName, String email, String password)
        {
           
                using (SqlCommand cmd = new SqlCommand("sp_CreateAccount"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", userName);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Type", "Patient");
                    cmd.Parameters.AddWithValue("@Email", email);

                    cmd.Connection = connection;
                    connection.Open();
                    int rowsaffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (rowsaffected == 0)
                        return false;
                }
            
            return false;
        }
        public List<Doctor> searchDoctors(String searchString)
        {
            Doctor doctorObj;
            doctorObj = new Doctor();

            string sql = "sp_SearchDoctors";
            SqlCommand command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@SearchString", searchString);
            List<Doctor> listDoctors = new List<Doctor>();
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            doctorObj = new Doctor();
                            doctorObj.userId = Convert.ToInt32(reader["userid"]);
                            doctorObj.name = Convert.ToString(reader["Name"]);
                            doctorObj.qualification = Convert.ToString(reader["Qualification"]);
                            doctorObj.speciality = Convert.ToString(reader["Speciality"]);
                            listDoctors.Add(doctorObj);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return listDoctors;
        }
        public List<String> getFilledSlots(int doctorId, DateTime appointmentDate)
        {
            string sql = "sp_GetCurrentAppointments";
            SqlCommand command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@DoctorId", doctorId);
            command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
            List<String> listSlots = new List<String>();
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            listSlots.Add(Convert.ToString(reader["Slot"]));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return listSlots;
        }
    }
}