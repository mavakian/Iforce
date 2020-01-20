using System;
using System.Data.SqlClient;


namespace IForce
{
   public static class UserInput
    {   //SQL
        public static string ServerName { get; set; } 
        public static string ADDDatabase { get; set; }   
        public static string CaseDataase { get; set; }    
        public static string CaseDir { get; set; } 
        public static string IntegrationDir { get; set; }
        public static string SQLUserName { get; set; }
        public static string Password { get; set; }
        public static string CaseName { get; set; }
        public static int CPEID { get; set; }
        public static string EcapConfig { get; set; }
        public static int DocCount { get; set; }


        //API
        public static string IproURL { get; set; }  // = "https://tst-suptrk034:1125";
        public static string IproSvcURL { get; set; }
        public static string IdentURL { get; set;  }
        public static string Client_ID { get; set; } = "iforce";
        public static string Client_Secret { get; set; } = "iforce";
        public static string AcquiredToken { get; set; }
        public static string Response { get; set; }
        public static string Request { get; set; }
        public static string Location { get; set; }
        public static string JobID { get; set; }
        //Paths
        public static string SourcePath { get; set; } //This should be the integration directory
        public static string OutputPath { get; set; } //This should be the case directory 
        //Review
        public static int ResultsID { get; set; } //search resuts id from CaseDB.UserTables.SearchResultsUser[Dim_User.UserID]
        public static string ReviewUsername { get; set; }
        public static int UserID { get; set; }  
        
        //Queries
        public static string GetInstalledComponents()
        {
            string sqlqry = $"SELECT ICT.[Descr], IC.[Endpoint] FROM Enterprise.InstalledComponent IC " +
                            $"JOIN Enterprise.InstalledComponentType ICT ON ICT.InstalledComponentTypeId = IC.InstalledComponentTypeId " +
                            $"WHERE ICT.Descr IN  ( 'ADDService', 'EclipseWebService')";
            return sqlqry;
        }

        public static string GetCaseName()
        {
            string sqlqry = $"SELECT [Name] FROM Enterprise.CaseProductEnvironment WHERE ProductID = 3";
            return sqlqry;
        }
        public static string GetCaseDatabase()
        {
            string sqlqry = $"SELECT DatabaseName FROM Enterprise.CaseProductEnvironment WHERE [Name] = '{CaseName}'";
            return sqlqry;
        }

        public static string GetCPEID()
        {
            string sqlqry = $"SELECT CaseProductEnvironmentID FROM Enterprise.CaseProductEnvironment WHERE [Name] = '{CaseName}'";
            return sqlqry;
        }
        public static string GetDataDir()
        {
            string sqlqry = $"SELECT PropertyValue FROM Enterprise.CaseProductEnvironmentProperty CPP" +
                            $"JOIN Enterprise.CaseProductenvironmentProprtyName CPN ON CPN.CaseProductEnvironmentPropertyNameID = CPP.CaseProductEnvironmentPropertyNameID " +
                            $"WHERE PropertyName = 'DataDirectory' AND CPP.CaseProductEnvironmentID = {CPEID}";
            return sqlqry;
        }

        public static string GetDocids(int userId, int resultsId)
        {
            string sqlqry = $"SELECT R1.DocId, BEGDOC, Native, NativeFileExtension " +
                            $"FROM[UserTables].[SearchResults{userId}] R1 " +
                            $"JOIN vDocumentFields DF  WITH(NOLOCK) ON DF.DocId = R1.DocId " +
                            $"WHERE RESULTSID IN ({resultsId})";
            return sqlqry;
        }

        public static string GetCaseDetails()
        {
            string sqlqry = $"SELECT CPE.CaseProductEnvironmentId, [Name], DatabaseName, CPP.PropertyValue AS DataFolder " +
                            $"FROM Enterprise.CaseProductEnvironment CPE " +
                            $"JOIN Enterprise.CaseProductEnvironmentProperty CPP ON CPP.CaseProductEnvironmentId = CPE.CaseProductEnvironmentId " +
                            $"JOIN Enterprise.CaseProductEnvironmentPropertyName CPN ON CPN.CaseProductEnvironmentPropertyNameId = CPP.CaseProductEnvironmentPropertyNameId " +
                            $"WHERE CPE.[NAME] = '{UserInput.CaseName}'AND CPN.PropertyName = 'DataDirectory'";
            return sqlqry;
        }

        public static string GetUserId()
        {
            string sqlqry = $"SELECT UserKey FROM ActivityTracking.DIM_User WHERE UserName = '{UserInput.Client_ID}'";
            return sqlqry;
        }

