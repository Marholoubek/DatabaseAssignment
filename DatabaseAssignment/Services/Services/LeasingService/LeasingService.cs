﻿using StudentAccomodation.Models;
using StudentAccomodation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Services.Services.LeasingService
{
    public class LeasingService :ILeasingService
    {
        private ADOLeasing service;

        public LeasingService(ADOLeasing studentService)
        {
            service = studentService;
        }

        public IEnumerable<Leasing> GetAllLeasings()
        {
            return service.GetAllLeasings();
        }
    }
}