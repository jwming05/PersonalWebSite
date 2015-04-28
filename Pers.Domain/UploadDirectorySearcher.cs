using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pers.Domain
{
    public class UploadDirectorySearcher : IUploadDirectorySearcher
    {
        public IEnumerable<FileInfo> GetFiles()
        {
            DirectoryInfo d = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath("~/Upload"));
            return d.GetFileSystemInfos("*.jpg").OfType<FileInfo>();
        }
    }
}
