using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using MetroFramework;
using MySql.Data.MySqlClient;

namespace Marathon.Admin
{
    public partial class AddUser : MetroForm
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime(2019, 1, 1);
        public AddUser()
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
            metroComboBox1.Text = "RUS";
            metroComboBox2.Text = "Бегун";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            metroLabel1.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroTextBox2.Text == metroTextBox3.Text)
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;database=marathone;user=root;password=");
                connection.Open();
                string role;
                if (metroComboBox2.SelectedIndex == 0)
                {
                    role = "R";
                    MySqlCommand command = new MySqlCommand("INSERT INTO user (Email, Password, FirstName, LastName, RoleId) VALUES (@login, @password, @firstname, @lastname, @role)", connection);
                    command.Parameters.AddWithValue("@login", metroTextBox1.Text);
                    command.Parameters.AddWithValue("@password", metroTextBox2.Text);
                    command.Parameters.AddWithValue("@firstname", metroTextBox4.Text);
                    command.Parameters.AddWithValue("@lastname", metroTextBox5.Text);
                    command.Parameters.AddWithValue("@role", role);
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
                    MySqlCommand command1 = new MySqlCommand("INSERT INTO runner (Email,Gender,DateOfBirth,CountryCode) values(@login,@gender,@dateOfBirth,@countryCode)", connection);
                    command1.Parameters.AddWithValue("@login", metroTextBox1.Text);
                    command1.Parameters.AddWithValue("@gender", gender);
                    command1.Parameters.AddWithValue("@dateOfBirth", metroDateTime1.Value);
                    command1.Parameters.AddWithValue("@countryCode", metroComboBox1.Text);
                    command1.Prepare();
                    command1.ExecuteNonQuery();
                    connection.Close();
                    MetroMessageBox.Show(this, "Пользователь добавлен!");
                }
                else if (metroComboBox2.SelectedIndex == 1)
                {
                    role = "C";
                    MySqlCommand command = new MySqlCommand("INSERT INTO user (Email, Password, FirstName, LastName, RoleId) VALUES (@login, @password, @firstname, @lastname, @role)", connection);
                    command.Parameters.AddWithValue("@login", metroTextBox1.Text);
                    command.Parameters.AddWithValue("@password", metroTextBox2.Text);
                    command.Parameters.AddWithValue("@firstname", metroTextBox4.Text);
                    command.Parameters.AddWithValue("@lastname", metroTextBox5.Text);
                    command.Parameters.AddWithValue("@role", role);
                    command.Prepare();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MetroMessageBox.Show(this, "Пользователь добавлен!");
                }
                else if (metroComboBox2.SelectedIndex == 2) 
                {
                    role = "A";
                    MySqlCommand command = new MySqlCommand("INSERT INTO user (Email, Password, FirstName, LastName, RoleId) VALUES (@login, @password, @firstname, @lastname, @role)", connection);
                    command.Parameters.AddWithValue("@login", metroTextBox1.Text);
                    command.Parameters.AddWithValue("@password", metroTextBox2.Text);
                    command.Parameters.AddWithValue("@firstname", metroTextBox4.Text);
                    command.Parameters.AddWithValue("@lastname", metroTextBox5.Text);
                    command.Parameters.AddWithValue("@role", role);
                    command.Prepare();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MetroMessageBox.Show(this, "Пользователь добавлен!");
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Введенные пароли не совпдаюат!");
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
