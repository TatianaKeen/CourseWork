using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace К2
{
    public partial class Costs : Form
    {
        public int selectRow = -1;
        private string indexprovider;
        public Costs()
        {
            InitializeComponent();
        }

        private void Costs_Load(object sender, EventArgs e)
        {
            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT * FROM Расходы";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Расходы");
            dataGridView1.DataSource = ds.Tables["Расходы"].DefaultView;

            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 135;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 9.5F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.Columns[0].HeaderText = "Код расхода";
            dataGridView1.Columns[1].HeaderText = "Код пользователя";
            dataGridView1.Columns[2].HeaderText = "Код категории расхода";
            connection.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //добавление

            button1.Visible = true;
            button6.Visible = false;

            panel1.Visible = true;
            label1.Text = "Добавление данных";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //изменение

            button1.Visible = false;
            button6.Visible = true;

            panel1.Visible = true;
            label1.Text = "Редактирование данных";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //удаление

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;

            string sql = "DELETE * FROM Расходы WHERE Код_расхода = " + indexprovider + "";
            //MessageBox.Show(indexprovider);
            //MessageBox.Show(sql);
            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            myCommand.ExecuteNonQuery();
            connection.Close();

            connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            sql = "SELECT * FROM Расходы";
            myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Расходы");
            dataGridView1.DataSource = ds.Tables["Расходы"].DefaultView;

            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 135;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 9.5F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.Columns[0].HeaderText = "Код расхода";
            dataGridView1.Columns[1].HeaderText = "Код пользователя";
            dataGridView1.Columns[2].HeaderText = "Код категории расхода";
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // сохр

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;

            string sql;
            OleDbCommand myCommand;

            int kod = dataGridView1.RowCount;           
            int user = Convert.ToInt32(textBox2.Text);
            int category = Convert.ToInt32(textBox3.Text);
            string sum = Convert.ToString(textBox4.Text);
            string date = Convert.ToString(dateTimePicker1.Text);
            sql = "INSERT INTO Расходы (Код_расхода, Код_пользователя, Код_категории_расхода, Сумма, Дата) " +
              " VALUES (" + kod +","+ user + "," + category + ",'" + sum + "','" + date + "')";


            myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            myCommand.ExecuteNonQuery();
            connection.Close();

            connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            sql = "SELECT * FROM Расходы";
            myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Расходы");
            dataGridView1.DataSource = ds.Tables["Расходы"].DefaultView;

            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 135;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 9.5F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.Columns[0].HeaderText = "Код расхода";
            dataGridView1.Columns[1].HeaderText = "Код пользователя";
            dataGridView1.Columns[2].HeaderText = "Код категории расхода";
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //отменить
            
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexprovider = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();           
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //изменить

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " UPDATE Расходы SET  " +                         
                         " Код_пользователя = " + textBox2.Text + ", " +
                         " Код_категории_расхода  = " + textBox3.Text + ", " +
                         " Сумма = '" + textBox4.Text + "', " +
                         " Дата = '" + dateTimePicker1.Text + "' " +
                         " WHERE Код_расхода = " + indexprovider + "";
            //MessageBox.Show(sql);
            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            myCommand.ExecuteNonQuery();
            connection.Close();

            connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            sql = "SELECT * FROM Расходы";
            myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Расходы");
            dataGridView1.DataSource = ds.Tables["Расходы"].DefaultView;

            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 135;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 9.5F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.Columns[0].HeaderText = "Код расхода";
            dataGridView1.Columns[1].HeaderText = "Код пользователя";
            dataGridView1.Columns[2].HeaderText = "Код категории расхода";
            connection.Close();
        }
    }
}
