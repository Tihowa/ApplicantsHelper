using ApplicantsHelper.BLL.Interfaces.Services.Base;
using ApplicantsHelper.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsHelper.BLL.Interfaces.Services
{
    public interface IUniversityService : IService<UniversityDTO>
    {
        List<SpecialtyDTO> GetSpecialties(int id);
    }
}
