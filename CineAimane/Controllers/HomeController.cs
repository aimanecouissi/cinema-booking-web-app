using BarcodeLib;
using CineAimane.Data;
using CineAimane.Models;
using CineAimane.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stripe.Checkout;
using System.Drawing;

namespace CineAimane.Controllers
{
	public class HomeController : Controller
	{
		private readonly CineAimaneDbContext _context;
		public HomeController(CineAimaneDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var nowPlaying = _context.Movies.Where(m => m.StartDate <= DateTime.UtcNow && m.EndDate > DateTime.UtcNow).OrderByDescending(m => m.Id).ToList();
			var comingSoon = _context.Movies.Where(m => m.StartDate > DateTime.UtcNow).ToList();
			ViewBag.NowPlaying = nowPlaying;
			ViewBag.ComingSoon = comingSoon;
			return View();
		}
		public IActionResult Movies(string search)
		{
			if (string.IsNullOrEmpty(search))
			{
				return NotFound();
			}
			var movies = _context.Movies.Where(m => m.Title.Contains(search) && m.EndDate >= DateTime.Now).OrderByDescending(m => m.Id).ToList();
			ViewBag.Search = search;
			return View(movies);
		}
		public IActionResult Movie(int? id)
		{
			if (id == null || _context.Movies == null)
			{
				return NotFound();
			}
			var movie = _context.Movies.Include(m => m.Showtimes).FirstOrDefault(m => m.Id == id);
			if (movie == null || movie.EndDate < DateTime.Now)
			{
				return NotFound();
			}
			var showtimes = movie.Showtimes.Where(s => s.IsDeleted == false).Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Time.ToString() });
			var movieViewModel = new MovieViewModel { Movie = movie, Showtimes = showtimes, SelectedShowdate = DateTime.Now, SelectedShowtime = 0 };
			return View(movieViewModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Checkout(MovieViewModel movieViewModel)
		{
			var selectedShowdate = movieViewModel.SelectedShowdate;
			var selectedShowtime = movieViewModel.SelectedShowtime;
			var selectedMovie = _context.Showtimes.Find(selectedShowtime)?.MovieId;
			var inDateTime = _context.Showdates.Where(s => s.Date == selectedShowdate && s.ShowtimeId == selectedShowtime);
			if (inDateTime.Any())
			{
				if (inDateTime.Select(a => a.Reserved).FirstOrDefault() == 100)
				{
					TempData["Info"] = "The screening time you chose is full.";
					return RedirectToAction(nameof(Movie), new { id = selectedMovie });
				}
			}
			ViewBag.MTitle = _context.Movies.Find(selectedMovie)?.Title.ToString();
			ViewBag.MPoster = _context.Movies.Find(selectedMovie)?.Poster.ToString();
			ViewBag.Showtime = _context.Showtimes.Find(selectedShowtime)?.Time.ToString();
			ViewBag.Showdate = selectedShowdate.ToString("MM/dd/yyyy");
			HttpContext.Session.SetInt32("ShowtimeId", selectedShowtime);
			HttpContext.Session.SetString("Showdate", selectedShowdate.ToString());
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CheckoutPost(CheckoutViewModel checkoutViewModel)
		{
			if (ModelState.IsValid)
			{
				HttpContext.Session.SetString("FirstName", checkoutViewModel.FirstName);
				HttpContext.Session.SetString("LastName", checkoutViewModel.LastName);
				//HttpContext.Session.SetString("Email", checkoutViewModel.Email);
				var options = new SessionCreateOptions
				{
					LineItems = new List<SessionLineItemOptions>
					{
						new SessionLineItemOptions
						{
							PriceData = new SessionLineItemPriceDataOptions
							{
								UnitAmount = 500,
								Currency = "usd",
								ProductData = new SessionLineItemPriceDataProductDataOptions
								{
									Name = _context.Movies.Find(_context.Showtimes.Find(HttpContext.Session.GetInt32("ShowtimeId"))?.MovieId)?.Title,
								},
							},
							Quantity = 1,
						},
					},
					Mode = "payment",
					SuccessUrl = "https://localhost:44315/Home/Ticket",
					CancelUrl = "https://localhost:44315/Home/Movie/" + _context.Showtimes.Find(HttpContext.Session.GetInt32("ShowtimeId"))?.MovieId,
				};
				var service = new SessionService();
				Session session = service.Create(options);
				HttpContext.Session.SetString("SessionId", session.Id);
				Response.Headers.Add("Location", session.Url);
				return new StatusCodeResult(303);
			}
			return View(checkoutViewModel);
		}
		public IActionResult Ticket()
		{
			if (HttpContext.Session.GetString("SessionId") != null)
			{
				var service = new SessionService();
				Session session = service.Get(HttpContext.Session.GetString("SessionId"));
				if (session.PaymentStatus.ToLower() == "paid")
				{
					var showdate = _context.Showdates.Where(s => s.Date == DateTime.Parse(HttpContext.Session.GetString("Showdate")) && s.ShowtimeId == HttpContext.Session.GetInt32("ShowtimeId")).FirstOrDefault();
					if (showdate != null)
					{
						showdate.Reserved += 1;
						_context.Showdates.Update(showdate);
					}
					else
					{
						showdate = new()
						{
							Date = DateTime.Parse(HttpContext.Session.GetString("Showdate") ?? DateTime.Now.ToString()),
							Reserved = 1,
							ShowtimeId = HttpContext.Session.GetInt32("ShowtimeId") ?? 0,
						};
						_context.Showdates.Add(showdate);
					}
					Reservation reservation = new()
					{
						FirstName = HttpContext.Session.GetString("FirstName") ?? string.Empty,
						LastName = HttpContext.Session.GetString("LastName") ?? string.Empty,
						Showdate = showdate,
					};
					_context.Reservations.Add(reservation);
					_context.SaveChanges();
					TicketViewModel ticketViewModel = new()
					{
						TicketNumber = reservation.Id,
						FullName = HttpContext.Session.GetString("FirstName") + " " + HttpContext.Session.GetString("LastName"),
						MovieTitle = _context.Movies.First(m => m.Id == _context.Showtimes.First(s => s.Id == HttpContext.Session.GetInt32("ShowtimeId")).MovieId).Title,
						Date = DateTime.Parse(HttpContext.Session.GetString("Showdate") ?? DateTime.Now.ToString()),
						Time = _context.Showtimes.First(s => s.Id == HttpContext.Session.GetInt32("ShowtimeId")).Time,
					};
					HttpContext.Session.Clear();
					return View(ticketViewModel);
				}
			}
			return NotFound();
		}
		public IActionResult GenerateBarcode(string toEncode)
		{
			Barcode barcode = new();
			Image image = barcode.Encode(TYPE.CODE39Extended, toEncode, Color.Black, Color.White, 2500, 1000);
			return File(ConvertImageToByte(image), "image/jpeg");
		}
		private static byte[] ConvertImageToByte(Image image)
		{
			using MemoryStream memoryStream = new();
			image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
			return memoryStream.ToArray();
		}
	}
}