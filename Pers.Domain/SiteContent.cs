
namespace Pers.Domain
{
    public class SiteContent:ISiteContent
    {
        private int _textId;
        private string _homepageWelcome;
        private string _homepageWhatsNew;
        private string _homepageWhatsUpLately;

        public SiteContent(int textId, string homepageWelcome, string homepageWhatsNew, string homepageWhatsUpLately)
        {
            _textId = textId;
            _homepageWelcome = homepageWelcome;
            _homepageWhatsNew = homepageWhatsNew;
            _homepageWhatsUpLately = homepageWhatsUpLately;
        }

        public int TextId
        {
            get { return _textId; }
        }

        public string HomepageWelcome
        {
            get { return _homepageWelcome; }
        }

        public string HomepageWhatsNew
        {
            get { return _homepageWhatsNew; }
        }

        public string HomepageWhatsUpLately
        {
            get { return _homepageWhatsUpLately; }
        }
    }
}
