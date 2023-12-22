using AutoMapper;
using pMan.BAL.Interface;
using pMan.DAL.Entities;
using pMan.DAL.Interfaces;
using pMan.Models;
namespace pMan.BAL
{
    public class KeyService : IKeyService
    {
        private readonly IKeyRepo _KeyRepo;
        private readonly IMapper _mapper;
        public KeyService(IKeyRepo KeyRepo, IMapper mapper) {
            _KeyRepo = KeyRepo;
            _mapper = mapper;
        }
    }
}
