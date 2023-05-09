using Task10_11.DTOs;
using Microsoft.EntityFrameworkCore;
using Task10_11.Application.Interface;
using Task10_11.EFCore.DTOs;
using Task10_11.DTOs.Paging;

namespace Task10_11.Services
{
    public class QuickLinkService : IQuickLinkService
    {
        public readonly MyDbContext _context;

        public QuickLinkService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<QuickLink> Add(QuickLinkDTO QL)
        {
            var _newQL = new QuickLink
            {
                Image = QL.Image,
                Title = QL.Title,
            };
            await _context.AddAsync(_newQL);
            await _context.SaveChangesAsync();
            return new QuickLink
            {
                Id = _newQL.Id,
                Image = _newQL.Image,
                Title = _newQL.Title,
            };
        }

        public async Task<List<QuickLink>> GetAll()
        {
            var quicklinks = _context.QuickLink.Select(ql => new QuickLink
            {
                Title = ql.Title,
                Image = ql.Image,
                Id = ql.Id
            });

            return await quicklinks.ToListAsync();
        }

        public async Task<int> Delete(int Id)
        {
            var Quicklinks = await _context.QuickLink.SingleOrDefaultAsync(a => a.Id == Id);
            if (Quicklinks != null)
            {
                _context.Remove(Quicklinks);
                return await _context.SaveChangesAsync();
            }
            throw new ArgumentException("object is null");
        }

        public async Task<QuickLink> GetById(int Id)
        {
            var QuickLinks = await _context.QuickLink.SingleOrDefaultAsync(a => a.Id == Id);
            if (QuickLinks != null)
            {
                return new QuickLink
                {
                    Id = QuickLinks.Id,
                    Title = QuickLinks.Title,
                    Image = QuickLinks.Image
                };
            }
            return null;
        }

        public async Task<int> Update(QuickLinkDTOUpdateRequest QuickLink)
        {
            var _quickLinks = await _context.QuickLink.SingleOrDefaultAsync(ql => ql.Id == QuickLink.Id);
            if (_quickLinks != null)
            {
                _quickLinks.Title = QuickLink.Title;
                _quickLinks.Image = QuickLink.Image;
                return await _context.SaveChangesAsync();
            }
            throw new ArgumentException("object is null");
        }

        public async Task<PagedResult<QuickLink>> GetAllPaging(PagedRequest pageRequest)
        {
            var quicklinks = _context.QuickLink.Select(ql => new QuickLink
            {
                Title = ql.Title,
                Image = ql.Image,
                Id = ql.Id
            });

            // paging

            var data = await quicklinks.Skip((pageRequest.PageIndex - 1) * pageRequest.PageSize)
                .Take(pageRequest.PageSize).ToListAsync();

            var result = new PagedResult<QuickLink>()
            {
                items = data
            };

            return result;
        }
    }
}