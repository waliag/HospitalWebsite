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
        public Account AuthenticateUser(String userName, String password)
        {
            Account userDetails;
            userDetails = new Account();
            SqlCommand command = new SqlCommand("sp_ValidateUser");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Username", userName);
            command.Parameters.AddWithValue("@Password", password);
            command.Connection = connection;

            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            userDetails.userId = Convert.ToInt32(reader["UserId"]);
                            userDetails.name = Convert.ToString(reader["Name"]);
                            userDetails.password = Convert.ToString(reader["Password"]);
                            userDetails.type = Convert.ToString(reader["Type"]);
                            userDetails.email = Convert.ToString(reader["Email"]);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();

            return userDetails;
        }
        public bool CreateUserAccount(String userName, String email, String password)
        {
            try
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
                    if (rowsaffected == 0)
                        return false;
                }
            }
            catch(Exception ex)
            {
                 Console.WriteLine(ex.Message);
                 return false;
            }
            connection.Close();
            return true;
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
        public bool addAppointment(AppointmentDetails appointment)
        {
            string sql = "sp_AddAppointment";
            SqlCommand command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@DoctorId", appointment.doctorId);
            command.Parameters.AddWithValue("@PatientId", appointment.patientId);
            command.Parameters.AddWithValue("@Date", appointment.date);
            command.Parameters.AddWithValue("@Slot", appointment.Slot);

            try
            {
                connection.Open();
                int rowsaffected = command.ExecuteNonQuery();
                if (rowsaffected == 0)
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return true;
        }
        public int getUserId(String name)
        {

            int userId = 0;
            string constr = ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand("sp_getUserId"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Connection = connection;
                connection.Open();
                userId = Convert.ToInt32(cmd.ExecuteScalar());

                connection.Close();
            }

            return userId;

        }

        public void addPatientDetails(int userId, String name, String dob, String height, String weight, String allergies)
        {
            string sql = "sp_addPatientDetail";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@DOB", dob);
            cmd.Parameters.AddWithValue("@Height", height);
            cmd.Parameters.AddWithValue("@Weight", weight);
            cmd.Parameters.AddWithValue("@Allergies", allergies);

            cmd.Connection = connection;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }
        public Patient getPatients(int userid)
        {
            Patient obj = new Patient();

            string sql = "sp_getPatients";
            SqlCommand command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserId", userid);

            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    obj.name = Convert.ToString(reader["Name"]);
                    DateTime dob = Convert.ToDateTime(reader["DOB"]);
                    obj.dob = dob.Date.ToString("dd/MM/yyyy");
                    obj.height = Convert.ToString(reader["Height"]);
                    obj.weight = Convert.ToString(reader["Weight"]);
                    obj.allergies = Convert.ToString(reader["Allergies"]);
                    connection.Close();
                    return obj;

                }
                else
                    return null;

            }
        }
		public Patient getAppointment(int userid)
        {
            Patient obj = new Patient();


            string sql = "sp_getAppointment";
            SqlCommand command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserId", userid);


            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {


                if (reader.Read())
                {
                    obj.doctor = Convert.ToString(reader["Name"]);
                    DateTime appointmentDate = Convert.ToDateTime(reader["Date"]);
                    obj.date = appointmentDate.Date.ToString("dd/MM/yyyy");
                    obj.slot = Convert.ToString(reader["Slot"]);
                    
                    connection.Close();
                    return obj;

                }
                else
                    return null;

            }
        }
    }
}