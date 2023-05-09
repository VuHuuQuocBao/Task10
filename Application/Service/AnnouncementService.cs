using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

using Task10_11.Application.Interface;
using Task10_11.DTOs;
using Task10_11.DTOs.Paging;
using Task10_11.EFCore.DTOs;

namespace Task10_11.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        public readonly MyDbContext _context;
        private readonly IConfiguration _configuration;

        public AnnouncementService(MyDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<Announcement> Add(AnnouncementDTO Ann)
        {
            var _newAnn = new Announcement
            {
                Date = Ann.Date,
                Desc = Ann.Desc,
                linkImage = Ann.linkImage,
                Text = Ann.Text,
                Title = Ann.Title
            };
            await _context.AddAsync(_newAnn);
            await _context.SaveChangesAsync();
            return new Announcement
            {
                Date = _newAnn.Date,
                Desc = _newAnn.Desc,
                linkImage = _newAnn.linkImage,
                Text = _newAnn.Text,
                Title = _newAnn.Title,
                Id = _newAnn.Id
            };
        }

        public async Task<List<Announcement>> GetAll()
        {
            var announcements = _context.Announcement.Select(ann => new Announcement
            {
                Id = ann.Id,
                Title = ann.Title,
                Date = ann.Date,
                Desc = ann.Desc,
                linkImage = ann.linkImage,
                Text = ann.Text,
            });

            return await announcements.ToListAsync();
        }

        public async Task<int> Delete(int Id)
        {
            var Ann = await _context.Announcement.SingleOrDefaultAsync(a => a.Id == Id);
            if (Ann != null)
            {
                _context.Remove(Ann);
                return await _context.SaveChangesAsync();
            }
            throw new ArgumentException("object is null");
        }

        public async Task<Announcement> GetById(int Id)
        {
            var Ann = await _context.Announcement.SingleOrDefaultAsync(a => a.Id == Id);
            if (Ann != null)
            {
                return new Announcement
                {
                    Id = Ann.Id,
                    Title = Ann.Title,
                    Date = Ann.Date,
                    Text = Ann.Text,
                    Desc = Ann.Desc,
                    linkImage = Ann.linkImage
                };
            }
            return null;
        }

        public async Task<int> Update(AnnouncementDTOUpdateRequest Ann)
        {
            var _ann = await _context.Announcement.SingleOrDefaultAsync(ann => ann.Id == Ann.Id);
            if (_ann != null)
            {
                _ann.Date = Ann.Date;
                _ann.Text = Ann.Text;
                _ann.Desc = Ann.Desc;
                _ann.linkImage = Ann.linkImage;
                _ann.Title = Ann.Title;
                return await _context.SaveChangesAsync();
            }
            throw new ArgumentException("object is null");
        }

        public async Task<PagedResult<Announcement>> GetAllPaging(PagedRequest pageRequest)
        {
            var announcements = _context.Announcement.Select(ann => new Announcement
            {
                Id = ann.Id,
                Title = ann.Title,
                Date = ann.Date,
                Desc = ann.Desc,
                linkImage = ann.linkImage,
                Text = ann.Text,
            });

            // paging

            var data = await announcements.Skip((pageRequest.PageIndex - 1) * pageRequest.PageSize)
                .Take(pageRequest.PageSize).ToListAsync();

            var result = new PagedResult<Announcement>()
            {
                items = data
            };

            return result;
        }
    }
}