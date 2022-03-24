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
        public PageResult OnGet(string isVacant, string placeNo)
        {
            if (placeNo != null)
            {
                return OnPost(placeNo);
                
            }
            IsVacant = isVacant is "true";
            rooms = IsVacant ? roomService.GetAllVacantRooms() : roomService.GetAllRooms();
            return Page();
        }

        public PageResult OnPost(string placeNo) 
        {
            leasingService.AssignRoomToStudent(Convert.ToInt32(placeNo));
            rooms = roomService.GetAllRooms();
            throw new NotImplementedException();
            return Page();
            

        }
    }
}
