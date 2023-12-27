using pMan.DAL.Entities;
using pMan.DAL.Interfaces;
namespace pMan.DAL
{
   public class CardRepo : Repository<Card, pManDBContext>, ICardRepo
   {
       public CardRepo(pManDBContext context) : base(context)
       {
       }
   }
}