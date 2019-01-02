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

namespace Marathon.Runner
{
    public partial class RunnerAuthMenu : MetroForm
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime(2019, 1, 1);
        string login;
        public RunnerAuthMenu(string data)
        {
            InitializeComponent();
            this.Resizable = false;
            this.MaximizeBox = false;
            this.ControlBox = false;
            timer1.Start();
            login = data;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            metroLabel1.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Runner.RunnerEventRegister revg = new RunnerEventRegister(login);
            revg.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Runner.RunnerEditProfile rep = new RunnerEditProfile(login);
            rep.Show();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Runner.RunnerSponsors rs = new RunnerSponsors(login);
            rs.Show();
        }
    }
}
