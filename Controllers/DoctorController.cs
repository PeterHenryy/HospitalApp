using HospitalApp.Models;
using HospitalApp.Models.Doctors;
using HospitalApp.Models.Doctors.ViewModelForm;
using HospitalApp.Models.Identity;
using HospitalApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HospitalApp.Controllers
{
    public class DoctorController : Controller
    {
        private readonly DoctorService _doctorService;
        private readonly UserService _userService;
        private readonly AppUser _currentUser;

        public DoctorController(DoctorService doctorService, UserService userService)
        {
            _doctorService = doctorService;
            _userService = userService;
            _currentUser = userService.GetCurrentUser();
        }

        [HttpGet]
        public IActionResult CreateAppointment()
        {
            List<string> appointmentTimes = new List<string>();

            for (int hour = 1; hour <= 12; hour++)
            {
                appointmentTimes.Add($"{hour}:00 AM");
            }

            for (int hour = 1; hour <= 12; hour++)
            {
                appointmentTimes.Add($"{hour}:00 PM");
            }

            ViewBag.AppointmentTimes = appointmentTimes;
            return View();
        }

        [HttpPost]
        public IActionResult CreateAppointment(Appointment appointment)
        {
            Doctor doctor = _doctorService.GetDoctorByUserID(_currentUser.Id);
            appointment.DoctorID = doctor.ID;
            appointment.IsBooked = true;
            bool createdAppointment = _doctorService.CreateAppointment(appointment);
            if (createdAppointment)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}
