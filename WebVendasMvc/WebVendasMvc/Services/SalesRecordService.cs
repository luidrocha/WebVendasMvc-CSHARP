using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMvc.Data;
using WebVendasMvc.Models;

namespace WebVendasMvc.Services
{
    public class SalesRecordService
    {
        public WebVendasMvcContext _context;

        public SalesRecordService(WebVendasMvcContext contexto)
        {
            _context = contexto;
        }

        public async Task<List<SallersRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            // cria um obj do tipo IQueryable 
            var result = from obj in _context.SellersRecord select obj; // LINQ
            
            if(minDate.HasValue)
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }
                return await result
                      // pacote Microsoft.EntityFrameworkCore; Include faz o JOINN
                      .Include(x => x.Seller)
                      .Include(x => x.Seller.Department)
                      .OrderByDescending(x => x.Data)
                      .ToListAsync();
            
           
        }
        // Busca Agrupada por departamento
        public async Task<List<IGrouping<Department, SallersRecord>>> FindGroupingByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            // cria um obj do tipo IQueryable 
            var result = from obj in _context.SellersRecord select obj; // LINQ

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }
            return await result
                  // pacote Microsoft.EntityFrameworkCore; Include faz o JOINN
                  .Include(x => x.Seller)
                  .Include(x => x.Seller.Department)
                  .OrderByDescending(x => x.Data)
                  // Retorna uma coleção Igroup
                  .GroupBy(x => x.Seller.Department)
                  .ToListAsync();


        }
    }
}
