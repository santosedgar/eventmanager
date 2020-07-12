using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventManager.Core.Interfaces;
using EventManager.Database;
using EventManager.Models;
using EventManager.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendController : ControllerBase
    {
        private readonly EventManagerContext _context;
        private readonly IAttendRepository _attendRepository;
        private readonly IMapper _mapper;

        public AttendController(EventManagerContext context, IAttendRepository attendRepository, IMapper mapper)
        {
            this._context = context;
            this._attendRepository = attendRepository;
            this._mapper = mapper;
        }



        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AttendRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var attendMapped = _mapper.Map<AttendRequest, Attend>(request);

            await _attendRepository.AddAsync(attendMapped);

            await _attendRepository.SaveChangesAsync();

            return CreatedAtAction("Attend", "Attend", new { id = attendMapped.ID });
        }
    }
}
