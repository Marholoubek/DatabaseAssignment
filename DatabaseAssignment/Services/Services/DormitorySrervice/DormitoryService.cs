using StudentAccomodation.Models;
using StudentAccomodation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Services.Services.DormitorySrervice
{
    public class DormitoryService : IDormitoryService
    {
        private ADODormitory service;

        public DormitoryService(ADODormitory dormitoryService)
        {
            service =dormitoryService;
        }

        public IEnumerable<Dormitory> GetAllDormitories()
        {
            return service.GetAllDormitories();
        }
        
        public Dormitory GetDormitoryById(int id)
        {
            return service.GetDormitoryById(id);
        }
    }
}
