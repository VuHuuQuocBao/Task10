using Task10_11.DTOs;
using Microsoft.EntityFrameworkCore;
using Task10_11.EFCore.DTOs;
using Task10_11.Application.Interface;
using Task10_11.DTOs.Paging;

namespace Task10_11.Services
{
    public class DocumentItemService : IDocumentItemService
    {
        public readonly MyDbContext _context;
        private readonly IConfiguration _configuration;

        public DocumentItemService(MyDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<DocumentItem> Add(DocumentItemDTO documentItemDTO)
        {
            var data = new DocumentItem
            {
                Title = documentItemDTO.Title,
                Type = documentItemDTO.Type,
                DocumentId = documentItemDTO.DocumentId,
            };

            await _context.AddAsync(data);
            await _context.SaveChangesAsync();

            return new DocumentItem
            {
                Id = data.Id,
                Title = data.Title,
                Type = data.Type,
                DocumentId = data.DocumentId,
            };
        }

        public async Task<int> Delete(int id)
        {
            var data = await _context.DocumentItem.SingleOrDefaultAsync(dt => dt.Id == id);

            if (data != null)
            {
                _context.Remove(data);
                return await _context.SaveChangesAsync();
            }
            throw new ArgumentException("object is null");
        }

        public async Task<List<DocumentItem>> GetAll()
        {
            var datas = _context.DocumentItem.Select(dt => new DocumentItem
            {
                Id = dt.Id,
                Title = dt.Title,
                Type = dt.Type,
                DocumentId = dt.DocumentId,
            });

            return await datas.ToListAsync();
        }

        public async Task<PagedResult<DocumentItem>> GetAllPaging(PagedRequest pageRequest)
        {
            var documentItems = _context.DocumentItem.Select(dt => new DocumentItem
            {
                Id = dt.Id,
                Title = dt.Title,
                Type = dt.Type,
                DocumentId = dt.DocumentId,
            });

            // paging

            var data = await documentItems.Skip((pageRequest.PageIndex - 1) * pageRequest.PageSize)
                .Take(pageRequest.PageSize).ToListAsync();

            var result = new PagedResult<DocumentItem>()
            {
                items = data
            };

            return result;
        }

        public async Task<DocumentItem> GetById(int id)
        {
            var data = await _context.DocumentItem.SingleOrDefaultAsync(dt => dt.Id == id);

            if (data != null)
            {
                return new DocumentItem
                {
                    Id = data.Id,
                    Title = data.Title,
                    Type = data.Type,
                    DocumentId = data.DocumentId,
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<int> Update(DocumentItemDTOUpdateRequest documentItem)
        {
            var data = await _context.DocumentItem.SingleOrDefaultAsync(dt => dt.Id == documentItem.Id);

            if (data != null)
            {
                data.Title = documentItem.Title;
                data.Type = documentItem.Type;
                data.DocumentId = documentItem.DocumentId;
                return await _context.SaveChangesAsync();
            }
            throw new ArgumentException("object is null");
        }
    }
}