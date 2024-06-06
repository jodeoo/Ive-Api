using System;
using IveApi.Interfaces;
using IveApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IveApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class VenueController : Controller
	{
		private readonly IVenueRepository _venueRepository;

		public VenueController(IVenueRepository venueRepository)
		{
			_venueRepository = venueRepository;
		}

		[HttpGet("{id}")]
		public IActionResult GetVenueById(int id)
		{
			// Checks that an id has been given.
            if (id == 0)
            {
                ModelState.AddModelError("ErrorMessage", "Id should not be null.");
                return BadRequest(ModelState);
            }

            var venue = _venueRepository.GetVenue(id);

			// Returns a 404 error if no venbue was found.
			if (venue == null)
			{
                ModelState.AddModelError("ErrorMessage", "Venue not found.");
                return StatusCode(404, ModelState);
            }

			return Ok(venue);
		}

        [HttpGet("{name}")]
        public IActionResult GetVenueByName(string name)
        {
			// Checks that a name has been given.
            if (name == null || name == "")
            {
                ModelState.AddModelError("ErrorMessage", "Name should not be empty.");
                return BadRequest(ModelState);
            }

            var venue = _venueRepository.GetVenue(name);

			// Returns a 404 error if no venue was found.
            if (venue == null)
            {
                ModelState.AddModelError("ErrorMessage", "Venue not found.");
                return StatusCode(404, ModelState);
            }

            return Ok(venue);
        }

        [HttpPost]
		public IActionResult CreateVenue(Venue venue)
		{
			// Cannot add a null venue.
			if (venue == null)
			{
                return BadRequest(ModelState);
			}

			// Checks that the Venue model is valid. Checks to see if the Name field is not empty.
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			// Checks to see if the venue already exists before adding.
			if (_venueRepository.VenueExists(venue.Name))
			{
				ModelState.AddModelError("ErrorMessage", "Venue already exists");
				return StatusCode(403, ModelState);
			}

			// CreateVenue should return 1 if it was successfully added.
			if (_venueRepository.CreateVenue(venue) != 1)
			{
				ModelState.AddModelError("ErrorMessage", "Error 500");
				return StatusCode(500, ModelState);
			}

			return Ok("Successfully added");
		}
	}
}

