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
            string query1 = "insert into Leasing (Leasing_No, Student_No, Place_No, Date_From, Date_To) values ('1', '1', '1','2015-12-25T15:32:06.427'. '2016-12-25T15:32:06.427')";
            string connectionString = Configuration["ConnectionStrings:AccommodationConection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query1, connection))
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
