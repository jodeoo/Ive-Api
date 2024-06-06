using System;
namespace IveApi.Models
{
	public class Event
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateOnly Date { get; set; }
		public int VenueId { get; set; }
		public Venue Venue { get; set; }
		public ICollection<Performance>? Performances { get; set; }
    }
}