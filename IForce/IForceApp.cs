﻿using System;
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
using Newtonsoft.Json;
using System.Timers;

namespace IForce
{
    class IForceApp
    {

        //Program
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
                // SetCaseDatabsse();
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
                UserInput.OutputPath = reader.GetValue(3).ToString() + @"\Api\";
                

            }
            reader.Close();
            Results.Connection.Close();
                IForce.Logger("CPEID: "+UserInput.CPEID);
                IForce.Logger("CaseName: " + UserInput.CaseName);
                IForce.Logger("CaseDatabase: " + UserInput.CaseDataase);
                IForce.Logger("Case Directory: " + UserInput.OutputPath);
            GetEcapconfig();
            ResetSettingsToUI();
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
            GetIntegrationDir();
        }

        public static void GetIntegrationDir()
        {
            OpenSQL Results = new OpenSQL(UserInput.GetIntegrationDir(), UserInput.EcapConfig);
            Results.Connection.Open();
            SqlDataReader reader = Results.Cmd.ExecuteReader();
            while (reader.Read())
            {
                UserInput.SourcePath = reader.GetValue(0).ToString() + @"Natives\" ;

            }
            reader.Close();
            Results.Connection.Close();
                IForce.Logger("Integration Directory: " + UserInput.SourcePath);
            GetUserKey();
        }
        public static void GetUserKey()
        {
            OpenSQL Results = new OpenSQL(UserInput.GetUserId());
            Results.Connection.Open();
            SqlDataReader reader = Results.Cmd.ExecuteReader();
            while (reader.Read())
            {
                UserInput.UserID = (int)reader.GetValue(0);
            }
            reader.Close();
                IForce.Logger("UserID: " + UserInput.UserID);
            Results.Connection.Close();
        }

        public static void ResetSettingsToUI()
        {
            WebRequests.startJobRequest(UserInput.SourcePath, UserInput.OutputPath);
            IForce._iforce.rchTxtBx2.Text = UserInput.StartJobRequest;
        }

        public static void ConnectToImage(DataGridView dview1, RichTextBox rchbx1)
        {
            IForce.Logger("Native File Copy In Progress: " + UserInput.SourcePath);
            DataTable res = new DataTable();
            OpenSQL Results = new OpenSQL(UserInput.GetDocids());
            Results.Connection.Open();
            res.Load(Results.Cmd.ExecuteReader());
            Results.Connection.Close();
            dview1.DataSource = res;
            CopyAndRenameFiles(res, rchbx1);
            tokenRequest(WebRequests.authenticateRequest(), rchbx1);
            StartImagingJob(UserInput.StartJobRequest, rchbx1);
            IForce.Logger("Checking Job Status..."); //temp
        }

        public static void Search(DataGridView dview1)
        {
            DataTable srch = new DataTable();
            OpenSQL Results = new OpenSQL(UserInput.GetDocids());
            try
            {
                Results.Connection.Open();
                srch.Load(Results.Cmd.ExecuteReader());
                Results.Connection.Close();
                dview1.DataSource = srch;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        internal static void CopyAndRenameFiles(DataTable _res, RichTextBox rchbx1)
        {
           
            var docInfos = new List<DocInfo>();
            var errordocs = new List<string>();

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
                catch{errordocs.Add(x.BegDoc); } // rchbx1.AppendText(@"\r\n" + x.BegDoc + " " + ex.Message);
            });

            IForce.Logger("ERRORS:");

            foreach(string doc in errordocs)
            {
                IForce.ListLogger(doc);
            }
            


        }

     
        public static void tokenRequest(string _postdata, RichTextBox richTextBox)
        {
            try
            {
                IForce.Logger("Acquiring authorization token.");

                WebRequest request = WebRequest.Create(UserInput.IproURL + WebRequests.authURLSuffix);
                request.Method = "POST";
                string postData = _postdata;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                //get response
                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();

                IForce.Logger("WebResponse: " + ((HttpWebResponse)response).StatusDescription);


                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer);
                var token = jObject.SelectToken("access_token");
                UserInput.AcquiredToken = token.ToString();
                    IForce.Logger("Token acquired.");
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();
                //Start call for job start
                //StartImagingJob(WebRequests.startJobRequest(UserInput.SourcePath, UserInput.OutputPath), richTextBox);
                


            }
            catch(Exception ex)
            {
                IForce.Logger("Token acquisition failed. "+ ex.Message);
            }
               
        }

        public static void StartImagingJob(string _postdata, RichTextBox richTextBox)
        {
            try
            {
                    IForce.Logger("Job Creation Request Initiated.");
                WebRequest request = WebRequest.Create(UserInput.IproURL + WebRequests.jobStartURLsuffix);
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
                dataStream = response.GetResponseStream();
                
                    IForce.Logger("Job Creation Response: "+ ((HttpWebResponse)response).StatusDescription);
                UserInput.Location = ((HttpWebResponse)response).Headers.Get("Location");
                    //IForce.Logger(UserInput.Location);


                StreamReader reader = new StreamReader(dataStream);
                // string responseFromServer = reader.ReadToEnd();
                // IForce.Logger(responseFromServer);
                // IForce.Logger("Imaging Job available in Job Manager.");
                // richTextBox.AppendText(responseFromServer);

                //GetJobID()
                //GetJobStatus()
                //When Status = Complete Then

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
        public static bool importStarted;
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
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
                    DocumentIterator.IterateDocuments(ReadDisk.getFilePaths(UserInput.OutputPath));
                }
                
            }
            else
            {
                JobStatusCheck();
            }
            
        }
        public static void JobStatusCheck()
        {
            IForce.Logger("Checking Job Status...");
            WebRequest request = WebRequest.Create(WebRequests.getJobDetails(UserInput.JobID));
            request.Method = "GET";
            request.Headers.Add($"authorization: Bearer {UserInput.AcquiredToken}");
            request.ContentType = "application/x-www-form-urlencoded";
            //request.ContentLength = byteArray.Length;
            Stream dataStream;// = request.GetRequestStream();
           // dataStream.Write(byteArray, 0, byteArray.Length);
           // dataStream.Close();
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
            //MessageBox.Show(jobStatus.ToString()+ jObjectChild.SelectToken("queue").ToString());
            IForce.Logger(jobStatus.ToString() + Environment.NewLine + details);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
            status = jobStatus.ToString();
            

        }

        //end of IForceAPP class

    }



    public static class DocumentIterator
    {
        public static DataTable ResultsTable;


        public static void BuildDatatable()
        {
            DataTable srch = new DataTable();
            OpenSQL Results = new OpenSQL(UserInput.GetDocids());
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
                //RchBox1.AppendText($"\r\n {begdoc}");

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

                    MessageBox.Show(ex.ToString());

                }

            }
            IForce.Logger("Import Complete");
            MessageBox.Show("Done.");
        }
    }


}
