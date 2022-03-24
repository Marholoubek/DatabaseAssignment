using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAccomodation.Models;
using StudentAccomodation.Services.Interfaces;

namespace StudentAccomodation.Pages.Students
{
    public class GetStudentsModel : PageModel
    {
        private IStudentService studentService;
        

        public IEnumerable<Student> students { get; set; }

        public bool IsWaiting { get; set; } 

        public GetStudentsModel(IStudentService service)
        {
            studentService = service;
        }
        public void OnGet(string isWaiting)
        {
            IsWaiting = isWaiting is "true";
            students = IsWaiting ? studentService.GetAllWaitingStudents() : studentService.GetAllStudents();
        }
    }
}
