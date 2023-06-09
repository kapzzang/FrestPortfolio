using System.Collections.Generic;

namespace FileUploadDownload.Models
{
    public class FileUpload
    {
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public IEnumerable<FileUpload> FileList { get; set; }
    }
}