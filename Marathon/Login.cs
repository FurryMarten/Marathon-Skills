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
using MySql.Data.MySqlClient;

namespace Marathon
{
    public partial class Login : MetroForm
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime(2019, 1, 1);
        public Login()
        {
            InitializeComponent();
            this.Resizable = false;
            this.MaximizeBox = false;
            this.ControlBox = false;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            metroLabel1.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
                MySqlConnection connection = new MySqlConnection("server=localhost;database=marathone;user=root;password=");
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM user WHERE Email = @login AND Password = @password", connection);
                command.Parameters.AddWithValue("@login", metroTextBox1.Text);
                command.Parameters.AddWithValue("@password", metroTextBox2.Text);
                command.Prepare();
                MySqlDataReader reader = command.ExecuteReader();
                int result = 0;
                while (reader.Read())
                {
                    result = result + 1;
                }
                if (result == 1)
                {
                    connection.Close();
                    MySqlCommand roleCommand = new MySqlCommand("SELECT RoleId FROM user WHERE Email = @login", connection);
                    connection.Open();
                    roleCommand.Parameters.AddWithValue("@login", metroTextBox1.Text);
                    roleCommand.Prepare();
                    var value = roleCommand.ExecuteScalar();
                    if (value.ToString() == "R")
                    {
                        Runner.RunnerAuthMenu ram = new Runner.RunnerAuthMenu(this.metroTextBox1.Text);
                        ram.Show();
                        this.Close();
                        connection.Close();
                    }
                    if (value.ToString() == "A")
                    {
                        Admin.AdminMenu am = new Admin.AdminMenu();
                        am.Show();
                        this.Close();
                        connection.Close();
                    }
                    if (value.ToString() == "C")
                    {
                        Coordinator.Menu cm = new Coordinator.Menu();
                        cm.Show();
                        this.Close();
                        connection.Close();
                    }
                }
                else
                    MetroMessageBox.Show(this, "Неверный логин или пароль");
            }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }
    }
