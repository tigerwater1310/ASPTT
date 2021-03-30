using ASPTT.Data;
using ASPTT.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPTT.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<Country> _countries;
        private IGenericRepository<Hotel> _Hotels;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IGenericRepository<Country> Countries => _countries  ??= new GenericRepository <Country>(_context ) ;

        public IGenericRepository<Hotel> Hotels => _Hotels  ??= new GenericRepository <Hotel >(_context );

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

  

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
