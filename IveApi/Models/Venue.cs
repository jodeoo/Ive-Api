using System;
using System.ComponentModel.DataAnnotations;

namespace IveApi.Models
{
	public class Venue
	{
		public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Name { get; set; }
		public double MinLat { get; set; }
		public double MinLong { get; set; }
		public double MaxLat { get; set; }
		public double MaxLong { get; set; }
		public int Capacity { get; set; }
		public ICollection<Event>? Events { get; set; }
    }
}

