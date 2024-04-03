using System.ComponentModel.DataAnnotations;

namespace CineAimane.Models
{
	public class Showtime
	{
		[Key]
		public int Id { get; set; }
		public string Time { get; set; }
		public bool IsDeleted { get; set; } = false;
		public int MovieId { get; set; }
		public virtual Movie Movie { get; set; }
		public virtual ICollection<Showdate> Showdates { get; set; }
	}
}
