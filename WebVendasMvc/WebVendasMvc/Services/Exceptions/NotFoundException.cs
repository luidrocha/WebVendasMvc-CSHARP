using System;


namespace WebVendasMvc.Services.Exceptions
{
    public class NotFoundException : ApplicationException

    {
        public NotFoundException(string menssage) : base(menssage)
        {

        }
    }
}
