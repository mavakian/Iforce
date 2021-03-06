﻿using System.IO;

namespace IForce
{
    public class DocInfo
    {
        public int DocId { get; set; }
        public string BegDoc { get; set; }
        public string Native { get; set; }
        public string FileExtension { get; set; }

        public DocInfo(int docId, string begDoc, string native, string fileExtension)
        {
            DocId = docId;
            BegDoc = begDoc;
            Native = native;
            FileExtension = fileExtension;
        }

    }

    public class ReadDisk
    {
        public string[] getFilePaths(string sourcePath)
        {
            string[] filePaths = Directory.GetFiles(sourcePath, "*.pdf", SearchOption.AllDirectories);
            return filePaths;
        }


    }
}
