using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Data;
using Presentation.Models;
using Presentation.Service;
using System.ComponentModel;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController(EventService eventService) : ControllerBase
    {
        private readonly EventService _eventService = eventService;

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] EventDto eventDto)
        {
            if (eventDto == null)
            {
                return BadRequest("Event data is null");
            }
            var entity = new EventEntity
            {
                EventName = eventDto.EventName,
                EventDescription = eventDto.EventDescription,
                EventImage = eventDto.EventImage,
                Location = eventDto.Location,
                City = eventDto.City,
                State = eventDto.State,
                EventStartDate = eventDto.EventStartDate,
                EventEndDate = eventDto.EventEndDate,
                TicketStartDate = eventDto.TicketStartDate,
                TicketAmount = eventDto.TicketAmount,
                Price = eventDto.Price
            };



            var createdEvent = await _eventService.CreateEvent(entity);

            return Ok(createdEvent);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _eventService.GetAllEvents();
            return Ok(events);
        }
        [HttpGet("getevent/{id}")]
        public async Task<IActionResult> GetEventById(string id)
        {
            var eventEntity = await _eventService.GetEventById(id);
            if (eventEntity == null)
            {
                return NotFound($"Event with ID {id} not found.");
            }
            return Ok(eventEntity);
        }
    }
}
