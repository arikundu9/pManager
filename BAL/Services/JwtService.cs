using AutoMapper;
using pMan.BAL.Interface;
using pMan.DAL.Entities;
using pMan.DAL.Interfaces;
using pMan.Models;
namespace pMan.BAL
{
    public class JwtService : IJwtService
    {
        private readonly IJwtRepo _JwtRepo;
        private readonly IMapper _mapper;
        public JwtService(IJwtRepo JwtRepo, IMapper mapper) {
            _JwtRepo = JwtRepo;
            _mapper = mapper;
        }
    }
}
