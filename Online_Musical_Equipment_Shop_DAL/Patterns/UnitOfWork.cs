using Online_Musical_Equipment_Shop_DAL.Context;
using Online_Musical_Equipment_Shop_DAL.Patterns.Interfaces;
using Online_Musical_Equipment_Shop_DAL.Repositories;
using Online_Musical_Equipment_Shop_DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_DAL.Patterns
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MusicalEquipmentShopContext _context;

        public UnitOfWork(MusicalEquipmentShopContext context)
        {
            _context = context;

            InstrumentsRepository = new InstrumentsRepository(context);
        }

        public IInstrumentsRepository InstrumentsRepository { get; private set; }

        public void Dispose() => _context.Dispose();
    }
}
