using WebSite.DataLayer.Entities.Contact;


namespace WebSite.Core.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetContactList();
        Task<Contact> GetContact(int language);
    }

    public class ContactService : IContactService
    {
        private readonly IGenericRepository<Contact> _contactRepository;

        public ContactService(IGenericRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<Contact>> GetContactList()
        {
            var contactList = await _contactRepository.Get();

            return contactList;
        }

        public async Task<Contact> GetContact(int language)
        {
            var contactList = await _contactRepository.Get(
                l=>l.LanguageRefId==language);
            
            return contactList.First();
        }

       
    }
}
