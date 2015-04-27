using System.Collections.Generic;
using System.Linq;

namespace Pers.Domain
{
    public class SiteContentManagementService : ISiteContentManagementService
    {
        private ISiteContentManagementRepository _repository;

        public SiteContentManagementService(ISiteContentManagementRepository repository)
        {
            _repository = repository;
        }

        public IList<ISiteContent> GetSiteContent()
        {
            return _repository.GetSiteContent();
        }

        public void EditSiteContent(int textId, string homepageWelcome, string homepageWhatsNew, string homepageWhatsUpLately)
        {
            _repository.EditSiteContent(textId, homepageWelcome, homepageWhatsNew, homepageWhatsUpLately);
        }
    }
}
