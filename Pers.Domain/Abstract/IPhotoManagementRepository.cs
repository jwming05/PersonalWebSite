using System;
using System.Collections.Generic;

namespace Pers.Domain
{
    public interface IPhotoManagementRepository
    {
        void AddAlbum(string caption, bool isPublic);
        void AddPhoto(int albumID, string caption, byte[] bytesOriginal, byte[] bytesFull, byte[] bytesPoster, byte[] bytesThumb);
        void EditAlbum(string caption, bool isPublic, int albumID);
        void EditPhoto(string caption, int photoID);
        IList<IAlbum> GetAlbums(bool isPublic);
        byte[] GetFirstPhoto(int albumId, PhotoSize size, bool isPublic);
        IList<IAlbum> GetNonEmptyAlbums();
        byte[] GetPhoto(int photoId, PhotoSize size, bool isPublic);
        IList<IPhoto> GetPhotos(int albumID, bool isPublic);
        void RemoveAlbum(int albumID);
        void RemovePhoto(int photoID);
    }

    //public interface IAlbumRepository
    //{
    //    void AddAlbum(string caption, bool isPublic);
    //    void RemoveAlbum(int albumID);
    //    void EditAlbum(string caption, bool isPublic, int albumID);
    //    IList<IAlbum> GetAlbums(bool isPublic);
    //    IList<IAlbum> GetNonEmptyAlbums();
    //}

    //public interface IPhotoRepository
    //{
    //    void AddPhoto(int albumID, string caption, byte[] bytesOriginal, byte[] bytesFull, byte[] bytesPoster, byte[] bytesThumb);
    //    void RemovePhoto(int photoID);
    //    void EditPhoto(string caption, int photoID);

    //    byte[] GetFirstPhoto(int albumId, PhotoSize size, bool isPublic);
    //    byte[] GetPhoto(int photoId, PhotoSize size, bool isPublic);
    //    IList<IPhoto> GetPhotos(int albumID, bool isPublic);
    //}
}
