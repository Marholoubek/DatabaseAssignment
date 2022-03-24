using Microsoft.Extensions.Configuration;
using StudentAccomodation.Models;
using StudentAccomodation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Services.Services.DormitorySrervice
{
    public class ADODormitory 
    {

        public IConfiguration Configuration { get; }
        public ADODormitory(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Dormitory> GetAllDormitories()
        {
            List<Dormitory> returnList = new List<Dormitory>();
            string connectionString = Configuration["ConnectionStrings:AccommodationConection"];
            string query = "select *  from Dormitory";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Dormitory dormitory = new Dormitory();
                        dormitory.DormitorytNo = Convert.ToInt32(reader["Dormitory_No"]);
                        dormitory.Name = Convert.ToString(reader["Name"]);
                        dormitory.Address = Convert.ToString(reader["Address"]);
                        
                        returnList.Add(dormitory);
                    }
                }
                return returnList;
            }
        }
    }
}
