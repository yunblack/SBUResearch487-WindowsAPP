using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;

namespace WindowsFormsApp1
{
    public partial class Information_form : MetroFramework.Forms.MetroForm
    {
        public Information_form()
        {
            InitializeComponent();
        }
        public string project = "energyresearch-43949";
        private void Information_form_Load(object sender, EventArgs e)
        {
            loadDataFromDB();
        }

        public void loadDataFromDB()
        {
            loaduserData();
        }

        public async void loaduserData()
        {
            FirestoreDb db = FirestoreDb.Create(project);
            CollectionReference usersRef = db.Collection("users");
            QuerySnapshot snapshot = await usersRef.GetSnapshotAsync();
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                Dictionary<string, object> documentDictionary = document.ToDictionary();
                textBox1.Text = documentDictionary["userName"].ToString();
                //textBox2.Text = documentDictionary["user"].ToString();
                textBox3.Text = documentDictionary["userPhone"].ToString();
                textBox4.Text = documentDictionary["userKey"].ToString();
                textBox5.Text = documentDictionary["userID"].ToString();
                textBox6.Text = documentDictionary["userHouseID"].ToString();
                textBox7.Text = documentDictionary["userElectMeterID"].ToString();
                textBox8.Text = documentDictionary["userTempID"].ToString();
                textBox9.Text = documentDictionary["userHumidID"].ToString();
                textBox16.Text = documentDictionary["userCountry"].ToString();
                textBox15.Text = documentDictionary["userProvince"].ToString();
                //textBox14.Text = documentDictionary["user"].ToString();
                textBox17.Text = documentDictionary["userHouseNumber"].ToString();
                textBox11.Text = documentDictionary["userElectDate"].ToString();
                textBox12.Text = documentDictionary["userTempDate"].ToString();
                textBox13.Text = documentDictionary["userHumidDate"].ToString();
                //textBox10.Text = documentDictionary["user"].ToString();
            }
        }

        public void writeDataToDB()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modify();
        }

        public void Modify()
        {
            FirestoreDb db = FirestoreDb.Create(project);
            DocumentReference docRef = db.Collection("users").Document(textBox5.Text);
            Dictionary<string, object> user = new Dictionary<string, object>
            {
                { "userName", textBox1.Text },
                { "userPassword", textBox1.Text },
                { "userNickName", textBox1.Text },

                { "userID", textBox5.Text },
                { "userKey", textBox4.Text },
                { "userEmail", textBox1.Text },
                { "userPhone", textBox3.Text },
                { "userHouseID", textBox6.Text },

                { "userCountry", textBox16.Text },
                { "userProvince", textBox15.Text },
                { "userHouseNumber", textBox17.Text },
                { "userHouseAddress", textBox1.Text },
                { "userLocationLatitude", textBox1.Text },

                { "userElectMeterID", textBox7.Text },
                { "userTempID", textBox8.Text },
                { "userHumidID", textBox9.Text  },

                { "userElectDate", textBox11.Text },
                { "userTempDate", textBox12.Text },
                { "userHumidDate", textBox13.Text }
            };
            docRef.SetAsync(user);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
