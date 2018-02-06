using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Assignment.Business.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IWorkRepository WorkRepository { get; }
    }
}
