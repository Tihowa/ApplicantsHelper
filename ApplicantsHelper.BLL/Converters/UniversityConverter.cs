using ApplicantsHelper.BLL.Interfaces.Converters;
using ApplicantsHelper.BLL.Models;
using ApplicantsHelper.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsHelper.BLL.Converters
{
    public class UniversityConverter : IUniversityConverter
    {
        //private SpecialtyConverter specialtyConverter = new SpecialtyConverter();
        public University ConvertFromDTO(UniversityDTO data)
        {
            if (data != null)
            {
                University university = new University
                {
                    Id = data.Id,
                    Name = data.Name,
                    UrlForData = data.UrlForData
                };
                //foreach (SpecialtyDTO item in data.Specialties)
                //{
                //    university.Specialties.Add(specialtyConverter.ConvertFromDTO(item));
                //}
                return university;
            }
            return null;
        }

        public List<University> ConvertListFromDTO(List<UniversityDTO> list)
        {
            List<University> result = new List<University>();
            foreach (UniversityDTO item in list)
            {
                result.Add(this.ConvertFromDTO(item));
            }
            return result;
        }

        public List<UniversityDTO> ConvertListToDTO(List<University> list)
        {
            List<UniversityDTO> result = new List<UniversityDTO>();
            foreach (University item in list)
            {
                result.Add(this.ConvertToDTO(item));
            }
            return result;
        }

        public UniversityDTO ConvertToDTO(University data)
        {
            if (data != null)
            {
                UniversityDTO university = new UniversityDTO
                {
                    Id = data.Id,
                    Name = data.Name,
                    UrlForData = data.UrlForData
                };
                //foreach (Specialty item in data.Specialties)
                //{
                //    university.Specialties.Add(specialtyConverter.ConvertToDTO(item));
                //}
                return university;
            }
            return null;
        }
    }
}
