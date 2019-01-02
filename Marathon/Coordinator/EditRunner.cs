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
using MySql.Data.MySqlClient;

namespace Marathon.Coordinator
{
    public partial class EditRunner : MetroForm
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime(2019, 1, 1);
        string RunnerId;
        string email;
        public EditRunner(string index)
        {
            InitializeComponent();
            this.Resizable = false;
            this.MaximizeBox = false;
            timer1.Start();
            email = index;
            MySqlConnection connection = new MySqlConnection("server=localhost;database=marathone;user=root;password=");
            byte regStatus = 0;
            try
               {
                    MySqlDataReader reader;
                    connection.Open();
                    metroLabel3.Text = index;
                    MySqlCommand firstCommand = new MySqlCommand("SELECT user.FirstName, user.LastName, runner.Gender, runner.DateOfBirth, runner.CountryCode FROM user, runner WHERE user.Email = @email AND runner.Email = @email", connection);
                    firstCommand.Parameters.AddWithValue("@email", index);
                    reader = firstCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        metroLabel4.Text = reader.GetString("FirstName");
                        metroLabel6.Text = reader.GetString("LastName");
                        metroLabel10.Text = reader.GetString("Gender");
                        metroLabel8.Text = reader.GetString("DateOfBirth");
                        metroLabel12.Text = reader.GetString("CountryCode");
                    }
                    reader.Close();
                    MySqlCommand secondCommand = new MySqlCommand("SELECT RunnerId FROM runner WHERE Email = @email", connection);
                    secondCommand.Parameters.AddWithValue("@email", index);
                    secondCommand.Prepare();
                    var value = secondCommand.ExecuteScalar();
                    RunnerId = value.ToString();
                    MySqlCommand thirdCommand = new MySqlCommand("SELECT RaceKitOptionId, SponsorshipTarget, RegistrationStatusId FROM registration WHERE RunnerId = @runnerId", connection);
                    thirdCommand.Parameters.AddWithValue("@runnerId", RunnerId);
                    reader = thirdCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        metroLabel14.Text = reader.GetString("SponsorshipTarget");
                        metroLabel16.Text = reader.GetString("RaceKitOptionId");
                        regStatus = Convert.ToByte(reader.GetString("RegistrationStatusId"));
                    }
                    reader.Close();
                }
                finally
                {
                    connection.Close();
                }
            if (regStatus == 2) 
            {
                pictureBox2.Image = Image.FromFile(@"images/ok.png");
            }
            else if (regStatus == 3) 
            {
                pictureBox2.Image = Image.FromFile(@"images/ok.png");
                pictureBox3.Image = Image.FromFile(@"images/ok.png");
            }
            else if (regStatus == 4)
            {
                pictureBox2.Image = Image.FromFile(@"images/ok.png");
                pictureBox3.Image = Image.FromFile(@"images/ok.png");
                pictureBox4.Image = Image.FromFile(@"images/ok.png");
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            metroLabel1.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            PrintDialog dlg = new PrintDialog();
            dlg.ShowDialog();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;database=marathone;user=root;password=");
            try
            {
                connection.Open();
                if (metroComboBox1.SelectedIndex + 1 == 1)
                {
                    MySqlCommand command = new MySqlCommand("UPDATE registration SET RegistrationStatusId = @RegistrationStatusId WHERE RunnerId = @RunnerId", connection);
                    command.Parameters.AddWithValue("@RegistrationStatusId", "1");
                    command.Parameters.AddWithValue("@RunnerId", RunnerId);
                    command.Prepare();
                    command.ExecuteNonQuery();
                }
                else if (metroComboBox1.SelectedIndex + 1 == 2)
                {
                    MySqlCommand command = new MySqlCommand("UPDATE registration SET RegistrationStatusId = @RegistrationStatusId WHERE RunnerId = @RunnerId", connection);
                    command.Parameters.AddWithValue("@RegistrationStatusId", "2");
                    command.Parameters.AddWithValue("@RunnerId", RunnerId);
                    command.Prepare();
                    command.ExecuteNonQuery();
                }
                else if (metroComboBox1.SelectedIndex + 1 == 3)
                {
                    MySqlCommand command = new MySqlCommand("UPDATE registration SET RegistrationStatusId = @RegistrationStatusId WHERE RunnerId = @RunnerId", connection);
                    command.Parameters.AddWithValue("@RegistrationStatusId", "3");
                    command.Parameters.AddWithValue("@RunnerId", RunnerId);
                    command.Prepare();
                    command.ExecuteNonQuery();
                }
                else if (metroComboBox1.SelectedIndex + 1 == 4)
                {
                    MySqlCommand command = new MySqlCommand("UPDATE registration SET RegistrationStatusId = @RegistrationStatusId WHERE RunnerId = @RunnerId", connection);
                    command.Parameters.AddWithValue("@RegistrationStatusId", "4");
                    command.Parameters.AddWithValue("@RunnerId", RunnerId);
                    command.Prepare();
                    command.ExecuteNonQuery();
                }
                byte regStatus = 0;
                try
                {
                    MySqlDataReader reader;
                    metroLabel3.Text = email;
                    MySqlCommand firstCommand = new MySqlCommand("SELECT user.FirstName, user.LastName, runner.Gender, runner.DateOfBirth, runner.CountryCode FROM user, runner WHERE user.Email = @email AND runner.Email = @email", connection);
                    firstCommand.Parameters.AddWithValue("@email", email);
                    reader = firstCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        metroLabel4.Text = reader.GetString("FirstName");
                        metroLabel6.Text = reader.GetString("LastName");
                        metroLabel10.Text = reader.GetString("Gender");
                        metroLabel8.Text = reader.GetString("DateOfBirth");
                        metroLabel12.Text = reader.GetString("CountryCode");
                    }
                    reader.Close();
                    MySqlCommand secondCommand = new MySqlCommand("SELECT RunnerId FROM runner WHERE Email = @email", connection);
                    secondCommand.Parameters.AddWithValue("@email", email);
                    secondCommand.Prepare();
                    var value = secondCommand.ExecuteScalar();
                    RunnerId = value.ToString();
                    MySqlCommand thirdCommand = new MySqlCommand("SELECT RaceKitOptionId, SponsorshipTarget, RegistrationStatusId FROM registration WHERE RunnerId = @runnerId", connection);
                    thirdCommand.Parameters.AddWithValue("@runnerId", RunnerId);
                    reader = thirdCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        metroLabel14.Text = reader.GetString("SponsorshipTarget");
                        metroLabel16.Text = reader.GetString("RaceKitOptionId");
                        regStatus = Convert.ToByte(reader.GetString("RegistrationStatusId"));
                    }
                    reader.Close();
                }
                finally
                {
                    connection.Close();
                }
                if (regStatus == 1)
                {
                    pictureBox1.Image = Image.FromFile(@"images/ok.png");
                    pictureBox2.Image = Image.FromFile(@"images/neok.png");
                    pictureBox3.Image = Image.FromFile(@"images/neok.png");
                    pictureBox4.Image = Image.FromFile(@"images/neok.png");
                }
                if (regStatus == 2)
                {
                    pictureBox1.Image = Image.FromFile(@"images/ok.png");
                    pictureBox2.Image = Image.FromFile(@"images/ok.png");
                    pictureBox3.Image = Image.FromFile(@"images/neok.png");
                    pictureBox4.Image = Image.FromFile(@"images/neok.png");
                }
                else if (regStatus == 3)
                {
                    pictureBox1.Image = Image.FromFile(@"images/ok.png");
                    pictureBox2.Image = Image.FromFile(@"images/ok.png");
                    pictureBox3.Image = Image.FromFile(@"images/ok.png");
                    pictureBox4.Image = Image.FromFile(@"images/neok.png");
                }
                else if (regStatus == 4)
                {
                    pictureBox1.Image = Image.FromFile(@"images/ok.png");
                    pictureBox2.Image = Image.FromFile(@"images/ok.png");
                    pictureBox3.Image = Image.FromFile(@"images/ok.png");
                    pictureBox4.Image = Image.FromFile(@"images/ok.png");
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
