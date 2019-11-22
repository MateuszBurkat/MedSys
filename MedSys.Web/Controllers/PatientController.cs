using MedSys.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedSys.Domain.Entities;

namespace MedSys.Web.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        // GET: Patient

        private IPatientRepository repository;

        public PatientController(IPatientRepository patientRepository)
        {
            this.repository = patientRepository;
        }
        public ViewResult ListPatient()
        {
            return View(repository.Patients);
        }
        public ViewResult Details(int patientId)
        {
            Patient patient = repository.Patients.FirstOrDefault(p => p.PatientId == patientId);
            return View(patient);

        }
        public ViewResult Edit(int patientId)
        {
            Patient patient = repository.Patients.FirstOrDefault(p => p.PatientId == patientId);
            return View(patient);
        }
        [HttpPost]
        public ActionResult Edit (Patient patient)
        {
            if(ModelState.IsValid)
            {
                repository.SavePatient(patient);
                TempData["message"] = string.Format("Zapisano {0} ", patient.Surname);
                return RedirectToAction("Details", patient);
            }
            else
            {
                return View(patient);
            }
        }
        public ViewResult Create()
        {
            return View("Edit", new Patient());
        }

        public ActionResult Delete (int patientId)
        {
            Patient deletePatient = repository.DeletePatient(patientId);
            if (deletePatient != null)
            {
                TempData["message"] = string.Format("Usunięto pacjenta {0}", deletePatient.Surname +" " + deletePatient.Name);
            }
            return RedirectToAction("ListPatient");
            
        }
    } 
}