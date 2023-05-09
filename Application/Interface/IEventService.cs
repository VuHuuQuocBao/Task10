using Task10_11.DTOs;
using Task10_11.DTOs.Paging;
using Task10_11.EFCore.DTOs;

namespace Task10_11.Application.Interface
{
    public interface IEventService
    {
        Task<List<Event>> GetAll();

        Task<Event> GetById(int id);

        Task<Event> Add(EventDTO EventDTO);

        Task<int> Update(EventDTOUpdateRequest EventDTO);

        Task<int> Delete(int id);

        Task<PagedResult<Event>> GetAllPaging(PagedRequest pageRequest);
    }
}