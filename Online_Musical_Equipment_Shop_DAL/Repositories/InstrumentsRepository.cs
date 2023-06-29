using Microsoft.EntityFrameworkCore;
using Online_Musical_Equipment_Shop_DAL.Context;
using Online_Musical_Equipment_Shop_DAL.Entities;
using Online_Musical_Equipment_Shop_DAL.Patterns;
using Online_Musical_Equipment_Shop_DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_DAL.Repositories
{
    public class InstrumentsRepository : GenericRepository<Instruments>, IInstrumentsRepository
    {
        private readonly MusicalEquipmentShopContext _context;

        private readonly DbSet<Instruments> _instruments;

        public InstrumentsRepository(MusicalEquipmentShopContext context) : base(context)
        {
            _context = context;
            _instruments = _context.Set<Instruments>(); 
        }

        public async Task<IEnumerable<string>> GetAllTitlesInstrumentsAsync()
        {
            return await _instruments
                .Select(x => x.InstrumentTitle)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Instruments>> GetInstrumentsWithPaginationAsync(InstrumentParameters parameters)
        {
           return await _instruments
                .OrderBy(on => on.InstrumentTitle)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Instruments>> GetInstrumentsSortByDescroptionAsync()
        {
            return await _instruments
                 .OrderBy(on => on.Description)
                 .AsNoTracking().ToListAsync();
        }
    }
}
