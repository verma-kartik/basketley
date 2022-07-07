using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Result
    {
        public bool Success { get; }

        public string Error { get; }

        protected Result(bool success, string error)
        {
            Success = success;
            Error = error;
        }

        public static Result Fail(string error)
        {
            return new Result(false, error);
        }

        public static Result<TValue> Fail<TValue>(string error)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            return new Result<TValue>(default, false, error);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public static Result Ok()
        {
            return new Result(true, error: null);
        }

        public static Result<TValue> Ok<TValue>(TValue value)
        {
            return new Result<TValue>(value, true, error: null);
        }

        
    }
}
