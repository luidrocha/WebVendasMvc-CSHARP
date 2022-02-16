using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVendasMvc.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string menssage) : base(menssage)
        {

        }
    }
}
