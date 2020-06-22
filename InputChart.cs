using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;


namespace WindowsFormsApp1
{
    class InputChart
    {
        public string project = "energyresearch-43949";
        public Main frm;
        
        public InputChart(Main frm)
        {
            this.frm = frm;
        }
        public void intoUserData()
        {
            //frm.chart1.ChartAreas[0].AxisX.Maximum = 30;
            //frm.chart1.ChartAreas[0].AxisY.Maximum = 100;
            loaduserData_chart();
            getValueIntoPanel();
            TestDataIntoGraph();
        }
        public async void loaduserData_chart()
        {
            FirestoreDb db = FirestoreDb.Create(project);
            CollectionReference usersRef = db.Collection("EnergyPredictionData");
            QuerySnapshot snapshot = await usersRef.GetSnapshotAsync();
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
// Dictionary<string, object> documentDictionary = document.ToDictionary();
                frm.newlabel.Text = FSJsonParser.ObjToJson(document) + "";
            }
        }

        public void getValueIntoPanel()
        {
            loadweatherdata();
            loadECdata();
        }
        private async void loadECdata()
        {
            FirestoreDb db = FirestoreDb.Create(project);
            DocumentReference documentRef = db.Collection("RealtimeEnergyConsumption").Document("ef186d131588258800");
            
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
                
                frm.D_value2.Text = documentDictionary["Avg_Temp"].ToString() + " \'C";
                frm.D_value3.Text = documentDictionary["Humidity"].ToString() + " %";
                frm.D_value4.Text = documentDictionary["Pressure"].ToString() + " hPa";
                frm.D_value5.Text = "0";
                frm.D_value6.Text = documentDictionary["Wind"].ToString() + "";
                
            }
        }

        public void TestDataIntoGraph()
        {
            frm.chart1.Series["Series1"].Points.Add(10);
            frm.chart1.Series["Series1"].Points.Add(25);
            frm.chart1.Series["Series1"].Points.Add(5);
            frm.chart1.Series["Series1"].Points.Add(15);
            frm.chart1.Series["Series1"].Points.Add(10);
            frm.chart1.Series["Series1"].Points.Add(25);
            frm.chart1.Series["Series1"].Points.Add(5);
            frm.chart1.Series["Series1"].Points.Add(15);
            frm.chart1.Series["Series1"].Points.Add(10);
            frm.chart1.Series["Series1"].Points.Add(25);
            frm.chart1.Series["Series1"].Points.Add(5);
            frm.chart1.Series["Series1"].Points.Add(15);
            frm.chart1.Series["Series1"].Points.Add(10);
            frm.chart1.Series["Series1"].Points.Add(25);
            frm.chart1.Series["Series1"].Points.Add(5);
            frm.chart1.Series["Series1"].Points.Add(15);
            frm.chart1.Series["Series1"].Points.Add(10);
            frm.chart1.Series["Series1"].Points.Add(25);
            frm.chart1.Series["Series1"].Points.Add(5);
        }
    }
}
