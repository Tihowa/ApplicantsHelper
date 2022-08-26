using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsHelper.BLL.Models.Base
{
    [Serializable]
    public abstract class BaseSpecialtyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PassingGrade { get; set; } = 0;
    }
}
