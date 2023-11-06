using HospitalApp.Data;
using HospitalApp.Models.Doctors;
using HospitalApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalApp.Models.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(Doctor doctor)
        {
            try
            {
                _context.Doctors.Add(doctor);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool Delete(int doctorID)
        {
            try
            {
                Doctor doctor = GetDoctorByID(doctorID);
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = _context.Doctors.Include(x => x.User).ToList();
            return doctors;
        }

        public Doctor GetDoctorByID(int doctorID)
        {
            Doctor doctor = _context.Doctors.SingleOrDefault(x => x.ID == doctorID);
            return doctor;
        }

        public bool CreateAppointment(Appointment appointment)
        {
            try
            {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public Doctor GetDoctorByUserID(int userID)
        {
            Doctor doctor = _context.Doctors.SingleOrDefault(x => x.UserID == userID);
            return doctor;
        }
    }
}
