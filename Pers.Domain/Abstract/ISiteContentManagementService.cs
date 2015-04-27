
using System.Collections.Generic;
namespace Pers.Domain
{
    public interface ISiteContentManagementService
    {
        IList<ISiteContent> GetSiteContent();

        void EditSiteContent(int textId, string homepageWelcome, string homepageWhatsNew, string homepageWhatsUpLately);
    }
}
