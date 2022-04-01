using Microsoft.Extensions.Configuration;
using StudentAccomodation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace StudentAccomodation.Services.Services.StudentService
{
    public class ADOStudent
    {
        public IConfiguration Configuration { get; }
        public ADOStudent(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void DeleteStudent(int id)
        {
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Student WHERE Student_No = @id", connection);
                var command2 = new SqlCommand("DELETE FROM Leasing WHERE Student_No = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                command2.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                command2.ExecuteNonQuery();
            }
        }

        public List<Student> GetAllStudents()
        {
            string query = "select *  from Student";
            return GetStudents(query);
        }
        public List<Student> GetAllWaitingStudents()
        {
            string query = "select *  from Student where Has_Room = 'False' ORDER BY Registration_Date ASC";
            return GetStudents(query);
        }

        public Student GetStudentById(int id)
        {
            string query = $"select *  from Student where Student_No = {id}";
            return GetStudents(query).First();
        }
        
        public List<Student> GetAllAcceptedStudents()
        {
            string query = "select *  from Student where Has_Room = 'True' ORDER BY Registration_Date ASC";
            return GetStudents(query);
        }
        


        public List<Student> GetStudents(string query)
        {
            List<Student> returnList = new List<Student>();
            string connectionString = Configuration["ConnectionStrings:AccommodationConection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.StudentNo = Convert.ToInt32(reader["Student_No"]);
                        student.SName = Convert.ToString(reader["SName"]);
                        student.SAddress = Convert.ToString(reader["SAddress"]);
                        student.HasRent = Convert.ToBoolean(reader["Has_Room"]);
                        student.RegistrationDate = Convert.ToDateTime(reader["Registration_Date"]);
                        returnList.Add(student);
                    }
                }
                return returnList;
            }
        }
    }
}
