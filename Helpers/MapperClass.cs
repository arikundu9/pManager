using AutoMapper;
using pMan.DAL.Entities;

// using pMan.DAL.Entities;
using pMan.DAL.Enums;
using pMan.DTOs;
using pMan.Models;

namespace pMan.Helpers
{
    public class MapperClass : Profile
    {
        public MapperClass()
        {
            CreateMap<BoardModel, Board>();
            CreateMap<Board, BoardModel>();
            CreateMap<BoardDto, Board>();
            CreateMap<Board, BoardDto>();
        }
    }
}
