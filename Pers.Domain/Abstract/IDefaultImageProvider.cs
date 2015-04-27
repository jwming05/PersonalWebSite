using System.IO;

namespace Pers.Domain
{
    public interface IDefaultImageProvider
    {
        Stream GetPhoto(PhotoSize size);
    }
}
