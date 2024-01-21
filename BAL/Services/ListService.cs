using AutoMapper;
using pMan.BAL.Interface;
using pMan.DAL.Entities;
using pMan.DAL.Interfaces;
using pMan.DTOs;
using pMan.Models;
namespace pMan.BAL
{
    public class ListService : IListService
    {
        private readonly IListRepo _ListRepo;
        private readonly IMapper _mapper;
        public ListService(IListRepo ListRepo, IMapper mapper)
        {
            _ListRepo = ListRepo;
            _mapper = mapper;
        }
        public void Add(ListInsertDto list)
        {
            // pMan.DAL.Entities.List listEntry = _mapper.Map<pMan.DAL.Entities.List>(list);
            pMan.DAL.Entities.List listEntry = new()
            {
                ParentBoardId = list.BoardId,
                Name = list.Name,
                CreatedBy = 2
            };
            _ListRepo.Add(listEntry);
            _ListRepo.SaveChangesManaged();
        }

        public List<ListModel> GetAll()
        {
            return _mapper.Map<List<ListModel>>(_ListRepo.GetAll().ToList());
        }
        public async Task<List<ListModel>> GetAllAsync()
        {
            return _mapper.Map<List<ListModel>>(await _ListRepo.GetAllAsync());
        }
    }
}
