using System;
using System.Collections.Generic;
using DatabaseAssignment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAccomodation.Models;
using StudentAccomodation.Services.Interfaces;

namespace StudentAccomodation.Pages.Dormitories
{
    public class DormitoriesRooms : PageModel
    {
        private IDormitoryService dormitoryService;
        private IRoomService roomService;


        public IEnumerable<Room> Rooms { get; set; }
        public Dormitory Dormitory { get; set; }

        public DormitoriesRooms(IDormitoryService service, IRoomService serviceRoom)
        {
            dormitoryService = service;
            roomService = serviceRoom;
        }
        public void OnGet(string id)
        {
            Rooms = roomService.GetAllRoomsInDormitory(Convert.ToInt32(id));
            Dormitory = dormitoryService.GetDormitoryById(Convert.ToInt32(id));
        }
    }
}