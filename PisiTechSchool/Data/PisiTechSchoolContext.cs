using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PisiTechSchool.Models;

namespace PisiTechSchool.Data
{
    public class PisiTechSchoolContext : DbContext
    {
        public PisiTechSchoolContext (DbContextOptions<PisiTechSchoolContext> options)
            : base(options)
        {
        }

       
        public DbSet<PisiTechSchool.Models.Service> Service { get; set; } = default!;
        public DbSet<PisiTechSchool.Models.Subscription> Subscription { get; set; } = default!;
        public DbSet<PisiTechSchool.Models.TokenPeriod> TokenPeriod { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Service>().HasData(
            new Service { ServiceId = 1,  Email = "goodjoe@gmail.com", PhoneNumber="09078884321", CreatedDate = System.DateTime.Today},
            new Service { ServiceId = 2,  Email = "thomike@gmail.com", PhoneNumber = "08087654321", CreatedDate = System.DateTime.Today },
            new Service { ServiceId = 3,  Email = "jkay@gmail.com",  PhoneNumber = "070876543217", CreatedDate = System.DateTime.Today},
            new Service { ServiceId = 4,  Email = "smith@gmail.com", PhoneNumber = "07087699092", CreatedDate = System.DateTime.Today }
            );

            modelBuilder.Entity<TokenPeriod>().HasData(
            new TokenPeriod { Id = 1, ExpiryPeriod = 1, Description="Expires After I day"}
            
            );
        }
       
    }

  
}
