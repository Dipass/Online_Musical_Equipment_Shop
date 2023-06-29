using Online_Musical_Equipment_Shop_DAL.Entities;
using Online_Musical_Equipment_Shop_DAL.Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_DAL.Repositories.Interfaces
{
    public interface IInstrumentsRepository : IGenericRepository<Instruments>
    {
        Task<IEnumerable<string>> GetAllTitlesInstrumentsAsync();
        Task<IEnumerable<Instruments>> GetInstrumentsWithPaginationAsync(InstrumentParameters parameters);
        Task<IEnumerable<Instruments>> GetInstrumentsSortByDescroptionAsync();


    }
}
