using Microsoft.EntityFrameworkCore;
using Snappet.Assignment.Business.Interfaces;
using Snappet.Assignment.Business.Repositories;
using Snappet.Assignment.Data.Context;
using Snappet.Assignment.Data.Interfaces;
using System;
namespace Snappet.Assignment.Business.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISchoolDbContext _context;

        private IWorkRepository _WorkRepository;
        private bool disposed;


        public UnitOfWork(DbContextOptions<SchoolDbContext> options)
        {

            _context = new SchoolDbContext(options);
        }
        public UnitOfWork(string connectionString) :
            this(new DbContextOptionsBuilder<SchoolDbContext>().
                UseSqlServer(connectionString).
                Options)
        {

        }


        public IWorkRepository WorkRepository
        {
            get
            {
                if (_WorkRepository == null)
                {
                    _WorkRepository = new WorkRepository(_context);
                }
                return _WorkRepository;
            }
        }






        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

