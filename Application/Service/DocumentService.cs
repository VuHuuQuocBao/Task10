using Task10_11.DTOs;
using Microsoft.EntityFrameworkCore;
using Task10_11.EFCore.DTOs;
using Task10_11.Application.Interface;
using Task10_11.DTOs.Paging;

namespace Task10_11.Services
{
    public class DocumentService : IDocumentService
    {
        public readonly MyDbContext _context;

        public DocumentService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Document> Add(DocumentDTO documentDTO)
        {
            var data = new Document
            {
                Title = documentDTO.Title,
            };

            await _context.AddAsync(data);
            await _context.SaveChangesAsync();

            return new Document
            {
                Id = data.Id,
                Title = data.Title,
            };
        }

        public async Task<int> Delete(int id)
        {
            var data = await _context.Document.SingleOrDefaultAsync(d => d.Id == id);

            if (data != null)
            {
                _context.Remove(data);
                return await _context.SaveChangesAsync();
            }
            throw new ArgumentException("object is null");
        }

        public async Task<List<Document>> GetAll()
        {
            var datas = _context.Document.Select(d => new Document
            {
                Id = d.Id,
                Title = d.Title,
            });

            return await datas.ToListAsync();
        }

        public async Task<PagedResult<Document>> GetAllPaging(PagedRequest pageRequest)
        {
            var documents = _context.Document.Select(d => new Document
            {
                Id = d.Id,
                Title = d.Title,
            });

            // paging

            var data = await documents.Skip((pageRequest.PageIndex - 1) * pageRequest.PageSize)
                .Take(pageRequest.PageSize).ToListAsync();

            var result = new PagedResult<Document>()
            {
                items = data
            };

            return result;
        }

        public async Task<Document> GetById(int id)
        {
            var data = await _context.Document.SingleOrDefaultAsync(d => d.Id == id);

            if (data != null)
            {
                return new Document
                {
                    Id = data.Id,
                    Title = data.Title,
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<int> Update(DocumentDTOUpdateRequest document)
        {
            var data = await _context.Document.SingleOrDefaultAsync(d => d.Id == document.Id);

            if (data != null)
            {
                data.Title = document.Title;
                return await _context.SaveChangesAsync();
            }
            throw new ArgumentException("object is null");
        }
    }
}