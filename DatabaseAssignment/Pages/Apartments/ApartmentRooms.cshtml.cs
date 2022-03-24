using System;
using System.Collections.Generic;
using DatabaseAssignment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAccomodation.Models;
using StudentAccomodation.Services.Interfaces;

namespace StudentAccomodation.Pages.Apartments
{
    public class ApartmentRoomsModel : PageModel
    {
        private IApartmentService apartmentService;
        private IRoomService roomService;


        public IEnumerable<Room> Rooms { get; set; }
        // public Apartment Apartment { get; set; }

        public ApartmentRoomsModel(IApartmentService service, IRoomService serviceRoom)
        {
            apartmentService = service;
            roomService = serviceRoom;
        }
        public void OnGet(string id)
        {
            Rooms = roomService.GetAllRoomsInApartment(Convert.ToInt32(id));
        }
    }
}