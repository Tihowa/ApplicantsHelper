using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsHelper.DAL.Models
{
    public class SpecialityUniversity
    {
        public int SpecialityId { get; set; }
        public virtual Specialty Specialty { get; set; }

        public int UniversityId { get; set; }
        public virtual University University { get; set; }
    }
}
