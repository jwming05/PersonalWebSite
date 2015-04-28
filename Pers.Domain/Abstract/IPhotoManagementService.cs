using System;
using System.Collections.Generic;
using System.IO;
namespace Pers.Domain
{
    public interface IPhotoManagementService
    {
        void AddAlbum(string caption, bool isPublic);
        void AddPhoto(int albumID, string caption, byte[] bytesOriginal);
        void EditAlbum(string caption, bool isPublic, int albumId);
        void EditPhoto(string caption, int photoId);
        IList<IAlbum> GetAlbums();
        Stream GetFirstPhoto(int albumId, PhotoSize size);
        Stream GetPhoto(PhotoSize size);
        Stream GetPhoto(int photoId, PhotoSize size);
        //IList<IPhoto> GetPhotos();
        IList<IPhoto> GetPhotos(int albumID);
        //int GetRandomAlbumID();
        void RemoveAlbum(int albumId);
        void RemovePhoto(int photoId);

        IList<IPhoto> GetRandomPhotos();

        IList<IAlbum> GetAlbums(int pageIndex, int rowCountOfPage);
        int CountAlbums();
        IList<IPhoto> GetPhotos(int pageIndex, int rowCountOfPage, int albumID);
        int CountPhotos(int albumID);
    }


    //public interface IAlbumService
    //{
    //    void AddAlbum(string caption, bool isPublic);
    //    void EditAlbum(string caption, bool isPublic, int albumId);
    //    IList<IAlbum> GetAlbums();
    //    void RemoveAlbum(int albumId);
    //    int GetRandomAlbumID();
    //}

    //public interface IPhotoService
    //{
    //    void AddPhoto(int albumID, string caption, byte[] bytesOriginal);
    //    void EditPhoto(string caption, int photoId);
    //    void RemovePhoto(int photoId);

    //    Stream GetFirstPhoto(int albumId, PhotoSize size);
    //    Stream GetPhoto(PhotoSize size);
    //    Stream GetPhoto(int photoId, PhotoSize size);
    //    IList<IPhoto> GetPhotos();
    //    IList<IPhoto> GetPhotos(int albumID);
    //}
}
