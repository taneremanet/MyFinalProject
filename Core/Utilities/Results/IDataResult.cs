using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // Is durumuna gore Exception da dondurme ihtiyaci olabilir
    // Bu yuzden where kosulu ile daraltmadik
    public interface IDataResult<T> : IResult
    {
        T Data { get; } // Urun, Urunler gibi
    }
}
