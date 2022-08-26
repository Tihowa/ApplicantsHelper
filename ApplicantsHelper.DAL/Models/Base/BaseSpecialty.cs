using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsHelper.DAL.Models.Base
{
    public abstract class BaseSpecialty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PassingGrade { get; set; } = 0;
        public virtual List<University> Universities { get; set; } = new List<University>();
    }
}
