#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScienticPedagogicalWorkersRating.Models;

namespace ScienticPedagogicalWorkersRating.Data
{
    public class ScienticPedagogicalWorkersRatingContext : DbContext
    {
        public ScienticPedagogicalWorkersRatingContext (DbContextOptions<ScienticPedagogicalWorkersRatingContext> options)
            : base(options)
        {
        }

        public DbSet<ScienticPedagogicalWorkersRating.Models.Work_Type> Work_Type { get; set; }
    }
}
