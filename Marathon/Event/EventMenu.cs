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
    public partial class EventMenu : MetroForm
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime(2019, 1, 1);
        public EventMenu()
        {
            InitializeComponent();
            this.Resizable = false;
            this.MaximizeBox = false;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            metroLabel1.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            BMICalc bmi = new BMICalc();
            bmi.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            BMRCalc bmr = new BMRCalc();
            bmr.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            AboutEvent ae = new AboutEvent();
            ae.Show();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            HowLong hl = new HowLong();
            hl.Show();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Charity charity = new Charity();
            charity.Show();
        }
    }
}
