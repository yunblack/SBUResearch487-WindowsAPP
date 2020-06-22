using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace WindowsFormsApp1
{
    class Userdata
    {
        public static string project = "energyresearch-43949";
        public static string userID = "-";
        public static string userName = "-";
        public static string userKey = "-";
        public static string userPassword = "-";
        public static string userHouseID = "-";
        public static string userHouseAddress = "-";
        public static string userCountry = "-";
        public static string userProvince = "-";
        public static string userHouseNumber = "-";
        public static string userLocationLatitude = "-";
        public static string userElectMeterID = "-";
        public static string userHumidID = "-";
        public static string userTempID = "-";
        public static string userTempDate = "-";
        public static string userHumidDate = "-";
        public static string userElectDate = "-";
        public static string userPhone = "-";
        public static string userEmail = "-";
        public static string userNickName = "-";

        public static void loadAlldataFromDB()
        {
        }

        private static async void loadweatherdata()
        {
            string userID = "";
            FirestoreDb db = FirestoreDb.Create(project);
            CollectionReference usersRef = db.Collection("users");
            QuerySnapshot snapshot = await usersRef.GetSnapshotAsync();
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                Dictionary<string, object> documentDictionary = document.ToDictionary();
                if(documentDictionary["userID"].ToString().Contains("danieljuyyun"))
                {
                    userID = documentDictionary["userID"].ToString();
                    /*userName = documentDictionary["userName"].ToString();
                    userKey = documentDictionary["userKey"].ToString();
                    userPassword = documentDictionary["userPassword"].ToString();
                    userHouseID = documentDictionary["userHouseID"].ToString();
                    userHouseAddress = documentDictionary["userHouseAddress"].ToString();
                    userCountry = documentDictionary["userCountry"].ToString();
                    userProvince = documentDictionary["userProvince"].ToString();
                    userHouseNumber = documentDictionary["userHouseNumber"].ToString();
                    userLocationLatitude = documentDictionary["userLocationLatitude"].ToString();
                    userElectMeterID = documentDictionary["userElectMeterID"].ToString();
                    userHumidID = documentDictionary["userHumidID"].ToString();
                    userTempID = documentDictionary["userTempID"].ToString();
                    userTempDate = documentDictionary["userTempDate"].ToString();
                    userHumidDate = documentDictionary["userHumidDate"].ToString();
                    userElectDate = documentDictionary["userElectDate"].ToString();
                    userPhone = documentDictionary["userPhone"].ToString();
                    userEmail = documentDictionary["userEmail"].ToString();
                    userNickName = documentDictionary["userNickName"].ToString();*/
                }
            }
        }
    }
}
