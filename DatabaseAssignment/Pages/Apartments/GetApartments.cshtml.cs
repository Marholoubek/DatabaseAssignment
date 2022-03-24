using System.Collections.Generic;
using DatabaseAssignment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAccomodation.Models;
using StudentAccomodation.Services.Interfaces;

namespace DatabaseAssignment.Pages.Apartments
{
    public class GetApartmentsModel : PageModel
    {
        private IApartmentService apartmentService;

        public IEnumerable<Apartment> apartments { get; set; }

        public GetApartmentsModel(IApartmentService service)
        {
            apartmentService = service;
        }
        public void OnGet()
        {
            apartments = apartmentService.GetAllApartments();
        }
    }
}
