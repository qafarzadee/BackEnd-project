using static System.Net.Mime.MediaTypeNames;

namespace BackEndProcetMVC.Extentions
{
    public static class FileUploadExtention
    {
        public static string CreateImage(this IFormFile formfile,string root,string folder)
        {
            string FullName = Guid.NewGuid().ToString() + formfile.FileName;
            string FullPath = Path.Combine(root, folder, FullName);
            using(FileStream filstream=new FileStream(FullPath, FileMode.Create))
            {
                formfile.CopyTo(filstream);
            }
            return FullName;
        }     
    }
}
