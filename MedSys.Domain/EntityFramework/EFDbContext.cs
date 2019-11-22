using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedSys.Domain.Entities;
using MedSys.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;


namespace MedSys.Domain.EntityFramework
{
   
    public class EFDbContext :IdentityDbContext<ApplicationUser>

    {
       
        public DbSet<Patient> Patients { get; set; }
        public EFDbContext() : base("EFDbContext")
        {
        }


        public static EFDbContext Create()
        {
            return new EFDbContext();
        }





    }

   
}
