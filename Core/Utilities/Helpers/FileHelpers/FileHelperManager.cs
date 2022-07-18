using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Helpers.GuidHelpers;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelpers
{
    //Project Images --> Add, Delete, Update
    public class FileHelperManager : IFileHelper
    {
        public string Update(IFormFile file, string filePath, string root) //File Update
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath); 
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0) //file.Length --> byte
            {
                if (!Directory.Exists(root))//Directory --> It's the class of the System.IO.
                {
                    Directory.CreateDirectory(root);
                }

                string extension = Path.GetExtension(file.FileName); //file extention
                string guid = GuidHelper.CreateGuid(); //go to --> Core.Utilities.Helpers.GuidHelper 
                string filePath = guid + extension; //Dosyanın adı ve uzantısı yan yana getirilir.

                using (FileStream fileStream = File.Create(root + filePath)) //FileStream class instance
                {                                                            //File.Create(root + filePath) --> creating a file
                                                                             //(root + filePath) --> file path
                    file.CopyTo(fileStream); 
                    fileStream.Flush(); //remove from the buffer
                    return filePath;
                }
            }

            return null;
        }

        public void Delete(string filePath)  
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath); 
            }
        }
    }

}
