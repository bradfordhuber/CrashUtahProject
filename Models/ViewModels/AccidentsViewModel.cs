using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrashUtahProject.Models;

namespace CrashUtahProject.Models.ViewModels
{
    public class AccidentsViewModel
    {
        public IQueryable<Accident> Accidents { get; set; }
        public PageInfo PageInfo { get; set; }

    }
}