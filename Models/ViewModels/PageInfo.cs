using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrashUtahProject.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumAccidents { get; set; }
        public int AccidentsPerPage { get; set; }
        public int CurrentPage { get; set; }

        //figure out how many pages we need
        public int TotalPages => (int)Math.Ceiling((double)TotalNumAccidents / AccidentsPerPage);
    }
}