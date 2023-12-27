using pMan.DAL.Entities;
using pMan.DAL.Interfaces;
namespace pMan.DAL
{
   public class CardAssignedToUserRepo : Repository<CardAssignedToUser, pManDBContext>, ICardAssignedToUserRepo
   {
       public CardAssignedToUserRepo(pManDBContext context) : base(context)
       {
       }
   }
}