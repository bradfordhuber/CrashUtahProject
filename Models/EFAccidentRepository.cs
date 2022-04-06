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

        public void SaveAccident(Accident a)
        {
            _context.Update(a);
            _context.SaveChanges();
        }

        public void CreateAccident(Accident a)
        {
            _context.Add(a);
            _context.SaveChanges();
        }

        public void DeleteAccident(Accident a)
        {
            _context.Remove(a);
            _context.SaveChanges();
        }
    }
}