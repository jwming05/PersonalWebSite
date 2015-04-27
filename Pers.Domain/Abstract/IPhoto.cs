using System;
namespace Pers.Domain
{
    public interface IPhoto
    {
        int AlbumID { get; }
        string Caption { get; }
        int PhotoID { get; }
    }
}
