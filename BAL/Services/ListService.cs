using AutoMapper;
using pMan.BAL.Interface;
using pMan.DAL.Entities;
using pMan.DAL.Interfaces;
using pMan.Models;
namespace pMan.BAL
{
    public class ListService : IListService
    {
        private readonly IListRepo _ListRepo;
        private readonly IMapper _mapper;
        public ListService(IListRepo ListRepo, IMapper mapper) {
            _ListRepo = ListRepo;
            _mapper = mapper;
        }
    }
}