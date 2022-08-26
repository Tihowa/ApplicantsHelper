using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsHelper.BLL.Models.Base
{
    public abstract class BaseUniversityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string AbbreviationOnEn { get; set; }
    }
}
