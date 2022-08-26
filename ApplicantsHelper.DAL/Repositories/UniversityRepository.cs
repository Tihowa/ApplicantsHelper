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
    public class UniversityRepository : IUniversityRepository
    {
        private ApplicationDbContext context;
        public UniversityRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(University data)
        {
            if (data == null)
                throw new NullReferenceException();
            context.Universities.Add(data);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public University Read(int id)
        {
            if (id < 0)
                throw new ArgumentException("Id cannot be negative");
            University university = context.Universities.Include(u=>u.Specialties).FirstOrDefault(u => u.Id == id);
            if (university == null)
                throw new ArgumentException($"Университета с id - {id} не существует");
            return university;
        }

        public List<University> ReadAll()
        {
            return context.Universities.ToList();
        }

        public void Remove(int id)
        {
            if (id < 0)
                throw new ArgumentException("Id cannot be negative");
            University university = context.Universities.FirstOrDefault(u => u.Id == id);
            if (university == null)
                throw new ArgumentException($"Комментария с id - {id} не существует");
            context.Universities.Remove(university);
            context.SaveChanges();
        }

        public void Remove(University data)
        {
            if (data == null)
                throw new NullReferenceException();
            context.Universities.Remove(data);
            context.SaveChanges();
        }

        public void Update(University data)
        {
            if (data == null)
                throw new NullReferenceException();
            context.Entry(data).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
