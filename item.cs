using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class item
    {
        public float usage;
        public string date;

        public item(string date, float usage)
        {
            this.usage = usage;
            this.date = date;
        }
    }
}
