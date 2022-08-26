using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApplicantsHelper.Models;
using ApplicantsHelper.BLL.Interfaces.Services;
using ApplicantsHelper.BLL.Models;
using ApplicantsHelper.ViewModels;
using Microsoft.Extensions.Localization;
using System.Net.Http;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace ApplicantsHelper.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> localizer;

        private ISpecialtyService specialtyService;
        private IUniversityService universityService;

        private IWebHostEnvironment webHostEnvironment;

        public string MinGrate { get; set; }
        //List<University> universities = new List<University> { new University { Name = "ГОМЕЛЬСКИЙ ГОСУДАРСТВЕННЫЙ УНИВЕРСИТЕТ ИМЕНИ ФРАНЦИСКА СКОРИНЫ", Abbreviation = "ГГУ", AbbreviationOnEn = "GSU" }, new University { Name = "ГОМЕЛЬСКИЙ ГОСУДАРСТВЕННЫЙ ТЕХНИЧЕСКИЙ УНИВЕРСИТЕТ ИМЕНИ П.О.СУХОГО", Abbreviation = "ГГТУ", AbbreviationOnEn = "GSTU" } };
        public HomeController(ISpecialtyService specialtyService, IUniversityService universityService,IStringLocalizer<HomeController> localizer, IWebHostEnvironment webHostEnvironment)
        {
            this.specialtyService = specialtyService;
            this.universityService = universityService;
            this.localizer = localizer;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            //GSUDataHtmlParser parser = new GSUDataHtmlParser();
            ////GSTUDataPDFParser parser = new GSTUDataPDFParser();
            ////List<Specialty> result = parser.ParseDate(@"\PDFs\GSTU\gstu_balls_2020.pdf");
            //List<Specialty> spec = parser.ParseDate("http://old.gsu.by/dinamika/2020/konkurs_i_prohodnoy_ball/ProchBallDN.html");
            ////List<SpecialtyDTO> specialties = parserService.ParseDate(new GSUDataHtmlParser(), "http://old.gsu.by/dinamika/2020/konkurs_i_prohodnoy_ball/ProchBallDN.html");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Universities()
        {
            return PartialView(universityService.ReadAll());
        }
        public IActionResult Specialties()
        {
            //GSUDataHtmlParser parser = new GSUDataHtmlParser();
            //List<Specialty> result = parser.ParseDate("http://old.gsu.by/dinamika/2020/konkurs_i_prohodnoy_ball/ProchBallDN.html");
            return PartialView(specialtyService.ReadAll());
        }
        public IActionResult ShowSpecInfo(int id)
        {
            //GSUDataHtmlParser parser = new GSUDataHtmlParser();
            //List<Specialty> result = parser.ParseDate("http://old.gsu.by/dinamika/2020/konkurs_i_prohodnoy_ball/ProchBallDN.html");
            SpecialtyDTO specialty = specialtyService.Read(id);
            if (specialty != null)
                return View(specialty);
            return NoContent();
        }
        public IActionResult ShowUniversityInfo(int id)
        {
            UniversityDTO university = universityService.Read(id);
            if (university != null)
                return View(university);
            return NoContent();
        }
        public IActionResult GetAllData()
        {
            return View(universityService.ReadAll());
        }
        [HttpGet]
        public IActionResult FindUniversityByOption()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FindUniversityByOption(int mingrate, int maxgrate, int university = 0)
        {
            List<SpecialtyDTO> result = new List<SpecialtyDTO>();
            if(university == 0)
            {
                result = specialtyService.ReadAll().Where(s => s.PassingGrade >= mingrate && s.PassingGrade <= maxgrate).ToList();
            }
            else
            {
                result = universityService.GetSpecialties(university).Where(s => s.PassingGrade >= mingrate && s.PassingGrade <= maxgrate).ToList();
            }
          
            return PartialView("FoundSpecialties", result);
        }
        [HttpGet]
        public IActionResult AddingInforamtion()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddingInforamtion([FromBody]string file)
        {

            if(file != null)
            {
                List<SpecialtyDTO> list = new List<SpecialtyDTO>();
                string json = "";

                using (StreamReader stream = new StreamReader(@"D:\Тихон\Diplom\Preview\PrePre\" + file))
                {
                    //while (!stream.EndOfStream)
                    //{
                    //    json = stream.ReadLine();
                    //    list.Add(JsonConvert.DeserializeObject<SpecialtyDTO>(json));
                    //}
                    json = stream.ReadToEnd();
                    list = JsonConvert.DeserializeObject<SpecialtyDTO[]>(json).ToList();
                }
                Console.WriteLine(list);
                return PartialView("FoundSpecialties", list);
            }
            return View();
        }
        public IActionResult CloseTable()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult FindByGrate()
        {
            return PartialView();
        }
        [HttpGet]
        public IActionResult FindByGrateInSelectUniversity()
        {
            return PartialView(universityService.ReadAll());
        }
        [HttpPost]
        public IActionResult FindByGrateInSelectUniversity(int mingrate, int maxgrate, int university)
        {
            List<SpecialtyDTO> result = universityService.GetSpecialties(university).Where(s => s.PassingGrade >= mingrate && s.PassingGrade <= maxgrate).ToList();
            return PartialView("FoundSpecialties", result);
        }
        [HttpPost]
        public IActionResult FindByGrate(int mingrate, int maxgrate)
        {
            List<SpecialtyDTO> result = specialtyService.ReadAll().Where(s => s.PassingGrade >= mingrate && s.PassingGrade <= maxgrate).ToList();
            return PartialView("FoundSpecialties", result);
        }
        
    }
}
