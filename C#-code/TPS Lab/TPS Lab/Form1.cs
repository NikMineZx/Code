using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;

namespace TPS_Lab
{
    public partial class Form1 : Form
    {
        private SQLiteConnection connection;
        private string query;

        public Form1()
        {
            InitializeComponent();

            string databasePath = @"C:\\Code\\C#-code\\TPS Lab\\Data_Base_code\\bin\\Debug\\net8.0\\program_vacancy.db"; // Имя базы данных
            connection = new SQLiteConnection("Data Source=" + databasePath + ";Version=3;");
            connection.Open();
        }

        public void SearchAndPush(bool Query, string table)
        {
            string dataFromTextBox = textBox1.Text;
            if (string.IsNullOrEmpty(dataFromTextBox))
            {
                MessageBox.Show("Filtru de căutare este gol", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query;

            if (Query == true)
            {
                query = $"SELECT Position,Department, Salary, CompanyType, ExperienceLevel FROM Vacancies WHERE {table} = @Date";
            }
            else
            {
                query = $"SELECT Position,Department, Salary, CompanyType, ExperienceLevel FROM Vacancies WHERE {table} >= @Date";
            }

            using SQLiteCommand cmd = new(query, connection);
            cmd.Parameters.Add("@Date", DbType.String).Value = dataFromTextBox;
            using SQLiteDataReader reader = cmd.ExecuteReader();
            DataTable dt = new();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
        }

        public void ReadAndPrintAllVacancies()
        {
            string query = "SELECT Position,Department, Salary, CompanyType, ExperienceLevel  FROM Vacancies";
            using SQLiteCommand cmd = new(query, connection);
            using SQLiteDataReader reader = cmd.ExecuteReader();
            DataTable dt = new();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchAndPush(true, "Position");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchAndPush(false, "Salary");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchAndPush(true, "CompanyType");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SearchAndPush(true, "ExperienceLevel");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ReadAndPrintAllVacancies();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
