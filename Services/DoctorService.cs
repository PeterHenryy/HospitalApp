using HospitalApp.Models;
using HospitalApp.Models.Doctors;
using HospitalApp.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HospitalApp.Services
{
    public class DoctorService
    {
        private readonly DoctorRepository _doctorRepository;

        public DoctorService(DoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public bool Create(Doctor doctor)
        {
            bool createdDoctor = _doctorRepository.Create(doctor);
            return createdDoctor;
        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = _doctorRepository.GetAllDoctors();
            return doctors;
        }

        public bool Delete(int doctorID)
        {
            bool deletedDoctor = _doctorRepository.Delete(doctorID);
            return deletedDoctor;
        }


        public Doctor GetDoctorByID(int doctorID)
        {
            Doctor doctor = _doctorRepository.GetDoctorByID(doctorID);
            return doctor;
        }

        public bool CreateAppointment(Appointment appointment)
        {
            bool createdAppointment = _doctorRepository.CreateAppointment(appointment);
            return createdAppointment;
        }

        public Doctor GetDoctorByUserID(int userID)
        {
            Doctor doctor = _doctorRepository.GetDoctorByUserID(userID);
            return doctor;
        }
    }
}
