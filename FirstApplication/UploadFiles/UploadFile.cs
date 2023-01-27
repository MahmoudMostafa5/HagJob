using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.UploadFile
{
    public class UploadFiles
    {
        public static string UploadFile(IFormFile File)
        {
            var PhotoPath = Directory.GetCurrentDirectory() + "/wwwroot/ImageProfile";
            string PhotoName = Guid.NewGuid() + Path.GetFileName(File.FileName);
            string FinallPath = Path.Combine(PhotoPath, PhotoName);
            using(var stream = new FileStream(FinallPath , FileMode.Create))
            {
                File.CopyTo(stream);
            }
            return PhotoName;
        }
    }
}
