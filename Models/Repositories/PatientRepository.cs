using HospitalApp.Data;
using HospitalApp.Models.Doctors;
using HospitalApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalApp.Models.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateCreditCard(CreditCard creditCard)
        {
            try
            {
                _context.CreditCards.Add(creditCard);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public bool DeleteCreditCard(int creditCardID)
        {
            try
            {
                CreditCard card = GetCreditCardByID(creditCardID);
                _context.CreditCards.Remove(card);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public CreditCard GetCreditCardByID(int creditCardID)
        {
            CreditCard creditCard = _context.CreditCards.SingleOrDefault(x => x.ID == creditCardID);
            return creditCard;
        }

        public List<Doctor> GetDoctorsDropdown()
        {
            List<Doctor> doctors = _context.Doctors.Include(x => x.User).ToList();
            return doctors;
        }

        public List<CreditCard> GetSpecificUserCards(int userID)
        {
            var userCards = _context.CreditCards.Where(x => x.UserID == userID).ToList();
            return userCards;
        }
    }
}
