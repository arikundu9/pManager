using pMan.DAL.Entities;
using pMan.DAL.Interfaces;
namespace pMan.DAL
{
   public class BoardRepo : Repository<Board, pManDBContext>, IBoardRepo
   {
       public BoardRepo(pManDBContext context) : base(context)
       {
       }
   }
}