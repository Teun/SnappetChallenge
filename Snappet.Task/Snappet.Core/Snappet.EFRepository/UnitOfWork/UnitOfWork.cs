using Snappet.EFDesinger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.EFRepository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private snappetdbEntities _context = null;


        public UnitOfWork()
        {
            if (this._context == null)
                this._context = new snappetdbEntities();


            this._context.Configuration.LazyLoadingEnabled = false;
            this._context.Configuration.ProxyCreationEnabled = false;
            this._context.Configuration.AutoDetectChangesEnabled = false;
            this._context.Database.CommandTimeout = 0;
            this._context.Database.Initialize(force: false);
        }

        public snappetdbEntities Context
        {
            get
            {
                if (this._context == null)
                    this._context = new snappetdbEntities();
                return this._context;
            }
        }

        #region  Dispose
        private bool disposed = false;
        

        public new void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
        
    }
}
