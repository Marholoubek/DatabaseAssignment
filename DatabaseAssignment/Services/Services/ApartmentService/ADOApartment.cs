﻿using Microsoft.Extensions.Configuration;
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

        public List<Apartment> GetAllApartments()
        {
            List<Apartment> returnList = new List<Apartment>();
            string connectionString = Configuration["ConnectionStrings:AccommodationConection"];
            string query = "select *  from Appartment";

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
