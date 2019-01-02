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
using MySql.Data.MySqlClient;

namespace Marathon.Runner
{
    public partial class RunnerEventRegister : MetroForm
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime(2019, 1, 1);
        int itog = 0;
        string login;
        string brace = "A";
        public RunnerEventRegister(string data)
        {
            InitializeComponent();
            this.Resizable = false;
            this.MaximizeBox = false;
            this.ControlBox = false;
            timer1.Start();
            MySqlConnection connection = new MySqlConnection("server=localhost;database=marathone;user=root;password=");
            MySqlCommand roleCommand = new MySqlCommand("SELECT RunnerId FROM runner WHERE Email = @login", connection);
            connection.Open();
            roleCommand.Parameters.AddWithValue("@login", data);
            roleCommand.Prepare();
            var value = roleCommand.ExecuteScalar();
            login = value.ToString();
            MetroMessageBox.Show(this, login);
            MySqlCommand newcommand = new MySqlCommand("SELECT DISTINCT CharityName FROM charity", connection);
            MySqlDataReader reader = newcommand.ExecuteReader();
            while (reader.Read())
            {
                metroComboBox1.Items.Add(reader.GetString("CharityName"));
            }
            connection.Close();
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

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            itog = metroCheckBox1.Checked ? itog += 145 : itog -= 145;
            metroLabel8.Text = "$" + itog.ToString();
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            itog = metroCheckBox2.Checked ? itog += 75 : itog -= 75;
            metroLabel8.Text = "$" + itog.ToString();
        }

        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            itog = metroCheckBox3.Checked ? itog += 20 : itog -= 20;
            metroLabel8.Text = "$" + itog.ToString();
        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            itog = metroRadioButton2.Checked ? itog += 20 : itog -= 20;
            metroLabel8.Text = "$" + itog.ToString();
        }

        private void metroRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            itog = metroRadioButton3.Checked ? itog += 45 : itog -= 45;
            metroLabel8.Text = "$" + itog.ToString();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroRadioButton2.Checked) brace = "B";
            else if (metroRadioButton3.Checked) brace = "C";
            MySqlConnection connection = new MySqlConnection("server=localhost;database=marathone;user=root;password=");
            connection.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO registration (RunnerId, RegistrationDateTime, RaceKitOptionId, RegistrationStatusId, Cost, CharityId, SponsorshipTarget) VALUES (@RunnerId, @RegistrationDateTime, @RaceKitOptionId, @RegistrationStatusId, @Cost, @CharityId, @SponsorshipTarget)", connection);
            command.Parameters.AddWithValue("@RunnerId", login);
            command.Parameters.AddWithValue("@RegistrationDateTime", DateTime.Now);
            command.Parameters.AddWithValue("@RaceKitOptionId", brace);
            command.Parameters.AddWithValue("@RegistrationStatusId", "1");
            command.Parameters.AddWithValue("@Cost", itog);
            command.Parameters.AddWithValue("@CharityId", metroComboBox1.SelectedIndex + 1);
            command.Parameters.AddWithValue("@SponsorshipTarget", metroTextBox2.Text);
            command.Prepare();
            command.ExecuteNonQuery();
            connection.Close();
            MetroMessageBox.Show(this, "Вы успешно зарегистрированы на забег! С вами свяжутся для уточнения деталей оплаты");
        }
    }
}
