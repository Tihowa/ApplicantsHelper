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
    public class SpecialtyService : ISpecialtyService
    {
        private ISpecialtyRepository repository;
        private ISpecialtyConverter converter;
        private IUniversityConverter universityConverter;
        public SpecialtyService(ISpecialtyRepository repository, ISpecialtyConverter converter,IUniversityConverter universityConverter)
        {
            this.repository = repository;
            this.converter = converter;
            this.universityConverter = universityConverter;
        }

        public void Create(SpecialtyDTO data)
        {
            if (data == null)
                throw new NullReferenceException();
            repository.Create(converter.ConvertFromDTO(data));
        }

        public void Dispose()
        {
            repository.Dispose();
        }

        public List<UniversityDTO> GetUniversities(int id)
        {
            Specialty specialty = repository.Read(id);
            return universityConverter.ConvertListToDTO(specialty.Universities);
        }

        public SpecialtyDTO Read(int id)
        {
            if (id < 0)
                throw new ArgumentException("Id cannot be negative");
            return converter.ConvertToDTO(repository.Read(id));
        }

        public List<SpecialtyDTO> ReadAll()
        {
            return converter.ConvertListToDTO(repository.ReadAll());
        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }

        public void Remove(SpecialtyDTO data)
        {
            if (data == null)
                throw new NullReferenceException();
            repository.Remove(converter.ConvertFromDTO(data));
        }

        public void Update(SpecialtyDTO data)
        {
            if (data == null)
                throw new NullReferenceException();
            repository.Update(converter.ConvertFromDTO(data));
        }
    }
}
