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
    public partial class EditUser : MetroForm
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime(2019, 1, 1);
        public EditUser(string index)
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
            metroLabel10.Text = index;
            metroComboBox2.Text = "Бегун";
            metroComboBox1.Text = "RUS";
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
                string role;
                MySqlConnection connection = new MySqlConnection("server=localhost;database=marathone;user=root;password=");
                connection.Open();
                if (metroComboBox2.SelectedIndex == 0)
                {
                    role = "R";
                    MySqlCommand command = new MySqlCommand("UPDATE user SET Password = @password, FirstName = @firstname, LastName = @lastname, RoleId = @role WHERE Email = @login", connection);
                    command.Parameters.AddWithValue("@login", metroLabel10.Text);
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
                    MySqlCommand command1 = new MySqlCommand("UPDATE runner SET Gender = @gender,DateOfBirth = @dateOfBirth,CountryCode = @countryCode WHERE Email = @login", connection);
                    command1.Parameters.AddWithValue("@login", metroLabel10.Text);
                    command1.Parameters.AddWithValue("@gender", gender);
                    command1.Parameters.AddWithValue("@dateOfBirth", metroDateTime1.Value);
                    command1.Parameters.AddWithValue("@countryCode", metroComboBox1.Text);
                    command1.Prepare();
                    command1.ExecuteNonQuery();
                    connection.Close();
                    MetroMessageBox.Show(this, "Данные успешно изменены!");
                }
                else if (metroComboBox2.SelectedIndex == 1)
                {
                    role = "C";
                    MySqlCommand command = new MySqlCommand("UPDATE user SET Password = @password, FirstName = @firstname, LastName = @lastname, RoleId = @role WHERE Email = @login", connection);
                    command.Parameters.AddWithValue("@login", metroLabel10.Text);
                    command.Parameters.AddWithValue("@password", metroTextBox2.Text);
                    command.Parameters.AddWithValue("@firstname", metroTextBox4.Text);
                    command.Parameters.AddWithValue("@lastname", metroTextBox5.Text);
                    command.Parameters.AddWithValue("@role", role);
                    command.Prepare();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MetroMessageBox.Show(this, "Данные успешно изменены!");
                }
                else if (metroComboBox2.SelectedIndex == 2)
                {
                    role = "A";
                    MySqlCommand command = new MySqlCommand("UPDATE user SET Password = @password, FirstName = @firstname, LastName = @lastname, RoleId = @role WHERE Email = @login", connection);
                    command.Parameters.AddWithValue("@login", metroLabel10.Text);
                    command.Parameters.AddWithValue("@password", metroTextBox2.Text);
                    command.Parameters.AddWithValue("@firstname", metroTextBox4.Text);
                    command.Parameters.AddWithValue("@lastname", metroTextBox5.Text);
                    command.Parameters.AddWithValue("@role", role);
                    command.Prepare();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MetroMessageBox.Show(this, "Данные успешно изменены!");
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Введенные пароли не совпдаюат!");
            }
        }
    }
}
