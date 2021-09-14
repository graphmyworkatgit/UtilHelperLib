using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace UtilHelper.FileHandler
{
    public class TextFileHelper
    {

        public TextFileHelper()
        {

        }
        public void FileWriter(string filePathWithFileNameWithExtn, StringBuilder DataToWrite)
        {
            if (File.Exists(filePathWithFileNameWithExtn))
            {
                File.AppendAllText(filePathWithFileNameWithExtn, DataToWrite.ToString());
            }


            
        }
        public string FileReader(string filePathWithFileNameWithExtn)
        {
            if (File.Exists(filePathWithFileNameWithExtn))
            {
                return File.ReadAllText(filePathWithFileNameWithExtn);
            }
            else
            {
                throw new FileNotFoundException($"{filePathWithFileNameWithExtn}");
            }
           
        }
    }
}
