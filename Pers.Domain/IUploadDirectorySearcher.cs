
using System.Collections.Generic;
using System.IO;
namespace Pers.Domain
{
    public interface IUploadDirectorySearcher
    {
        IEnumerable<FileInfo> GetFiles();
    }
}
