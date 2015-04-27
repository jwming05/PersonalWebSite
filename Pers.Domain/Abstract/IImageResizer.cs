
namespace Pers.Domain
{
    public interface IImageResizer
    {
        byte[] ResizeImageFile(byte[] imageFile, int targetSize);
    }
}
