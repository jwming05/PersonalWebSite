using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace Pers.Domain
{
    public class PhotoManagementService : IPhotoManagementService
    {
        private IPhotoManagementRepository _repository;
        private IAlbumFilter _albumFilter;
        private IImageResizer _imageResizer;
        private IDefaultImageProvider _defaultImageProvider;

        public PhotoManagementService(IPhotoManagementRepository repository, IAlbumFilter albumFilter, IImageResizer imageResizer,
            IDefaultImageProvider defaultImageProvider)
        {
            _repository = repository;
            _albumFilter = albumFilter;
            _imageResizer = imageResizer;
            _defaultImageProvider = defaultImageProvider;
        }

        #region Photo-Related Methods
        public Stream GetPhoto(int photoId, PhotoSize size)
        {
            byte[] bytes = _repository.GetPhoto(photoId, size, _albumFilter.IsPublic);

            return bytes != null ? new MemoryStream(bytes) : null;
        }

        public Stream GetPhoto(PhotoSize size)
        {
            return _defaultImageProvider.GetPhoto(size);
        }

        public Stream GetFirstPhoto(int albumId, PhotoSize size)
        {
            byte[] bytes = _repository.GetFirstPhoto(albumId, size, _albumFilter.IsPublic);
            return bytes != null ? new MemoryStream(bytes) : null;
        }

        public IList<IPhoto> GetPhotos(int albumID)
        {
            return _repository.GetPhotos(albumID, _albumFilter.IsPublic);
        }

        public IList<IPhoto> GetPhotos()
        {
            return GetPhotos(GetRandomAlbumID());
        }

        public void AddPhoto(int albumID, string caption, byte[] bytesOriginal)
        {
            _repository.AddPhoto(albumID, caption, bytesOriginal,
                _imageResizer.ResizeImageFile(bytesOriginal, 600),
                _imageResizer.ResizeImageFile(bytesOriginal, 198),
                _imageResizer.ResizeImageFile(bytesOriginal, 100));
        }

        public void RemovePhoto(int photoId)
        {
            _repository.RemovePhoto(photoId);
        }

        public void EditPhoto(string caption, int photoId)
        {
            _repository.EditPhoto(caption, photoId);
        }
        #endregion
        

        #region Album-Related Methods
        public IList<IAlbum> GetAlbums()
        {
            return _repository.GetAlbums(_albumFilter.IsPublic);
        }

        public void AddAlbum(string caption, bool isPublic)
        {
            _repository.AddAlbum(caption, isPublic);
        }

        public void RemoveAlbum(int albumId)
        {
            _repository.RemoveAlbum(albumId);
        }

        public void EditAlbum(string caption, bool isPublic, int albumId)
        {
            _repository.EditAlbum(caption, isPublic, albumId);
        }

        public int GetRandomAlbumID()
        {
            IList<IAlbum> albums = _repository.GetNonEmptyAlbums();

            if (albums.Count > 0)
            {
                Random r = new Random();
                return albums[r.Next(albums.Count)].AlbumID;
            }
            else
            {
                return -1;
            }
        }
        #endregion

        // Helper Functions

        //public static ICollection ListUploadDirectory()
        //{
        //    DirectoryInfo d = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath("~/Upload"));
        //    return d.GetFileSystemInfos("*.jpg");
        //}

    }
}