using pMan.DAL.Entities;
using pMan.DAL.Interfaces;
namespace pMan.DAL
{
   public class AppRepo : Repository<App, pManDBContext>, IAppRepo
   {
       public AppRepo(pManDBContext context) : base(context)
       {
       }
   }
}
