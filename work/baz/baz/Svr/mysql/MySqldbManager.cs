using System;
using System.Data;
using System.Configuration;
using System.Web;
using MySql.Data.MySqlClient;
using PlayV.MYSqlDal;


/// <summary>
/// Summary description for FundManager
/// </summary>
/// 
namespace PlayV.MySqlManagers
{

    // Manager class Funds
    public class MySqlDbManager
    {


        public MySqlDbManager()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public static MySqlDataReader GetCommandDDLlist(int commandID)
        {
            MySQLParameterList sqlParams = new MySQLParameterList();
            sqlParams.AddParameter("p_commandId", commandID);
            return MySQLDatabaseManager.GetDataReader("spGetCmdDDLlist", sqlParams);
        }
       




        public static DataSet GetAllSystems()
        {
            return MySQLDatabaseManager.GetDataSet("spGetAllSystems");
        }



        public static DataTable GetAdboxCost()
        {
           string  systemid = "0"; // null not used
            MySQLParameterList sqlParams = new MySQLParameterList();
            sqlParams.AddParameter("p_systemid", systemid);
            return MySQLDatabaseManager.GetDataTable("getAdboxchargeCost", sqlParams);
        }



        public static DataSet GetTemplateList()
        {
            return MySQLDatabaseManager.GetDataSet("spGetTemplateList");
        }

        public static DataSet GetSystems(string id)
        {
            MySQLParameterList sqlParams = new MySQLParameterList();
            sqlParams.AddParameter("p_systemId", id);
            return MySQLDatabaseManager.GetDataSet("spGetSystem",sqlParams);
        }



        public static int GetMaxCmdQId()
        {
            int rtn = 0;

            string sql = "select max(commandqid) from commandq";
            try
            {
                rtn = Convert.ToInt32(MySQLDatabaseManager.ExecuteScalar(sql));
            }

            catch (InvalidCastException ice)
            {
                rtn = 0;
            }


            return rtn;

        }



      

       


      

        public static string GetNextCommand(int systemId)
        {

            MySQLParameterList sqlParams = new MySQLParameterList();
            sqlParams.AddParameter("p_systemId", systemId);
            return (string) MySQLDatabaseManager.ExecuteScalar("spGetCommand",sqlParams).ToString();
    }

       
        public static void SavePoll(string ip, string mac, string authKey)
        {
            MySQLParameterList sqlParams = new MySQLParameterList();
            sqlParams.AddParameter("p_ip", ip);
            sqlParams.AddParameter("p_mac", mac);
            sqlParams.AddParameter("p_authKey",authKey);
            int result = -1;
             MySQLDatabaseManager.ExecuteScalar("spPolling", sqlParams);

        }



        public static void SaveAuthKey(string ip, string mac, string authKey)
        {
            MySQLParameterList sqlParams = new MySQLParameterList();
            sqlParams.AddParameter("p_ip", ip);
            sqlParams.AddParameter("p_mac", mac);
            sqlParams.AddParameter("p_authKey", authKey);
            int result = -1;
            MySQLDatabaseManager.ExecuteScalar("spLogAuthKey", sqlParams);
        }


       


        public static bool CheckSystemExists(string ip, string mac)
        {
            MySQLParameterList sqlParams = new MySQLParameterList();
            sqlParams.AddParameter("p_ip", ip);
            sqlParams.AddParameter("p_mac", mac);
            bool rtn = false;
            int result = -1;
            object x;
            x=  MySQLDatabaseManager.ExecuteScalar("spCheckSystem", sqlParams);


            result = Convert.ToInt32(x);

            if (result > 0)
                rtn = true;
            else rtn = false;

            return rtn;


        }








       



        public static void SaveContentAd(
            string adboxsize,
            DateTime expirydate,
            string expirylength,
            DateTime publishdate, 
            string priority, 
            string cssstyle,
            string bgcolor,
            string font,
            string fontsize,
            bool premium, 
            string category, 
            string heading,
            string contact,
            string htmltext,
            bool qr,
            string systemId,
            string recordStatus,
            int approved,
            string supercedeId
            )
        {



           string  idbtvuser = baz.utils.bazutils.GetUserSessionVal("idbtvusers");

            MySQLParameterList sqlParams = new MySQLParameterList();
            sqlParams.AddParameter("p_adboxsize",adboxsize);
            sqlParams.AddParameter("p_expirydate", expirydate);
            sqlParams.AddParameter("p_expirylength", expirylength);
            sqlParams.AddParameter("p_publishdate", publishdate);
            sqlParams.AddParameter("p_priority", priority);
            sqlParams.AddParameter("p_cssstyle", cssstyle);
            sqlParams.AddParameter("p_bgcolor", bgcolor);
            sqlParams.AddParameter("p_font", font);
            sqlParams.AddParameter("p_fontsize", fontsize);
            sqlParams.AddParameter("p_premium", premium);
            sqlParams.AddParameter("p_category", category);

            sqlParams.AddParameter("p_heading", heading);
            sqlParams.AddParameter("p_contact", contact);
            sqlParams.AddParameter("p_htmltext", htmltext);
            sqlParams.AddParameter("p_qrcode", qr);
            sqlParams.AddParameter("p_btvuser", idbtvuser);

            sqlParams.AddParameter("p_systemid", systemId);

            sqlParams.AddParameter("p_recordStatus",recordStatus);
            sqlParams.AddParameter("p_approved", approved);
            sqlParams.AddParameter("p_supercedeid", supercedeId);

            int result = -1;
            MySQLDatabaseManager.ExecuteScalar("spPostAd", sqlParams);
        }


