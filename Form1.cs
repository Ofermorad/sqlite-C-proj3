using System;
using System.Data;
using System.Data.SQLite;

namespace WinFormsApp1
{
    public partial class ofer : Form
    {
        public ofer()
        {
            InitializeComponent();
        }

        private void ofer_Load(object sender, EventArgs e)
        {

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {         
            SQLiteConnection conn1 = new SQLiteConnection(@"data source=C:\Users\oferm\Downloads\C#\proj3\db\sq.db");
            conn1.Open();
            string q1 = "SELECT* from users_table";
            SQLiteCommand comm1 = new SQLiteCommand(q1, conn1);
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm1);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn1.Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn1 = new SQLiteConnection(@"data source=C:\Users\oferm\Downloads\C#\proj3\db\sq.db");
            conn1.Open();
            string q1 = "INSERT INTO users_table (name, password) VALUES (@name,@password)";
            SQLiteCommand comm1 = new SQLiteCommand(q1, conn1);
            comm1.Parameters.AddWithValue("name", txt_name.Text);
            comm1.Parameters.AddWithValue("password", txt_pass.Text);
            comm1.ExecuteNonQuery();
            conn1.Close();
            MessageBox.Show("new user added to the data-base");
            clearf();
        }

        public void clearf()
        {
            txt_name.Text = "";
            txt_pass.Text = "";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clearf();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn1 = new SQLiteConnection(@"data source=C:\Users\oferm\Downloads\C#\proj3\db\sq.db");
            conn1.Open();
            string q1 = "SELECT * from users_table";
            SQLiteCommand comm1 = new SQLiteCommand(q1, conn1);
            SQLiteDataReader read1= comm1.ExecuteReader();
            while (read1.Read())
            {
                if (read1.GetString(0) == txt_name.Text)
                {
                    txt_pass.Text = read1.GetString(1);
                }
            }
            conn1.Close();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn1 = new SQLiteConnection(@"data source=C:\Users\oferm\Downloads\C#\proj3\db\sq.db");
            conn1.Open();
            string q1 = "DELETE from users_table WHERE name=@name1";
            SQLiteCommand comm1 = new SQLiteCommand(q1, conn1);
            comm1.Parameters.AddWithValue("name1", txt_name.Text);
            comm1.ExecuteNonQuery();
            conn1.Close();
            MessageBox.Show("user deleted from the data-base");
            clearf();
        }
    }
}