using MedSys.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSys.Domain.Abstract
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> Patients { get; }

        void SavePatient(Patient patient);

        Patient DeletePatient(int patientId);
    }
}