        public static DataSet GetcontentadList()
        {
           return  MySQLDatabaseManager.GetDataSet("spGetContentAdList");
            
        }





        public static DataSet GetMyAdContentGrid(string btvuser)
        {
            MySQLParameterList sqlParams = new MySQLParameterList();
            sqlParams.AddParameter("p_systemid", 0);
            sqlParams.AddParameter("p_btvuserid", btvuser);
            return MySQLDatabaseManager.GetDataSet("spGetMyContentGrid", sqlParams);

        }



        public static  MySqlDataReader GetPreviewAd(string idContentAd)
        {
           return MySQLDatabaseManager.GetDataReader("select * from contentad where idcontentad=" + idContentAd);
        }


        // admin only view
         public static DataSet GetAdminAds()
        {
           // MySQLParameterList sqlParams = new MySQLParameterList();
            //sqlParams.AddParameter("p_systemid", 0);
            //sqlParams.AddParameter("p_userid", 0);
            return MySQLDatabaseManager.GetDataSet("spGetContentAdList");

        }




      



        public static void RegisterUser(string name, string email, string pwd,string guidgen)
        {
            MySQLParameterList sqlParams = new MySQLParameterList();
            sqlParams.AddParameter("p_name", name);
            sqlParams.AddParameter("p_email", email);
            sqlParams.AddParameter("p_pwd", pwd);
            sqlParams.AddParameter("p_guid",guidgen);
            MySQLDatabaseManager.ExecuteNonQuery("spRegisterBTVuser", sqlParams);

        }




        public static DataTable CheckLoginUser(string user, string pwd)
        {
            MySQLParameterList sqlParams = new MySQLParameterList();

            sqlParams.AddParameter("p_user", user);
            sqlParams.AddParameter("p_pwd", pwd);
            DataTable dt = MySQLDatabaseManager.GetDataTable("spCheckLogin", sqlParams);
           
            
           // bool flagAuth = false;
            //if ((int)Convert.ToInt32(o) > 0) flagAuth = true;

            return dt;

        }






        public static int CheckEmailGuid(string email,string confirmguid)
        {
            MySQLParameterList sqlParams = new MySQLParameterList();
            sqlParams.AddParameter("p_email", email);
            sqlParams.AddParameter("p_guid", confirmguid);
            int rows=0;
            
            rows = MySQLDatabaseManager.ExecuteNonQuery("spCheckEmailGuid", sqlParams);
            
            return rows;

        }


        public static bool IsUserAlreadyRegistered(string email)
        {

            MySQLParameterList sqlParams = new MySQLParameterList();
            sqlParams.AddParameter("p_email", email);
            //sqlParams.AddParameter("p_pwd", pwd);
            object o = MySQLDatabaseManager.ExecuteScalar("spBTVuserExists", sqlParams);

            bool flagAuth = false;

            if ((int)Convert.ToInt32(o) > 0) flagAuth = true;

            return flagAuth;

        }




        public static  MySqlDataReader  GetContentAdRecord(string idContentAd, string btvUserId)
        {

            MySQLParameterList sqlParams = new MySQLParameterList();
            sqlParams.AddParameter("p_idContentId", idContentAd);
            sqlParams.AddParameter("p_btvuserid", btvUserId);

            return MySQLDatabaseManager.GetDataReaderSP("spGetContentAdRecord", sqlParams);
        }


        public static void AdminApprovedContentAd(string id)
        {
             MySQLParameterList sqlParams = new MySQLParameterList();
            sqlParams.AddParameter("p_idContentAd", id);
            MySQLDatabaseManager.ExecuteNonQuery(" btvAdminapprovedContentAd", sqlParams);
        }


        public static void AdminDeleteContentAd(string id)
        {
            MySQLParameterList sqlParams = new MySQLParameterList();
            sqlParams.AddParameter("p_idContentAd", id);
            sqlParams.AddParameter("p_status", "deleted");
            MySQLDatabaseManager.ExecuteNonQuery("btvAdminUpdateContentAdRecordStatus", sqlParams);
        }




        public static void MarkContentRecordasDeleted(string id)
        {
            MySQLParameterList sqlParams = new MySQLParameterList();
            sqlParams.AddParameter("p_idContentAd", id);
            MySQLDatabaseManager.ExecuteNonQuery("spMarkContentRecordasDeleted", sqlParams);
        }





    }





}

