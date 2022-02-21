using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMvc.Data;
using WebVendasMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace WebVendasMvc.Services
{
    public class DepartmentService
    {
        private readonly WebVendasMvcContext _context;

        public DepartmentService(WebVendasMvcContext context)
        {
            _context = context;
        }
        // Metodo ASSINCRONO Não trava a aplicação.
        // Este metodo Task pertence ao pacote /  using System.Threading.Tasks;
        public async Task<List<Department>> FindAllAsync()
        {
            // A expressão LINQ  não é executada até que algum metodo provoque a EXECUÇÃO.
            
            return await _context.Department.OrderBy(d => d.Name).ToListAsync(); // ToListAsync() É DO  EF

        }

    }
}
