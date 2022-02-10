using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMvc.Data;
using WebVendasMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace WebVendasMvc.Services
{
    public class SellerService
    {
        private readonly WebVendasMvcContext _context;



        public SellerService(WebVendasMvcContext context)
        {

            _context = context;
        }

        public List<Seller> FindAll()
        {
            // acessa a tabela e retorna a lista
            return _context.Seller.ToList(); 
        }

        public void Insert(Seller obj)
        {
            
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller  FindById(int id)
        {
            // Include(obj => obj.Department) Faz com que a associação seja Carregada Equivale a um JOINN

            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

    }
}
