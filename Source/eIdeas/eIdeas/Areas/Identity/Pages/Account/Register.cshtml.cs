using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using eIdeas.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace eIdeas.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<eIdeasUser> _signInManager;
        private readonly UserManager<eIdeasUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private IHostingEnvironment _environment;

        public RegisterModel(
            UserManager<eIdeasUser> userManager,
            SignInManager<eIdeasUser> signInManager,
            ILogger<RegisterModel> logger,

            IEmailSender emailSender,
            IHostingEnvironment environment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _environment = environment;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "First name")]
            public string Firstname { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Last name")]
            public string Lastname { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Team")]
            public string Team { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Role")]
            public string Role { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            //[Url]
            [Display(Name = "PictureURL")]
            public string PictureURL { get; set; }

            //[Required]
            [Display(Name = "Image")]
            public IFormFile Image { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new eIdeasUser {
                    UserName = Input.Email,
                    Email = Input.Email,
                    Firstname = Input.Firstname,
                    Lastname = Input.Lastname,
                    Team = Input.Team,
                    Role = Input.Role,
                    PictureURL = "https://www.princeton-house.org/Handlers/ViewUserPhoto.ashx?id=3063"
                };


                var image = HttpContext.Request.Form.Files;
                Input.Image = image[0];

                if (Input.Image != null)
                {
                    var fileName = string.Empty;
                    var newFileName = string.Empty;
                    //Getting FileName
                    fileName = ContentDispositionHeaderValue.Parse(Input.Image.ContentDisposition).FileName.Trim('"');

                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                    //Getting file Extension
                    var FileExtension = Path.GetExtension(fileName);

                    // concating  FileName + FileExtension
                    newFileName = myUniqueFileName + FileExtension;

                    // Combines two strings into a path.
                    user.PictureURL = Path.Combine(_environment.WebRootPath, "images/") + newFileName;

                    using (var fileStream = System.IO.File.Create(user.PictureURL))
                    {
                        await Input.Image.CopyToAsync(fileStream);
                    }
                }

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}
