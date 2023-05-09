using Task10_11.DTOs;
using Microsoft.EntityFrameworkCore;
using Task10_11.Application.Interface;
using Task10_11.EFCore.DTOs;
using Task10_11.DTOs.Paging;

namespace Task10_11.Services
{
    public class NewService : INewService
    {
        public readonly MyDbContext _context;
        private readonly IConfiguration _configuration;

        public NewService(MyDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<New> Add(NewDTO NewDTO)
        {
            var _newNews = new New
            {
                linkImage = NewDTO.linkImage,
                Desc = NewDTO.Desc,
                Date = NewDTO.Date,
                Title = NewDTO.Title
            };
            await _context.AddAsync(_newNews);
            await _context.SaveChangesAsync();
            return new New
            {
                Date = _newNews.Date,
                Desc = _newNews.Desc,
                linkImage = _newNews.linkImage,
                Title = _newNews.Title,
                Id = _newNews.Id
            };
        }

        public async Task<List<New>> GetAll()
        {
            var news = _context.New.Select(news => new New
            {
                Id = news.Id,
                Title = news.Title,
                Date = news.Date,
                Desc = news.Desc,
                linkImage = news.linkImage,
            });

            return await news.ToListAsync();
        }

        public async Task<int> Delete(int Id)
        {
            var News = await _context.New.SingleOrDefaultAsync(a => a.Id == Id);
            if (News != null)
            {
                _context.Remove(News);
                return await _context.SaveChangesAsync();
            }
            throw new ArgumentException("object is null");
        }

        public async Task<New> GetById(int Id)
        {
            var News = await _context.New.SingleOrDefaultAsync(a => a.Id == Id);
            if (News != null)
            {
                return new New
                {
                    Id = News.Id,
                    Title = News.Title,
                    Date = News.Date,
                    Desc = News.Desc,
                    linkImage = News.linkImage
                };
            }
            return null;
        }

        public async Task<int> Update(NewDTOUpdateRequest New)
        {
            var _news = await _context.New.SingleOrDefaultAsync(news => news.Id == New.Id);
            if (_news != null)
            {
                _news.Date = New.Date;
                _news.Desc = New.Desc;
                _news.linkImage = New.linkImage;
                _news.Title = New.Title;
                return await _context.SaveChangesAsync();
            }
            throw new ArgumentException("object is null");
        }

        public async Task<PagedResult<New>> GetAllPaging(PagedRequest pageRequest)
        {
            var news = _context.New.Select(news => new New
            {
                Id = news.Id,
                Title = news.Title,
                Date = news.Date,
                Desc = news.Desc,
                linkImage = news.linkImage,
            });

            // paging

            var data = await news.Skip((pageRequest.PageIndex - 1) * pageRequest.PageSize)
                .Take(pageRequest.PageSize).ToListAsync();

            var result = new PagedResult<New>()
            {
                items = data
            };

            return result;
        }
    }
}