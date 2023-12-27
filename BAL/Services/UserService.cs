using AutoMapper;
using pMan.BAL.Interface;
using pMan.DAL.Entities;
using pMan.DAL.Interfaces;
using pMan.Models;
namespace pMan.BAL
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _UserRepo;
        private readonly IMapper _mapper;
        public UserService(IUserRepo UserRepo, IMapper mapper) {
            _UserRepo = UserRepo;
            _mapper = mapper;
        }
    }
}