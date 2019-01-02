using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using System.Windows.Forms;

namespace Marathon.Event
{
    public partial class Checkpoints : MetroForm
    {
        int number;
        public Checkpoints(int num)
        {
            InitializeComponent();
            number = num;
            this.Resizable = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            StartPosition = FormStartPosition.Manual;
            Form f = Application.OpenForms["InteractiveMap"];
            Location = new Point(f.Location.X + f.Width - Width - 15, f.Location.Y + 60);
        }

        private void Checkpoints_Load(object sender, EventArgs e)
        {
            List<PictureBox> logos = new List<PictureBox>();
            logos.Add(new PictureBox());
            logos.Add(new PictureBox());
            logos.Add(new PictureBox());
            logos.Add(new PictureBox());
            logos.Add(new PictureBox());

            logos[0].Image = Image.FromFile(@"images\map-icons\map-icon-drinks.png");
            logos[0].Width = 40;
            logos[0].Height = 40;
            logos[0].SizeMode = PictureBoxSizeMode.Zoom;

            logos[1].Image = Image.FromFile(@"images\map-icons\map-icon-energy-bars.png");
            logos[1].Width = 40;
            logos[1].Height = 40;
            logos[1].SizeMode = PictureBoxSizeMode.Zoom;

            logos[2].Image = Image.FromFile(@"images\map-icons\map-icon-toilets.png");
            logos[2].Width = 40;
            logos[2].Height = 40;
            logos[2].SizeMode = PictureBoxSizeMode.Zoom;

            logos[3].Image = Image.FromFile(@"images\map-icons\map-icon-information.png");
            logos[3].Width = 40;
            logos[3].Height = 40;
            logos[3].SizeMode = PictureBoxSizeMode.Zoom;

            logos[4].Image = Image.FromFile(@"images\map-icons\map-icon-medical.png");
            logos[4].Width = 40;
            logos[4].Height = 40;
            logos[4].SizeMode = PictureBoxSizeMode.Zoom;




            switch (number)
            {
                case 1:

                    this.Text = "Checkpoint 1";

                    metroLabel1.Text = "Avenida Rudge";
                    metroLabel3.Text = "Drinks";
                    metroLabel4.Text = "Energy Bars";
                    metroLabel5.Text = "";
                    metroLabel6.Text = "";
                    logos[0].Location = new Point(0, 0);
                    metroPanel1.Controls.Add(logos[0]);


                    logos[1].Location = new Point(0, logos[0].Location.Y + 46);
                    metroPanel1.Controls.Add(logos[1]);

                    metroLabel3.Location = new Point(46, 12);
                    metroLabel4.Location = new Point(46, logos[1].Location.Y + 12);
                    break;

                case 2:
                    this.Text = "Checkpoint 2";
                    metroLabel1.Text = "Theatro Municipal";
                    metroLabel3.Text = "Drinks";
                    metroLabel4.Text = "Energy Bars";
                    metroLabel5.Text = "Toilets";
                    metroLabel6.Text = "Information";
                    logos[0].Location = new Point(0, 0);
                    metroPanel1.Controls.Add(logos[0]);


                    logos[1].Location = new Point(0, logos[4].Location.Y + 46);
                    metroPanel1.Controls.Add(logos[1]);

                    logos[2].Location = new Point(0, logos[1].Location.Y + 46);
                    metroPanel1.Controls.Add(logos[2]);

                    logos[3].Location = new Point(0, logos[2].Location.Y + 46);
                    metroPanel1.Controls.Add(logos[3]);

                    logos[4].Location = new Point(0, logos[2].Location.Y + 46);
                    metroPanel1.Controls.Add(logos[4]);


                    metroLabel3.Location = new Point(46, 10);
                    metroLabel4.Location = new Point(46, logos[1].Location.Y + 12);
                    metroLabel5.Location = new Point(46, logos[2].Location.Y + 12);
                    metroLabel6.Location = new Point(46, logos[3].Location.Y + 12);
                    break;

                case 3:
                    this.Text = "Checkpoint 3";
                    metroLabel1.Text = "Parque do Ibirapuera";
                    metroLabel3.Text = "Drinks";
                    metroLabel4.Text = "Energy Bars";
                    metroLabel5.Text = "Medical";
                    metroLabel6.Text = "";


                    logos[0].Location = new Point(0, 0);
                    metroPanel1.Controls.Add(logos[0]);

                    logos[1].Location = new Point(0, logos[0].Location.Y + 46);
                    metroPanel1.Controls.Add(logos[1]);

                    logos[4].Location = new Point(0, logos[1].Location.Y + 46);
                    metroPanel1.Controls.Add(logos[4]);


                    metroLabel3.Location = new Point(46, 5);
                    metroLabel4.Location = new Point(46, logos[1].Location.Y + 12);
                    metroLabel5.Location = new Point(46, logos[4].Location.Y + 12);
                    metroLabel6.Location = new Point(46, logos[3].Location.Y + 12);
                    break;

                case 4:
                    this.Text = "Checkpoint 4";
                    metroLabel1.Text = "Jardim Luzitania";
                    metroLabel3.Text = "Drinks";
                    metroLabel4.Text = "Energy Bars";
                    metroLabel5.Text = "Toilets";
                    metroLabel6.Text = "";

                    logos[0].Location = new Point(0, 0);
                    metroPanel1.Controls.Add(logos[0]);

                    logos[1].Location = new Point(0, logos[0].Location.Y + 46);
                    metroPanel1.Controls.Add(logos[1]);

                    logos[2].Location = new Point(0, logos[1].Location.Y + 46);
                    metroPanel1.Controls.Add(logos[2]);


                    metroLabel3.Location = new Point(46, 5);
                    metroLabel4.Location = new Point(46, logos[1].Location.Y + 12);
                    metroLabel5.Location = new Point(46, logos[2].Location.Y + 12);
                    metroLabel6.Location = new Point(46, logos[3].Location.Y + 12);
                    break;
                case 5:
                    this.Text = "Race Start";
                    metroLabel1.Text = "Samba Full Marathon";
                    metroLabel3.Text = "Drinks";
                    metroLabel4.Text = "Energy Bars";
                    metroLabel5.Text = "Toilets";
                    metroLabel6.Text = "";

                    logos[0].Location = new Point(0, 0);
                    metroPanel1.Controls.Add(logos[0]);

                    logos[1].Location = new Point(0, logos[0].Location.Y + 46);
                    metroPanel1.Controls.Add(logos[1]);

                    logos[2].Location = new Point(0, logos[1].Location.Y + 46);
                    metroPanel1.Controls.Add(logos[2]);


                    metroLabel3.Location = new Point(46, 5);
                    metroLabel4.Location = new Point(46, logos[1].Location.Y + 12);
                    metroLabel5.Location = new Point(46, logos[2].Location.Y + 12);
                    metroLabel6.Location = new Point(46, logos[3].Location.Y + 12);
                    break;
                case 6:
                    this.Text = "Race Start";
                    metroLabel1.Text = "Jongo Half Marathon";
                    metroLabel3.Text = "Drinks";
                    metroLabel4.Text = "Energy Bars";
                    metroLabel5.Text = "Toilets";
                    metroLabel6.Text = "";

                    logos[0].Location = new Point(0, 0);
                    metroPanel1.Controls.Add(logos[0]);

                    logos[1].Location = new Point(0, logos[0].Location.Y + 46);
                    metroPanel1.Controls.Add(logos[1]);

                    logos[2].Location = new Point(0, logos[1].Location.Y + 46);
                    metroPanel1.Controls.Add(logos[2]);


                    metroLabel3.Location = new Point(46, 5);
                    metroLabel4.Location = new Point(46, logos[1].Location.Y + 12);
                    metroLabel5.Location = new Point(46, logos[2].Location.Y + 12);
                    metroLabel6.Location = new Point(46, logos[3].Location.Y + 12);
                    break;
                case 7:
                    this.Text = "Race Start";
                    metroLabel1.Text = "Capoiera 5km Fun Run";
                    metroLabel3.Text = "Drinks";
                    metroLabel4.Text = "Energy Bars";
                    metroLabel5.Text = "Toilets";
                    metroLabel6.Text = "";

                    logos[0].Location = new Point(0, 0);
                    metroPanel1.Controls.Add(logos[0]);

                    logos[1].Location = new Point(0, logos[0].Location.Y + 46);
                    metroPanel1.Controls.Add(logos[1]);

                    logos[2].Location = new Point(0, logos[1].Location.Y + 46);
                    metroPanel1.Controls.Add(logos[2]);


                    metroLabel3.Location = new Point(46, 5);
                    metroLabel4.Location = new Point(46, logos[1].Location.Y + 12);
                    metroLabel5.Location = new Point(46, logos[2].Location.Y + 12);
                    metroLabel6.Location = new Point(46, logos[3].Location.Y + 12);
                    break;
            }
        }
    }
}
