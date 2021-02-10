using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // Temel voidler icin baslangic
    public interface IResult
    {
        bool Success { get; } // Sadece okunabilir, ekleme isi basarili true gibi
        string Message { get; } // "Urun eklendi", "Eklenemedi" gibi bilgilendirme 
    }
}
