using HospitalApp.Models;
using HospitalApp.Models.Identity;
using HospitalApp.Models.Patients.ViewModels;
using HospitalApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        public IActionResult DisplayUserCreditCards()
        {
            List<CreditCard> creditCards = _patientService.GetSpecificUserCards(_currentUser.Id);
            return View(creditCards);
        }

        [HttpGet]
        public IActionResult CreateCreditCard()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCreditCard(CreditCard creditCard)
        {
            creditCard.UserID = _currentUser.Id;
            bool createdCard = _patientService.CreateCreditCard(creditCard);
            if (createdCard)
            {
                return RedirectToAction("DisplayUserCreditCards", "Patient");
            }
            return View();
        }

        public IActionResult DeleteCreditCard(int creditCardID)
        {
            bool deletedCard = _patientService.DeleteCreditCard(creditCardID);
            return RedirectToAction("DisplayUserCreditCards", "Patient");
        }

    }
}
