using AutoMapper;
using pMan.BAL.Interface;
using pMan.DAL.Entities;
using pMan.DAL.Interfaces;
using pMan.Models;
namespace pMan.BAL
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepo _BoardRepo;
        private readonly IMapper _mapper;
        public BoardService(IBoardRepo BoardRepo, IMapper mapper) {
            _BoardRepo = BoardRepo;
            _mapper = mapper;
        }
    }
}