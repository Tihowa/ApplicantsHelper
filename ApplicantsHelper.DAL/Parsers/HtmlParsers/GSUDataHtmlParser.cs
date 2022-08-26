using AngleSharp.Html.Parser;
using ApplicantsHelper.DAL.Interfaces.Parsers;
using ApplicantsHelper.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ApplicantsHelper.DAL.Parsers.HtmlParsers
{
    public class GSUDataHtmlParser : IDataHtmlParser
    {
        public University University { get; set; } = new University { Name = "ГОМЕЛЬСКИЙ ГОСУДАРСТВЕННЫЙ УНИВЕРСИТЕТ ИМЕНИ ФРАНЦИСКА СКОРИНЫ", Abbreviation = "ГГУ", AbbreviationOnEn = "GSU" };


        public List<Specialty> ParseDate(string param)
        {
            List<Specialty> result = new List<Specialty>();
            string html = "";
            using (HttpClient client = new HttpClient())
            {
                var resp = client.GetAsync(param).Result;
                html = resp.Content.ReadAsStringAsync().Result;
            }
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html).QuerySelectorAll("tr");
            for (int i = 3; i < document.Count(); i++)
            {
                Specialty specialty = new Specialty
                {
                    //Id = Convert.ToInt32(document[i].Children[0].TextContent),
                    Name = document[i].Children[1].TextContent
                };

                string grate = document[i].Children[document[i].Children.Count() - 1].TextContent;
                if (grate.Contains("п/п"))
                {
                    int n = grate.IndexOf("п/п");
                    grate = grate.Remove(n - 1);
                    specialty.GradeType = Enums.GradeType.SemiPassGrade;
                }
                else
                {
                    if (grate.Contains("ВК"))
                    {
                        int n = grate.IndexOf("ВК");
                        grate = grate.Remove(n - 1);
                        specialty.GradeType = Enums.GradeType.OutOfCompetitionGrade;
                    }
                    else
                    {
                        specialty.GradeType = Enums.GradeType.PassGrade;
                    }
                }
                if (document[i].Children.Count() <= 3)
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (document[j].Children.Count() == 4)
                        {
                            specialty.Competition = double.Parse(document[j].Children[2].TextContent);
                            break;
                        }
                    }
                }
                else
                {
                    specialty.Competition = double.Parse(document[i].Children[2].TextContent);
                }
                specialty.PassingGrade = int.Parse(grate);
                //specialty.Universities.Add(University);
                //University.Specialties.Add(specialty);
                result.Add(specialty);
            }
            return result;
        }
    }
}
