using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineLaboratory.Models;

namespace OnlineLaboratory.Data
{
    public class OnlineLaboratoryContext : DbContext
    {
        public OnlineLaboratoryContext (DbContextOptions<OnlineLaboratoryContext> options)
            : base(options)
        {
        }


        public DbSet<OnlineLaboratory.Models.Appointment> Appointment { get; set; }
        public DbSet<OnlineLaboratory.Models.Tests> Tests { get; set; }

        public DbSet<OnlineLaboratory.Models.GetMedicine> GetMedicine { get; set; }
    }
}
