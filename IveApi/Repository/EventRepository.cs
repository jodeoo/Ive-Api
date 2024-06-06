using IveApi.Interfaces;

namespace IveApi.Repository
{
	public class EventRepository : IEventRepository
	{
        private readonly DataContext _context;

        public EventRepository(DataContext context)
		{
			_context = context;
		}

        // Used by GetArtistsByEvent to check that the event exists before retrieving the artists.
        public bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}

