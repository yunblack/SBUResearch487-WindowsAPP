using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class PredictClass
    {
        public static string project = "energyresearch-43949";
        public Main frm;

        public PredictClass(Main frm)
        {
            this.frm = frm;
        }
        public void Mload()
        {
            testDataIntoChart();
        }

        public void testDataIntoChart()
        {
            //frm.chart2.ChartAreas[0].AxisX.Maximum = 30;
            //frm.chart2.ChartAreas[0].AxisY.Maximum = 100;
            //frm.chart2.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            //frm.chart2.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;

            frm.chart2.Series["Series1"].Points.Add(10);
            frm.chart2.Series["Series1"].Points.Add(60);
            frm.chart2.Series["Series1"].Points.Add(6);
            frm.chart2.Series["Series1"].Points.Add(12);
            frm.chart2.Series["Series1"].Points.Add(54);
            frm.chart2.Series["Series1"].Points.Add(1);
            frm.chart2.Series["Series1"].Points.Add(9);
            frm.chart2.Series["Series1"].Points.Add(14);
            frm.chart2.Series["Series1"].Points.Add(2);
            frm.chart2.Series["Series1"].Points.Add(67);
            frm.chart2.Series["Series1"].Points.Add(23);
            frm.chart2.Series["Series1"].Points.Add(98);
            frm.chart2.Series["Series1"].Points.Add(10);
            frm.chart2.Series["Series1"].Points.Add(14);
            frm.chart2.Series["Series1"].Points.Add(9);
            frm.chart2.Series["Series1"].Points.Add(55);
            frm.chart2.Series["Series1"].Points.Add(87);
            frm.chart2.Series["Series1"].Points.Add(10);
            frm.chart2.Series["Series1"].Points.Add(10);
            frm.chart2.Series["Series1"].Points.Add(14);
            frm.chart2.Series["Series1"].Points.Add(9);
            frm.chart2.Series["Series1"].Points.Add(55);
            frm.chart2.Series["Series1"].Points.Add(87);
            frm.chart2.Series["Series1"].Points.Add(10);
        }
    }
}
