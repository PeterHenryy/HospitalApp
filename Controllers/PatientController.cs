using HospitalApp.Models;
using HospitalApp.Models.Identity;
using HospitalApp.Models.Patients.ViewModels;
using HospitalApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly PatientService _patientService;
        private readonly UserService _userService;
        private readonly AppUser _currentUser;

        public PatientController(PatientService patientService, UserService userService)
        {
            _patientService = patientService;
            _userService = userService;
            _currentUser = userService.GetCurrentUser();
        }

    }
}
