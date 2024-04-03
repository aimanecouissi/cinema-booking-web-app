using CineAimane.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CineAimane.ViewModels
{
	public class MovieViewModel
	{
		public Movie Movie { get; set; }
		public IEnumerable<SelectListItem> Showtimes { get; set; }
		public int SelectedShowtime { get; set; }
		public DateTime SelectedShowdate { get; set; }
	}
}
