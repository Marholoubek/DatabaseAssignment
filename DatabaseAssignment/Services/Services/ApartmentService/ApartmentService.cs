using System.Collections.Generic;
using DatabaseAssignment.Services.Interfaces;
using StudentAccomodation.Models;
using StudentAccomodation.Services.Services.ApartmentService;

namespace DatabaseAssignment.Services.Services.ApartmentService
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
        
        public Apartment GetApartmentById(int id)
        {
            return service.GetApartmentById(id);
        }
        
    }
}
