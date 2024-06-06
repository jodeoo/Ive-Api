using IveApi.Interfaces;
using IveApi.Models;

namespace IveApi.Repository
{
	public class ArtistRepository : IArtistRepository
	{
        private readonly DataContext _context;

        public ArtistRepository(DataContext context)
		{
			_context = context;
		}

        public IEnumerable<Artist> GetArtistsByEvent(int eventId)
        {
			var performances = _context.Performances.Where(p => p.EventId == eventId).ToList();
			var artists = _context.Artists.ToList();

			//Explain the inner join.
			var result = from p in performances
						 join a in artists
						 on p.ArtistId equals a.Id
						 select new Artist
						 {
							 Id = a.Id,
							 Name = a.Name,
							 Genre = a.Genre
						 };
			return result;
        }
    }
}

