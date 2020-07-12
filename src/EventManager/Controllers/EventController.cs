using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventManager.Core.Interfaces;
using EventManager.Models;
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

        //TODO
        //[Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Event request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            await _eventRepository.AddAsync(request);

            await _eventRepository.SaveChangesAsync();

            return CreatedAtAction("Register", "Event", new { id = request.ID }, request);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var events = await this._eventRepository.ListAsync();

            var result = _mapper.Map<IEnumerable<Event>, IEnumerable<EventResponse>>(events);

            return Ok(result);
        }

    }
}
