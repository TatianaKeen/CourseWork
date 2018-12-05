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
    public partial class Income : Form
    {
        public int selectRow = -1;
        private string indexprovider;
        public Income()
        {
            InitializeComponent();
        }

        private void Income_Load(object sender, EventArgs e)
        {
            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT * FROM Доходы";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Доходы");
            dataGridView1.DataSource = ds.Tables["Доходы"].DefaultView;
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
            dataGridView1.Columns[0].HeaderText = "Код дохода";
            dataGridView1.Columns[1].HeaderText = "Код пользователя";
            dataGridView1.Columns[2].HeaderText = "Код категории дохода";
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

            panel1.Visible = false;

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;

            string sql = "DELETE * FROM Доходы WHERE Код_дохода = " + indexprovider + "";
            //MessageBox.Show(indexprovider);
            //MessageBox.Show(sql);
            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            myCommand.ExecuteNonQuery();
            connection.Close();

            connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            sql = "SELECT * FROM Доходы";
            myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Доходы");
            dataGridView1.DataSource = ds.Tables["Доходы"].DefaultView;

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
            dataGridView1.Columns[0].HeaderText = "Код дохода";
            dataGridView1.Columns[1].HeaderText = "Код пользователя";
            dataGridView1.Columns[2].HeaderText = "Код категории дохода";
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
            sql = "INSERT INTO Доходы (Код_дохода, Код_пользователя, Код_категории_дохода, Сумма, Дата) " +
              " VALUES (" + kod + "," + user + "," + category + ",'" + sum + "','" + date + "')";


            myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            myCommand.ExecuteNonQuery();
            connection.Close();

            connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            sql = "SELECT * FROM Доходы";
            myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Доходы");
            dataGridView1.DataSource = ds.Tables["Доходы"].DefaultView;

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
            dataGridView1.Columns[0].HeaderText = "Код дохода";
            dataGridView1.Columns[1].HeaderText = "Код пользователя";
            dataGridView1.Columns[2].HeaderText = "Код категории дохода";
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
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            selectRow = dataGridView1.CurrentCell.RowIndex;
            if (selectRow < (dataGridView1.RowCount - 1))
            {
                textBox2.Text = dataGridView1[1, selectRow].Value.ToString();
                textBox3.Text = dataGridView1[2, selectRow].Value.ToString();
                textBox4.Text = dataGridView1[3, selectRow].Value.ToString();
                dateTimePicker1.Text = dataGridView1[4, selectRow].Value.ToString();

            }
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
            string sql = " UPDATE Доходы SET  " +                         
                         " Код_пользователя = " + textBox2.Text + ", " +
                         " Код_категории_дохода  = " + textBox3.Text + ", " +
                         " Сумма = '" + textBox4.Text + "', " +
                         " Дата = '" + dateTimePicker1.Text + "' " +
                         " WHERE Код_дохода = " + indexprovider + "";
            //MessageBox.Show(sql);
            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            myCommand.ExecuteNonQuery();
            connection.Close();

            connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            sql = "SELECT * FROM Доходы";
            myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Доходы");
            dataGridView1.DataSource = ds.Tables["Доходы"].DefaultView;

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
            dataGridView1.Columns[0].HeaderText = "Код дохода";
            dataGridView1.Columns[1].HeaderText = "Код пользователя";
            dataGridView1.Columns[2].HeaderText = "Код категории дохода";
            connection.Close();
        }
    }
}
