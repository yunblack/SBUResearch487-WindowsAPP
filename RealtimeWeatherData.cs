using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace WindowsFormsApp1
{
    class RealtimeWeatherData
    {
        public static string project = "energyresearch-43949";
        public Main frm;
        public RealtimeWeatherData(Main frm)
        {
            this.frm = frm;
        }
        public void getWeatherDataFromDB()
        {
            loadweatherdata();
        }

        private async void loadweatherdata()
        {
            FirestoreDb db = FirestoreDb.Create(project);
            CollectionReference usersRef = db.Collection("RealTimeData_Test");
            Query query = usersRef.OrderByDescending("Date").Limit(1);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();
            //QuerySnapshot snapshot = await usersRef.GetSnapshotAsync();
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                Dictionary<string, object> documentDictionary = document.ToDictionary();
                frm.w_value1.Text = documentDictionary["Avg_Temp"].ToString() + " \'C";
                frm.w_value2.Text = documentDictionary["Humidity"].ToString() + " %";
                frm.w_value3.Text = documentDictionary["Pressure"].ToString() + " hPa";
                frm.w_value4.Text = documentDictionary["Wind"].ToString() + " Km/h";
                frm.w_value5.Text = documentDictionary["High_Temp"].ToString() + " \'C";
                frm.w_value6.Text = documentDictionary["Low_Temp"].ToString() + " \'C";
            }

            
        }
    }
}
