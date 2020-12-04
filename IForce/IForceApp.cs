using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Net;
using Newtonsoft.Json.Linq;
using PdfSharp.Pdf.IO;
using System.Timers;
using System.Net.Http;
using IdentityModel.Client;
using System.Configuration;
using System.ComponentModel;

namespace IForce
{
    partial class IForceApp
    {
  
        //Program
        public static void UpdateTextFieldsFromConfig()
        {
            try
            {
                IForce._iforce.tboxServer.Text = ConfigurationManager.AppSettings.Get("Server");
                IForce._iforce.tboxDb.Text = ConfigurationManager.AppSettings.Get("Database");
                IForce._iforce.tboxSQLUser.Text = ConfigurationManager.AppSettings.Get("User");
                // IForce._iforce.tboxPassword.Text = ConfigurationManager.AppSettings.Get("Password");
                IForce._iforce.tboxURL.Text = ConfigurationManager.AppSettings.Get("IproUrl");
            }
            catch { IForce.Logger("Unable to read connection info from file."); }
        }
        public static void GetDatabaseList(CheckedListBox chxLstBx1)
        {           
            try
            {                
                OpenSQL Results = new OpenSQL(UserInput.GetCaseName(), UserInput.ADDDatabase);
                Results.Connection.Open();
                SqlDataReader reader = Results.Cmd.ExecuteReader();
                while (reader.Read())
                {
                    {
                        chxLstBx1.Items.Add(reader.GetValue(0));
                    }
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                IForce.Logger("Case List Retrieval Failed");
                MessageBox.Show(ex.Message);
                IForce._iforce.btnConnect.Enabled = true;
            }
        }
        public static void SetCaseName(CheckedListBox chxLstBx1, ItemCheckEventArgs e)
        {
            if (chxLstBx1.CheckedItems.Count == 0)
            {

                UserInput.CaseName = chxLstBx1.SelectedItem.ToString();
                IForce.Logger("Case: "+ UserInput.CaseName);                
                GetCaseDetails();
            }
            else if (chxLstBx1.CheckedItems.Count > 0)
            {
                if ((string)chxLstBx1.SelectedItem == UserInput.CaseName)
                {
                    UserInput.CaseName = String.Empty;
                    UserInput.CaseDataase = String.Empty;
                    IForce.Logger("Case Cleared");
                }
                e.NewValue = CheckState.Unchecked;
                chxLstBx1.ClearSelected();
            }
        }
        public static void GetCaseDetails()
        {
            OpenSQL Results = new OpenSQL(UserInput.GetCaseDetails(), UserInput.ADDDatabase);
            Results.Connection.Open();
            SqlDataReader reader = Results.Cmd.ExecuteReader();
            while (reader.Read())
            {
                UserInput.CPEID = (int)reader.GetValue(0);
                UserInput.CaseName = reader.GetValue(1).ToString();
                UserInput.CaseDataase = reader.GetValue(2).ToString();
                UserInput.CaseDir = reader.GetValue(3).ToString();
                string path = UserInput.CaseDir;
                path.Trim();
                if (!path.EndsWith("\\")) path += "\\";
                UserInput.OutputPath = Path.Combine(path, @"Images\API\");                
            }
            reader.Close();
            Results.Connection.Close();
            IForce.Logger("CPEID: "+UserInput.CPEID);
            IForce.Logger("CaseName: " + UserInput.CaseName);
            IForce.Logger("CaseDatabase: " + UserInput.CaseDataase);
            IForce.Logger("Case Directory: " + UserInput.CaseDir);
            GetInstalledComponents();
            GetEcapconfig();
            GetIntegrationDir();
            GetUserKey();
            UserInput.SetPaths();
            
            ResetSettingsToUI();
        }
        public static void GetInstalledComponents()
        {
            OpenSQL Results = new OpenSQL(UserInput.GetInstalledComponents(), UserInput.ADDDatabase);
            Results.Connection.Open();
            DataTable tbl = new DataTable();
            tbl.Load(Results.Cmd.ExecuteReader());
            DataRow[] row = tbl.Select("Descr = 'ADDService'");
            UserInput.IproSvcURL = row[0]["Endpoint"].ToString();
            row = tbl.Select("Descr = 'EclipseWebService'");
            UserInput.IproURL = row[0]["Endpoint"].ToString();
        }
        public static void GetEcapconfig()
        {   
            OpenSQL Results = new OpenSQL(UserInput.GetEcapConfig(), UserInput.ADDDatabase);
            Results.Connection.Open();
            SqlDataReader reader = Results.Cmd.ExecuteReader();
            while (reader.Read())
            {
                UserInput.EcapConfig = reader.GetValue(0).ToString();
            }
            reader.Close();
            Results.Connection.Close();
            IForce.Logger("EcapConfig Database Name: " + UserInput.EcapConfig);            
        }
        public static void GetIntegrationDir()
        {
            OpenSQL Results = new OpenSQL(UserInput.GetIntegrationDir(), UserInput.EcapConfig);
            Results.Connection.Open();
            SqlDataReader reader = Results.Cmd.ExecuteReader();
            while (reader.Read())
            {   string str = reader.GetValue(0).ToString();
                str.Trim();
                if (!str.EndsWith("\\")) str += "\\"; 
                UserInput.IntegrationDir = str;
                UserInput.SourcePath = Path.Combine(UserInput.IntegrationDir, @"Natives\");
            }
            reader.Close();
            Results.Connection.Close();
            IForce.Logger("Integration Directory: " + UserInput.IntegrationDir);            
        }
        public static int GetUserKey()
        {
            int Userkey = 0;
            OpenSQL Results = new OpenSQL(UserInput.GetUserId());
            Results.Connection.Open();
            SqlDataReader reader = Results.Cmd.ExecuteReader();
            while (reader.Read())
            {
                Userkey = (int)reader.GetValue(0);
                UserInput.UserID = Userkey;                
            }
            reader.Close();
            Results.Connection.Close();
            if (Userkey == 0)
            {
                IForce.Logger("User name is invalid.");
            }
            return Userkey;
        }
        public static void ResetSettingsToUI()
        {
            WebRequests.startJobRequest(UserInput.SourcePath, UserInput.OutputPath, UserInput.SearchName, UserInput.CaseName, UserInput.CPEID);
            IForce._iforce.rchTxtBx2.Text = UserInput.StartJobRequest;
        }
        public static void ResetSettingsToUiOnly()
        {
            //WebRequests.startJobRequest(UserInput.SourcePath, UserInput.OutputPath);
            IForce._iforce.rchTxtBx2.Text = UserInput.StartJobRequest;
        }
        public static async void ConnectToImage(DataGridView dview1, RichTextBox rchbx1)
        {
            IForce.Logger("Native File Copy In Progress: " + UserInput.SourcePath);
            DataTable res = new DataTable();
            OpenSQL Results = new OpenSQL(UserInput.GetDocids(UserInput.UserID, UserInput.ResultsID));
            Results.Connection.Open();
            res.Load(Results.Cmd.ExecuteReader());
            Results.Connection.Close();
            //dview1.DataSource = res;
            CopyAndRenameFiles(res, rchbx1);
            UserInput.AcquiredToken = _TokenRequest().GetAwaiter().GetResult();
            StartImagingJob(UserInput.StartJobRequest, rchbx1);
            IForce.Logger("Checking Job Status..."); //temp
        }
        public static void Search( int userId, int resultsId)
        {
            DataTable srch = new DataTable();
            OpenSQL Results = new OpenSQL(UserInput.GetDocids(userId, resultsId));
            try
            {
                Results.Connection.Open();
                srch.Load(Results.Cmd.ExecuteReader());
                Results.Connection.Close();
                UserInput.DocCount = srch.Rows.Count;
                IForce.dgview(srch);
                IForce.srchCount(UserInput.DocCount.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

     


        internal static async void CopyAndRenameFiles(DataTable _res, RichTextBox rchbx1)
        {
            try
            {
                var docInfos = new List<DocInfo>();
                var errordocs = new List<string>();
                int i = 0; 

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
                        i++;
                        //ProgressChanged
                        //IForce.Logger($"Files Coppied: {i}");
                    }
                    catch { errordocs.Add(x.BegDoc); } // rchbx1.AppendText(@"\r\n" + x.BegDoc + " " + ex.Message);
                });
                if (errordocs.Count > 0)
                {
                    IForce.Logger("ERRORS:");

                    foreach (string doc in errordocs)
                    {                        
                        IForce.ListLogger(doc);
                    }
                }
                else
                {
                    IForce.Logger("All files copied successfully.");
                }
            }
            catch(Exception ex)
            {
                IForce.Logger(ex.Message);
                return;
            }
        }
        public static async Task<string> _TokenRequest()
        {
            try
            {
                IForce.Logger("Acquiring authorization token.");
                var identityServerUrl = UserInput.IdentURL + "/auth";
                var client = new HttpClient();
                var discoveryRequest = new DiscoveryDocumentRequest //Well known Config - tells you what endpoint to hit
                {
                    Address = identityServerUrl,
                    Policy = new DiscoveryPolicy
                    {
                        RequireHttps = true
                    }
                };
                var discoveryDocument = client.GetDiscoveryDocumentAsync(discoveryRequest).GetAwaiter().GetResult();
                if (discoveryDocument.IsError) throw new Exception(discoveryDocument.Error);
                var tokenEndpoint = discoveryDocument.TokenEndpoint;
                var tokenResponse = client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest //requests the token
                {
                    Address = tokenEndpoint,
                    ClientId = "iforce",
                    ClientSecret = "iforce",
                    Scope = "ipro.api ipro.superadmin"
                })
                .GetAwaiter().GetResult();
                var accessToken = tokenResponse.AccessToken;
                if (accessToken != null)
                {
                    IForce.Logger("Token Acquired.");
                }
                return accessToken;
            }
            catch (Exception ex)
            {
                IForce.Logger(ex.Message);
                throw;
            }
        }     
        //public static void TokenRequest(string _postdata, RichTextBox richTextBox)
        //{
        //    try
        //    {
        //        IForce.Logger("Acquiring authorization token.");
        //        WebRequest request = WebRequest.Create(UserInput.IproURL + WebRequests.authURLSuffix);
        //        request.Method = "POST";
        //        string postData = _postdata;
        //        byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        //        request.ContentType = "application/x-www-form-urlencoded";
        //        request.ContentLength = byteArray.Length;
        //        Stream dataStream = request.GetRequestStream();
        //        dataStream.Write(byteArray, 0, byteArray.Length);
        //        dataStream.Close();
        //        //get response
        //        WebResponse response = request.GetResponse();
        //        dataStream = response.GetResponseStream();
        //        IForce.Logger("WebResponse: " + ((HttpWebResponse)response).StatusDescription);
        //        StreamReader reader = new StreamReader(dataStream);
        //        string responseFromServer = reader.ReadToEnd();
        //        JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer);
        //        var token = jObject.SelectToken("access_token");
        //        UserInput.AcquiredToken = token.ToString();
        //            IForce.Logger("Token acquired.");
        //        // Clean up the streams.
        //        reader.Close();
        //        dataStream.Close();
        //        response.Close();
        //        //Start call for job start
        //        //StartImagingJob(WebRequests.startJobRequest(UserInput.SourcePath, UserInput.OutputPath), richTextBox);
        //    }
        //    catch(Exception ex)
        //    {
        //        IForce.Logger("Token acquisition failed. "+ ex.Message);
        //    }               
        //}
        public static void StartImagingJob(string _postdata, RichTextBox richTextBox)
        {
            try
            {
                IForce.Logger("Job Creation Request Initiated.");
                WebRequest request = WebRequest.Create(UserInput.IdentURL + WebRequests.jobStartURLsuffix);
                request.Method = "POST";
                request.Headers.Add($"authorization: Bearer {UserInput.AcquiredToken}");
                string postData = _postdata;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/json-patch+json";
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                // Get the response.
                WebResponse response = request.GetResponse();                
                IForce.Logger("Job Creation Response: "+ ((HttpWebResponse)response).StatusDescription);
                UserInput.Location = ((HttpWebResponse)response).Headers.Get("Location");
                UserInput.JobID = UserInput.Location.Split('/').Last();
                IForce.Logger("JobID: " + UserInput.JobID);

                SetTimer();
            }
            catch(Exception ex)
            {
                IForce.Logger("Unable to create imaging Job. " + ex.Message);                
            }          
        }
        




        private static System.Timers.Timer aTimer;
        private static string status;
        public static bool importStarted = false;

        private static void SetTimer()
        {
            // Create a timer with a 7 second interval.
            aTimer = new System.Timers.Timer(7000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (status == "Completed")
            {
                aTimer.Stop();
                if(importStarted == false)
                {
                    ReadDisk files = new ReadDisk();
                    DocumentIterator importDocs = new DocumentIterator(files.getFilePaths(UserInput.OutputPath));
                    //DocumentIterator.IterateDocuments(ReadDisk.getFilePaths(UserInput.OutputPath));
                    status = string.Empty;               
                }                
            }
            else
            {
                try
                {
                    JobStatusCheck();
                }
                catch(Exception ex)
                {
                    IForce.Logger(ex.Message);
                        if(ex.Message == "The remote server returned an error: (401) Unauthorized.")
                        {
                            UserInput.AcquiredToken = _TokenRequest().GetAwaiter().GetResult();
                        }                    
                }
            }            
        }
        public static void JobStatusCheck()
        {           
            WebRequest request = WebRequest.Create(WebRequests.getJobDetails(UserInput.IdentURL, UserInput.JobID));
            request.Method = "GET";
            request.Headers.Add($"authorization: Bearer {UserInput.AcquiredToken}");
            request.ContentType = "application/x-www-form-urlencoded";
            Stream dataStream;
            //get response
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            //MessageBox.Show("WebResponse: " + ((HttpWebResponse)response).StatusCode);
            IForce.Logger("WebResponse: " + ((HttpWebResponse)response).StatusCode);            
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer);
            var data = jObject.SelectToken("data");
            JObject jObjectChild = JObject.Parse(data.ToString());
            var jobStatus = jObjectChild.SelectToken("status");
            string details = jObjectChild.SelectToken("queue").ToString();
            IForce.Logger(jobStatus.ToString() + Environment.NewLine + details);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
            status = jobStatus.ToString();            
        }
        public static void SaveLog()
        {
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFile1 = new SaveFileDialog();
            // Initialize the SaveFileDialog to specify the Txt extension for the file.
            saveFile1.DefaultExt = "*.txt";
            saveFile1.Filter = "TXT Files|*.txt";
            // Determine if the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                IForce._iforce.rchTxtBx1.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
            }
        }
        public static bool CheckForExistingImages()
        { 
            IForce.Logger("Checking for existing images.");
            bool okToContinue = false;
            int rows;
            DataTable ResultsTable;
            DataTable srch = new DataTable();
            OpenSQL Results = new OpenSQL(UserInput.CheckForExistingImages());
            try
            {
                Results.Connection.Open();
                srch.Load(Results.Cmd.ExecuteReader());
                Results.Connection.Close();
                ResultsTable = srch;
                rows = ResultsTable.Rows.Count;
                if (rows > 0)
                {
                    UserInput.EnblLaunchBtn = false;
                    IForce.Logger("Images already exist.");
                    var Result = MessageBox.Show("Images already exist. Delete existing images and continue?", "Warning!" ,MessageBoxButtons.YesNo);
                    if(Result == DialogResult.No)
                    {
                        okToContinue = false;
                        return okToContinue;
                        
                    }
                    else if(Result == DialogResult.Yes)
                    {
                        try
                        {
                            OpenSQL DeletePages = new OpenSQL(UserInput.DeleteImagesInSearch());
                            DeletePages.Connection.Open();
                            DeletePages.Cmd.ExecuteNonQuery();
                            DeletePages.Connection.Close();
                            IForce.Logger($"Pages deleted: {rows}");
                            okToContinue = true;
                            return okToContinue;
                        }
                        catch
                        {
                           IForce.Logger("Unabe to delete existing images");
                           okToContinue = false;
                           return okToContinue;
                        }
                    }
                    
                }
                return okToContinue = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return okToContinue;
            }            
        }

        
        //end of IForceAPP class
    }
    public class DocumentIterator
    {
        public DocumentIterator(string[] _path)
        {
            IterateDocuments(_path);
        }
        public static DataTable ResultsTable;
        public static void BuildDatatable()
        {
            DataTable srch = new DataTable();
            OpenSQL Results = new OpenSQL(UserInput.GetDocids(UserInput.UserID, UserInput.ResultsID));
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
                    //MessageBox.Show(ex.ToString());
                }
            }
            IForce.Logger("Import Complete");
            IForce.Logger($"Deleting temporary native file source: {UserInput.SourcePath}");
            DeleteNatives(UserInput.SourcePath);
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
        public static void DeleteNatives(string path)
        {
            string dir = path;
            try
            {
                Directory.Delete(path, true);
            }
            catch(Exception ex)
            {
                IForce.Logger($"Unable to delete temp natives: {path}" + ex.Message);
            }
        }
    }
}
