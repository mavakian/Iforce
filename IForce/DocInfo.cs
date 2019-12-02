using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
