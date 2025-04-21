using System.Security.Claims;
using GoogleReCaptcha.V3.Interface;
using WebSite.Core.Services;
using WebSite.Core.Utility;
using WebSite.DataLayer.Entities.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.Account;

namespace WebSite.Areas.English.Controllers
{
	public class AccountController : BaseController
	{
		private readonly IGenericRepository<Users> _userRepository;
		private readonly IGenericRepository<UserJoinRole> _userJoinRoleRepository;
		private readonly ICaptchaValidator _captchaValidator;
		private readonly IUserService _userService;
		private readonly IConfiguration _configuration;
	
        public AccountController(IGenericRepository<Users> userRepository, IGenericRepository<UserJoinRole> userJoinRoleRepository, ICaptchaValidator captchaValidator, IUserService userService, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _userJoinRoleRepository = userJoinRoleRepository;
            _captchaValidator = captchaValidator;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpGet("en/register")]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost("en/register"), ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModelEnglish viewmodel)
		{
			//google recaptcha validation
			if (!await _captchaValidator.IsCaptchaPassedAsync(viewmodel.Captcha))
			{
				TempData["AlertMessage"] = AlertResource.FailedReCaptchaAlert;
				TempData["AlertType"] = "alert-warning";

				return View(viewmodel);
			}

			//check model validation 
			if (!ModelState.IsValid)
			{
				TempData["AlertMessage"] = AlertResource.FailRequestAlert;
				TempData["AlertType"] = "alert-warning";
				return View(viewmodel);
			}

			//check mobile exist 
			var mobileExistResult = await _userService.MobileExist(viewmodel.Mobile!);
			if (mobileExistResult)
			{
				TempData["AlertMessage"] = AlertResource.ExistMobileAlert;
				TempData["AlertType"] = "alert-warning";
				return View(viewmodel);
			}

			//new user 
			Users user = new Users()
			{
				Mobile = MyText.CleanMobile(viewmodel.Mobile!),
				FirstName = viewmodel.FirstName,
				LastName = viewmodel.LastName,
				Password = PasswordHelper.EncodePasswordMd5(viewmodel.Password!),
			};
			await _userRepository.Add(user);

			UserJoinRole memberRole = new UserJoinRole()
			{
				RoleRefId = 3,
				UserRefId = user.Id,
			};
			await _userJoinRoleRepository.Add(memberRole);

		
			TempData["AlertMessage"] = AlertResource.SuccessRegisterAlert;
			TempData["AlertType"] = "alert-success";

			return RedirectToAction("Login", "Account");
		}


		//login
		[HttpGet("en/login")]
		public ActionResult Login()
		{
			return View();
		}


		[HttpPost("en/login"), ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModelEnglish viewmodel)
		{
			viewmodel.Mobile = MyText.CleanMobile(viewmodel.Mobile!);


			if (!ModelState.IsValid)
			{
				TempData["AlertMessage"] = AlertResource.FailRequestAlert;
				TempData["AlertType"] = "alert-warning";

				return View(viewmodel);
			}

			var mobileExistResult = await _userService.MobileExist(viewmodel.Mobile);
			if (mobileExistResult == false)
			{
				TempData["AlertMessage"] = AlertResource.NotFoundMobileAlert;
				TempData["AlertType"] = "alert-warning";

				await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

				return View(viewmodel);
			}

			//find user
			var user = await _userService.GetCurrentUserByUserName(viewmodel.Mobile);

			string strHashPassword = PasswordHelper.EncodePasswordMd5(viewmodel.Password!.Trim());
			if (user.Password != strHashPassword)
			{
				TempData["AlertMessage"] = AlertResource.PasswordIsIncorrectAlert;
				TempData["AlertType"] = "alert-warning";
				return View(viewmodel);
			}

			if (user.IsActive == false)
			{
				TempData["AlertMessage"] = AlertResource.DeactiveAccountAlert;
				TempData["AlertType"] = "alert-warning";

				await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

				return View(viewmodel);
			}

			//login user 
			var loginCookieExpirationDays = _configuration.GetValue("LoginCookieExpirationDays", defaultValue: 30);
			var cookieClaims = await CreateCookieClaimsAsync(user).ConfigureAwait(false);
			await HttpContext.SignInAsync(
				CookieAuthenticationDefaults.AuthenticationScheme,
				cookieClaims,
				new AuthenticationProperties
				{
					IsPersistent = true, // "Remember Me"
					IssuedUtc = DateTimeOffset.UtcNow,
					ExpiresUtc = DateTimeOffset.UtcNow.AddDays(loginCookieExpirationDays)
				});

			await _userService.UpdateUserLastActivityDateAsync(user.Id).ConfigureAwait(false);

			return RedirectToAction("Index", "Home");

		}

		//logout 
		[Route("en/logout")]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Home");
		}

		//create cookie 
		private async Task<ClaimsPrincipal> CreateCookieClaimsAsync(Users user)
		{
			var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
			identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
			identity.AddClaim(new Claim(ClaimTypes.Name, user.Mobile!));
			string strFullName = user.FirstName + " " + user.LastName;
			identity.AddClaim(new Claim("DisplayName", strFullName));

			// to invalidate the cookie
			identity.AddClaim(new Claim(ClaimTypes.SerialNumber, user.SerialNumber!));

			// custom data
			identity.AddClaim(new Claim(ClaimTypes.UserData, user.Id.ToString()));

			// add roles
			var roles = await _userService.FindUserRolesAsync(user.Id).ConfigureAwait(false);
			foreach (var role in roles)
			{
				identity.AddClaim(new Claim(ClaimTypes.Role, role.Title!));
			}

			return new ClaimsPrincipal(identity);
		}


	}
}