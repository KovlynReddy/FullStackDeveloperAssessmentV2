using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FullStackAPIAssessment.Models;

namespace FullStackDeveloperAssessment.Data
{
    public class FullStackDeveloperAssessmentContext : DbContext
    {
        public FullStackDeveloperAssessmentContext (DbContextOptions<FullStackDeveloperAssessmentContext> options)
            : base(options)
        {
        }

        public DbSet<FullStackAPIAssessment.Models.LocationModel> LocationModel { get; set; }

        public DbSet<FullStackAPIAssessment.Models.ImageModel> ImageModel { get; set; }

        public DbSet<FullStackAPIAssessment.Models.UserModel> UserModel { get; set; }
    }
}
