using AutoMapper;
using Online_Musical_Equipment_Shop_BLL.DTOs.RequestsDTOs;
using Online_Musical_Equipment_Shop_BLL.DTOs.ResponseDTOs;
using Online_Musical_Equipment_Shop_BLL.Services.Interfaces;
using Online_Musical_Equipment_Shop_DAL.Entities;
using Online_Musical_Equipment_Shop_DAL.Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_BLL.Services
{
    public class InstrumentsService : IInstrumentsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InstrumentsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetInstrumentsDTO>> DeleteEntityByIdAsync(Guid Id)
        {
            var result = await _unitOfWork.InstrumentsRepository.DeleteEntityByIdAsync(Id);

            return _mapper.Map<IEnumerable<Instruments>, IEnumerable<GetInstrumentsDTO>>(result);
        }

        public async Task<IEnumerable<GetInstrumentsDTO>> GetAllEntitiesAsync()
        {
            var result = await _unitOfWork.InstrumentsRepository.GetAllEntitiesAsync();

            return _mapper.Map<IEnumerable<Instruments>, IEnumerable<GetInstrumentsDTO>>(result);
        }

        public async Task<GetInstrumentsDTO> GetEntityByIdAsync(Guid Id)
        {
            var result = await _unitOfWork.InstrumentsRepository.GetEntityByIdAsync(Id);

            return _mapper.Map<GetInstrumentsDTO>(result);
        }

        public async Task<GetInstrumentsDTO> InsertEntityAsync(InsertInstrumentsDTO insertInstrumentsDTO)
        {
            var result = await _unitOfWork.InstrumentsRepository.InsertEntityAsync(_mapper.Map<Instruments>(insertInstrumentsDTO));

            return _mapper.Map<GetInstrumentsDTO>(result);
        }

        public async Task<GetInstrumentsDTO> UpdateEntityAsync(UpdateInstrumentsDTO updateInstrumentsDTO)
        {
            var result = await _unitOfWork.InstrumentsRepository.UpdateEntityAsync(_mapper.Map<Instruments>(updateInstrumentsDTO));

            return _mapper.Map<GetInstrumentsDTO>(result);
        }

        public async Task<IEnumerable<GetInstrumentsDTO>> GetInstrumentsWithPaginationAsync(InstrumentParameters parameters)
        {
            var result = await _unitOfWork.InstrumentsRepository.GetInstrumentsWithPaginationAsync(parameters);

            return _mapper.Map<IEnumerable<Instruments>, IEnumerable<GetInstrumentsDTO>>(result);
        }

        public async Task<IEnumerable<GetInstrumentsDTO>> GetInstrumentsSortByDescroptionAsync( )
        {
            var result = await _unitOfWork.InstrumentsRepository.GetInstrumentsSortByDescroptionAsync();

            return _mapper.Map<IEnumerable<Instruments>, IEnumerable<GetInstrumentsDTO>>(result);
        }
    }
}
