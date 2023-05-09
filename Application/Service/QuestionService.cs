using Task10_11.DTOs;
using Microsoft.EntityFrameworkCore;
using Task10_11.Application.Interface;
using Task10_11.EFCore.DTOs;
using Task10_11.DTOs.Paging;

namespace Task10_11.Services
{
    public class QuestionService : IQuestionService
    {
        public readonly MyDbContext _context;
        private readonly IConfiguration _configuration;

        public QuestionService(MyDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<Question> Add(QuestionDTO Question)
        {
            var _newQuestions = new Question
            {
                Title = Question.Title,
                Content = Question.Content,
            };
            await _context.AddAsync(_newQuestions);
            await _context.SaveChangesAsync();
            return new Question
            {
                Title = Question.Title,
                Content = Question.Content,
                Id = _newQuestions.Id
            };
        }

        public async Task<List<Question>> GetAll()
        {
            var questions = _context.Question.Select(ques => new Question
            {
                Title = ques.Title,
                Content = ques.Content,
                Id = ques.Id
            });

            return await questions.ToListAsync();
        }

        public async Task<int> Delete(int Id)
        {
            var Question = await _context.Question.SingleOrDefaultAsync(a => a.Id == Id);
            if (Question != null)
            {
                _context.Remove(Question);
                return await _context.SaveChangesAsync();
            }
            throw new ArgumentException("object is null");
        }

        public async Task<Question> GetById(int Id)
        {
            var Question = await _context.Question.SingleOrDefaultAsync(a => a.Id == Id);
            if (Question != null)
            {
                return new Question
                {
                    Id = Question.Id,
                    Title = Question.Title,
                    Content = Question.Content
                };
            }
            return null;
        }

        public async Task<int> Update(QuestionDTOUpdateRequest Question)
        {
            var _ques = await _context.Question.SingleOrDefaultAsync(ques => ques.Id == Question.Id);
            if (_ques != null)
            {
                _ques.Title = Question.Title;
                _ques.Content = Question.Content;
                return await _context.SaveChangesAsync();
            }
            throw new ArgumentException("object is null");
        }

        public async Task<PagedResult<Question>> GetAllPaging(PagedRequest pageRequest)
        {
            var questions = _context.Question.Select(ques => new Question
            {
                Title = ques.Title,
                Content = ques.Content,
                Id = ques.Id
            });

            // paging

            var data = await questions.Skip((pageRequest.PageIndex - 1) * pageRequest.PageSize)
                .Take(pageRequest.PageSize).ToListAsync();

            var result = new PagedResult<Question>()
            {
                items = data
            };

            return result;
        }
    }
}