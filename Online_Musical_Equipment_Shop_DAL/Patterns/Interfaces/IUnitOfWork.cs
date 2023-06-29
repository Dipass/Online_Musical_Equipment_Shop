using Online_Musical_Equipment_Shop_DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_DAL.Patterns.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IInstrumentsRepository InstrumentsRepository { get; }
    }
}
