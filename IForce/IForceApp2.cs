using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using PdfSharp.Pdf.IO;
using System.Threading.Tasks;

namespace IForce
{
    partial class IForceApp
    {
        public static void ExecuteEclipseSearch()
        {
            IForce.Logger("Connecting to API and Executing Search. Please wait...");
            WebWork apiSearch = new WebWork();
            IForce._iforce.lblCount.Text = apiSearch.Count;
            IForce._iforce.tboxResultsID.Text = apiSearch.ResultsId;
            IForce.Logger($"Search ResultsID = {apiSearch.ResultsId}");
            int _userKey = GetUserKey();
            if(_userKey > 0)
            {
                IForce.Logger("Returning sql results.");
                Search(IForce._iforce.dView1, _userKey, Convert.ToInt32(apiSearch.ResultsId));
                UserInput.ResultsID = Convert.ToInt32(apiSearch.ResultsId);
               IForce.Logger($"Documents Returned: {apiSearch.Count}");
                
                if (CheckForExistingImages())
                {
                    IForce._iforce.btnLaunch.Enabled = true;
                    IForce.Logger("No images found. OK to proceed.");
                }
                else
                {
                    IForce._iforce.btnLaunch.Enabled = false;
                }

                IForce.Logger("Search execution complete.");
            }
            
        }

    }

    public class DocumentImporter
    {
        public DocumentImporter(string[] _path)
        {
            IterateDocuments(_path);
        }

        public static DataTable ResultsTable;

        public static void BuildDatatable()
        {
            DataTable srch = new DataTable();
            WebWork srchresult = new WebWork();            
            OpenSQL Results = new OpenSQL(UserInput.GetDocids(UserInput.UserID, Convert.ToInt32(srchresult.ResultsId)));
            try
            {
                Results.Connection.Open();
                srch.Load(Results.Cmd.ExecuteReader());
                Results.Connection.Close();
                ResultsTable = srch;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void IterateDocuments(string[] filePaths)
        {
            IForceApp.importStarted = true;
            IForce.Logger("Starting Import...");
            BuildDatatable();



            foreach (string file in filePaths)
            {
                string begdoc = Path.GetFileNameWithoutExtension(file);
                long filesizeKb = (new FileInfo(file).Length) / 1024;

                try
                {
                    using (var sourceDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import))
                    {
                        int pgCnt = sourceDocument.PageCount;
                        DataRow[] row = ResultsTable.Select($"BEGDOC = '{begdoc}'");
                        int Docid = (int)row[0]["Docid"];
                        for (int i = 1; i <= pgCnt; i++)
                        {
                            if (i == 1)
                            {
                                OpenSQL Results = new OpenSQL(UserInput.InsertFirstPage(Docid, 1, begdoc, file, filesizeKb, UserInput.UserID));
                                Results.Connection.Open();
                                Results.Cmd.ExecuteNonQuery();
                                Results.Cmd.CommandText = UserInput.UpdateHasImage(Docid);
                                Results.Cmd.ExecuteNonQuery();
                                Results.Connection.Close();
                            }
                            else
                            {
                                string imagekey = begdoc + "." + i.ToString("D9");
                                OpenSQL Results = new OpenSQL(UserInput.InsertOtherPages(Docid, i, imagekey, file, UserInput.UserID));
                                Results.Connection.Open();
                                Results.Cmd.ExecuteNonQuery();
                                Results.Connection.Close();
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    IForce.Logger(ex.Message);
                    MessageBox.Show(ex.ToString());

                }

            }

            IForce.Logger("Import Complete");
            IForce.Logger($"Deleting temporary native file source: {UserInput.SourcePath}");
            IForceApp.importStarted = false;

            IForce._iforce.chxLstBx1.Invoke(new MethodInvoker(delegate ()
            {
                IForce._iforce.chxLstBx1.SetItemCheckState(IForce._iforce.chxLstBx1.SelectedIndex, CheckState.Unchecked);
                IForce._iforce.chxLstBx1.ClearSelected();
                IForce._iforce.btnAPISearch.Enabled = true;
                IForce._iforce.chxLstBx1.Enabled = true;
                IForce._iforce.btnLaunch.Enabled = true;
                IForce._iforce.btnImport.Enabled = true;
                IForce._iforce.rchTxtBx2.ReadOnly = false;
            }));


            MessageBox.Show("Done.");

        }


    }


}



