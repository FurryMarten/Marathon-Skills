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
    public partial class RunnerEditProfile : MetroForm
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime(2019, 1, 1);
        string login;
        public RunnerEditProfile(string data)
        {
            InitializeComponent();
            this.Resizable = false;
            this.MaximizeBox = false;
            this.ControlBox = false;
            timer1.Start();
            MySqlConnection connection = new MySqlConnection("server=localhost;database=marathone;user=root;password=");
            connection.Open();
            MySqlCommand newcommand = new MySqlCommand("SELECT DISTINCT CountryCode FROM country", connection);
            MySqlDataReader reader = newcommand.ExecuteReader();
            while (reader.Read())
            {
                metroComboBox1.Items.Add(reader.GetString("CountryCode"));
            }
            connection.Close();
            login = data;
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
            if (metroTextBox2.Text == metroTextBox3.Text)
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;database=marathone;user=root;password=");
                connection.Open();
                MySqlCommand command = new MySqlCommand("UPDATE user SET Password = @password, FirstName = @firstname, LastName = @lastname WHERE Email = @login", connection);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", metroTextBox2.Text);
                command.Parameters.AddWithValue("@firstname", metroTextBox4.Text);
                command.Parameters.AddWithValue("@lastname", metroTextBox5.Text);
                command.Prepare();
                command.ExecuteNonQuery();
                connection.Close();
                connection.Open();
                var gender = "";
                if (metroRadioButton1.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                MySqlCommand command1 = new MySqlCommand("UPDATE runner SET Gender = @gender,DateOfBirth = @dateOfBirth,CountryCode = @countryCode WHERE Email = @login", connection);
                command1.Parameters.AddWithValue("@login", login);
                command1.Parameters.AddWithValue("@gender", gender);
                command1.Parameters.AddWithValue("@dateOfBirth", metroDateTime1.Value);
                command1.Parameters.AddWithValue("@countryCode", metroComboBox1.Text);
                command1.Prepare();
                command1.ExecuteNonQuery();
                connection.Close();
                MetroMessageBox.Show(this, "Данные успешно изменены!");
            }
            else
            {
                MetroMessageBox.Show(this, "Введенные пароли не совпдаюат!");
            }
        }
    }
}
