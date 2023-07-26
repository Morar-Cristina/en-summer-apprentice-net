﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TMSystem.Api.Models.Dto;
using TMSystem.Api.Repositories;

namespace TMSystem.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public ActionResult<List<EventDto>> GetAll()
        {
            var events = _eventRepository.GetAll();

            var dtoEvents = events.Select(e => new EventDto()
            {
                EventId = e.EventId,
                EventDescription = e.EventDescription,
                EventName = e.EventName,
                EventType = e.EventType?.EventTypeName ?? string.Empty,
                Venue = e.Venue?.Location ?? string.Empty
            });


            return Ok(dtoEvents);
        }


        [HttpGet]
        public ActionResult<EventDto> GetById(long id)
        {
            var @event = _eventRepository.GetById(id);

            if (@event == null)
            {
                return NotFound();
            }

            var dtoEvent = new EventDto()
            {
                EventId = @event.EventId,
                EventDescription = @event.EventDescription,
                EventName = @event.EventName,
                EventType = @event.EventType?.EventTypeName ?? string.Empty,
                Venue = @event.Venue?.Location ?? string.Empty
            };

            return Ok(dtoEvent);
        }
    }
}