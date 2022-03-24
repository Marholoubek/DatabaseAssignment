using Microsoft.Extensions.Configuration;
using StudentAccomodation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Services.Services.ApartmentService
{
    public class ADOApartment
    {
        public IConfiguration Configuration { get; }
        public ADOApartment(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Apartment GetApartmentById(int id)
        {
            
            string query = $"select *  from Appartment where Appart_No = {id}";
            return GetApartments(query).First();
        }

        public List<Apartment> GetAllApartments()
        {
            string query = "select *  from Appartment";
            return GetApartments(query);

        }
        
        public List<Apartment> GetApartments(string query)
        {
            List<Apartment> returnList = new List<Apartment>();
            string connectionString = Configuration["ConnectionStrings:AccommodationConection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Apartment apartment = new Apartment();
                        apartment.ApartmentNo = Convert.ToInt32(reader["Appart_No"]);
                        apartment.Address = Convert.ToString(reader["Address"]);
                        apartment.Types = Convert.ToString(reader["Types"]);
                        returnList.Add(apartment);
                    }
                }
                return returnList;
            }
        }
    }
}
