using ApplicantsHelper.BLL.Models.Base;
using ApplicantsHelper.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsHelper.BLL.Models
{
    public class SpecialtyDTO : BaseSpecialtyDTO
    {
        public double Competition { get; set; } = 0;
        public int AdmissionPlan { get; set; } = 0;
        public GradeType GradeType { get; set; } = 0;
        public SpecialtyDTO()
        {

        }
        public SpecialtyDTO(int id,string name,int passinggrate)
        {
            this.Id = id;
            this.Name = name;
            this.PassingGrade = passinggrate;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
