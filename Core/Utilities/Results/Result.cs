using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Success { get; }

        public string Message { get; }

        public Result(bool success, string message):this(success)
        {
            // Onemli Not!!! read-only'ler constructor icinde set edilebilir! (Success, Message bunlar read-only)
            //Success = success;
            Message = message;
        }

        public Result(bool success) // Constructor overloading
        {            
            Success = success;            
        }
    }
}
