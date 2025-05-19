using Microsoft.EntityFrameworkCore;
using Presentation.Data;

namespace Presentation.Service;

public class EventService(DataContext context)
{
    private readonly DataContext _context = context;


    public async Task<EventEntity> CreateEvent(EventEntity eventEntity)
    {

        await _context.Events.AddAsync(eventEntity);
        await _context.SaveChangesAsync();
        return eventEntity;
    }
    public async Task<List<EventEntity>> GetAllEvents()
    {
        return await _context.Events.ToListAsync();
    }
}
