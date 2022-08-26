using ApplicantsHelper.DAL.Context;
using ApplicantsHelper.DAL.Interfaces.Repositories;
using ApplicantsHelper.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicantsHelper.DAL.Repositories
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
        private ApplicationDbContext context;
        public SpecialtyRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Specialty data)
        {
            if (data == null)
                throw new NullReferenceException();
            context.Specialties.Add(data);
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public Specialty Read(int id)
        {
            if (id < 0)
                throw new ArgumentException("Id cannot be negative");
            Specialty specialty = context.Specialties.Include(s=>s.Universities).FirstOrDefault(u => u.Id == id);
            if (specialty == null)
                throw new ArgumentException($"Комментария с id - {id} не существует");
            return specialty;
        }
        public List<Specialty> ReadAll()
        {
            return context.Specialties.ToList();
        }

        public void Remove(int id)
        {
            if (id < 0)
                throw new ArgumentException("Id cannot be negative");
            Specialty specialty = context.Specialties.FirstOrDefault(u => u.Id == id);
            if (specialty == null)
                throw new ArgumentException($"Комментария с id - {id} не существует");
            context.Specialties.Remove(specialty);
            context.SaveChanges();
        }

        public void Remove(Specialty data)
        {
            if (data != null)
                context.Specialties.Remove(data);
            else
                throw new NullReferenceException();
            context.SaveChanges();
        }
        public void Update(Specialty data)
        {
            if (data == null)
                throw new NullReferenceException();
            context.Entry(data).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
