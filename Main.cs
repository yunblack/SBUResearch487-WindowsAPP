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
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Main : MetroFramework.Forms.MetroForm
    {
        public Main()
        {
            InitializeComponent();
            this.text_pw.KeyDown += text_pw_KeyDown;
            
        }
        public string project = "energyresearch-43949";
        public string userID = "-";
        public string userName = "-";
        public string userKey = "-";
        public string userPassword = "-";
        public string userHouseID = "-";
        public string userHouseAddress = "-";
        public string userCountry = "-";
        public string userProvince = "-";
        public string userHouseNumber = "-";
        public string userLocationLatitude = "-";
        public string userElectMeterID = "-";
        public string userHumidID = "-";
        public string userTempID = "-";
        public string userTempDate = "-";
        public string userHumidDate = "-";
        public string userElectDate = "-";
        public string userPhone = "-";
        public string userEmail = "-";
        public string userNickName = "-";

        public string id = "";
        public string pw = "";
        public bool islogin = false;
        public bool load_done = false;

        public string street = "";
        public string state = "";
        public string country = "";

       
        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            side_bar0_Click(sender, e);
            panel_Login.Location = new Point(-6, 27);
            
            MakeNewAccount.makenewAccount();
            
            InputChart frm = new InputChart(this);
            frm.intoUserData();
            RealtimeWeatherData RT = new RealtimeWeatherData(this);
            RT.getWeatherDataFromDB();
            MapLoad mapload = new MapLoad(this);
            mapload.loadMap();
            PredictClass PC = new PredictClass(this);
            PC.Mload();
        }

        public void main_all()
        {
            MessageBox.Show("Successfully Connected","Login");
            panel_Login.Visible = false;
            inner_main.BringToFront();

        }

        public async void load(string id, string pw)
        {
            FirestoreDb db = FirestoreDb.Create(project);
            CollectionReference usersRef = db.Collection("users");
            QuerySnapshot snapshot = await usersRef.GetSnapshotAsync();
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                Dictionary<string, object> documentDictionary = document.ToDictionary();
                string temp_id = (string)documentDictionary["Name"];
                string temp_pw = Convert.ToString(documentDictionary["Password"]);
                if (check_info(temp_id, id, temp_pw, pw)){
                    islogin = true;
                }
            }
            //MessageBox.Show(islogin.ToString());
            if (islogin)
            {
                main_all();
            }
            else
            {
                MessageBox.Show("Login Failed", "Error");
                text_ID.Text = "";
                text_pw.Text = "";
            }
        }


        public bool check_info(string o_id, string i_id, string o_pw, string i_pw)
        {
            if (o_id == i_id && o_pw == i_pw)
            {
                return true;
            }
            return false;
        }

        private void connect_btn_Click(object sender, EventArgs e)
        {
            this.id = text_ID.Text;
            this.pw = text_pw.Text;

            load(id, pw);
        }

        private void login_btn2_Click(object sender, EventArgs e)
        {
            connect_btn_Click(sender,e);
        }

        private void signup_btn2_Click(object sender, EventArgs e)
        {
            signup_btn_Click(sender, e);
        }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Error", "Error");
        }

        private void l0_Click(object sender, EventArgs e)
        {
            side_bar0_Click(sender, e);
        }

        private void l1_Click(object sender, EventArgs e)
        {
            side_bar1_Click(sender, e);
        }

        private void l2_Click(object sender, EventArgs e)
        {
            side_bar3_Click(sender, e);
            //fake_panel.BringToFront();
        }

        private void l3_Click(object sender, EventArgs e)
        {
            side_bar4_Click(sender, e);
        }

        private void l4_Click(object sender, EventArgs e)
        {
            side_bar5_Click(sender, e);
        }

        private void side_bar0_Click(object sender, EventArgs e)
        {
            nullall();
            c0.Visible = true;
            inner_main.BringToFront();
        }

        private async void loaduserData()
        {
            FirestoreDb db = FirestoreDb.Create(project);
            CollectionReference usersRef = db.Collection("users");
            QuerySnapshot snapshot = await usersRef.GetSnapshotAsync();
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                Dictionary<string, object> documentDictionary = document.ToDictionary();
                if (documentDictionary["userID"].ToString().Contains("danieljuyyun"))
                {
                    textBox1.Text = documentDictionary["userID"].ToString();
                    textBox2.Text = documentDictionary["userName"].ToString();
                    textBox3.Text = documentDictionary["userKey"].ToString();
                    textBox4.Text = documentDictionary["userPassword"].ToString();
                    textBox5.Text = documentDictionary["userHouseID"].ToString();
                    textBox6.Text = documentDictionary["userHouseAddress"].ToString();
                    textBox7.Text = documentDictionary["userCountry"].ToString();
                    textBox8.Text = documentDictionary["userProvince"].ToString();
                    textBox9.Text = documentDictionary["userHouseNumber"].ToString();
                    textBox10.Text = documentDictionary["userLocationLatitude"].ToString();
                    textBox11.Text = documentDictionary["userElectMeterID"].ToString();
                    textBox12.Text = documentDictionary["userHumidID"].ToString();
                    textBox13.Text = documentDictionary["userTempID"].ToString();
                    textBox14.Text = documentDictionary["userTempDate"].ToString();
                    textBox15.Text = documentDictionary["userHumidDate"].ToString();
                    textBox16.Text = documentDictionary["userElectDate"].ToString();
                    textBox17.Text = documentDictionary["userPhone"].ToString();
                    textBox18.Text = documentDictionary["userEmail"].ToString();
                    textBox19.Text = documentDictionary["userNickName"].ToString();
                }
            }
        }

        private void side_bar1_Click(object sender, EventArgs e)
        {
            nullall();
            c1.Visible = true;
            EU_panel.BringToFront();
            //fake_panel.BringToFront();
            loaduserData();
        }

        private void side_bar3_Click(object sender, EventArgs e)
        {
            nullall();
            c2.Visible = true;
            Pre_Panel_M.BringToFront();
        }

        private void side_bar4_Click(object sender, EventArgs e)
        { 
            nullall();
            c3.Visible = true;
            Map_Panel.BringToFront();
            
        }

        private void side_bar5_Click(object sender, EventArgs e)
        {
            nullall();
            c4.Visible = true;
        }

        private void nullall()
        {
            c0.Visible = false;
            c1.Visible = false;
            c2.Visible = false;
            c3.Visible = false;
            c4.Visible = false;
        }

        private void text_pw_TextChanged(object sender, EventArgs e)
        {

        }

        private void text_pw_KeyDown(object sender, KeyEventArgs e) { 
            if (e.KeyCode == Keys.Enter) {
                this.connect_btn_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;

            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            panel_Login.BringToFront();
            panel_Login.Location = new Point(-6, 27);
            panel_Login.Visible = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Information_form frm = new Information_form();
            frm.ShowDialog();
        }
    }
}
