using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;

namespace Marathon.Coordinator
{
    public partial class Menu : MetroForm
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime(2019, 1, 1);
        MySqlConnection connection = new MySqlConnection("server=localhost;database=marathone;user=root;password=");
        public Menu()
        {
            InitializeComponent();
            this.Resizable = false;
            this.MaximizeBox = false;
            timer1.Start();
            metroGrid1.ReadOnly = true;
            metroGrid1.BackgroundColor = Color.WhiteSmoke;
            metroGrid1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(102,102,102);
            try
            {
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("select distinct User.Email, User.FirstName, User.LastName, Registration.RegistrationStatusId from User, Runner, Registration where Registration.RunnerId = Runner.RunnerId and Runner.Email = User.Email", connection);
                DataSet DS = new DataSet();
                da.Fill(DS);
                metroGrid1.DataSource = DS.Tables[0];
                metroGrid1.Columns[0].HeaderText = "Email";
                metroGrid1.Columns[1].HeaderText = "Фамилия";
                metroGrid1.Columns[2].HeaderText = "Имя";
                metroGrid1.Columns[3].HeaderText = "Статус";
                MySqlCommand countCommand = new MySqlCommand("SELECT COUNT(RunnerId) FROM runner", connection);
                countCommand.Prepare();
                var value = countCommand.ExecuteScalar();
                metroLabel3.Text = "Участников: " + value.ToString();
            }
            finally
            {
                connection.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            metroLabel1.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.FileName = "Output.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                MetroMessageBox.Show(this, "Данные будут экспортированы, и вы будете уведомлены, когда они будут готовы.");
                if (File.Exists(filename))
                {
                    try
                    {
                        File.Delete(filename);
                    }
                    catch (IOException ex)
                    {
                        MetroMessageBox.Show(this, "Не удалось записать данные на диск." + ex.Message);
                    }
                }
                int columnCount = metroGrid1.ColumnCount;
                string columnNames = "";
                string[] output = new string[metroGrid1.RowCount + 1];
                for (int i = 0; i < columnCount; i++)
                {
                    columnNames += metroGrid1.Columns[i].Name.ToString() + ",";
                }
                output[0] += columnNames;
                for (int i = 1; (i - 1) < metroGrid1.RowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        output[i] += metroGrid1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                    }
                }
                System.IO.File.WriteAllLines(sfd.FileName, output, System.Text.Encoding.UTF8);
                MetroMessageBox.Show(this, "Ваш файл был создан и готов к использованию.");
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedIndex == 0)
            {
                try
                {
                    connection.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("select distinct User.Email, User.FirstName, User.LastName, Registration.RegistrationStatusId from User, Runner, Registration where Registration.RunnerId = Runner.RunnerId and Runner.Email = User.Email and Registration.RegistrationStatusId = '1'", connection);
                    DataSet DS = new DataSet();
                    da.Fill(DS);
                    metroGrid1.DataSource = DS.Tables[0];
                    metroGrid1.Columns[0].HeaderText = "Email";
                    metroGrid1.Columns[1].HeaderText = "Фамилия";
                    metroGrid1.Columns[2].HeaderText = "Имя";
                    metroGrid1.Columns[3].HeaderText = "Статус";
                }
                finally
                {
                    connection.Close();
                }
            }
            else if (metroComboBox1.SelectedIndex == 1)
            {
                try
                {
                    connection.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("select distinct User.Email, User.FirstName, User.LastName, Registration.RegistrationStatusId from User, Runner, Registration where Registration.RunnerId = Runner.RunnerId and Runner.Email = User.Email and Registration.RegistrationStatusId = '2'", connection);
                    DataSet DS = new DataSet();
                    da.Fill(DS);
                    metroGrid1.DataSource = DS.Tables[0];
                    metroGrid1.Columns[0].HeaderText = "Email";
                    metroGrid1.Columns[1].HeaderText = "Фамилия";
                    metroGrid1.Columns[2].HeaderText = "Имя";
                    metroGrid1.Columns[3].HeaderText = "Статус";
                }
                finally
                {
                    connection.Close();
                }
            }
            else if (metroComboBox1.SelectedIndex == 2)
            {
                try
                {
                    connection.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("select distinct User.Email, User.FirstName, User.LastName, Registration.RegistrationStatusId from User, Runner, Registration where Registration.RunnerId = Runner.RunnerId and Runner.Email = User.Email and Registration.RegistrationStatusId = '3'", connection);
                    DataSet DS = new DataSet();
                    da.Fill(DS);
                    metroGrid1.DataSource = DS.Tables[0];
                    metroGrid1.Columns[0].HeaderText = "Email";
                    metroGrid1.Columns[1].HeaderText = "Фамилия";
                    metroGrid1.Columns[2].HeaderText = "Имя";
                    metroGrid1.Columns[3].HeaderText = "Статус";
                }
                finally
                {
                    connection.Close();
                }
            }
            else if (metroComboBox1.SelectedIndex == 3)
            {
                try {
                    connection.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("select distinct User.Email, User.FirstName, User.LastName, Registration.RegistrationStatusId from User, Runner, Registration where Registration.RunnerId = Runner.RunnerId and Runner.Email = User.Email and Registration.RegistrationStatusId = '4'", connection);
                    DataSet DS = new DataSet();
                    da.Fill(DS);
                    metroGrid1.DataSource = DS.Tables[0];
                    metroGrid1.Columns[0].HeaderText = "Email";
                    metroGrid1.Columns[1].HeaderText = "Фамилия";
                    metroGrid1.Columns[2].HeaderText = "Имя";
                    metroGrid1.Columns[3].HeaderText = "Статус";
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("select distinct User.Email, User.FirstName, User.LastName, Registration.RegistrationStatusId from User, Runner, Registration where Registration.RunnerId = Runner.RunnerId and Runner.Email = User.Email", connection);
                DataSet DS = new DataSet();
                da.Fill(DS);
                metroGrid1.DataSource = DS.Tables[0];
                metroGrid1.Columns[0].HeaderText = "Email";
                metroGrid1.Columns[1].HeaderText = "Фамилия";
                metroGrid1.Columns[2].HeaderText = "Имя";
                metroGrid1.Columns[3].HeaderText = "Статус";
                MySqlCommand countCommand = new MySqlCommand("SELECT COUNT(RunnerId) FROM runner", connection);
                countCommand.Prepare();
                var value = countCommand.ExecuteScalar();
                metroLabel3.Text = "Участников: " + value.ToString();
            }
            finally
            {
                connection.Close();
            }
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string index = metroGrid1.SelectedCells[0].Value.ToString();
            EditRunner er = new EditRunner(index);
            er.Show();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;database=marathone;user=root;password=");
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("select distinct User.Email, User.FirstName, User.LastName, Registration.RegistrationStatusId from User, Runner, Registration where Registration.RunnerId = Runner.RunnerId and Runner.Email = User.Email", connection);
                DataSet DS = new DataSet();
                da.Fill(DS);
                metroGrid1.DataSource = DS.Tables[0];
                metroGrid1.Columns[0].HeaderText = "Email";
                metroGrid1.Columns[1].HeaderText = "Фамилия";
                metroGrid1.Columns[2].HeaderText = "Имя";
                metroGrid1.Columns[3].HeaderText = "Статус";
                MySqlCommand countCommand = new MySqlCommand("SELECT COUNT(RunnerId) FROM runner", connection);
                countCommand.Prepare();
                var value = countCommand.ExecuteScalar();
                metroLabel3.Text = "Участников: " + value.ToString();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
