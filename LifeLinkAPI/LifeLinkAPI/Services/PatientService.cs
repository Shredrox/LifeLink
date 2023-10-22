using LifeLinkAPI.Data;
using LifeLinkAPI.Models;
using LifeLinkAPI.Services.Interfaces;

namespace LifeLinkAPI.Services
{
    public class PatientService : IPatientService
    {
        private readonly AppDbContext _context;

        public PatientService(AppDbContext context)
        {
            _context = context;
        }

        public async Task RegisterPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Patient> DeletePatient(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> UpdatePatient(int id, Patient request)
        {
            throw new NotImplementedException();
        }
    }
}
