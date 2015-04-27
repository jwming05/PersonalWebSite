using System.Web;

namespace Pers.Domain
{
    public class AlbumFilter : IAlbumFilter
    {
        public bool IsPublic
        {
            get
            {
                return !(HttpContext.Current.User.IsInRole("Friends") || HttpContext.Current.User.IsInRole("Administrators"));
            }
        }
    }
}
