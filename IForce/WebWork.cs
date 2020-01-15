using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Net.Http;


namespace IForce
{
    class WebWork
    {
        
        public string Token;
        public string SessionID;
        public string ReviewUserSessionID;
        public string authenticateRequest = $"grant_type=client_credentials&scope=ipro.api&client_id={UserInput.Client_ID}&client_secret={UserInput.Client_Secret}";
        public string searchid;
        public string ResultsId;
        public string Count;



        public WebWork()
        {
            try
            {
                TokenRequest(authenticateRequest);
                StartSession();
                StartReviewUserSession();
                UpdateReviewSession();
                OpenEclipseCase();
                SearchList();
                ResultsId = search();
                //SearchResults();
                CloseTheCall();
            }
            catch (Exception ex)
            {

                IForce.Logger(ex.Message);
            }

        }



        public void TokenRequest(string _postdata)
        {
            try
            {
                IForce.Logger("Acquiring access token.");
                string postData = _postdata;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                //Make the call
                WebRequest request = WebRequest.Create("https://tst-suptrk034:1125/auth/connect/token");
                request.Method = "POST";
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
            catch (Exception ex)
            {

                IForce.Logger(ex.Message);
            }
            
        }

        public void StartSession()
        {
            try
            {

                IForce.Logger("Nuclues session starting.");
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
            catch (Exception ex)
            {

                IForce.Logger(ex.Message);
            }
            
        }

        public void StartReviewUserSession()
        {
            try
            {
                IForce.Logger("Review user session starting.");
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
            catch (Exception ex)
            {
                IForce.Logger(ex.Message);
            }
        }

        public void UpdateReviewSession()
        {
            try
            {
                IForce.Logger($"Setting case context to caseproductenvironmentID: {UserInput.CPEID}.");
                WebRequest request = WebRequest.Create("https://tst-suptrk034:1124//api//ReviewUserSession//UpdateReviewUserSessionCaseProductEnvironmentId?sessionId=" + ReviewUserSessionID + "&caseProductEnvironmentId=" + UserInput.CPEID);
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
            catch (Exception ex)
            {

                IForce.Logger(ex.Message);
            }           
        }

        public void OpenEclipseCase()
        {
            try
            {
                IForce.Logger("Resetting user search cache.");
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
            catch (Exception ex)
            {
                IForce.Logger(ex.Message);
            }
            
        }

        public void SearchList()
        {
            try
            {
                IForce.Logger("Getting authorized search list.");
                WebRequest request = WebRequest.Create("https://tst-suptrk034//api//SearchHeader//GetAuthorized");
                request.Method = "GET";
                request.Headers.Add($"Authorization: Bearer {Token}");
                request.Headers.Add($"iprosession: {SessionID}");

                using (WebResponse response = request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();

                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    var records = ser.Deserialize<List<SearchIdList>>(responseFromServer);
                    var target = records.Find(x => x.Name.Equals(IForce._iforce.tbxSearchName.Text));
                    searchid = target.Id.ToString();

                }
            }
            catch (Exception ex)
            {

                IForce.Logger(ex.Message);
            }
            
        }

        public string search()
        {
            IForce.Logger($"Executing Search: {IForce._iforce.tbxSearchName.Text}.");
            try
            {   //Make the call
                string _postdata = "";
                WebRequest request = WebRequest.Create($"https://tst-suptrk034/api/SearchHistory/SearchDocuments?searchId={searchid}");
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
                Count = jObject.SelectToken("Count").ToString();

                //Log It

                reader.Close();
                return ResultsId;
                
            }
            catch (Exception ex)
            {
                IForce.Logger(ex.Message);
                return "0";
            }

        }


        public void SearchResults()
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

            }
            catch (Exception ex)
            {
                IForce.Logger(ex.Message);
            }

        }


        public void CloseTheCall()
        {

            try
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
            catch (Exception ex)
            {

                IForce.Logger(ex.Message);
            }

        }

    }
    class SearchIdList
    {
        public int Id;
        public string Name;
        public int ParentFolderId;
        public string CreatedByUserName;

    }


}