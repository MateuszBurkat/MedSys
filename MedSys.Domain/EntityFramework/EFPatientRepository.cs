using MedSys.Domain.Abstract;
using MedSys.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSys.Domain.EntityFramework
{
    public class EFPatientRepository : IPatientRepository
    {
       private EFDbContext context = new EFDbContext();
        public IEnumerable<Patient> Patients
        {
            get { return context.Patients; }
        }

        public void SavePatient (Patient patient)
        {
            if(patient.PatientId == 0)
            {
                context.Patients.Add(patient);
            }
            else
            {
                Patient dbPat = context.Patients.Find(patient.PatientId);
                if (dbPat != null)
                {
                    dbPat.Surname = patient.Surname;
                    dbPat.Name = patient.Name;
                    dbPat.Pesel = patient.Pesel;
                    dbPat.Address = patient.Address;
                    dbPat.City = patient.City;
                    dbPat.Description = patient.Description;
                    dbPat.MedicalTestResult = patient.MedicalTestResult;
                }
            }
            context.SaveChanges();

        }

        public Patient DeletePatient (int patientId)
        {
            Patient dbPat = context.Patients.Find(patientId);
            if(dbPat != null)
            {
                context.Patients.Remove(dbPat);
                context.SaveChanges();
            }
            return dbPat;
        }
    }
}
