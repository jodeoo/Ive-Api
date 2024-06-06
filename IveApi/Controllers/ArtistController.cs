using System;
using IveApi.Interfaces;
using IveApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace IveApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ArtistController : Controller
	{
		private readonly IArtistRepository _artistRepository;
        private readonly IEventRepository _eventRepository;

		public ArtistController(IArtistRepository artistRepository, IEventRepository eventRepository)
		{
			_artistRepository = artistRepository;
            _eventRepository = eventRepository;
		}

        [HttpGet("{eventId}")]
        public IActionResult GetArtistsByEvent(int eventId)
        {
            // Checks that an event id has been given.
            if (eventId == 0)
            {
                ModelState.AddModelError("ErrorMessage", "EventId should not be null.");
                return BadRequest(ModelState);
            }

            // Checks to see if the event exists. Returns a 404 error if not.
            if (!_eventRepository.EventExists(eventId))
            {
                ModelState.AddModelError("ErrorMessage", "Event not found.");
                return StatusCode(404, ModelState);
            }

            var artists = _artistRepository.GetArtistsByEvent(eventId);
            return Ok(artists);
        }
    }
}

