
namespace Pers.Domain
{
    public interface ISiteContent
    {
        int TextId { get; }
        string HomepageWelcome { get; }
        string HomepageWhatsNew { get; }
        string HomepageWhatsUpLately { get; }
    }
}
