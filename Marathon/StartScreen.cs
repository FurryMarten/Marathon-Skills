using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace Marathon
{
    public partial class StartScreen : MetroForm
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime(2019,1,1);
        public StartScreen()
        {
            InitializeComponent();
            this.Resizable = false;
            this.MaximizeBox = false;
            timer1.Start();
            //MetroMessageBox.Show(this, metroLabel1.Text.ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            metroLabel1.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void StartScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            Application.Exit();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Runner.RunnerMenu rm = new Runner.RunnerMenu();
            rm.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Event.EventMenu em = new Event.EventMenu();
            em.Show();
        }
    }
}
