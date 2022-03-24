using System.Collections.Generic;
using StudentAccomodation.Models;

namespace DatabaseAssignment.Services.Interfaces
{
    public interface IApartmentService
    {
        IEnumerable<Apartment> GetAllApartments();
        Apartment GetApartmentById(int id);
        
    }
}
