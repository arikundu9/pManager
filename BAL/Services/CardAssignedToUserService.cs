using AutoMapper;
using pMan.BAL.Interface;
using pMan.DAL.Entities;
using pMan.DAL.Interfaces;
using pMan.Models;
namespace pMan.BAL
{
    public class CardAssignedToUserService : ICardAssignedToUserService
    {
        private readonly ICardAssignedToUserRepo _CardAssignedToUserRepo;
        private readonly IMapper _mapper;
        public CardAssignedToUserService(ICardAssignedToUserRepo CardAssignedToUserRepo, IMapper mapper) {
            _CardAssignedToUserRepo = CardAssignedToUserRepo;
            _mapper = mapper;
        }
    }
}