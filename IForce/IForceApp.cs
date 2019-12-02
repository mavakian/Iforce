using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace IForce
{
    class IForceApp
    {
        internal static void CopyAndRenameFiles(DataTable _res, RichTextBox rchbx1)
        {
                    var docInfos = new List<DocInfo>();

                    foreach (DataRow row in _res.Rows)
                    {
                        var docInfo = new DocInfo((int)row["DocID"], (string)row["BEGDOC"], (string)row["Native"], (string)row["NativeFileExtension"]);
                        docInfos.Add(docInfo);
                    }

                    Parallel.ForEach(docInfos, x =>
                    {
                        try
                        {
                            //FileName changing and copy goes in here x is each docInfo
                            var fileInfo = new FileInfo(x.Native);
                            var destFileName = UserInput.SourcePath + ((docInfos.IndexOf(x) % 1000) + 1) + "\\" + x.BegDoc + (x.FileExtension.Contains('.') ? x.FileExtension : "." + x.FileExtension);
                            var dirInfo = new DirectoryInfo(UserInput.SourcePath + ((docInfos.IndexOf(x) % 1000) + 1));
                            if (!dirInfo.Exists)
                            {
                                dirInfo.Create();
                            }
                            fileInfo.CopyTo(destFileName);
                        }
                        catch(Exception ex) { MessageBox.Show(ex.Message); }// rchbx1.AppendText(@"\r\n" + x.BegDoc + " " + ex.Message); }
                    });

                //BeginWebrequest()

        }

        //public string beginWebRequst()
        //{
        //    return;
        //}

    }
}
