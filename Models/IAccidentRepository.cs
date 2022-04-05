using System;
using System.Linq;
namespace CrashUtahProject.Models
{
    public interface IAccidentRepository
    {
        IQueryable<Accident> Accidents { get; }

        public void SaveAccident(Accident a);
        public void CreateAccident(Accident a);
        public void DeleteAccident(Accident a);
    }
}