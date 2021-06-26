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

        public List<Vendedor> FindAll()
        {
            return _context.vendedors.ToList();

        }
        public void Insert(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Vendedor FindById(int id)
        {
            return _context.vendedors.Include(obj => obj.departamento).FirstOrDefault(obj => obj.Id == id);
        }
        public void Remove(int id)
        {
            var obj = _context.vendedors.Find(id);
            _context.vendedors.Remove(obj);
            _context.SaveChanges();
        }

        internal object FindById(int id, object value)
        {
            throw new NotImplementedException();
        }
        public void Update(Vendedor obj)
        {
            if (!_context.vendedors.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}