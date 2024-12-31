using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MusicApp2
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Server=DESKTOP-ROIMI0J;Database=Музыкальный_хит_парад;Trusted_Connection=True;";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Исполнитель (Название) VALUES (@Название)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Название", textBox1.Text);
                connection.Open();
                command.ExecuteNonQuery();
            }
            LoadData();
        }
        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Исполнитель";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Исполнитель SET Название = @НовоеНазвание WHERE ID_исполнителя = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@НовоеНазвание", textBox3.Text);
                command.Parameters.AddWithValue("@ID", textBox2.Text); 
                connection.Open();
                command.ExecuteNonQuery();
            }
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Исполнитель WHERE ID_исполнителя = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", textBox4.Text);

                connection.Open();
                command.ExecuteNonQuery();
            }
            LoadData();
        }
    }
}
