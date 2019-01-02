using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Marathon.Event
{
    public partial class InteractiveMap : MetroForm
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime(2019, 1, 1);
        public InteractiveMap()
        {
            InitializeComponent();
            this.Resizable = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            metroLabel1.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form f1 = Application.OpenForms["Checkpoints"];
            if (f1 != null)
                f1.Close();
            Form f = new Checkpoints(1);
            f.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form f1 = Application.OpenForms["Checkpoints"];
            if (f1 != null)
                f1.Close();
            Form f = new Checkpoints(2);
            f.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form f1 = Application.OpenForms["Checkpoints"];
            if (f1 != null)
                f1.Close();
            Form f = new Checkpoints(3);
            f.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form f1 = Application.OpenForms["Checkpoints"];
            if (f1 != null)
                f1.Close();
            Form f = new Checkpoints(4);
            f.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form f1 = Application.OpenForms["Checkpoints"];
            if (f1 != null)
                f1.Close();
            Form f = new Checkpoints(5);
            f.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form f1 = Application.OpenForms["Checkpoints"];
            if (f1 != null)
                f1.Close();
            Form f = new Checkpoints(6);
            f.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form f1 = Application.OpenForms["Checkpoints"];
            if (f1 != null)
                f1.Close();
            Form f = new Checkpoints(7);
            f.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            
        }
      }
}

