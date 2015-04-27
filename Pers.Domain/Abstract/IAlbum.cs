using System;
namespace Pers.Domain
{
    public interface IAlbum
    {
        int AlbumID { get; }
        string Caption { get; }
        int Count { get; }
        bool IsPublic { get; }
    }
}
