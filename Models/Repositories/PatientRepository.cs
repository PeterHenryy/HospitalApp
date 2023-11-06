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

        public List<Doctor> GetDoctorsDropdown()
        {
            List<Doctor> doctors = _context.Doctors.Include(x => x.User).ToList();
            return doctors;
        }
    }
}
