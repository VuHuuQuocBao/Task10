using Task10_11.EFCore.DTOs;
using Task10_11.DTOs;
using Task10_11.DTOs.Paging;

namespace Task10_11.Application.Interface
{
    public interface IQuestionService
    {
        Task<List<Question>> GetAll();

        Task<Question> GetById(int id);

        Task<Question> Add(QuestionDTO QuestionDTO);

        Task<int> Update(QuestionDTOUpdateRequest QuestionDTO);

        Task<int> Delete(int id);

        Task<PagedResult<Question>> GetAllPaging(PagedRequest pageRequest);
    }
}