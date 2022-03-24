using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAccomodation.Models;
using StudentAccomodation.Services.Interfaces;

namespace StudentAccomodation.Pages.Rooms
{
    public class GetRoomsModel : PageModel
    {
        private IRoomService roomService;
        private ILeasingService leasingService;

        public IEnumerable<Room> rooms { get; set; }
        public bool IsVacant { get; set; } 
        public GetRoomsModel(IRoomService service, ILeasingService lService)
        {
            roomService = service;
            leasingService = lService;
        }
        public void OnGet(string isVacant)
        {
            IsVacant = isVacant is "true";
            rooms = IsVacant ? roomService.GetAllVacantRooms() : roomService.GetAllRooms();
        }

        public PageResult OnPost(string id) 
        {
            leasingService.AssignRoomToStudent(Convert.ToInt32(id));
            rooms = roomService.GetAllRooms();
            return Page();

        }
    }
}
