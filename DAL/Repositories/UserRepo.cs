using pMan.DAL.Entities;
using pMan.DAL.Interfaces;
namespace pMan.DAL
{
   public class UserRepo : Repository<User, pManDBContext>, IUserRepo
   {
       public UserRepo(pManDBContext context) : base(context)
       {
       }
   }
}