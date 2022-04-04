using System;
using System.Linq;
namespace CrashUtahProject.Models
{
    public class EFAccidentRepository : IAccidentRepository
    {
        private AccidentDbContext _context { get; set; }
        public EFAccidentRepository(AccidentDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Accident> Accidents => _context.Accidents;
    }
}