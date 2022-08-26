using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsHelper.DAL.Models.Base
{
    public abstract class BaseUniversity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string AbbreviationOnEn { get; set; }
        public virtual List<Specialty> Specialties { get; set; } = new List<Specialty>();
    }
}
