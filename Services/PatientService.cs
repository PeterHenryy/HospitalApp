using HospitalApp.Models;
using HospitalApp.Models.Doctors;
using HospitalApp.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HospitalApp.Services
{
    public class PatientService
    {
        private readonly PatientRepository _patientRepository;

        public PatientService(PatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public List<Doctor> GetDoctorsDropdown()
        {
            List<Doctor> doctors = _patientRepository.GetDoctorsDropdown();
            return doctors;
        }

        public bool CreateCreditCard(CreditCard creditCard)
        {
            bool createdCard = _patientRepository.CreateCreditCard(creditCard);
            return createdCard;
        }

        public bool DeleteCreditCard(int creditCardID)
        {
            bool updatedCard = _patientRepository.DeleteCreditCard(creditCardID);
            return updatedCard;
        }

        public CreditCard GetCreditCardByID(int creditCardID)
        {
            CreditCard card = _patientRepository.GetCreditCardByID(creditCardID);
            return card;
        }

        public List<CreditCard> GetSpecificUserCards(int userID)
        {
            List<CreditCard> userCards = _patientRepository.GetSpecificUserCards(userID);
            return userCards;
        }
    }
}
