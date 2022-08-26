using ApplicantsHelper.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicantsHelper.ViewModels
{
    public class TablesViewModel
    {
        public List<UniversityDTO> Universities { get; set; }
        public List<SpecialtyDTO> Specialties { get; set; }
    }
}
