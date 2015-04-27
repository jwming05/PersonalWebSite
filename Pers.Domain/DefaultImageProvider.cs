using System.IO;
using System.Web;

namespace Pers.Domain
{
    public class DefaultImageProvider : IDefaultImageProvider
    {
        public Stream GetPhoto(PhotoSize size)
        {
            string path = HttpContext.Current.Server.MapPath("~/Images/");
            switch (size)
            {
                case PhotoSize.Small:
                    path += "placeholder-100.jpg";
                    break;
                case PhotoSize.Medium:
                    path += "placeholder-200.jpg";
                    break;
                case PhotoSize.Large:
                    path += "placeholder-600.jpg";
                    break;
                default:
                    path += "placeholder-600.jpg";
                    break;
            }
            return new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        }
    }
}
