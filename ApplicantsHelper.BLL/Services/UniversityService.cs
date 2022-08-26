using ApplicantsHelper.BLL.Interfaces.Converters;
using ApplicantsHelper.BLL.Interfaces.Services;
using ApplicantsHelper.BLL.Models;
using ApplicantsHelper.DAL.Interfaces.Repositories;
using ApplicantsHelper.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsHelper.BLL.Services
{
    public class UniversityService : IUniversityService
    {
        private IUniversityRepository repository;
        private IUniversityConverter converter;
        private ISpecialtyConverter specialtyConverter;
        public UniversityService(IUniversityRepository repository, IUniversityConverter converter,ISpecialtyConverter specialtyConverter)
        {
            this.repository = repository;
            this.converter = converter;
            this.specialtyConverter = specialtyConverter;
        }
        public void Create(UniversityDTO data)
        {
            if (data == null)
                throw new NullReferenceException();
            University university = converter.ConvertFromDTO(data);
            repository.Create(university);
        }

        public void Dispose()
        {
            repository.Dispose();
        }

        public List<SpecialtyDTO> GetSpecialties(int id)
        {
            University university = repository.Read(id);
            return specialtyConverter.ConvertListToDTO(university.Specialties);
        }

        public UniversityDTO Read(int id)
        {
            return converter.ConvertToDTO(repository.Read(id));
        }

        public List<UniversityDTO> ReadAll()
        {
            return converter.ConvertListToDTO(repository.ReadAll());
        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }

        public void Remove(UniversityDTO data)
        {
            University university = converter.ConvertFromDTO(data);
            repository.Remove(university);
        }

        public void Update(UniversityDTO data)
        {
            if (data == null)
                throw new NullReferenceException();
            University university = converter.ConvertFromDTO(data);
            repository.Update(university);
        }
    }
}
