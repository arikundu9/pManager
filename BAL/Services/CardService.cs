using AutoMapper;
using pMan.BAL.Interface;
using pMan.DAL.Entities;
using pMan.DAL.Interfaces;
using pMan.Models;
namespace pMan.BAL
{
    public class CardService : ICardService
    {
        private readonly ICardRepo _CardRepo;
        private readonly IMapper _mapper;
        public CardService(ICardRepo CardRepo, IMapper mapper) {
            _CardRepo = CardRepo;
            _mapper = mapper;
        }
    }
}