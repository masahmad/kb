using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using PlayV.Dal;


/// <summary>
/// Summary description for FundManager
/// </summary>
/// 
namespace PlayV.Managers
{

    // Manager class Funds
    public class DbManager
    {


        public DbManager()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public static SqlDataReader GetCommandDDLlist(int commandID)
        {
            SQLParameterList sqlParams = new SQLParameterList();
            sqlParams.AddParameter("@commandId", commandID);
            return DatabaseManager.GetDataReader("spGetCmdDDLlist", sqlParams);
        }
       


        public static DataSet GetAllSystems()
        {
            return DatabaseManager.GetDataSet("spGetAllSystems");
        }


        public static DataSet GetAllCommandQ()
        {
            return DatabaseManager.GetDataSet("spGetCmdQ");
        }


        public static DataSet GetCmdMap(int templateId)
        {
            SQLParameterList sqlParams = new SQLParameterList();
            sqlParams.AddParameter("@templateId", templateId);
            return DatabaseManager.GetDataSet("spGetCmdMap", sqlParams);
        }


        public static string GetNextCommand(int systemId)
        {

            SQLParameterList sqlParams = new SQLParameterList();
            sqlParams.AddParameter("@systemId", systemId);
            return (string) DatabaseManager.ExecuteScalar("spGetCommand",sqlParams).ToString();
    }

       
        public static void SavePoll(string ip, string mac, string authKey)
        {
            SQLParameterList sqlParams = new SQLParameterList();
            sqlParams.AddParameter("@ip", ip);
            sqlParams.AddParameter("@mac", mac);
            sqlParams.AddParameter("@authKey",authKey);
            int result = -1;
             DatabaseManager.ExecuteScalar("spPolling", sqlParams);

        }



        public static void SaveAuthKey(string ip, string mac, string authKey)
        {
            SQLParameterList sqlParams = new SQLParameterList();
            sqlParams.AddParameter("@ip", ip);
            sqlParams.AddParameter("@mac", mac);
            sqlParams.AddParameter("@authKey", authKey);
            int result = -1;
            DatabaseManager.ExecuteScalar("spLogAuthKey", sqlParams);
        }


       


        public static bool CheckSystemExists(string ip, string mac)
        {
            SQLParameterList sqlParams = new SQLParameterList();
            sqlParams.AddParameter("@ip", ip);
            sqlParams.AddParameter("@mac", mac);
            bool rtn = false;
            int result = -1;
            result =  (int) DatabaseManager.ExecuteScalar("spCheckSystem", sqlParams);

            if (result > 0)
                rtn = true;
            else rtn = false;

            return rtn;


        }








        internal static void SaveCommandQ(string cmd , string status, 
            DateTime executeTime, int systemId)
        {


            SQLParameterList sqlParams = new SQLParameterList();
            sqlParams.AddParameter("@cmd", cmd.Trim());
            sqlParams.AddParameter("@status", status);
            sqlParams.AddParameter("@executeTime", executeTime);
            sqlParams.AddParameter("@systemid",systemId);
            int result = -1;
            DatabaseManager.ExecuteNonQuery("spAddCommandQ", sqlParams);

            
        }
    }





}

