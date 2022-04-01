using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAccomodation.Models;
using StudentAccomodation.Services.Interfaces;

namespace StudentAccomodation.Pages.Students
{
    public class StudentDetails : PageModel
    {
        [BindProperty]public Student Student { get; set; }
        public IEnumerable<Leasing> Leasings { get; set; }
        public List<Room> Rooms { get; set; }

        private IStudentService _studentService;
        private ILeasingService _leasingService;
        private IRoomService _roomService;
        public StudentDetails(IStudentService studentService, ILeasingService leasingService, IRoomService roomService)
        {
            _studentService = studentService;
            _leasingService = leasingService;
            _roomService = roomService;
            Rooms = new List<Room>();
            Leasings = new List<Leasing>();
        }

        public void OnGet(string id)
        {
            
            Student = _studentService.GetStudentById(Convert.ToInt32(id));
            if (Student == null)
            {
                RedirectToPage("/Students/GetStudents");
            }
            Leasings = _leasingService.GetStudentsLeasings(Convert.ToInt32(id));
            foreach (var leasing in Leasings)
            {
                Rooms.Add(_roomService.GetRoom(leasing.PlaceNo));
            }
        }
        
        public IActionResult OnPost()
        {
            _studentService.DeleteStudent(Student.StudentNo);
           return RedirectToPage("/Students/GetStudents");
        }
    }
}