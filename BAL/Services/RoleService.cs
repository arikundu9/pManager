using AutoMapper;
using pMan.BAL.Interface;
using pMan.DAL.Entities;
using pMan.DAL.Interfaces;
using pMan.Models;
namespace pMan.BAL
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepo _RoleRepo;
        private readonly IMapper _mapper;
        public RoleService(IRoleRepo RoleRepo, IMapper mapper) {
            _RoleRepo = RoleRepo;
            _mapper = mapper;
        }
    }
}
