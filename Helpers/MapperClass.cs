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
            CreateMap<BoardModel, Board>(MemberList.None).PreserveReferences();
            CreateMap<Board, BoardModel>(MemberList.None).PreserveReferences();
            CreateMap<BoardDto, Board>(MemberList.None).PreserveReferences();
            CreateMap<Board, BoardDto>(MemberList.None).PreserveReferences();
            CreateMap<ListInsertDto, pMan.DAL.Entities.List>();
            CreateMap<pMan.DAL.Entities.List, ListInsertDto>();
            CreateMap<ListModel, pMan.DAL.Entities.List>();
            CreateMap<pMan.DAL.Entities.List, ListModel>();
        }
    }
}
