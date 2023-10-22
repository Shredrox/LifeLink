using LifeLinkAPI.Models;

namespace LifeLinkAPI.Services.Interfaces
{
    public interface IPatientService
    {
        public Task RegisterPatient(Patient patient);
        public IEnumerable<Patient> GetAllPatients();
        public Patient GetPatientById(int id);
        public IEnumerable<Patient> UpdatePatient(int id, Patient request);
        public IEnumerable<Patient> DeletePatient(int id);
    }
}
