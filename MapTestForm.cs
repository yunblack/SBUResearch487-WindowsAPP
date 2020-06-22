using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MapTestForm : MetroFramework.Forms.MetroForm
    {
        public MapTestForm()
        {
            InitializeComponent();
        }

        private void MapTestForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string city = textBox1.Text;
            string state = textBox2.Text;
            string country = textBox3.Text;

            StringBuilder add = new StringBuilder("http://map.daum.net/?q=");
            add.Append(city);
            add.Append(state);
            add.Append(country);

            webBrowser1.Navigate(add.ToString());
        }
    }
}
