using Task10_11.DTOs;
using Task10_11.DTOs.Paging;
using Task10_11.EFCore.DTOs;

namespace Task10_11.Application.Interface
{
    public interface IDocumentService
    {
        Task<List<Document>> GetAll();

        Task<Document> GetById(int id);

        Task<Document> Add(DocumentDTO DocumentDTO);

        Task<int> Update(DocumentDTOUpdateRequest DocumentDTO);

        Task<int> Delete(int id);

        Task<PagedResult<Document>> GetAllPaging(PagedRequest pageRequest);
    }
}