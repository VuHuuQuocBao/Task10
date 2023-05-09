using Task10_11.EFCore.DTOs;
using Task10_11.DTOs;
using Task10_11.DTOs.Paging;

namespace Task10_11.Application.Interface
{
    public interface INewService
    {
        Task<List<New>> GetAll();

        Task<New> GetById(int id);

        Task<New> Add(NewDTO NewDTO);

        Task<int> Update(NewDTOUpdateRequest NewDTO);

        Task<int> Delete(int id);

        Task<PagedResult<New>> GetAllPaging(PagedRequest pageRequest);
    }
}