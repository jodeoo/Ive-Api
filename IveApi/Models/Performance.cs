namespace IveApi.Models
{
	//Join table for the many-to-many relationship between artist and event.
	public class Performance
	{
		public int ArtistId { get; set; }
		public int EventId { get; set; }
		public Artist Artist { get; set; }
		public Event Event { get; set; }
    }
}

