using AutoMapper;
using pMan.BAL.Interface;
using pMan.DAL.Entities;
using pMan.DAL.Interfaces;
using pMan.Models;
namespace pMan.BAL
{
    public class AppService : IAppService
    {
        private readonly IAppRepo _AppRepo;
        private readonly IMapper _mapper;
        public AppService(IAppRepo AppRepo, IMapper mapper) {
            _AppRepo = AppRepo;
            _mapper = mapper;
        }
    }
}
