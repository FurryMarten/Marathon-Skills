using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework;
using MetroFramework.Forms;

namespace Marathon.Event
{
    public partial class BMICalc : MetroForm
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime(2019, 1, 1);
        public BMICalc()
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            double BMI = 0, temp;
            temp = Convert.ToDouble(metroTextBox1.Text);
            temp /= 100;
            BMI = Convert.ToDouble(metroTextBox2.Text) / (temp * temp);
            metroTrackBar1.Value = Convert.ToInt32(BMI);
            BMI = Math.Round(BMI, 2);
            if (BMI < 18.5)
                metroLabel4.Text = String.Format("Недостаточный вес - {0:0.0}", BMI.ToString());
            else if (BMI >= 18.5 && BMI <= 24.9)
                metroLabel4.Text = String.Format("Здоровый вес - {0:0.0}", BMI.ToString());
            else if (BMI >= 25 && BMI <= 29.9)
                metroLabel4.Text = String.Format("Избыточный вес - {0:0.0}", BMI.ToString());
            else if (BMI >= 30)
                metroLabel4.Text = String.Format("Ожирение, индекс - {0:0.0}", BMI.ToString());
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
