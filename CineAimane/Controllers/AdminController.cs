using CineAimane.Data;
using CineAimane.Helpers;
using CineAimane.Helpers.EmailSenderHelper;
using CineAimane.Models;
using CineAimane.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace CineAimane.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
		private readonly CineAimaneDbContext _context;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly IPasswordHasher<IdentityUser> _passwordHasher;
		private readonly IEmailService _emailService;
		public AdminController(CineAimaneDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IPasswordHasher<IdentityUser> passwordHasher, IEmailService emailService)
		{
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;
			_passwordHasher = passwordHasher;
			_emailService = emailService;
		}
		[AllowAnonymous]
		public IActionResult Index()
		{
			if (_signInManager.IsSignedIn(User))
			{
				return RedirectToAction(nameof(Add));
			}
			return View();
		}
		[AllowAnonymous]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Index(AdminLoginViewModel adminLoginViewModel, string? returnUrl)
		{
			if (_signInManager.IsSignedIn(User))
			{
				return RedirectToAction(nameof(Add));
			}
			returnUrl ??= Url.Content("~/Admin/Add");
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(adminLoginViewModel.Username, adminLoginViewModel.Password, adminLoginViewModel.RememberMe, true);
				if (result.Succeeded)
				{
					return LocalRedirect(returnUrl);
				}
				if (result.IsLockedOut)
				{
					ViewBag.Error = "This account is locked out.";
				}
				else
				{
					ViewBag.Error = "Incorrect username or password.";
				}
			}
			return View(adminLoginViewModel);
		}
		[AllowAnonymous]
		public IActionResult Forgot()
		{
			if (_signInManager.IsSignedIn(User))
			{
				return RedirectToAction(nameof(Add));
			}
			return View();
		}
		[AllowAnonymous]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Forgot(AdminForgotViewModel adminForgotViewModel)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(adminForgotViewModel.Email);
				if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
				{
					ViewBag.Message = "Please check your email to reset your password.";
					return View();
				}
				string token = HttpUtility.UrlEncode(await _userManager.GeneratePasswordResetTokenAsync(user));
				var resetLink = Url.Action("Reset", "Admin", new { adminForgotViewModel.Email, token }, Request.Scheme);
				EmailModel emailModel = new()
				{
					To = new List<string> { adminForgotViewModel.Email },
					Subject = "Password Reset",
					Content = System.IO.File.ReadAllText("Helpers/EmailHelper/EmailTemplate.html").Replace("{{username}}", user.UserName).Replace("{{action_url}}", resetLink),
				};
				await _emailService.Send(emailModel);
				ViewBag.Message = "Please check your email to reset your password.";
				ModelState.Clear();
				return View();
			}
			return View();
		}
		[AllowAnonymous]
		public IActionResult Reset(string Email, string Token)
		{
			if (_signInManager.IsSignedIn(User))
			{
				return RedirectToAction(nameof(Add));
			}
			if (Email == null || Token == null)
			{
				ViewBag.Error = "Invalid password reset URL.";
			}
			return View();
		}
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Reset(AdminResetViewModel adminResetViewModel)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(adminResetViewModel.Email);
				if (user != null)
				{
					var token = HttpUtility.UrlDecode(adminResetViewModel.Token);
					var result = await _userManager.ResetPasswordAsync(user, token, adminResetViewModel.NewPassword);
					if (result.Succeeded)
					{
						if (await _userManager.IsLockedOutAsync(user))
						{
							await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow);
						}
						ViewBag.Message = "Your password is reset. Please click <a href='/Admin/' class='alert-link'>here to login</a>";
					}
					else
					{
						ViewBag.Errors = result.Errors;
					}
					return View();
				}
			}
			return View(adminResetViewModel);
		}
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Add(Movie movie)
		{
			if (ModelState.IsValid)
			{
				_context.Movies.Add(movie);
				_context.SaveChanges();
				if (Showtimes(movie).Any())
				{
					_context.Showtimes.AddRange(Showtimes(movie));
				}
				_context.SaveChanges();
				TempData["Success"] = "The movie was added successfully";
				return RedirectToAction(nameof(Add));
			}
			return View(movie);
		}
		public IActionResult Movies(string search = "", int page = 1)
		{
			List<Movie> movies;
			if (!string.IsNullOrEmpty(search))
			{
				movies = _context.Movies.Where(m => m.Title.Contains(search)).OrderByDescending(m => m.ReleaseDate).ToList();
			}
			else
			{
				movies = _context.Movies.OrderByDescending(m => m.ReleaseDate).ToList();
			}
			page = (page < 1) ? 1 : page;
			int moviesCount = movies.Count;
			var pagination = new PaginationHelper(moviesCount, page, 24);
			int toSkip = (page - 1) * pagination.PageSize;
			movies = movies.Skip(toSkip).Take(pagination.PageSize).ToList();
			if (!movies.Any() && page != 1)
			{
				return RedirectToAction(nameof(Movies), new { page = page - 1 });
			}
			ViewBag.Search = search;
			ViewBag.Pagination = pagination;
			TempData["CurrentPage"] = page;
			return View(movies);
		}
		public IActionResult Edit(int? id)
		{
			if (id == null || _context.Movies == null)
			{
				return NotFound();
			}
			var movie = _context.Movies.Find(id);
			if (movie == null)
			{
				return NotFound();
			}
			return View(movie);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, Movie movie)
		{
			if (id != movie.Id)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				try
				{
					var oldMovie = _context.Movies.Find(movie.Id);
					if (oldMovie?.Duration != movie.Duration)
					{
						var showtimesToDelete = _context.Showtimes.Where(s => s.MovieId == movie.Id);
						if (showtimesToDelete.Any())
						{
							showtimesToDelete = showtimesToDelete.AsEnumerable().Select(s => { s.IsDeleted = true; return s; }).AsQueryable();
							_context.UpdateRange(showtimesToDelete);
						}
						if (Showtimes(movie).Any())
						{
							_context.Showtimes.AddRange(Showtimes(movie));
						}
					}
					_context.Movies.Update(movie);
					_context.SaveChanges();
					TempData["Success"] = "The movie was updated successfully";
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!MovieExists(movie.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Movies), new { page = CurrentPage() });
			}
			return View(movie);
		}
		public IActionResult Delete(int? id)
		{
			if (id == null || _context.Movies == null)
			{
				return NotFound();
			}
			var movie = _context.Movies.Find(id);
			if (movie != null)
			{
				var showtimesToDelete = _context.Showtimes.Where(s => s.MovieId == movie.Id);
				if (showtimesToDelete.Any())
				{
					_context.Showtimes.RemoveRange(showtimesToDelete);
				}
				_context.Movies.Remove(movie);
				_context.SaveChanges();
				TempData["Success"] = "The movie was deleted successfully";
			}
			return RedirectToAction(nameof(Movies), new { page = CurrentPage() });
		}
		public IActionResult Account()
		{
			var user = _context.Users.Find(_userManager.GetUserId(User));
			if (user != null)
			{
				AdminAccountViewModel adminEditViewModel = new()
				{
					Username = user.UserName,
					Email = user.Email,
				};
				return View(adminEditViewModel);
			}
			return NotFound();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Account(AdminAccountViewModel adminAccountViewModel)
		{
			if (ModelState.IsValid)
			{
				var user = _context.Users.Find(_userManager.GetUserId(User));
				if (user != null)
				{
					var result = await _userManager.ChangePasswordAsync(user, adminAccountViewModel.CurrentPassword, adminAccountViewModel.NewPassword);
					if (result.Succeeded)
					{
						await _signInManager.RefreshSignInAsync(user);
						TempData["Success"] = "Your account was updated successfully";
					}
					else
					{
						ViewBag.Errors = result.Errors;
					}
				}
				else
				{
					return NotFound();
				}
				adminAccountViewModel.Username = user.UserName;
				adminAccountViewModel.Email = user.Email;
			}
			return View(adminAccountViewModel);
		}
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction(nameof(Index));
		}
		private bool MovieExists(int id)
		{
			return _context.Movies.Any(e => e.Id == id);
		}
		private static List<Showtime> Showtimes(Movie movie)
		{
			var duration = movie.Duration.Split(' ');
			int hours = int.Parse(duration[0][..duration[0].IndexOf('h')]);
			int minutes = int.Parse(duration[1][..duration[1].IndexOf('m')]);
			if (hours > 0)
			{
				TimeOnly time = new(9, 0);
				List<Showtime> showtimes = new();
				do
				{
					Showtime showtime = new()
					{
						Time = time.ToString(),
						MovieId = movie.Id,
					};
					showtimes.Add(showtime);
					time = time.AddHours(hours + 1);
					time = time.AddMinutes(minutes);
				} while (time.IsBetween(new TimeOnly(9, 0), new TimeOnly(0, 0)));
				return showtimes;
			}
			return new List<Showtime>();
		}
		private int CurrentPage()
		{
			return (int)(TempData["CurrentPage"] ?? 1);
		}
	}
}