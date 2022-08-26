using ApplicantsHelper.DAL.Models;
using ApplicantsHelper.DAL.Parsers.HtmlParsers;
using ApplicantsHelper.DAL.Parsers.PDFParsers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsHelper.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<University> Universities { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        private static GSUDataHtmlParser gsu = new GSUDataHtmlParser();
        private static GSTUDataPDFParser gstu = new GSTUDataPDFParser();
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialty>()
                   .HasMany(left => left.Universities)
                   .WithMany(right => right.Specialties)
                   .UsingEntity<SpecialityUniversity>(
                       right => right.HasOne(e => e.University).WithMany(),
                       left => left.HasOne(e => e.Specialty).WithMany().HasForeignKey(e => e.SpecialityId),
                       join => join.ToTable("SpecialityUniversity")
                   );

            List<University> universities = new List<University>();
            universities.Add(gsu.University);
            universities.Add(gstu.University);
            List<SpecialityUniversity> specialityUniversities = new List<SpecialityUniversity>();
            List<Specialty> specialtiesGsu = gsu.ParseDate("http://old.gsu.by/dinamika/2020/konkurs_i_prohodnoy_ball/ProchBallDN.html");
            List<Specialty> specialtiesGstu = gstu.ParseDate(@"gstu_balls_2020.pdf");
            int i = 1;
            specialtiesGsu.ForEach(s => { s.Id = i; i++; });

            specialtiesGstu.ForEach(s => { s.Id = i; i++; });
            i = 1;
            universities.ForEach(u => { u.Id = i; i++; });
            foreach (var item in specialtiesGsu)
            {
                specialityUniversities.Add(new SpecialityUniversity {SpecialityId = item.Id,UniversityId = gsu.University.Id });
            }
            foreach (var item in specialtiesGstu)
            {
                specialityUniversities.Add(new SpecialityUniversity { SpecialityId = item.Id, UniversityId = gstu.University.Id });
            }
            //List<Specialty> specialties = new List<Specialty>();
            //specialtiesGstu.AddRange(specialtiesGsu);
            //specialtiesGstu.AddRange(specialtiesGstu);
            modelBuilder.Entity<Specialty>().HasData(specialtiesGsu);
            modelBuilder.Entity<Specialty>().HasData(specialtiesGstu);
            modelBuilder.Entity<University>().HasData(universities);
            modelBuilder.Entity<SpecialityUniversity>().HasData(specialityUniversities);
            //modelBuilder.Entity<SpecialtySubject>().HasData(specialtySubjects);
        }
    }
}
