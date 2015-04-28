using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Pers.Domain;
using Pers.Utilities;

namespace Pers.DAL
{
    public class PhotoManagementRepository : IPhotoManagementRepository
    {
        private string _connectionString;

        public PhotoManagementRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region Photo-Related Methods
        public byte[] GetPhoto(int photoId, PhotoSize size, bool isPublic)
        {
            string cmdText = "GetPhoto";
            object result=ExecuteScalar(
                cmdText,
                CommandType.StoredProcedure,
                new SqlParameter("@PhotoID", photoId), 
                new SqlParameter("@Size", (int)size), 
                new SqlParameter("@IsPublic", isPublic));

            return result as byte[];
        }

        public IList<IPhoto> GetRandomPhotos()
        {
            string cmdText = "GetRandomPhotos";
            return ExecuteReader<IPhoto>(
                cmdText,
                CommandType.StoredProcedure,
                (r) => CreatePhoto((int)r["PhotoID"], (int)r["AlbumID"], (string)r["Caption"]));
        }

        public byte[] GetFirstPhoto(int albumId, PhotoSize size, bool isPublic)
        {
            string cmdText = "GetFirstPhoto";
            object result = ExecuteScalar(
                cmdText,
                CommandType.StoredProcedure,
                new SqlParameter("@AlbumID", albumId),
                new SqlParameter("@Size", (int)size),
                new SqlParameter("@IsPublic", isPublic));

            return result as byte[];
        }

        public IList<IPhoto> GetPhotos(int albumID, bool isPublic)
        {
            string cmdText = "GetPhotos";
            return ExecuteReader<IPhoto>(
                cmdText,
                CommandType.StoredProcedure,
                (r)=>CreatePhoto((int)r["PhotoID"],(int)r["AlbumID"],(string)r["Caption"]),
                new SqlParameter("@AlbumID", albumID),
                new SqlParameter("@IsPublic", isPublic));
        }

        public IList<IPhoto> GetPhotos(int rowIndex, int rowCount, int albumID, bool isPublic)
        {
            string cmdText = "GetPhotos2";
            return ExecuteReader<IPhoto>(
                cmdText,
                CommandType.StoredProcedure,
                (r) => CreatePhoto((int)r["PhotoID"], (int)r["AlbumID"], (string)r["Caption"]),
                new SqlParameter("@AlbumID", albumID),
                new SqlParameter("@IsPublic", isPublic),
                new SqlParameter("@RowIndex", rowIndex),
                new SqlParameter("@RowCount", rowCount));
        }

        public int CountPhotos(int albumID, bool isPublic)
        {
            string cmdText = "CountPhotos";
            return (int)this.ExecuteScalar(
                cmdText,
                CommandType.StoredProcedure,
                new SqlParameter("@AlbumID", albumID),
                new SqlParameter("@IsPublic", isPublic));
        }

        public void AddPhoto(int albumID, string caption, byte[] bytesOriginal, byte[] bytesFull, byte[] bytesPoster, byte[] bytesThumb)
        {
            string cmdText = "AddPhoto";
            ExecuteNonQuery(
                cmdText,
                CommandType.StoredProcedure,
                new SqlParameter("@AlbumID", albumID),
                new SqlParameter("@Caption", caption),
                new SqlParameter("@BytesOriginal", bytesOriginal),
                new SqlParameter("@BytesFull", bytesFull),
                new SqlParameter("@BytesPoster", bytesPoster),
                new SqlParameter("@BytesThumb", bytesThumb));
        }

        public void RemovePhoto(int photoID)
        {
            string cmdText = "RemovePhoto";
            ExecuteNonQuery(
                cmdText,
                CommandType.StoredProcedure,
                new SqlParameter("@PhotoID", photoID));
        }

