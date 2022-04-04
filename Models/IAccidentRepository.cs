using System;
using System.Linq;
namespace CrashUtahProject.Models
{
    public interface IAccidentRepository
    {
        IQueryable<Accident> Accidents { get; }
    }
}