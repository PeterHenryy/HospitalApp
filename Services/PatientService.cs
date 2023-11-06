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
    }
}
