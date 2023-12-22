using pMan.DAL.Entities;
using pMan.DAL.Interfaces;
namespace pMan.DAL
{
   public class KeyRepo : Repository<Key, pManDBContext>, IKeyRepo
   {
       public KeyRepo(pManDBContext context) : base(context)
       {
       }
   }
}
