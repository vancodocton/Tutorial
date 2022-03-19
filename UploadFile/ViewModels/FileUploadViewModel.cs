using UploadFile.Models;

namespace UploadFile.ViewModels
{
    public class FileUploadViewModel
    {
        public List<FileOnFileSystem> FilesOnFileSystem { get; set; }

        public List<FileOnDatabase> FilesOnDatabase { get; set; }
    }
}
