using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadPhotoAPI
{
    public class User
    {
        public string email { get; set; }
        public string username { get; set; }
        public string profile { get; set; }
    }
    public class Data
    {
        public bool success { get; set; }
        public string message { get; set; }
        public File data { get; set; }
    }
    public class File
    {
        public string path { get; set; }
    }
}
