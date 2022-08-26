using ApplicantsHelper.DAL.Interfaces.Parsers;
using ApplicantsHelper.DAL.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using UglyToad.PdfPig;

namespace ApplicantsHelper.DAL.Parsers.PDFParsers
{
    public class GSTUDataPDFParser : IDataPDFParser
    {
        public University University { get; set; } = new University { Name = "ГОМЕЛЬСКИЙ ГОСУДАРСТВЕННЫЙ ТЕХНИЧЕСКИЙ УНИВЕРСИТЕТ ИМЕНИ П.О.СУХОГО", Abbreviation = "ГГТУ", AbbreviationOnEn = "GSTU" };

        public List<Specialty> ParseDate(string param)
        {
            List<Specialty> result = new List<Specialty>();
           
            Regex firstSplit = new Regex(@"\b.+?\s+\d+?\s+\d+?\b");
            Regex secondSplit = new Regex(@"\d+");
            string content = "";
            var path = AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\..\\..\\ApplicantsHelper.DAL\\PDFs\\GSTU\\gstu_balls_2020.pdf";
            using (PdfDocument document = PdfDocument.Open(path))
            {
                content = document.GetPage(1).Text;
            }
            content = Regex.Replace(content, ".*Балл", "");
            var data = firstSplit.Matches(content);
            for (int i = 0; i < data.Count - 1; i++)
            {
                Specialty specialty = new Specialty();
                var digits = secondSplit.Matches(data[i].Value.ToString());
                specialty.AdmissionPlan = Convert.ToInt32(digits[0].Value);
                specialty.PassingGrade = Convert.ToInt32(digits[1].Value);
                //string str = "";
                //foreach (var dig in digits)
                //{
                //    str += dig.ToString() + " ";
                //}
                int n = data[i].Value.IndexOf(digits[0].Value);
                specialty.Name = data[i].Value.Remove(n).Trim();
                //specialty.Universities.Add(University);
                //University.Specialties.Add(specialty);
                result.Add(specialty);
            }
            return result;
        }
    }
}
