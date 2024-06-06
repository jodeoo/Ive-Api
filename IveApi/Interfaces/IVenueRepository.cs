using IveApi.Models;

namespace IveApi.Interfaces
{
	public interface IVenueRepository
	{
		Venue GetVenue(int id);
        Venue GetVenue(string name);
		bool VenueExists(string name);
        int CreateVenue(Venue venue);
	}
}

