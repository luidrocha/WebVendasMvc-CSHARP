using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMvc.Data;
using WebVendasMvc.Models;
using Microsoft.EntityFrameworkCore;
using WebVendasMvc.Services.Exceptions;

namespace WebVendasMvc.Services
{
    public class SellerService
    {
        private readonly WebVendasMvcContext _context;



        public SellerService(WebVendasMvcContext context)
        {

            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            // acessa a tabela e retorna a lista
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            // Execudado em memório
            _context.Add(obj);

            // Executa a ação no bd

            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            // Include(obj => obj.Department) Faz com que a associação seja Carregada Equivale a um JOINN

            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller obj)
        {
            // Verifica se existe um usuario com o Id que chegou

            bool existeAlgum = await _context.Seller.AnyAsync(x => x.Id == obj.Id);

            if (!existeAlgum)
            {
                throw new NotFoundException("Usuário não cadastrado !!");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();

            } // Esta exception indica que o banco foi atualizado simultaneamente  e nenm uma linha foi afetada 
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
