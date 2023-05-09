using Task10_11.DTOs;
using Microsoft.EntityFrameworkCore;
using Task10_11.Application.Interface;
using Task10_11.EFCore.DTOs;
using Task10_11.DTOs.Paging;

namespace Task10_11.Services
{
    public class EventService : IEventService
    {
        public readonly MyDbContext _context;
        private readonly IConfiguration _configuration;

        public EventService(MyDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<Event> Add(EventDTO e)
        {
            var _newEvent = new Event
            {
                Month = e.Month,
                Day = e.Day,
                Desc = e.Desc,
                Time = e.Time
            };
            await _context.AddAsync(_newEvent);
            await _context.SaveChangesAsync();
            return new Event
            {
                Month = _newEvent.Month,
                Day = _newEvent.Day,
                Desc = _newEvent.Desc,
                Time = _newEvent.Time,
                Id = _newEvent.Id
            };
        }

        public async Task<List<Event>> GetAll()
        {
            var Event = _context.Event.Select(e => new Event
            {
                Id = e.Id,
                Month = e.Month,
                Day = e.Day,
                Desc = e.Desc,
                Time = e.Time
            });

            return await Event.ToListAsync();
        }

        public async Task<int> Delete(int Id)
        {
            var evt = await _context.Event.SingleOrDefaultAsync(a => a.Id == Id);
            if (evt != null)
            {
                _context.Remove(evt);
                return await _context.SaveChangesAsync();
            }
            throw new ArgumentException("object is null");
        }

        public async Task<Event> GetById(int Id)
        {
            var evt = await _context.Event.SingleOrDefaultAsync(e => e.Id == Id);
            if (evt != null)
            {
                return new Event
                {
                    Id = evt.Id,
                    Month = evt.Month,
                    Day = evt.Day,
                    Desc = evt.Desc,
                    Time = evt.Time
                };
            }
            return null;
        }

        public async Task<int> Update(EventDTOUpdateRequest Evt)
        {
            var _evt = await _context.Event.SingleOrDefaultAsync(e => e.Id == Evt.Id);
            if (_evt != null)
            {
                _evt.Month = Evt.Month;
                _evt.Day = Evt.Day;
                _evt.Desc = Evt.Desc;
                _evt.Time = Evt.Time;
                return await _context.SaveChangesAsync();
            }
            throw new ArgumentException("object is null");
        }

        public async Task<PagedResult<Event>> GetAllPaging(PagedRequest pageRequest)
        {
            var events = _context.Event.Select(e => new Event
            {
                Id = e.Id,
                Month = e.Month,
                Day = e.Day,
                Desc = e.Desc,
                Time = e.Time
            });

            // paging

            var data = await events.Skip((pageRequest.PageIndex - 1) * pageRequest.PageSize)
                .Take(pageRequest.PageSize).ToListAsync();

            var result = new PagedResult<Event>()
            {
                items = data
            };

            return result;
        }
    }
}