        public static string GetEcapConfig()
        {
            string sqlqry = $"SELECT MAX(SUBSTRING(ConfigConnectionString " +	
                                            $", PATINDEX('%Initial Catalog=%', ConfigConnectionString)+16 " +
                                                $",PATINDEX('%;%' " +
                                                    $", SUBSTRING(ConfigConnectionString " +
                                                       $", PATINDEX('%Initial Catalog=%', ConfigConnectionString) + 16 " +
                                                        $", LEN(ConfigConnectionString) - PATINDEX('%Initial Catalog=%', ConfigConnectionString) + 16) " +
                                                    $") + LEN(ConfigConnectionString) - (LEN(ConfigConnectionString) - PATINDEX('%Initial Catalog=%', ConfigConnectionString) + 16) " +
                                                $"-(PATINDEX('%Initial Catalog=%', ConfigConnectionString) - 16) - 1)) AS Config, " +
                                  $"MAX(SUBSTRING(ConfigConnectionString " +
                                            $", PATINDEX('%DataSource=%', ConfigConnectionString) + 13 " +
                                                $", PATINDEX('%;%' " +
                                                    $", SUBSTRING(ConfigConnectionString " +
                                                        $", PATINDEX('%Data Source=%', ConfigConnectionString) + 13 " +
                                                        $", LEN(ConfigConnectionString) - PATINDEX('%Data Source=%', ConfigConnectionString) + 13) " +
                                                    $") + LEN(ConfigConnectionString) - (LEN(ConfigConnectionString) - PATINDEX('%Data Source=%', ConfigConnectionString) + 13) " +
                                                $"- (PATINDEX('%Data Source=%', ConfigConnectionString) - 13))) AS Server " +
                                    $"FROM Enterprise.ApplicationEnvironment AE " +
                                    $"WHERE ProductID = 2 AND ConfigConnectionString IS NOT NULL";
            return sqlqry;
        }

        public static string GetIntegrationDir()
        {
            string sqlqry = $"SELECT APILocation From ExternalIntegrationConfiguration";
            return sqlqry;
        }

        public static string InsertFirstPage(int Docid, int i, string begdoc, string file, long filesizeKb, int userid)
        {
            string sqlqry = $"INSERT INTO .dbo.DocumentPages ( Docid, PageNbr, ImageKey, ImageFilePath, Rotation, CreatedDate, ModifiedDate, HasImage, ImageFileSize, CreatedByKey, ModifiedByKey) " +
                            $"SELECT {Docid}, {i}, '{begdoc}', '{file}', 0, GETDATE(), GETDATE(), 1, {filesizeKb}, {userid},{userid}";
            return sqlqry;
        }

        public static string InsertOtherPages(int Docid, int i, string imagekey, string file, int userid)
        {
            string sqlqry = $"INSERT INTO .dbo.DocumentPages ( Docid, PageNbr, ImageKey, ImageFilePath, Rotation, CreatedDate, ModifiedDate, HasImage, ImageFileSize, CreatedByKey, ModifiedByKey) " +
                            $"SELECT {Docid}, {i}, '{imagekey}', '{file}', 0, GETDATE(), GETDATE(), 1, 0, {userid},{userid}";
            return sqlqry;
        }

        public static string UpdateHasImage(int docid)
        {
            string sqlqry = $"EXEC Documents_UpdateHasImageById {docid},1 ";
            return sqlqry;
        }

        public static string GetSessionID()
        {
            string sqlqry = $"SELECT SessionID FROM Enterprise.Session " +
                            $"WHERE Username = '{ReviewUsername}' " +
                            $"AND IssuedDate = (SELECT MAX(IssuedDate) FROM Enterprise.Session WHERE Username = '{ReviewUsername}')";
            return sqlqry;
        }

        public static string CheckForExistingImages()
        {
            string sqlqry = $"SELECT DP.Docid, Imagekey FROM dbo.DocumentPages DP " + 
                            $"JOIN [UserTables].[SearchResults{UserInput.UserID}] R on R.Docid = DP.Docid " +
                            $"WHERE ResultsID = {UserInput.ResultsID} " +
                            $"ORDER BY DP.Docid ASC";
            return sqlqry;
        }

        //Methods
        public static void SaveSettings()
        {
            UserInput.StartJobRequest = IForce._iforce.rchTxtBx2.Text;
        }

        public static void SetPaths()
        {
            UserInput.SourcePath  = UserInput.IntegrationDir + @"Natives\" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + @"\";
            UserInput.OutputPath = UserInput.CaseDir + @"\Images\API\" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + @"\";
        }
        //Web Requests
        public static string StartJobRequest { get; set; }


    }



