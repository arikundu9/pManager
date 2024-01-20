using pMan.DTOs;
using pMan.Models;
namespace pMan.BAL.Interface
{
    public interface IListService
    {
        List<ListModel> GetAll();
        Task<List<ListModel>> GetAllAsync();
        void Add(ListInsertDto list);
    }
}
