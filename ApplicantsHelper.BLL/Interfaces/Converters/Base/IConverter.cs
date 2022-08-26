using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsHelper.BLL.Interfaces.Converters.Base
{
    public interface IConverter<T, TDTO>
    {
        T ConvertFromDTO(TDTO data);
        TDTO ConvertToDTO(T data);
        List<TDTO> ConvertListToDTO(List<T> list);
        List<T> ConvertListFromDTO(List<TDTO> list);
    }
}
