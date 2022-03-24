﻿using StudentAccomodation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Services.Interfaces
{
    public interface IRoomService
    {
        IEnumerable<Room> GetAllRooms();
        IEnumerable<Room> GetAllRoomsInDormitory(int id);
        IEnumerable<Room> GetAllRoomsInApartment(int id);
        IEnumerable<Room> GetAllVacantRooms();
        
    }
}
