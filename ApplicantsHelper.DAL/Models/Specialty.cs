using ApplicantsHelper.DAL.Enums;
using ApplicantsHelper.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsHelper.DAL.Models
{
    public class Specialty : BaseSpecialty
    {
        public double Competition { get; set; } = 0;
        public int AdmissionPlan { get; set; } = 0;
        public GradeType GradeType { get; set; } = 0;
    }
}
