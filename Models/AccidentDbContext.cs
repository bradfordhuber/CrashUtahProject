using System;
using Microsoft.EntityFrameworkCore;
namespace CrashUtahProject.Models
{
    public class AccidentDbContext : DbContext
    {
        public AccidentDbContext(DbContextOptions<AccidentDbContext> options) : base(options)
        {
        }
        public DbSet<Accident> Accidents { get; set; }
    }
}