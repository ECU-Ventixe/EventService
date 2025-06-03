using Microsoft.EntityFrameworkCore;
using Presentation.Data;
using Presentation.Models;
using System.Net.Http.Json;

namespace Presentation.Service;

public class EventService(DataContext context, HttpClient httpClient)
{
    private readonly DataContext _context = context;
    private readonly HttpClient _httpClient = httpClient;



    public async Task<EventEntity> CreateEvent(EventEntity eventEntity)
    {

        if (eventEntity == null)
        {
            throw new ArgumentNullException(nameof(eventEntity), "Event entity cannot be null");
        }

        await _context.Events.AddAsync(eventEntity);
        await _context.SaveChangesAsync();
        return eventEntity;
    }
    public async Task<List<EventEntity>> GetAllEvents()
    {


        
        return await _context.Events.ToListAsync();
    }

    public async Task<int> GetTicketsLeft(string id)
    {
        var eventEntity = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
        if (eventEntity == null)
        {
            throw new KeyNotFoundException($"Event with ID {id} not found.");
        }
        var response = await _httpClient.GetAsync($"https://ventixe-ticket-ecu-bpbqcchqddg6ath9.swedencentral-01.azurewebsites.net/api/ticket/geteventtickets/{id}");
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to retrieve tickets for event with ID {id}");
        }
        var tickets = await response.Content.ReadFromJsonAsync<List<EventEntity>>();
        int bookedTickets = tickets?.Count ?? 0;

        return eventEntity.TicketAmount - bookedTickets;

    }
    public async Task<EventEntity?> GetEventById(string id)
    {
        return await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
    }
}