    public class OpenSQL
    {
        public string ConStr { get; set; }
        public SqlCommand Cmd { get; set; }
        public SqlConnection Connection { get; set; }

        public OpenSQL(string qry)
        {
           

            SqlConnectionStringBuilder conStr = new SqlConnectionStringBuilder
            {
                ["Data Source"] = UserInput.ServerName,
                ["Initial Catalog"] = UserInput.CaseDataase,
                ["User ID"] = UserInput.SQLUserName,
                ["Password"] = UserInput.Password
            };
            ConStr = conStr.ToString();

            SqlConnection connection = new SqlConnection(conStr.ToString());
            Connection = connection;

            SqlCommand cmd = new SqlCommand(qry, Connection);
            Cmd = cmd;
        }

        public OpenSQL(string qry, string adddb)
        {
            
            SqlConnectionStringBuilder conStr = new SqlConnectionStringBuilder
            {
                ["Data Source"] = UserInput.ServerName,
                ["Initial Catalog"] = adddb,
                ["User ID"] = UserInput.SQLUserName,
                ["Password"] = UserInput.Password
            };
            ConStr = conStr.ToString();

            SqlConnection connection = new SqlConnection(conStr.ToString());
            Connection = connection;

            SqlCommand cmd = new SqlCommand(qry, Connection);
            Cmd = cmd;
        }
    }

    public static class WebRequests 
    {
        public static string authURLSuffix = "/auth/connect/token";
        public static string jobStartURLsuffix = "/core/jobmanager/api/jobs/image";

