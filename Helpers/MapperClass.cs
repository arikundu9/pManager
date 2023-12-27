using AutoMapper;
using pMan.DAL.Entities;

// using pMan.DAL.Entities;
using pMan.DAL.Enums;
using pMan.Models;

namespace pMan.Helpers
{
    public class MapperClass : Profile
    {
        public MapperClass()
        {
            CreateMap<BoardModel, Board>();
            CreateMap<Board, BoardModel>();
        }
    }
}
