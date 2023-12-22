using pMan.DAL.Entities;
using pMan.DAL.Interfaces;
namespace pMan.DAL
{
   public class JwtRepo : Repository<Jwt, pManDBContext>, IJwtRepo
   {
       public JwtRepo(pManDBContext context) : base(context)
       {
       }
   }
}
