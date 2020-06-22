using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class MapLoad
    {
        public Main frm;
        public MapLoad(Main frm)
        {
            this.frm = frm;
        }
        public void loadMap()
        {
            string city = "인천 연수구 송도문화로 119-8";
            StringBuilder add = new StringBuilder("http://map.daum.net/?q=");
            add.Append(city);

            frm.webBrowser1.Navigate(add.ToString());
        }
    }
}
