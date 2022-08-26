using ApplicantsHelper.BLL.Interfaces.Services.Base;
using ApplicantsHelper.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsHelper.BLL.Interfaces.Services
{
    public interface ISpecialtyService : IService<SpecialtyDTO>
    {
        List<UniversityDTO> GetUniversities(int id);
    }
}
