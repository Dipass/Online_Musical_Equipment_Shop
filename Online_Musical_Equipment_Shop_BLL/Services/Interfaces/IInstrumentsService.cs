using Online_Musical_Equipment_Shop_BLL.DTOs.RequestsDTOs;
using Online_Musical_Equipment_Shop_BLL.DTOs.ResponseDTOs;
using Online_Musical_Equipment_Shop_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_BLL.Services.Interfaces
{
    public interface IInstrumentsService 
    {
        Task<IEnumerable<GetInstrumentsDTO>> GetAllEntitiesAsync();

        Task<GetInstrumentsDTO> GetEntityByIdAsync(Guid Id);

        Task<GetInstrumentsDTO> InsertEntityAsync(InsertInstrumentsDTO insertInstrumentsDTO);

        Task<GetInstrumentsDTO> UpdateEntityAsync(UpdateInstrumentsDTO updateInstrumentsDTO);

        Task<IEnumerable<GetInstrumentsDTO>> DeleteEntityByIdAsync(Guid Id);

        Task<IEnumerable<GetInstrumentsDTO>> GetInstrumentsWithPaginationAsync(InstrumentParameters parameters);

        Task<IEnumerable<GetInstrumentsDTO>> GetInstrumentsSortByDescroptionAsync();

    }
}