        public void EditPhoto(string caption, int photoID)
        {
            string cmdText = "EditPhoto";
            ExecuteNonQuery(
                cmdText,
                CommandType.StoredProcedure,
                new SqlParameter("@Caption", caption),
                new SqlParameter("@PhotoID", photoID));
        }
        #endregion

        #region Album-Related Methods
        public IList<IAlbum> GetAlbums(bool isPublic)
        {
            string cmdText = "GetAlbums";
            return ExecuteReader<IAlbum>(
                cmdText,
                CommandType.StoredProcedure,
                (r) => CreateAlbum(
                            (int)r["AlbumID"],
                            (int)r["NumberOfPhotos"],
                            (string)r["Caption"],
                            (bool)r["IsPublic"]),
                new SqlParameter("@IsPublic", isPublic));
        }

        public IList<IAlbum> GetAlbums(int rowIndex, int rowCount, bool isPublic)
        {
            string cmdText = "GetAlbums2";
            return ExecuteReader<IAlbum>(
                cmdText,
                CommandType.StoredProcedure,
                (r) => CreateAlbum(
                            (int)r["AlbumID"],
                            (int)r["NumberOfPhotos"],
                            (string)r["Caption"],
                            (bool)r["IsPublic"]),
                new SqlParameter("@IsPublic", isPublic),
                new SqlParameter("@RowIndex", rowIndex+1),
                new SqlParameter("@RowCount", rowCount));
        }

        public int CountAlbums(bool isPublic)
        {
            string cmdText = "CountAlbums";
            return (int)ExecuteScalar(cmdText, CommandType.StoredProcedure, new SqlParameter("@IsPublic", isPublic));
        }

        public void AddAlbum(string caption, bool isPublic)
        {
            string cmdText = "AddAlbum";
            ExecuteNonQuery(
                cmdText,
                CommandType.StoredProcedure,
                new SqlParameter("@Caption", caption),
                new SqlParameter("@IsPublic", isPublic));
        }

        public void RemoveAlbum(int albumID)
        {
            string cmdText = "RemoveAlbum";
            ExecuteNonQuery(
                cmdText,
                CommandType.StoredProcedure,
                new SqlParameter("@AlbumID", albumID));
        }

        public void EditAlbum(string caption, bool isPublic, int albumID)
        {
            string cmdText = "EditAlbum";
            ExecuteNonQuery(
                cmdText,
                CommandType.StoredProcedure,
                new SqlParameter("@Caption", caption),
                new SqlParameter("@IsPublic", isPublic),
                new SqlParameter("@AlbumID", albumID));
        }

        //public IList<IAlbum> GetNonEmptyAlbums()
        //{
        //    string cmdText = "GetNonEmptyAlbums";
        //    return ExecuteReader<IAlbum>(
        //        cmdText,
        //        CommandType.StoredProcedure,
        //        (r) => CreateAlbum((int)r["AlbumID"], 0, "", false));
        //}
        #endregion

        private object ExecuteScalar(string cmdText, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            return SqlDBUtils.ExecuteScalar(_connectionString, cmdText, commandType, sqlParameters);
        }

        private List<T> ExecuteReader<T>(string cmdText,
            CommandType commandType, Func<SqlDataReader, T> itemCreator, params SqlParameter[] sqlParameters)
        {
            return SqlDBUtils.ExecuteReader(_connectionString, cmdText, commandType, itemCreator, sqlParameters);
        }

        private int ExecuteNonQuery(string cmdText,
            CommandType commandType, params SqlParameter[] sqlParameters)
        {
            return SqlDBUtils.ExecuteNonQuery(_connectionString, cmdText, commandType, sqlParameters);
        }

        private IAlbum CreateAlbum(int albumId,int numberOfPhotos,string caption,bool isPublic)
        {
            return new Album(albumId, numberOfPhotos, caption, isPublic);
        }

        private IPhoto CreatePhoto(int photoId, int albumId, string caption)
        {
            return new Photo(photoId, albumId, caption);
        }
    }
}
