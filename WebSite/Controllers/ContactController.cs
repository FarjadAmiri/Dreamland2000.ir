using GoogleReCaptcha.V3.Interface;
using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;
using WebSite.DataLayer.Entities.Contact;
using WebSite.Core.ViewModel.Contact;

namespace WebSite.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IGenericRepository<ContactMessage> _messageRepository;
        private readonly IContactService _contactService;
        private readonly ICaptchaValidator _captchaValidator;


        public ContactController(IGenericRepository<ContactMessage> messageRepository, IContactService contactService, ICaptchaValidator captchaValidator)
        {
            _messageRepository = messageRepository;
            _contactService = contactService;
            _captchaValidator = captchaValidator;
        }

        [Route("contact")]
        public async Task<IActionResult> Index()
        {
            //contact 
            var contact = await _contactService.GetContact(1);

            ViewBag.Navbar = "About";

            return View(contact);
        }

        [HttpPost("contact/message/send")]
        public async Task<IActionResult> SendMessage(ContactSendMessageViewModel viewmodel)
        {
            //check google recaptcha
            if (!await _captchaValidator.IsCaptchaPassedAsync(viewmodel.Captcha))
            {
                TempData["AlertMessage"] = AlertResource.FailedReCaptchaAlert;
                TempData["AlertType"] = "alert-warning";

                return RedirectToAction("Index");
            }

            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return RedirectToAction("Index");
            }

            //new message
            ContactMessage msg = new ContactMessage()
            {
                Subject = viewmodel.Subject,
                SenderName = viewmodel.Name,
                SenderEmail = viewmodel.Email,
                SenderTell = viewmodel.Tell,
                Message = viewmodel.Message,
                LanguageRefId = 1,
                
            };

            //save message
            await _messageRepository.Add(msg);

            TempData["AlertMessage"] = AlertResource.MessageSentSuccessfulAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Index");
        }
    }


}