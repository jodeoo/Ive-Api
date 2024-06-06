using IveApi.Interfaces;
using IveApi.Models;

namespace IveApi.Repository
{
	public class VenueRepository : IVenueRepository
	{
		private readonly DataContext _context;

		public VenueRepository(DataContext context)
		{
			_context = context;
		}

		public Venue GetVenue(int id)
		{
			return _context.Venues.Where(v => v.Id == id).FirstOrDefault();
		}

        public Venue GetVenue(string name)
        {
            return _context.Venues.Where(v => v.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }

		//Used to check that a venue is not already in the database before creating a new venue.
        public bool VenueExists(string name)
        {
			return _context.Venues.Where(v => v.Name.ToLower() == name.ToLower()).Any();
        }

        public int CreateVenue(Venue venue)
		{
			_context.Add(venue);
			return _context.SaveChanges();
		}
	}
}

