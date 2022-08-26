using ApplicantsHelper.DAL.Models;
using ApplicantsHelper.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsHelper.DAL.Interfaces.Parsers.Base
{
    public interface IDataParser<T> where T : BaseSpecialty
    {
        University University { get; set; }
        List<T> ParseDate(string param);
    }
}
