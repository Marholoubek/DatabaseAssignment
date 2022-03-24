using StudentAccomodation.Models;
using StudentAccomodation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Services.Services.ApartmentService
{
    public class ApartmentService : IApartmentService
    {
        private ADOApartment service;

        public ApartmentService(ADOApartment apartmentService)
        {
            service = apartmentService;
        }

        public IEnumerable<Apartment> GetAllApartments()
        {
            return service.GetAllApartments();
        }
    }
}
