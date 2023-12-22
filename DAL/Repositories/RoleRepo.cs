using pMan.DAL.Entities;
using pMan.DAL.Interfaces;
namespace pMan.DAL
{
   public class RoleRepo : Repository<Role, pManDBContext>, IRoleRepo
   {
       public RoleRepo(pManDBContext context) : base(context)
       {
       }
   }
}