        //public static string authenticateRequest = $"client_id={UserInput.Client_ID}&client_secret={UserInput.Client_Secret}&grant_type=client_credentials";
        public static string authenticateRequest()
        {
            string authenticateRequest = $"client_id={UserInput.Client_ID}&client_secret={UserInput.Client_Secret}&grant_type=client_credentials";
            return authenticateRequest;
        }
        public static void startJobRequest(string pathIn, string pathOut)
        {

            pathIn = pathIn.Replace(@"\", @"\\\\");
            pathOut = pathOut.Replace(@"\", @"\\\\");

            //string startJobRequest = "{ \"description\": \"Imaging Request\", \"caseName\": \"Name of Case (Optional)\", \"caseId\": \"4 (Optional)\", \"submittedOnBehalfOf\": \"Name Of Submitter (Optional)\", \"request\": { \"inputDirectory\": \"" + pathIn + "\", \"outputDirectory\": \"" + pathOut + "\", \"splitImages\": false, \"fileSettings\": { \"colorDepth\": \"TrueColor\", \"paperSize\": \"AsIs\", \"orientation\": \"AsIs\" }, \"wordProcessingOptions\": { \"colorDepth\": \"TrueColor\", \"paperSize\": \"AsIs\", \"orientation\": \"AsIs\", \"revisions\": \"AsIs\", \"summaryGenerateImage\": false, \"summaryIncludeDocumentProperties\": false, \"summaryIncludeRevisions\": false, \"summaryIncludeComments\": false, \"summaryIncludeRoutingSlips\": false, \"linkedContentSummary\": false, \"dateFieldHandling\": \"DoNotReplace\", \"dateFieldComments\": \"\", \"filenameFieldHandling\": \"DoNotReplace\", \"filenameFieldComments\": \"\", \"resolution\": 300, \"showHiddenText\": true, \"scaleToPage\": false, \"customPaperSizeLength\": 11, \"customPaperSizeWidth\": 8.5 }, \"excelProcessingOptions\": { \"autoFilter\": false, \"autofitColumns\": false, \"autofitRows\": false, \"blankPageRemovalMethod\": \"BothPageOrderOptions\", \"centerOnPageHorizontally\": false, \"centerOnPageVertically\": false, \"clearPrintArea\": true, \"clearPrintTitleColumns\": true, \"clearPrintTitleRows\": true, \"colorDepth\": \"EightBitColor\", \"comments\": \"AsDisplayed\", \"customPaperSizeLength\": 11, \"customPaperSizeWidth\": 8.5, \"customPaperSizeUnitsInches\": true, \"dateFieldComments\": \"\", \"dateFieldHandlingType\": \"ReplaceWithDateCreated\", \"disableExcelFilters\": false, \"displayHeadings\": true, \"doNotIncludeFooters\": true, \"doNotIncludeHeaders\": true, \"excelPaperSize\": \"Letter\", \"expandPivotTables\": false, \"headerFooterFilenameFieldComments\": \"\", \"headerFooterFilenameFieldHandling\": \"ReplaceWithFilepath\", \"linkedContentSummary\": false, \"noFillColor\": true, \"orientation\": \"Portrait\", \"pageOrder\": \"DownAndOver\", \"printGridLines\": true, \"revealHiddenColumns\": false, \"revealHiddenRows\": false, \"scaling\": \"AdjustToPercent\", \"scalingPagesTall\": 50, \"scalingPagesWide\": 1, \"scalingPercent\": 100, \"summaryGenerateImage\": false, \"summaryIncludeComments\": false, \"summaryIncludeDocumentProperties\": false, \"summaryIncludeFormulas\": false, \"unhideVeryHiddenWorksheets\": false, \"unhideWindows\": false, \"unhideWorksheets\": true, \"wrapText\": true }, \"htmlProcessingOptions\": { \"shrinkToFit\": false }, \"powerPointProcessingOptions\": { \"asIs\": false, \"printHiddenSlides\": true, \"printComments\": false, \"frameSlides\": true, \"scaleToFitPage\": false, \"processWithStellent\": false, \"outputType\": \"OutputSlides\", \"slideSize\": \"LetterPaper\", \"paperSize\": \"Letter\", \"pageOrientation\": \"Landscape\", \"slideOrientation\": \"Portrait\", \"handoutOrder\": \"Horizontal\", \"colorDepth\": \"EightBitColor\", \"linkedContentSummary\": false, \"notesAndHandouts\": { \"showHeader\": true, \"showHeaderAsIs\": true, \"headerText\": \"\", \"showPageNumber\": \"AsIs\", \"showDateAndTime\": true, \"updateDateAndTimeFormat\": \"Automatically\", \"updateDateAndTimeAutomaticallyType\": \"ppDateTimeUseDateLastSaved\", \"updateDateAndTimeAutomaticallyFormat\": \"ppDateFormatAsIs\", \"fixedDateAndTimeText\": \"\", \"showFooter\": true, \"showFooterAsIs\": true, \"footerText\": \"\" }, \"slides\": { \"showSlideNumber\": \"AsIs\", \"showOnTitleSlide\": \"AsIs\", \"showDateAndTime\": false, \"updateDateAndTimeFormat\": \"Automatically\", \"updateDateAndTimeAutomaticallyType\": \"ppDateTimeUseDateLastSaved\", \"updateDateAndTimeAutomaticallyFormat\": \"ppDateFormatAsIs\", \"fixedDateAndTimeText\": \"\", \"showFooter\": true, \"showFooterAsIs\": true, \"footerText\": \"\" } }, \"pageCharacterThreshold\": 75, \"languageSet\": [ \"English\" ], \"timeZoneId\": \"UTC\" }}";
            string startJobRequest = "{\n  \"description\": \"Imaging Request\",\n  \"caseName\": \"Name of Case (Optional)\",\n  \"caseId\": \"4 (Optional)\",\n  \"submittedOnBehalfOf\": \"Name Of Submitter (Optional)\",\n  \"request\": {\n    \"inputDirectory\": \"" + pathIn + "\",\n    \"outputDirectory\": \"" + pathOut + "\",\n    \"splitImages\": false,\n    \"fileSettings\": {\n      \"colorDepth\": \"TrueColor\",\n      \"paperSize\": \"AsIs\",\n      \"orientation\": \"AsIs\"\n    },\n    \"wordProcessingOptions\": {\n      \"colorDepth\": \"TrueColor\",\n      \"paperSize\": \"AsIs\",\n      \"orientation\": \"AsIs\",\n      \"revisions\": \"AsIs\",\n      \"summaryGenerateImage\": false,\n      \"summaryIncludeDocumentProperties\": false,\n      \"summaryIncludeRevisions\": false,\n      \"summaryIncludeComments\": false,\n      \"summaryIncludeRoutingSlips\": false,\n      \"linkedContentSummary\": false,\n      \"dateFieldHandling\": \"DoNotReplace\",\n      \"dateFieldComments\": \"\",\n      \"filenameFieldHandling\": \"DoNotReplace\",\n      \"filenameFieldComments\": \"\",\n      \"resolution\": 300,\n      \"showHiddenText\": true,\n      \"scaleToPage\": false,\n      \"customPaperSizeLength\": 11,\n      \"customPaperSizeWidth\": 8.5\n    },\n    \"excelProcessingOptions\": {\n      \"autoFilter\": false,\n      \"autofitColumns\": false,\n      \"autofitRows\": false,\n      \"blankPageRemovalMethod\": \"BothPageOrderOptions\",\n      \"centerOnPageHorizontally\": false,\n      \"centerOnPageVertically\": false,\n      \"clearPrintArea\": true,\n      \"clearPrintTitleColumns\": true,\n      \"clearPrintTitleRows\": true,\n      \"colorDepth\": \"EightBitColor\",\n      \"comments\": \"AsDisplayed\",\n      \"customPaperSizeLength\": 11,\n      \"customPaperSizeWidth\": 8.5,\n      \"customPaperSizeUnitsInches\": true,\n      \"dateFieldComments\": \"\",\n      \"dateFieldHandlingType\": \"ReplaceWithDateCreated\",\n      \"disableExcelFilters\": false,\n      \"displayHeadings\": true,\n      \"doNotIncludeFooters\": true,\n      \"doNotIncludeHeaders\": true,\n      \"excelPaperSize\": \"Letter\",\n      \"expandPivotTables\": false,\n      \"headerFooterFilenameFieldComments\": \"\",\n      \"headerFooterFilenameFieldHandling\": \"ReplaceWithFilepath\",\n      \"linkedContentSummary\": false,\n      \"noFillColor\": true,\n      \"orientation\": \"Portrait\",\n      \"pageOrder\": \"DownAndOver\",\n      \"printGridLines\": true,\n      \"revealHiddenColumns\": false,\n      \"revealHiddenRows\": false,\n      \"scaling\": \"AdjustToPercent\",\n      \"scalingPagesTall\": 50,\n      \"scalingPagesWide\": 1,\n      \"scalingPercent\": 100,\n      \"summaryGenerateImage\": false,\n      \"summaryIncludeComments\": false,\n      \"summaryIncludeDocumentProperties\": false,\n      \"summaryIncludeFormulas\": false,\n      \"unhideVeryHiddenWorksheets\": false,\n      \"unhideWindows\": false,\n      \"unhideWorksheets\": true,\n      \"wrapText\": true\n    },\n    \"htmlProcessingOptions\": {\n      \"shrinkToFit\": false\n    },\n    \"powerPointProcessingOptions\": {\n      \"asIs\": false,\n      \"printHiddenSlides\": true,\n      \"printComments\": false,\n      \"frameSlides\": true,\n      \"scaleToFitPage\": false,\n      \"processWithStellent\": false,\n      \"outputType\": \"OutputSlides\",\n      \"slideSize\": \"LetterPaper\",\n      \"paperSize\": \"Letter\",\n      \"pageOrientation\": \"Landscape\",\n      \"slideOrientation\": \"Portrait\",\n      \"handoutOrder\": \"Horizontal\",\n      \"colorDepth\": \"EightBitColor\",\n      \"linkedContentSummary\": false,\n      \"notesAndHandouts\": {\n        \"showHeader\": true,\n        \"showHeaderAsIs\": true,\n        \"headerText\": \"\",\n        \"showPageNumber\": \"AsIs\",\n        \"showDateAndTime\": true,\n        \"updateDateAndTimeFormat\": \"Automatically\",\n        \"updateDateAndTimeAutomaticallyType\": \"ppDateTimeUseDateLastSaved\",\n        \"updateDateAndTimeAutomaticallyFormat\": \"ppDateFormatAsIs\",\n        \"fixedDateAndTimeText\": \"\",\n        \"showFooter\": true,\n        \"showFooterAsIs\": true,\n        \"footerText\": \"\"\n      },\n      \"slides\": {\n        \"showSlideNumber\": \"AsIs\",\n        \"showOnTitleSlide\": \"AsIs\",\n        \"showDateAndTime\": false,\n        \"updateDateAndTimeFormat\": \"Automatically\",\n        \"updateDateAndTimeAutomaticallyType\": \"ppDateTimeUseDateLastSaved\",\n        \"updateDateAndTimeAutomaticallyFormat\": \"ppDateFormatAsIs\",\n        \"fixedDateAndTimeText\": \"\",\n        \"showFooter\": true,\n        \"showFooterAsIs\": true,\n        \"footerText\": \"\"\n      }\n    },\n    \"pageCharacterThreshold\": 75,\n    \"languageSet\": [\n      \"English\"\n    ],\n    \"timeZoneId\": \"UTC\"\n  }\n}";
            
            UserInput.StartJobRequest = startJobRequest;
        }
        public static string getJobDetails(string jobID)
        {
            string getjobdetails = $"https://tst-suptrk034:1125/core/jobmanager/api/jobs/{jobID}";
            return getjobdetails;
        }
    }



}

