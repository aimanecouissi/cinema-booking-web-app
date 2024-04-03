using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CineAimane.Models
{
	public enum Rating
	{
		[Display(Name = "G")]
		G,
		[Display(Name = "PG")]
		PG,
		[Display(Name = "PG-13")]
		PG13,
		[Display(Name = "R")]
		R,
		[Display(Name = "NC-17")]
		NC17
	}
	public class Movie
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		[DisplayName("Release Date")]
		[DataType(DataType.Date)]
		[Required]
		public DateTime ReleaseDate { get; set; }
		[Required]
		public string Genres { get; set; }
		[RegularExpression(@"\d+h\s[1-5]?[0-9]m", ErrorMessage = "The field Duration is invalid")]
		[Required]
		public string Duration { get; set; }
		[Required]
		public Rating Rating { get; set; }
		[Required]
		public string Director { get; set; }
		[Required]
		public string Cast { get; set; }
		[DisplayName("Poster URL")]
		[DataType(DataType.ImageUrl)]
		[Required]
		public string Poster { get; set; }
		[DisplayName("Backdrop URL")]
		[DataType(DataType.ImageUrl)]
		[Required]
		public string Backdrop { get; set; }
		[DisplayName("Trailer URL")]
		[DataType(DataType.Url)]
		[Required]
		public string Trailer { get; set; }
		[Required]
		public string Overview { get; set; }
		[DisplayName("Start Date")]
		[DataType(DataType.Date)]
		[Required]
		public DateTime StartDate { get; set; }
		[DisplayName("End Date")]
		[DataType(DataType.Date)]
		[Required]
		public DateTime EndDate { get; set; }
		[ValidateNever]
		public virtual ICollection<Showtime> Showtimes { get; set; }
	}
}