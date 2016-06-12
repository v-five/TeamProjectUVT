using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Models;
using System.IO;

namespace MVCDemo.Utils
{
    public static class FileManagementUtils
    {
        public static void SaveUploadedCV(Person person)
        {
            if (HttpContext.Current.Request.Files["uploadedCV"] != null)
            {
                var file = HttpContext.Current.Request.Files["uploadedCV"];
                string targetLocation = HttpContext.Current.Server.MapPath("~/UploadedFiles/" + person.BasicInfo.FirstName + person.BasicInfo.LastName + "/CV/");
                if (file.ContentLength > 0)
                {
                    string fileName = file.FileName;
                    int fileSize = file.ContentLength;
                    byte[] fileByteArray = new byte[fileSize];
                    file.InputStream.Read(fileByteArray, 0, fileSize);
                    Directory.CreateDirectory(targetLocation);
                    file.SaveAs(targetLocation + fileName);
                }
            }
        }
    }
}