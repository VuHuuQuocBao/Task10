using Task10_11.DTOs;
using Task10_11.DTOs.Paging;
using Task10_11.EFCore.DTOs;

namespace Task10_11.Application.Interface
{
    public interface IAnnouncementService
    {
        Task<List<Announcement>> GetAll();

        Task<Announcement> GetById(int id);

        Task<Announcement> Add(AnnouncementDTO AnnouncementDTO);

        Task<int> Update(AnnouncementDTOUpdateRequest AnnouncementDTO);

        Task<int> Delete(int id);

        Task<PagedResult<Announcement>> GetAllPaging(PagedRequest pageRequest);
    }
}