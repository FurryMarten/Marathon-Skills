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
    public partial class RunnerSponsors : MetroForm
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime(2019, 1, 1);
        public RunnerSponsors(string data)
        {
            InitializeComponent();
            this.Resizable = false;
            this.MaximizeBox = false;
            timer1.Start();
            metroGrid1.ReadOnly = true;
            metroGrid1.BackgroundColor = Color.WhiteSmoke;
            metroGrid1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(102, 102, 102);
            MySqlConnection connection = new MySqlConnection("server=localhost;database=marathone;user=root;password=");
            try
            {
                connection.Open();
                MySqlCommand roleCommand1 = new MySqlCommand("SELECT RunnerId FROM runner WHERE Email = @login", connection);
                roleCommand1.Parameters.AddWithValue("@login", data);
                roleCommand1.Prepare();
                var value = roleCommand1.ExecuteScalar();
                var login = value.ToString();
                MySqlCommand roleCommand = new MySqlCommand("SELECT RegistrationId FROM registration WHERE RunnerId = @login", connection);
                roleCommand.Parameters.AddWithValue("@login", login);
                roleCommand.Prepare();
                var value1 = roleCommand.ExecuteScalar();
                string id = value1.ToString();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT SponsorName, Amount FROM sponsorship WHERE RegistrationId =\"" + id + "\"", connection);
                DataSet DS = new DataSet();
                da.Fill(DS);
                metroGrid1.DataSource = DS.Tables[0];
                metroGrid1.Columns[0].HeaderText = "Спонсор";
                metroGrid1.Columns[1].HeaderText = "Сумма";
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
    }
}
