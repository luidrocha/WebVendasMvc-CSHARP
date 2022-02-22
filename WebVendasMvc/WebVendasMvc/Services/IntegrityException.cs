using System;


namespace WebVendasMvc.Services
{
    public class IntegrityException : ApplicationException

    {
        public IntegrityException(string message): base(message)
        {

        }
    }
}
