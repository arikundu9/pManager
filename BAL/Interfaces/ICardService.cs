using pMan.DTOs;
using pMan.Models;
namespace pMan.BAL.Interface
{
    public interface ICardService
    {
        List<CardModel> GetAll();
        Task<List<CardModel>> GetAllAsync();
        void Add(CardInsertDto card);
    }
}
