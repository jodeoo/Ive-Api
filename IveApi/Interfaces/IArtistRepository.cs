using IveApi.Models;

namespace IveApi.Interfaces
{
	public interface IArtistRepository
	{
		IEnumerable<Artist> GetArtistsByEvent(int eventId);
	}
}

