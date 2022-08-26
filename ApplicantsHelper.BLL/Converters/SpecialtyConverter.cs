using ApplicantsHelper.BLL.Interfaces.Converters;
using ApplicantsHelper.BLL.Models;
using ApplicantsHelper.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsHelper.BLL.Converters
{
    public class SpecialtyConverter : ISpecialtyConverter
    {
        public Specialty ConvertFromDTO(SpecialtyDTO data)
        {
            if (data != null)
            {
                Specialty specialty = new Specialty
                {
                    Id = data.Id,
                    Name = data.Name,
                    PassingGrade = data.PassingGrade,
                    Competition = data.Competition,
                    AdmissionPlan = data.AdmissionPlan,
                    GradeType = data.GradeType
                };
                return specialty;
            }
            return null;
        }

        public List<Specialty> ConvertListFromDTO(List<SpecialtyDTO> list)
        {
            List<Specialty> result = new List<Specialty>();
            foreach (SpecialtyDTO item in list)
            {
                result.Add(this.ConvertFromDTO(item));
            }
            return result;
        }

        public List<SpecialtyDTO> ConvertListToDTO(List<Specialty> list)
        {
            List<SpecialtyDTO> result = new List<SpecialtyDTO>();
            foreach (Specialty item in list)
            {
                result.Add(this.ConvertToDTO(item));
            }
            return result;
        }

        public SpecialtyDTO ConvertToDTO(Specialty data)
        {
            if (data != null)
            {
                SpecialtyDTO specialty = new SpecialtyDTO
                {
                    Id = data.Id,
                    Name = data.Name,
                    PassingGrade = data.PassingGrade,
                    Competition = data.Competition,
                    AdmissionPlan = data.AdmissionPlan,
                    GradeType = data.GradeType
                };
                return specialty;
            }
            return null;
        }
    }
}
