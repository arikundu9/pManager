using AutoMapper;
using NPOI.SS.Formula.Functions;
using pMan.BAL.Interface;
using pMan.DAL.Entities;
using pMan.DAL.Interfaces;
using pMan.DTOs;
using pMan.Models;
namespace pMan.BAL
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepo _BoardRepo;
        private readonly IMapper _mapper;
        public BoardService(IBoardRepo BoardRepo, IMapper mapper)
        {
            _BoardRepo = BoardRepo;
            _mapper = mapper;
        }

        public void Add(BoardDto board)
        {
            Board boardEntry = _mapper.Map<Board>(board);
            boardEntry.CreatedBy = 2;
            _BoardRepo.Add(boardEntry);
            _BoardRepo.SaveChangesManaged();
        }

        public List<BoardModel> GetAll()
        {
            return _mapper.Map<List<BoardModel>>(_BoardRepo.GetAll().ToList());
        }
        public async Task<List<BoardModel>> GetAllAsync()
        {
            return _mapper.Map<List<BoardModel>>(await _BoardRepo.GetAllAsync());
        }
    }
}
