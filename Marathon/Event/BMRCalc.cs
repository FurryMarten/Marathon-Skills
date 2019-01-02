using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;

namespace Marathon.Event
{
    public partial class BMRCalc : MetroForm
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime(2019, 1, 1);
        public BMRCalc()
        {
            InitializeComponent();
            this.Resizable = false;
            this.MaximizeBox = false;
            this.ControlBox = false;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            metroLabel1.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            double height = double.Parse(metroTextBox1.Text);
            double weight = double.Parse(metroTextBox2.Text);
            double age = double.Parse(metroTextBox3.Text);
            double result;
            if (metroRadioButton1.Checked)
            {
                //result = 66 + (weight * 6.3) + (height * 12.9) + (age * 6.8);
                result = (10 * weight) + (6.25 * height) + (5 * age) + 5;
            }
            else 
            {
                //result = 655 + (weight * 4.3) + (height * 4.7) + (age * 4.7);
                result = (10 * weight) + (6.25 * height) + (5 * age) - 161;
            }
            metroLabel7.Text = result.ToString() + " к/день";
        }
    }
}
