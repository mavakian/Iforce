using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace IForce
{
   public static class UserInput
    {   //SQL
        public static string ServerName { get; set; }     //= @"tst-supsql001\sup12";
        public static string ADDDatabase { get; set; }   
        public static string CaseDataase { get; set; }    //= "MJA_Eclipse_12_Case000024";
        public static string SQLUserName { get; set; }    //= "mavakiansql";
        public static string Password { get; set; }      //= "iprotech";
        public static string CaseName { get; set; }
        public static int CPEID { get; set; }
        public static string EcapConfig { get; set; }

        //API
        public static string IproURL { get; set; } 
        public static string Client_ID { get; set; }
        public static string Client_Secret { get; set; }
        public static string AcquiredToken { get; set; }
        public static string Response { get; set; }
        public static string Request { get; set; }
        //Paths
        public static string SourcePath { get; set; } //= @"\\testing.local\dfs\SupportTestRacks\TST-SUPTRK012\Integration\34"; //This could be the integration directory
        public static string OutputPath { get; set; } //This should be the case directory 
        //Review
        public static int ResultsID { get; set; } = 1; //search resuts id from CaseDB.UserTables.SearchResultsUser[Dim_User.UserID]
        public static string ReviewUsername { get; set; }
        public static int UserID { get; set; } = 1;
        
        //Queries

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

        public static string GetDocids()
        {
            string sqlqry = $"SELECT R1.DocId, BEGDOC, Native, NativeFileExtension " +
                            $"FROM[UserTables].[SearchResults{UserInput.UserID}] R1 " +
                            $"JOIN vDocumentFields DF  WITH(NOLOCK) ON DF.DocId = R1.DocId " +
                            $"WHERE RESULTSID IN ({UserInput.ResultsID})";
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
            string sqlqry = $"SELECT UserKey FROM ActivityTracking.DIM_User WHERE UserName = '{UserInput.ReviewUsername}'";
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

    public class WebRequests
    {
        public static string authURLSuffix = "/auth/connect/token";
        public static string jobStartURLsuffix = "/core/jobmanager/api/jobs/image";

        public static string authenticateRequest = $"client_id={UserInput.Client_ID}&client_secret={UserInput.Client_Secret}&grant_type=client_credentials";

        public static string startJobRequest(string pathIn, string pathOut)
        {
            pathIn = pathIn.Replace(@"\", @"\\\\");
            pathOut = pathOut.Replace(@"\", @"\\\\");

            string startJobRequest = "{ \"description\": \"Imaging Request\", \"caseName\": \"Name of Case (Optional)\", \"caseId\": \"4 (Optional)\", \"submittedOnBehalfOf\": \"Name Of Submitter (Optional)\", \"request\": { \"inputDirectory\": \"" + pathIn + "\", \"outputDirectory\": \"" + pathOut + "\", \"splitImages\": false, \"fileSettings\": { \"colorDepth\": \"TrueColor\", \"paperSize\": \"AsIs\", \"orientation\": \"AsIs\" }, \"wordProcessingOptions\": { \"colorDepth\": \"TrueColor\", \"paperSize\": \"AsIs\", \"orientation\": \"AsIs\", \"revisions\": \"AsIs\", \"summaryGenerateImage\": false, \"summaryIncludeDocumentProperties\": false, \"summaryIncludeRevisions\": false, \"summaryIncludeComments\": false, \"summaryIncludeRoutingSlips\": false, \"linkedContentSummary\": false, \"dateFieldHandling\": \"DoNotReplace\", \"dateFieldComments\": \"\", \"filenameFieldHandling\": \"DoNotReplace\", \"filenameFieldComments\": \"\", \"resolution\": 300, \"showHiddenText\": true, \"scaleToPage\": false, \"customPaperSizeLength\": 11, \"customPaperSizeWidth\": 8.5 }, \"excelProcessingOptions\": { \"autoFilter\": false, \"autofitColumns\": false, \"autofitRows\": false, \"blankPageRemovalMethod\": \"BothPageOrderOptions\", \"centerOnPageHorizontally\": false, \"centerOnPageVertically\": false, \"clearPrintArea\": true, \"clearPrintTitleColumns\": true, \"clearPrintTitleRows\": true, \"colorDepth\": \"EightBitColor\", \"comments\": \"AsDisplayed\", \"customPaperSizeLength\": 11, \"customPaperSizeWidth\": 8.5, \"customPaperSizeUnitsInches\": true, \"dateFieldComments\": \"\", \"dateFieldHandlingType\": \"ReplaceWithDateCreated\", \"disableExcelFilters\": false, \"displayHeadings\": true, \"doNotIncludeFooters\": true, \"doNotIncludeHeaders\": true, \"excelPaperSize\": \"Letter\", \"expandPivotTables\": false, \"headerFooterFilenameFieldComments\": \"\", \"headerFooterFilenameFieldHandling\": \"ReplaceWithFilepath\", \"linkedContentSummary\": false, \"noFillColor\": true, \"orientation\": \"Portrait\", \"pageOrder\": \"DownAndOver\", \"printGridLines\": true, \"revealHiddenColumns\": false, \"revealHiddenRows\": false, \"scaling\": \"AdjustToPercent\", \"scalingPagesTall\": 50, \"scalingPagesWide\": 1, \"scalingPercent\": 100, \"summaryGenerateImage\": false, \"summaryIncludeComments\": false, \"summaryIncludeDocumentProperties\": false, \"summaryIncludeFormulas\": false, \"unhideVeryHiddenWorksheets\": false, \"unhideWindows\": false, \"unhideWorksheets\": true, \"wrapText\": true }, \"htmlProcessingOptions\": { \"shrinkToFit\": false }, \"powerPointProcessingOptions\": { \"asIs\": false, \"printHiddenSlides\": true, \"printComments\": false, \"frameSlides\": true, \"scaleToFitPage\": false, \"processWithStellent\": false, \"outputType\": \"OutputSlides\", \"slideSize\": \"LetterPaper\", \"paperSize\": \"Letter\", \"pageOrientation\": \"Landscape\", \"slideOrientation\": \"Portrait\", \"handoutOrder\": \"Horizontal\", \"colorDepth\": \"EightBitColor\", \"linkedContentSummary\": false, \"notesAndHandouts\": { \"showHeader\": true, \"showHeaderAsIs\": true, \"headerText\": \"\", \"showPageNumber\": \"AsIs\", \"showDateAndTime\": true, \"updateDateAndTimeFormat\": \"Automatically\", \"updateDateAndTimeAutomaticallyType\": \"ppDateTimeUseDateLastSaved\", \"updateDateAndTimeAutomaticallyFormat\": \"ppDateFormatAsIs\", \"fixedDateAndTimeText\": \"\", \"showFooter\": true, \"showFooterAsIs\": true, \"footerText\": \"\" }, \"slides\": { \"showSlideNumber\": \"AsIs\", \"showOnTitleSlide\": \"AsIs\", \"showDateAndTime\": false, \"updateDateAndTimeFormat\": \"Automatically\", \"updateDateAndTimeAutomaticallyType\": \"ppDateTimeUseDateLastSaved\", \"updateDateAndTimeAutomaticallyFormat\": \"ppDateFormatAsIs\", \"fixedDateAndTimeText\": \"\", \"showFooter\": true, \"showFooterAsIs\": true, \"footerText\": \"\" } }, \"pageCharacterThreshold\": 75, \"languageSet\": [ \"English\" ], \"timeZoneId\": \"UTC\" }}";

            return startJobRequest;
        }
    }



}

