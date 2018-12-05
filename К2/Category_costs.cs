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
    public partial class Category_costs : Form
    {
        public int selectRow = -1;
        private string indexprovider;
        public Category_costs()
        {
            InitializeComponent();
        }

        private void Category_costs_Load(object sender, EventArgs e)
        {
            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT * FROM Категории_расходов";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Категории_расходов");
            dataGridView1.DataSource = ds.Tables["Категории_расходов"].DefaultView;

            dataGridView1.Columns[0].Width = 230;
            dataGridView1.Columns[1].Width = 285;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 9.5F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.Columns[0].HeaderText = "Код категории расхода";
            dataGridView1.Columns[1].HeaderText = "Категория расхода";
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

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //изменение

            button1.Visible = false;
            button6.Visible = true;

            panel1.Visible = true;
            label1.Text = "Редактирование данных";
            textBox2.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //удаление

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;

            string sql = "DELETE * FROM Категории_расходов WHERE Код_категории_расхода = " + indexprovider + "";
            //MessageBox.Show(indexprovider);
            //MessageBox.Show(sql);
            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            myCommand.ExecuteNonQuery();
            connection.Close();

            connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            sql = "SELECT * FROM Категории_расходов";
            myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Категории_расходов");
            dataGridView1.DataSource = ds.Tables["Категории_расходов"].DefaultView;

            dataGridView1.Columns[0].Width = 230;
            dataGridView1.Columns[1].Width = 285;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 9.5F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.Columns[0].HeaderText = "Код категории расхода";
            dataGridView1.Columns[1].HeaderText = "Категория расхода";
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
            string name = Convert.ToString(textBox2.Text);
            sql = "INSERT INTO Категории_расходов (Код_категории_расхода, Название_категории_расхода) " +
              " VALUES (" + kod + " , " + "'" + name + "')";


            myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            myCommand.ExecuteNonQuery();
            connection.Close();

            connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            sql = "SELECT * FROM Категории_расходов";
            myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Категории_расходов");
            dataGridView1.DataSource = ds.Tables["Категории_расходов"].DefaultView;

            dataGridView1.Columns[0].Width = 230;
            dataGridView1.Columns[1].Width = 285;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 9.5F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.Columns[0].HeaderText = "Код категории расхода";
            dataGridView1.Columns[1].HeaderText = "Категория расхода";
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //отменить
            
            textBox2.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = "";

            selectRow = dataGridView1.CurrentCell.RowIndex;
            if (selectRow < (dataGridView1.RowCount - 1))
            {
                textBox2.Text = dataGridView1[1, selectRow].Value.ToString();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexprovider = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //изменить

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " UPDATE Категории_расходов SET  " +
                         " Название_категории_расхода  = '" + textBox2.Text + "'  " +
                         " WHERE Код_категории_расхода = " + indexprovider + "";
            //MessageBox.Show(sql);
            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            myCommand.ExecuteNonQuery();
            connection.Close();

            connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            sql = "SELECT * FROM Категории_расходов";
            myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Категории_расходов");
            dataGridView1.DataSource = ds.Tables["Категории_расходов"].DefaultView;

            dataGridView1.Columns[0].Width = 230;
            dataGridView1.Columns[1].Width = 285;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 9.5F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.Columns[0].HeaderText = "Код категории расхода";
            dataGridView1.Columns[1].HeaderText = "Категория расхода";
            connection.Close();
        }
    }
}
