using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Cloud.Firestore;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class MakeNewAccount
    {
        public static string project = "energyresearch-43949";
        public static string userID = "";
        public static string userName = "";
        public static string userKey = "";
        public static string userPassword = "";
        public static string userHouseID = "";
        public static string userHouseAddress = "";
        public static string userCountry = "";
        public static string userProvince = "";
        public static string userHouseNumber = "";
        public static string userLocationLatitude = "";
        public static string userElectMeterID = "";
        public static string userHumidID = "";
        public static string userTempID = "";
        public static string userTempDate = "";
        public static string userHumidDate = "";
        public static string userElectDate = "";
        public static string userPhone = "";
        public static string userEmail = "";
        public static string userNickName = "";


        public static void writeInfo()
        {     
        userID = "helloworldtest";
        userName = "HyeokKim";
        userKey = "ef186d13";
        userPassword = "dnwjd1227";
        userHouseID = "ef186d13";
        userHouseAddress = "대창면 운천리 399번지";
        userCountry = "대한민국";
        userProvince = "경상북도";
        userHouseNumber = "399번지";
        userLocationLatitude = "141,531";
        userElectMeterID = "ef186d13";
        userHumidID = "ef186d13";
        userTempID = "ef186d13";
        userTempDate = "2020/05/26";
        userHumidDate = "2020/05/26";
        userElectDate = "2020/05/26";
        userPhone = "01066065905";
        userEmail = "daniel.juyyun@gmail.com";
        userNickName = "CODER";
    }

        public static void makenewAccount()
        {
            writeInfo();
            FirestoreDb db = FirestoreDb.Create(project);
            Console.WriteLine("Created Cloud Firestore client with project ID: {0}", project);

            DocumentReference docRef = db.Collection("users").Document(userID);
            Dictionary<string, object> user = new Dictionary<string, object>
            {
                { "userName", userName },
                { "userPassword", userPassword },
                { "userNickName", userNickName },

                { "userID", userID },
                { "userKey", userKey },
                { "userEmail", userEmail },
                { "userPhone", userPhone },
                { "userHouseID", userHouseID },
                
                { "userCountry", userCountry },
                { "userProvince", userProvince },
                { "userHouseNumber", userHouseNumber },
                { "userHouseAddress", userHouseAddress },
                { "userLocationLatitude", userLocationLatitude },

                { "userCityID","Seoul"},
                { "userCityName","Seoul"},
                { "userZipCode","12345"},


                { "userElectMeterID", userElectMeterID },
                { "userTempID", userTempID },
                { "userHumidID", userHumidID  },
          
                { "userElectDate", userElectDate },
                { "userTempDate", userTempDate },
                { "userHumidDate", userHumidDate }
            };
            docRef.SetAsync(user);
        }
    }
}
