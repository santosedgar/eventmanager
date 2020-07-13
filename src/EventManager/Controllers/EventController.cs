using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventManager.Core.Interfaces;
using EventManager.Helpers.AuthProvider;
using EventManager.Models;
using EventManager.Request;
using EventManager.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventController(IEventRepository eventRepository, IMapper mapper)
        {
            this._eventRepository = eventRepository;
            this._mapper = mapper;
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            CurrentUser user = CurrentUser.GetCurrentUser(User);

            var eventModel = _mapper.Map<EventRequest, Event>(request);
            eventModel.UserId = user.UserId;

            await _eventRepository.AddAsync(eventModel);

            await _eventRepository.SaveChangesAsync();

            return CreatedAtAction("Register", "Event", new { id = eventModel.ID });
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var events = await this._eventRepository.ListAsync();

            var result = _mapper.Map<IEnumerable<Event>, IEnumerable<EventResponse>>(events);

            return Ok(result);
        }

        [HttpGet("{id=guid}")]
        [Route("attendees")]
        public async Task<IActionResult> GetAttendees(Guid Id)
        {
            var events = await this._eventRepository.GetAttendeesAsync(Id);

            var result = _mapper.Map<Event, EventResponse>(events);

            return Ok(result);
        }

    }
}
