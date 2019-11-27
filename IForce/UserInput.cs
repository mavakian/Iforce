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
        public static string CaseDataase { get; set; }    //= "MJA_Eclipse_12_Case000024";
        public static string SQLUserName { get; set; }    //= "mavakiansql";
        public static string Password { get; set; }       //= "iprotech";
        //API
        public static string IproURL { get; set; } 
        public static string Client_ID { get; set; }
        public static string Client_Secret { get; set; }
        //Paths
        public static string SourcePath { get; set; }  //This could be the integration directory
        public static string OutputPath { get; set; } //This should be the case directory
        //Review
        public static int ResultsID { get; set; } = 1; //search resuts id from CaseDB.UserTables.SearchResultsUser[Dim_User.UserID]
        public static string ReviewUsername { get; set; }
        public static int UserID { get; set; } = 1;
        //Queries
        public static string GetDocids()
        {
            string sqlqry = $"SELECT R1.DocId, BEGDOC, Native, NativeFileExtension " +
                            $"FROM[UserTables].[SearchResults{UserInput.UserID}] R1 " +
                            $"JOIN vDocumentFields DF  WITH(NOLOCK) ON DF.DocId = R1.DocId " +
                            $"WHERE RESULTSID IN ({UserInput.ResultsID})";
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
    }

   



}

