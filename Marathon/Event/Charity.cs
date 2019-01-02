using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;

namespace Marathon.Event
{
    public partial class Charity : MetroForm
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime(2019, 1, 1);
        public Charity()
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
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT CharityName, CharityDescription FROM charity", connection);
                DataSet DS = new DataSet();
                da.Fill(DS);
                metroGrid1.DataSource = DS.Tables[0];
                metroGrid1.Columns[0].HeaderText = "Название организации";
                metroGrid1.Columns[1].HeaderText = "Описание организации";
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
