using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAccomodation.Models;
using StudentAccomodation.Services.Interfaces;

namespace DatabaseAssignment.Pages.Students
{
    public class StudentDetails : PageModel
    {
        public Student Student { get; set; }
        public IEnumerable<Leasing> Leasings { get; set; }

        private IStudentService _studentService;
        private ILeasingService _leasingService;
        public StudentDetails(IStudentService studentService, ILeasingService leasingService)
        {
            _studentService = studentService;
            _leasingService = leasingService;
        }
        
        public void OnGet(string id)
        {
            
            Student = _studentService.GetStudentById(Convert.ToInt32(id));
            if (Student == null)
            {
                RedirectToPage("/Students/GetStudents");
            }
            Leasings = _leasingService.GetStudentsLeasings(Convert.ToInt32(id));
            
            
            
        }
    }
}