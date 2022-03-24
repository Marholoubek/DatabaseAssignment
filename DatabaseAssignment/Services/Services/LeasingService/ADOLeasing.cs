using Microsoft.Extensions.Configuration;
using StudentAccomodation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Services.Services.LeasingService
{
    public class ADOLeasing
    {
        public IConfiguration Configuration { get; }
        public ADOLeasing(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void AssignRoomToStudent(int id)
        {
            DateTime now = DateTime.Now;
            DateTime nowPlusHalf = DateTime.Now.Add(TimeSpan.FromDays(120));
            string day = now.Day.ToString();
            if (now.Day < 10)
            {
                day = $"0{day}";
            }
            string month = now.Month.ToString();
            if (now.Month < 10)
            {
                month = $"0{month}";
            }
            string day2 = nowPlusHalf.Day.ToString();
            if (nowPlusHalf.Day < 10)
            {
                day2 = $"0{day2}";
            }
            string month2 = nowPlusHalf.Month.ToString();
            if (nowPlusHalf.Month < 10)
            {
                month2 = $"0{month2}";
            }
            
            Student student = new Student();
            string queryStudents = "select * from Student where Has_Room = 0 order by Registration_Date";
            string connectionString = Configuration["ConnectionStrings:AccommodationConection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryStudents, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    student.StudentNo = Convert.ToInt32(reader["Student_No"]);
                    student.SName = Convert.ToString(reader["SName"]);
                    student.SAddress = Convert.ToString(reader["SAddress"]);
                    student.HasRent = Convert.ToBoolean(reader["Has_Room"]);
                    student.RegistrationDate = Convert.ToDateTime(reader["Registration_Date"]);
                }
                connection.Close();
            }
            
            
            
            string query1 = $"insert into Leasing (Student_No, Place_No, Date_From, Date_To) values ('{student.StudentNo}', '{id.ToString()}','{now.Year}-{month}-{day} 01:01:01', '{nowPlusHalf.Year}-{month2}-{day2} 01:01:01')";
            string query2 = $"update Room set Occupied = 'True' where Place_No = {id}";
            string query3 = $"update Student set Has_Room = 'True' where Student_No = {student.StudentNo}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (SqlCommand command = new SqlCommand(query3, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Leasing> GetAllLeasings()
        {
            List<Leasing> returnList = new List<Leasing>();
            string connectionString = Configuration["ConnectionStrings:AccommodationConection"];
            string query = "select *  from Leasing";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Leasing leasing = new Leasing();
                        leasing.LeasingNo = Convert.ToInt32(reader["Leasing_No"]);
                        leasing.StudentNo = Convert.ToInt32(reader["Student_No"]);
                        leasing.PlaceNo = Convert.ToInt32(reader["Place_No"]);
                        leasing.DateFrom = Convert.ToDateTime(reader["Date_From"]);
                        leasing.DateTo = Convert.ToDateTime(reader["Date_To"]);
                        
                        returnList.Add(leasing);
                    }
                }
                return returnList;
            }
        }


    }
}
