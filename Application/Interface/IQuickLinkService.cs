using Task10_11.EFCore.DTOs;
using Task10_11.DTOs;
using Task10_11.DTOs.Paging;

namespace Task10_11.Application.Interface
{
    public interface IQuickLinkService
    {
        Task<List<QuickLink>> GetAll();

        Task<QuickLink> GetById(int id);

        Task<QuickLink> Add(QuickLinkDTO QuickLinkDTO);

        Task<int> Update(QuickLinkDTOUpdateRequest QuickLinkDTO);

        Task<int> Delete(int id);

        Task<PagedResult<QuickLink>> GetAllPaging(PagedRequest pageRequest);
    }
}