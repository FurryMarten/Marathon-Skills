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
    public partial class HowLong : MetroForm
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime(2019, 1, 1);
        public HowLong()
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Image.FromFile(@"images/how-long/f1-car.jpg");
            metroLabel12.Text = "Гоночный болид F1 пройдет марафон за 7 минут 20 секунд";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Image.FromFile(@"images/how-long/worm.jpg");
            metroLabel12.Text = "Червь пройдет марафон за 58 дней 7 часов";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Image.FromFile(@"images/how-long/sloth.jpg");
            metroLabel12.Text = "Ленивец пройдет марафон за 14 дней 12 часов";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Image.FromFile(@"images/how-long/capybara.jpg");
            metroLabel12.Text = "Капибара пройдет марафон за 1 час 12 минут";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Image.FromFile(@"images/how-long/jaguar.jpg");
            metroLabel12.Text = "Ягуар пройдет марафон за 31 минуту 30 секунд";
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Image.FromFile(@"images/how-long/airbus-a380.jpg");
            metroLabel12.Text = "Ягуар пройдет марафон за 31 минуту 30 секунд";
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Image.FromFile(@"images/how-long/pair-of-havaianas.jpg");
            metroLabel12.Text = "Ягуар пройдет марафон за 31 минуту 30 секунд";
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Image.FromFile(@"images/how-long/football-field.jpg");
            metroLabel12.Text = "Ягуар пройдет марафон за 31 минуту 30 секунд";
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Image.FromFile(@"images/how-long/ronaldinho.jpg");
            metroLabel12.Text = "Ягуар пройдет марафон за 31 минуту 30 секунд";
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Image.FromFile(@"images/how-long/bus.jpg");
            metroLabel12.Text = "Ягуар пройдет марафон за 31 минуту 30 секунд";
        }
    }
}
