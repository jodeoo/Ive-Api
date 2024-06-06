namespace IveApi.Models
{
	public class Artist
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Genre { get; set; }
		public ICollection<Performance>? Performances { get; set; }
    }
}

