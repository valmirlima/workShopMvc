using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Vendedor>> FindAllAsync()
        {
            return await _context.vendedors.ToListAsync();

        }
        public async Task InsertAsync(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChangesAsync();
        }
        public async Task<Vendedor> FindByIdAsync(int id)
        {
            return await _context.vendedors.Include(obj => obj.departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.vendedors.FindAsync(id);
                _context.vendedors.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                throw new IntegrityException("Não é possivel deletar vendedor com vendas!!!");
            }
        }

        internal object FindById(int id, object value)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateAsync(Vendedor obj)
        {
            bool hasAny = await _context.vendedors.AnyAsync(x => x.Id == obj.Id);
            if(!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}