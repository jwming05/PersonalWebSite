using System.Collections.Generic;
using System.Web;

namespace Pers.Domain
{
    public class SiteContentManager
    {
        private static ISiteContentManagementService GetService()
        {
            return (ISiteContentManagementService)HttpContext.Current.Items["SiteContentManagementService"];
        }

        public static IList<ISiteContent> GetSiteContent()
        {
            return GetService().GetSiteContent();
        }

        public static void EditSiteContent(int textId, string homepageWelcome, string homepageWhatsNew, string homepageWhatsUpLately)
        {
            GetService().EditSiteContent(textId, homepageWelcome, homepageWhatsNew, homepageWhatsUpLately);
        }
    }
}
