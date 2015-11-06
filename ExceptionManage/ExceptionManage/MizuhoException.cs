using System;

namespace ExceptionManage
{
    public class MizuhoException : Exception
    {
        public int Code;
        public MizuhoException()
        {
        }

        public MizuhoException(string message, int code) : base(message)
        {
            Code = code;
        }

        public MizuhoException(string message, int code, Exception innerException) : base(message, innerException)
        {
            Code = code;
        }
    }
}
