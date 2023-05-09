using Task10_11.DTOs;
using Task10_11.DTOs.Paging;
using Task10_11.EFCore.DTOs;

namespace Task10_11.Application.Interface
{
    public interface IDocumentItemService
    {
        Task<List<DocumentItem>> GetAll();

        Task<DocumentItem> GetById(int id);

        Task<DocumentItem> Add(DocumentItemDTO DocumentItemDTO);

        Task<int> Update(DocumentItemDTOUpdateRequest DocumentItemDTO);

        Task<int> Delete(int id);

        Task<PagedResult<DocumentItem>> GetAllPaging(PagedRequest pageRequest);
    }
}