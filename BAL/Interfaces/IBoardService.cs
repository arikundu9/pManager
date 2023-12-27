using pMan.Models;
namespace pMan.BAL.Interface
{
    public interface IBoardService
    {
        List<BoardModel> GetAll();
        Task<List<BoardModel>> GetAllAsync();
    }
}
