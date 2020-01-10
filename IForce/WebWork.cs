using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace IForce
{
    class WebWork
    {
        ///public static AuthenticationHeaderValue Authorization { get; set; }
        public static string Token;
        public static string SessionID;
        public static string ReviewUserSessionID;
        public static string authenticateRequest = $"grant_type=client_credentials&scope=ipro.api&client_id={UserInput.Client_ID}&client_secret={UserInput.Client_Secret}";
        public static string ResultsId;
        


       public WebWork()
        {
            TokenRequest(authenticateRequest);
            StartSession();
            StartReviewUserSession();
            UpdateReviewSession();
            OpenEclipseCase();
            search();
            SearchResults();
            CloseTheCall();

        }

        public static void TokenRequest(string _postdata)
        {   //Make the call
            WebRequest request = WebRequest.Create("https://tst-suptrk034:1125/auth/connect/token");
            request.Method = "POST";
            string postData = _postdata;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
           
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer);
            var token = jObject.SelectToken("access_token");
            Token = token.ToString();

            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

        }

        public static void StartSession()
        {
            WebRequest request = WebRequest.Create("https://tst-suptrk034:1124/api/Session/Start");
            request.Method = "GET";
            request.Headers.Add($"Authorization: Bearer {Token}");

            // Get the response.
            using (WebResponse response = request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                SessionID = responseFromServer.Replace('"', ' ').Trim(); ;
                
            }

        }

        public static void StartReviewUserSession()
        {
            WebRequest request = WebRequest.Create("https://tst-suptrk034:1124/api/ReviewUserSession/StartReviewUserSession/?clientId=ADDWeb&appSessionId=" + SessionID);
            request.Method = "GET";
            request.Headers.Add($"Authorization: Bearer {Token}");

            // Get the response.
            using (WebResponse response = request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                ReviewUserSessionID = responseFromServer.Trim('\"');
                
            }


        }

        public static void UpdateReviewSession()
        {
            WebRequest request = WebRequest.Create("https://tst-suptrk034:1124//api//ReviewUserSession//UpdateReviewUserSessionCaseProductEnvironmentId?sessionId=" + ReviewUserSessionID + "&caseProductEnvironmentId=1");
            request.Method = "GET";
            request.Headers.Add($"Authorization: Bearer {Token}");
            request.Headers.Add($"iprosession: {SessionID}");
            //Get the response
            using (WebResponse response = request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                
            }


        }

        public static void OpenEclipseCase()
        {
            WebRequest request = WebRequest.Create("https://tst-suptrk034//api//Case//OpenCase//?caseId=1&resetUsersSearchCache=true");
            request.Method = "GET";
            request.Headers.Add($"Authorization: Bearer {Token}");
            request.Headers.Add($"iprosession: {SessionID}");

            using (WebResponse response = request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                
            }

        }


        public static void search()
        {
            try
            {   //Make the call
                string _postdata = "";
                WebRequest request = WebRequest.Create("https://tst-suptrk034/api/SearchHistory/SearchDocuments?searchId=16");
                request.Method = "POST";
                request.Headers.Add($"iprosession: {SessionID}");
                request.Headers.Add($"Authorization: Bearer {Token}");
                string postData = _postdata;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/json; charset=utf-8";
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                // Get the response.
                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer);
                ResultsId = jObject.SelectToken("ResultsId").ToString();
                //Log It

                reader.Close();
            }
            catch (Exception ex)
            {
                
            }

        }


        public static void SearchResults()
        {
            try
            {
                WebRequest request = WebRequest.Create($"https://tst-suptrk034/api/SearchResults/GetSearchResultDocIds?resultsId={ResultsId}");
                request.Method = "GET";
                request.Headers.Add($"iprosession: {SessionID}");
                request.Headers.Add($"Authorization: Bearer {Token}");
                Stream dataStream;
                // Get the response.
                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                MessageBox.Show(responseFromServer.ToString());
            }
            catch (Exception ex)
            {
                
            }

        }


        public static void CloseTheCall()
        {

            WebRequest request = WebRequest.Create($"https://tst-suptrk034:1124/api/Session/Close/{SessionID}");
            request.Method = "GET";
            request.Headers.Add($"Authorization: Bearer {Token}");
            Stream dataStream;
            // Get the response.
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            
        }

    }
}
