using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Usi_Project.Users;

namespace Usi_Project.Manage

{
    public class PatientManager
    {
        private string _patientFileName;
        private List<Patient> _patients;
        private Factory manager;

        public PatientManager()
        {
            _patients = new List<Patient>();
        }
        public PatientManager(string patientFile, Factory manager)
        {
            _patientFileName = patientFile;
            this.manager = manager;
        }
        public void LoadData()
        {
            JsonSerializerSettings json = new JsonSerializerSettings
                {PreserveReferencesHandling = PreserveReferencesHandling.Objects};
            _patients = JsonConvert.DeserializeObject<List<Patient>>(File.ReadAllText(_patientFileName), json);
        }
        public Patient CheckPersonalInfo(string email, string password)
        {
            foreach (Patient patient in _patients)
            {
                if (email == patient.email && password == patient.password)
                {
                    return patient;
                }
               
            }
            return null;
        }

        public bool CheckEmail(string email)
        {
            foreach (Patient patient in _patients)
            {
                if (email == patient.email)
                {
                    return true;
                }
            }
            return false;
        }
        

        public List<Patient> Patients
        {
            get => _patients;
        }

        public string patientFileName
        {
            get => _patientFileName;
        }
        
        
        
        
    }
}