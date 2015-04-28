using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
namespace Pers.Domain
{
    public class PhotoManager
    {
        private static IPhotoManagementService GetService()
        {
            return (IPhotoManagementService)HttpContext.Current.Items["PhotoManagementService"];
        }

        // Photo-Related Methods

        public static Stream GetPhoto(int photoId, PhotoSize size)
        {
            var service = GetService();
            return service.GetPhoto(photoId, size);
        }

        public static Stream GetPhoto(PhotoSize size)
        {
            var service = GetService();
            return service.GetPhoto(size);
        }

        public static Stream GetFirstPhoto(int albumId, PhotoSize size)
        {
            var service = GetService();
            return service.GetFirstPhoto(albumId,size);
        }

        public static IList<IPhoto> GetPhotos(int albumId)
        {
            var service = GetService();
            return service.GetPhotos(albumId);
        }

        //public static IList<IPhoto> GetPhotos()
        //{
        //    var service = GetService();
        //    return GetPhotos(service.GetRandomAlbumID());
        //}

        public static IList<IPhoto> GetRandomPhotos()
        {
            var service = GetService();
            return service.GetRandomPhotos(); // GetPhotos(service.GetRandomAlbumID());
        }

        public static void AddPhoto(int albumId, string caption, byte[] bytesOriginal)
        {
            var service = GetService();
            service.AddPhoto(albumId, caption, bytesOriginal);
        }

        public static void RemovePhoto(int photoId)
        {
            var service = GetService();
            service.RemovePhoto(photoId);
        }

        public static void EditPhoto(string caption, int photoId)
        {
            var service = GetService();
            service.EditPhoto(caption,photoId);
        }

        // Album-Related Methods

        public static IList<IAlbum> GetAlbums()
        {
            var service = GetService();
            return service.GetAlbums();
        }

        public static void AddAlbum(string caption, bool isPublic)
        {
            var service = GetService();
            service.AddAlbum(caption,isPublic);
        }

        public static void RemoveAlbum(int albumId)
        {
            var service = GetService();
            service.RemoveAlbum(albumId);
        }

        public static void EditAlbum(string caption, bool isPublic, int albumId)
        {
            var service = GetService();
            service.EditAlbum(caption,isPublic,albumId);
        }

        //public static int GetRandomAlbumID()
        //{
        //    var service = GetService();
        //    return service.GetRandomAlbumID();
        //}

        // Helper Functions

        public static ICollection ListUploadDirectory()
        {
            DirectoryInfo d = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath("~/Upload"));
            return d.GetFileSystemInfos("*.jpg");
        }
    }
}