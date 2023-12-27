using pMan.DAL.Entities;
using pMan.DAL.Interfaces;
namespace pMan.DAL
{
   public class ListRepo : Repository<List, pManDBContext>, IListRepo
   {
       public ListRepo(pManDBContext context) : base(context)
       {
       }
   }
}