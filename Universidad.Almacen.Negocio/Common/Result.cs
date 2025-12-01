using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Almacen.Negocio.Common
{
    public class Result
    {
        public bool OK { get; protected set; }
        public string Message { get; protected set; } = string.Empty;

        public Result(bool ok, string msg)
        {
            OK = ok;
            Message = msg;
        }

        public static Result Success(string message = null) => new Result(true, message);
        public static Result Failure(string message) => new Result(false, message);
    }

    public class Result<T>
    {
        public bool IsSuccess { get; private set; }   
        public string Message { get; private set; }
        public T Data { get; private set; }

        private Result(bool ok, T data, string message)
        {
            IsSuccess = ok;
            Data = data;
            Message = message;
        }

        public static Result<T> Success(T data, string message = null) => new Result<T>(true, data, message);
        public static Result<T> Failure(string message) => new Result<T>(false, default(T), message);
    }
}
