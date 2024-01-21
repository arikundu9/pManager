using AutoMapper;
using pMan.BAL.Interface;
using pMan.DAL.Entities;
using pMan.DAL.Interfaces;
using pMan.DTOs;
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
        public void Add(CardInsertDto card)
        {
            Card cardEntry = new()
            {
                ParentListId = card.ListId,
                Body = card.Body,
                CreatedBy = 2
            };
            _CardRepo.Add(cardEntry);
            _CardRepo.SaveChangesManaged();
        }

        public List<CardModel> GetAll()
        {
            return _mapper.Map<List<CardModel>>(_CardRepo.GetAll().ToList());
        }
        public async Task<List<CardModel>> GetAllAsync()
        {
            return _mapper.Map<List<CardModel>>(await _CardRepo.GetAllAsync());
        }
    }
}
