using Microsoft.Extensions.Configuration;
using StudentAccomodation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Services.Services.RoomService
{
    public class ADORoom
    {
        public IConfiguration Configuration { get; }
        public ADORoom(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Room> GetAllRooms()
        {
            string query = "select *  from Room";
            return GetRooms(query);
        }
        public List<Room> GetAllRoomsInApartment(int id)
        {
            string query = $"select *  from Room where Appart_No = {id}";
            return GetRooms(query);
        }
        public List<Room> GetAllRoomsInDormitory(int id)
        {
            string query = $"select *  from Room where Dormitory_No = {id}";
            return GetRooms(query);
        }
        
        public List<Room> GetAllVacantRooms()
        {
            string query = "select *  from Student where Occupied = 'False'";
            return GetRooms(query);
        }
        
        

        public List<Room> GetRooms(string query)
        {
            List<Room> returnList = new List<Room>();
            string connectionString = Configuration["ConnectionStrings:AccommodationConection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Room room = new Room();

                        room.PlaceNo = Convert.ToInt32(reader["Place_No"]);
                        room.RentPerSemester = Convert.ToInt32(reader["Rent_Per_Semester"]);
                        room.Occupied = Convert.ToBoolean(reader["Occupied"]);
                        room.RoomNo = Convert.ToInt32(reader["Room_No"]);
                        if (reader["Dormitory_No"] != DBNull.Value)
                        { room.DormitoryNo = Convert.ToInt32(reader["Dormitory_No"]); }
                        
                        if (reader["Appart_No"] != DBNull.Value)
                        { room.ApartmentNo = Convert.ToInt32(reader["Appart_No"]); }
                        
                        returnList.Add(room);
                    }
                }
                return returnList;
            }
        }
    }
}
