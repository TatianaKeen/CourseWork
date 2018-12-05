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
    public partial class Form1 : Form
    {
        public int selectRow = -1;
        private string indexprovider;
        bool night = false;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (night == true)
            {
                btnAllR.ForeColor = Color.Salmon;
                btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

                btnAllD.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
            }
            else
            {
                btnAllR.ForeColor = Color.FromArgb(228,68,50);
                btnDayR.ForeColor = Color.Black;
                btnWeekR.ForeColor = Color.Black;
                btnMonthR.ForeColor = Color.Black;
                btnYearR.ForeColor = Color.Black;

                btnAllD.ForeColor = Color.Black;
                btnDayD.ForeColor = Color.Black;
                btnWeekD.ForeColor = Color.Black;
                btnYearD.ForeColor = Color.Black;
                btnMonthD.ForeColor = Color.Black;
            }
            ToolBar.Checked = false;
            toolStrip1.Visible = false;
            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem1.Checked = true;
            заДеньToolStripMenuItem2.Checked = false;
            заНеделюToolStripMenuItem2.Checked = false;
            заМесяцToolStripMenuItem2.Checked = false;
            заГодToolStripMenuItem2.Checked = false;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem.Checked = false;
            заДеньToolStripMenuItem1.Checked = false;
            заНеделюToolStripMenuItem1.Checked = false;
            заМесяцToolStripMenuItem1.Checked = false;
            заГодToolStripMenuItem1.Checked = false;

            button10.Visible = false;
            button9.Visible = true;

            ToolBarLabel.Text = "Расходы";
            btnAllR.Visible = true;
            btnDayR.Visible = true;
            btnWeekR.Visible = true;
            btnMonthR.Visible = true;
            btnYearR.Visible = true;

            btnAllD.Visible = false;
            btnDayD.Visible = false;
            btnWeekD.Visible = false;
            btnMonthD.Visible = false;
            btnYearD.Visible = false;

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Расходы.Код_расхода, Пользователь.Имя_пользователя, Категории_расходов.Название_категории_расхода, Расходы.Сумма, Расходы.Дата FROM Пользователь INNER JOIN (Категории_расходов INNER JOIN Расходы ON Категории_расходов.Код_категории_расхода = Расходы.Код_категории_расхода) ON Пользователь.Код_пользователя = Расходы.Код_пользователя ORDER BY Расходы.Код_расхода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Расходы");
            dataGridView1.DataSource = ds.Tables["Расходы"].DefaultView;

            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 9.5F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;           
            dataGridView1.Columns[0].HeaderText = "Код расхода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";

            this.BackColor = Color.WhiteSmoke;
            this.ForeColor = Color.Black;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(209, 209, 209);
            /**/
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(3, 3, 3);
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(209, 209, 209);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(222, 222, 222);
            /**/
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(3, 3, 3);
            dataGridView1.BackgroundColor = Color.FromArgb(220, 220, 220);
            dataGridView1.GridColor = Color.FromArgb(220, 220, 220);
            /**/
            dataGridView1.ForeColor = Color.FromArgb(3, 3, 3);
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255); ;

            menuStrip1.BackColor = Color.FromArgb(245, 245, 245);
            /**/
            menuStrip1.ForeColor = Color.FromArgb(3, 3, 3);
            
            panel1.BackColor = Color.FromArgb(222, 222, 222);
            panel2.BackColor = Color.FromArgb(222, 222, 222);

            button1.BackColor = Color.FromArgb(211, 211, 211);
            button2.BackColor = Color.FromArgb(211, 211, 211);
            button9.BackColor = Color.FromArgb(211, 211, 211);
            button10.BackColor = Color.FromArgb(211, 211, 211);

            button5.BackColor = Color.FromArgb(211, 211, 211);
            button6.BackColor = Color.FromArgb(211, 211, 211);
            button7.BackColor = Color.FromArgb(211, 211, 211);
            button8.BackColor = Color.FromArgb(211, 211, 211);

            button3.BackColor = Color.FromArgb(211, 211, 211);
            button4.BackColor = Color.FromArgb(211, 211, 211);
            button3.ForeColor = Color.FromArgb(205, 0, 0);
            button4.ForeColor = Color.FromArgb(205, 0, 0);
            /**/
            button1.ForeColor = Color.FromArgb(3, 3, 3);
            button2.ForeColor = Color.FromArgb(3, 3, 3);
            button9.ForeColor = Color.FromArgb(3, 3, 3);
            button10.ForeColor = Color.FromArgb(3, 3, 3);

            button5.ForeColor = Color.FromArgb(3, 3, 3);
            button6.ForeColor = Color.FromArgb(3, 3, 3);
            button7.ForeColor = Color.FromArgb(3, 3, 3);
            button8.ForeColor = Color.FromArgb(3, 3, 3);


            connection.Close();

            //*********************************Пользователь***********************************//

           
            OleDbCommand myCommand2 = new OleDbCommand("SELECT * FROM Пользователь", connection);
            connection.Open();
            OleDbDataAdapter da2 = new OleDbDataAdapter(myCommand2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
                       
            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "Имя_пользователя";
            comboBox1.ValueMember = "Код_пользователя";

            comboBox4.DataSource = dt2;
            comboBox4.DisplayMember = "Имя_пользователя";
            comboBox4.ValueMember = "Код_пользователя";

            connection.Close();

            //*******************************Категория дохода*************************************//

            OleDbCommand myCommand3 = new OleDbCommand("SELECT * FROM Категории_доходов", connection);
            connection.Open();
            OleDbDataAdapter da3 = new OleDbDataAdapter(myCommand3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
                        
            comboBox3.DataSource = dt3;
            comboBox3.DisplayMember = "Название_категории_дохода";
            comboBox3.ValueMember = "Код_категории_дохода";

            connection.Close();

            //*********************************Категория расхода***********************************//

            OleDbCommand myCommand4 = new OleDbCommand("SELECT * FROM Категории_расходов", connection);
            connection.Open();
            OleDbDataAdapter da4 = new OleDbDataAdapter(myCommand4);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);

            comboBox2.DataSource = dt4;
            comboBox2.DisplayMember = "Название_категории_расхода";
            comboBox2.ValueMember = "Код_категории_расхода";

            connection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {            
            selectRow = dataGridView1.CurrentCell.RowIndex;
            if (selectRow < (dataGridView1.RowCount - 1))
            {
                comboBox1.Text = dataGridView1[1, selectRow].Value.ToString();
                comboBox2.Text = dataGridView1[2, selectRow].Value.ToString();
                comboBox4.Text = dataGridView1[1, selectRow].Value.ToString();
                comboBox3.Text = dataGridView1[2, selectRow].Value.ToString();
                textBox3.Text = dataGridView1[3, selectRow].Value.ToString();
                textBox4.Text = dataGridView1[3, selectRow].Value.ToString();
                dateTimePicker1.Text = dataGridView1[4, selectRow].Value.ToString();
                dateTimePicker2.Text = dataGridView1[4, selectRow].Value.ToString();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexprovider = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();



        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            //доход

            if (night == true)
            {
                btnAllR.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

                btnAllD.ForeColor = Color.Salmon;
                btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
            }
            else
            {
                btnAllR.ForeColor = Color.Black;
                btnDayR.ForeColor = Color.Black;
                btnWeekR.ForeColor = Color.Black;
                btnMonthR.ForeColor = Color.Black;
                btnYearR.ForeColor = Color.Black;

                btnAllD.ForeColor = Color.FromArgb(228,68,50);
                btnDayD.ForeColor = Color.Black;
                btnWeekD.ForeColor = Color.Black;
                btnYearD.ForeColor = Color.Black;
                btnMonthD.ForeColor = Color.Black;
            }
            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem1.Checked = false;
            заДеньToolStripMenuItem2.Checked = false;
            заНеделюToolStripMenuItem2.Checked = false;
            заМесяцToolStripMenuItem2.Checked = false;
            заГодToolStripMenuItem2.Checked = false;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem.Checked = true;
            заДеньToolStripMenuItem1.Checked = false;
            заНеделюToolStripMenuItem1.Checked = false;
            заМесяцToolStripMenuItem1.Checked = false;
            заГодToolStripMenuItem1.Checked = false;

            panel1.Visible = false;
            panel2.Visible = true;
            button9.Visible = false;
            button10.Visible = true;

            ToolBarLabel.Text = "Доходы";
            btnAllD.Visible = true;
            btnDayD.Visible = true;
            btnWeekD.Visible = true;
            btnMonthD.Visible = true;
            btnYearD.Visible = true;

            btnAllR.Visible = false;
            btnDayR.Visible = false;
            btnWeekR.Visible = false;
            btnMonthR.Visible = false;
            btnYearR.Visible = false;

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Доходы.Код_дохода, Пользователь.Имя_пользователя, Категории_доходов.Название_категории_дохода, Доходы.Сумма, Доходы.Дата FROM Пользователь INNER JOIN (Категории_доходов INNER JOIN Доходы ON Категории_доходов.Код_категории_дохода = Доходы.Код_категории_дохода) ON Пользователь.Код_пользователя = Доходы.Код_пользователя  ORDER BY Доходы.Код_дохода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Доходы");
            dataGridView1.DataSource = ds.Tables["Доходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код дохода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Доходы за всё время";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //расход
            if (night == true)
            {
                btnAllR.ForeColor = Color.Salmon;
                btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

                btnAllD.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
            }
            else
            {
                btnAllR.ForeColor = Color.FromArgb(228,68,50);
                btnDayR.ForeColor = Color.Black;
                btnWeekR.ForeColor = Color.Black;
                btnMonthR.ForeColor = Color.Black;
                btnYearR.ForeColor = Color.Black;

                btnAllD.ForeColor = Color.Black;
                btnDayD.ForeColor = Color.Black;
                btnWeekD.ForeColor = Color.Black;
                btnYearD.ForeColor = Color.Black;
                btnMonthD.ForeColor = Color.Black;
            }
            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem1.Checked = true;
            заДеньToolStripMenuItem2.Checked = false;
            заНеделюToolStripMenuItem2.Checked = false;
            заМесяцToolStripMenuItem2.Checked = false;
            заГодToolStripMenuItem2.Checked = false;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem.Checked = false;
            заДеньToolStripMenuItem1.Checked = false;
            заНеделюToolStripMenuItem1.Checked = false;
            заМесяцToolStripMenuItem1.Checked = false;
            заГодToolStripMenuItem1.Checked = false;

            panel1.Visible = true;
            panel2.Visible = false;
            button10.Visible = false;
            button9.Visible = true;

            ToolBarLabel.Text = "Расходы";
            btnAllR.Visible = true;
            btnDayR.Visible = true;
            btnWeekR.Visible = true;
            btnMonthR.Visible = true;
            btnYearR.Visible = true;

            btnAllD.Visible = false;
            btnDayD.Visible = false;
            btnWeekD.Visible = false;
            btnMonthD.Visible = false;
            btnYearD.Visible = false;

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Расходы.Код_расхода, Пользователь.Имя_пользователя, Категории_расходов.Название_категории_расхода, Расходы.Сумма, Расходы.Дата FROM Пользователь INNER JOIN (Категории_расходов INNER JOIN Расходы ON Категории_расходов.Код_категории_расхода = Расходы.Код_категории_расхода) ON Пользователь.Код_пользователя = Расходы.Код_пользователя  ORDER BY Расходы.Код_расхода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Расходы");
            dataGridView1.DataSource = ds.Tables["Расходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код расхода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Расходы за всё время";
        }

        private void заВсёВремяToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (night == true)
            {
                btnAllR.ForeColor = Color.Salmon;
                btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

                btnAllD.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
            }
            else
            {
                btnAllR.ForeColor = Color.FromArgb(228,68,50);
                btnDayR.ForeColor = Color.Black;
                btnWeekR.ForeColor = Color.Black;
                btnMonthR.ForeColor = Color.Black;
                btnYearR.ForeColor = Color.Black;

                btnAllD.ForeColor = Color.Black;
                btnDayD.ForeColor = Color.Black;
                btnWeekD.ForeColor = Color.Black;
                btnYearD.ForeColor = Color.Black;
                btnMonthD.ForeColor = Color.Black;
            }
            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem1.Checked = true;
            заДеньToolStripMenuItem2.Checked = false;
            заНеделюToolStripMenuItem2.Checked = false;
            заМесяцToolStripMenuItem2.Checked = false;
            заГодToolStripMenuItem2.Checked = false;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem.Checked = false;
            заДеньToolStripMenuItem1.Checked = false;
            заНеделюToolStripMenuItem1.Checked = false;
            заМесяцToolStripMenuItem1.Checked = false;
            заГодToolStripMenuItem1.Checked = false;

            ToolBarLabel.Text = "Расходы";
            btnAllR.Visible = true;
            btnDayR.Visible = true;
            btnWeekR.Visible = true;
            btnMonthR.Visible = true;
            btnYearR.Visible = true;

            btnAllD.Visible = false;
            btnDayD.Visible = false;
            btnWeekD.Visible = false;
            btnMonthD.Visible = false;
            btnYearD.Visible = false;

            button10.Visible = false;
            button9.Visible = true;
            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Расходы.Код_расхода, Пользователь.Имя_пользователя, Категории_расходов.Название_категории_расхода, Расходы.Сумма, Расходы.Дата FROM Пользователь INNER JOIN (Категории_расходов INNER JOIN Расходы ON Категории_расходов.Код_категории_расхода = Расходы.Код_категории_расхода) ON Пользователь.Код_пользователя = Расходы.Код_пользователя  ORDER BY Расходы.Код_расхода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Расходы");
            dataGridView1.DataSource = ds.Tables["Расходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код расхода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Расходы за всё время";
        }

        private void заВсёВремяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (night == true)
            {
                btnAllR.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

                btnAllD.ForeColor = Color.Salmon;
                btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
            }
            else
            {
                btnAllR.ForeColor = Color.Black;
                btnDayR.ForeColor = Color.Black;
                btnWeekR.ForeColor = Color.Black;
                btnMonthR.ForeColor = Color.Black;
                btnYearR.ForeColor = Color.Black;

                btnAllD.ForeColor = Color.FromArgb(228,68,50);
                btnDayD.ForeColor = Color.Black;
                btnWeekD.ForeColor = Color.Black;
                btnYearD.ForeColor = Color.Black;
                btnMonthD.ForeColor = Color.Black;
            }
            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem1.Checked = false;
            заДеньToolStripMenuItem2.Checked = false;
            заНеделюToolStripMenuItem2.Checked = false;
            заМесяцToolStripMenuItem2.Checked = false;
            заГодToolStripMenuItem2.Checked = false;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem.Checked = true;
            заДеньToolStripMenuItem1.Checked = false;
            заНеделюToolStripMenuItem1.Checked = false;
            заМесяцToolStripMenuItem1.Checked = false;
            заГодToolStripMenuItem1.Checked = false;

            button9.Visible = false;
            button10.Visible = true;

            ToolBarLabel.Text = "Доходы";
            btnAllD.Visible = true;
            btnDayD.Visible = true;
            btnWeekD.Visible = true;
            btnMonthD.Visible = true;
            btnYearD.Visible = true;

            btnAllR.Visible = false;
            btnDayR.Visible = false;
            btnWeekR.Visible = false;
            btnMonthR.Visible = false;
            btnYearR.Visible = false;

            
            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Доходы.Код_дохода, Пользователь.Имя_пользователя, Категории_доходов.Название_категории_дохода, Доходы.Сумма, Доходы.Дата FROM Пользователь INNER JOIN (Категории_доходов INNER JOIN Доходы ON Категории_доходов.Код_категории_дохода = Доходы.Код_категории_дохода) ON Пользователь.Код_пользователя = Доходы.Код_пользователя  ORDER BY Доходы.Код_дохода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Доходы");
            dataGridView1.DataSource = ds.Tables["Доходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код дохода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Доходы за всё время";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void светлаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            night = false;
            светлаяToolStripMenuItem.Checked = true;
            темнаяToolStripMenuItem.Checked = false;

            this.BackColor = Color.WhiteSmoke;
            this.ForeColor = Color.Black;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(209, 209, 209);
            /**/dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(3, 3, 3);
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(209, 209, 209);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(222, 222, 222);
            /**/dataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(3, 3, 3);
            dataGridView1.BackgroundColor = Color.FromArgb(220, 220, 220);
            dataGridView1.GridColor = Color.FromArgb(220, 220, 220);
            /**/dataGridView1.ForeColor = Color.FromArgb(3, 3, 3);
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255); ;

            menuStrip1.BackColor = Color.FromArgb(245, 245, 245);
            /**/menuStrip1.ForeColor = Color.FromArgb(3, 3, 3);
            //menuStrip1.SelectionForeColor = Color.FromArgb(222, 222, 224);

            panel1.BackColor = Color.FromArgb(222, 222, 222);
            panel2.BackColor = Color.FromArgb(222, 222, 222);

            button1.BackColor = Color.FromArgb(211,211,211);
            button2.BackColor = Color.FromArgb(211,211,211);
            button9.BackColor = Color.FromArgb(211,211,211);
            button10.BackColor = Color.FromArgb(211,211,211);

            button5.BackColor = Color.FromArgb(211,211,211);
            button6.BackColor = Color.FromArgb(211,211,211);
            button7.BackColor = Color.FromArgb(211,211,211);
            button8.BackColor = Color.FromArgb(211,211,211);
            /**/
            button1.ForeColor = Color.FromArgb(3, 3, 3);
            button2.ForeColor = Color.FromArgb(3, 3, 3);
            button9.ForeColor = Color.FromArgb(3, 3, 3);
            button10.ForeColor = Color.FromArgb(3, 3, 3);

            button5.ForeColor = Color.FromArgb(3, 3, 3);
            button6.ForeColor = Color.FromArgb(3, 3, 3);
            button7.ForeColor = Color.FromArgb(3, 3, 3);
            button8.ForeColor = Color.FromArgb(3, 3, 3);

            button3.BackColor = Color.FromArgb(211, 211, 211);
            button4.BackColor = Color.FromArgb(211, 211, 211);
            button3.ForeColor = Color.FromArgb(205, 0, 0);
            button4.ForeColor = Color.FromArgb(205, 0, 0);

            toolStrip1.BackColor = Color.FromArgb(245, 245, 245);
            btnAllR.ForeColor = Color.FromArgb(3, 3, 3);
            btnDayR.ForeColor = Color.FromArgb(3, 3, 3);
            btnWeekR.ForeColor = Color.FromArgb(3, 3, 3);
            btnMonthR.ForeColor = Color.FromArgb(3, 3, 3);
            btnYearR.ForeColor = Color.FromArgb(3, 3, 3);

            btnAllD.ForeColor = Color.FromArgb(3, 3, 3);
            btnDayD.ForeColor = Color.FromArgb(3, 3, 3);
            btnWeekD.ForeColor = Color.FromArgb(3, 3, 3);
            btnYearD.ForeColor = Color.FromArgb(3, 3, 3);
            btnMonthD.ForeColor = Color.FromArgb(3, 3, 3);

        }

        private void темнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            night = true;
            светлаяToolStripMenuItem.Checked = false;
            темнаяToolStripMenuItem.Checked = true;

            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ForeColor = Color.FromArgb(222, 222, 224);

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 46, 50);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(222, 222, 224);
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 46, 50);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(62, 62, 66);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(255, 255, 255);
            dataGridView1.BackgroundColor = Color.FromArgb(71, 71, 73);
            dataGridView1.GridColor = Color.FromArgb(30, 30, 30);
            dataGridView1.ForeColor = Color.FromArgb(222, 222, 224);
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 55); 

            menuStrip1.BackColor = Color.FromArgb(45, 45, 48);
            menuStrip1.ForeColor = Color.FromArgb(222, 222, 224);
            //menuStrip1.SelectionForeColor = Color.FromArgb(222, 222, 224);

            panel1.BackColor = Color.FromArgb(56, 56, 60);
            panel2.BackColor = Color.FromArgb(56, 56, 60);

            button1.BackColor = Color.FromArgb(56, 56, 58);
            button2.BackColor = Color.FromArgb(56, 56, 58);
            button9.BackColor = Color.FromArgb(56, 56, 58);
            button10.BackColor = Color.FromArgb(56, 56, 58);

            button5.BackColor = Color.FromArgb(46, 46, 50);
            button6.BackColor = Color.FromArgb(46, 46, 50);
            button7.BackColor = Color.FromArgb(46, 46, 50);
            button8.BackColor = Color.FromArgb(46, 46, 50);
            /**/
            button1.ForeColor = Color.FromArgb(222, 222, 224);
            button2.ForeColor = Color.FromArgb(222, 222, 224);
            button9.ForeColor = Color.FromArgb(222, 222, 224);
            button10.ForeColor = Color.FromArgb(222, 222, 224);

            button5.ForeColor = Color.FromArgb(222, 222, 224);
            button6.ForeColor = Color.FromArgb(222, 222, 224);
            button7.ForeColor = Color.FromArgb(222, 222, 224);
            button8.ForeColor = Color.FromArgb(222, 222, 224);

            button3.BackColor = Color.FromArgb(46, 46, 50);
            button4.BackColor = Color.FromArgb(46, 46, 50);
            button3.ForeColor = Color.FromArgb(205, 0, 0);
            button4.ForeColor = Color.FromArgb(205, 0, 0);

            toolStrip1.BackColor = Color.FromArgb(45, 45, 48);
            btnAllR.ForeColor = Color.FromArgb(222, 222, 224);
            btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
            btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
            btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
            btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

            btnAllD.ForeColor = Color.FromArgb(222, 222, 224);
            btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
            btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
            btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
            btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
        }


        private void заДеньToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (night == true)
            {
                btnAllR.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

                btnAllD.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayD.ForeColor = Color.Salmon;
                btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
            }
            else
            {
                btnAllR.ForeColor = Color.Black;
                btnDayR.ForeColor = Color.Black;
                btnWeekR.ForeColor = Color.Black;
                btnMonthR.ForeColor = Color.Black;
                btnYearR.ForeColor = Color.Black;

                btnAllD.ForeColor = Color.Black;
                btnDayD.ForeColor = Color.FromArgb(228,68,50);
                btnWeekD.ForeColor = Color.Black;
                btnYearD.ForeColor = Color.Black;
                btnMonthD.ForeColor = Color.Black;
            }
            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem1.Checked = false;
            заДеньToolStripMenuItem2.Checked = false;
            заНеделюToolStripMenuItem2.Checked = false;
            заМесяцToolStripMenuItem2.Checked = false;
            заГодToolStripMenuItem2.Checked = false;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem.Checked = false;
            заДеньToolStripMenuItem1.Checked = true;
            заНеделюToolStripMenuItem1.Checked = false;
            заМесяцToolStripMenuItem1.Checked = false;
            заГодToolStripMenuItem1.Checked = false;

            button9.Visible = false;
            button10.Visible = true;

            ToolBarLabel.Text = "Доходы";
            btnAllD.Visible = true;
            btnDayD.Visible = true;
            btnWeekD.Visible = true;
            btnMonthD.Visible = true;
            btnYearD.Visible = true;

            btnAllR.Visible = false;
            btnDayR.Visible = false;
            btnWeekR.Visible = false;
            btnMonthR.Visible = false;
            btnYearR.Visible = false;
            DateTime dt = DateTime.Now;
            string curDate = dt.ToShortDateString();

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Доходы.Код_дохода, Пользователь.Имя_пользователя, Категории_доходов.Название_категории_дохода, Доходы.Сумма, Доходы.Дата FROM Пользователь INNER JOIN (Категории_доходов INNER JOIN Доходы ON Категории_доходов.Код_категории_дохода = Доходы.Код_категории_дохода) ON Пользователь.Код_пользователя = Доходы.Код_пользователя  WHERE DATE() = Доходы.Дата  ORDER BY Доходы.Код_дохода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Доходы");
            dataGridView1.DataSource = ds.Tables["Доходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код дохода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Доходы за день";
        }

        private void заНеделюToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (night == true)
            {
                btnAllR.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

                btnAllD.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekD.ForeColor = Color.Salmon;
                btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
            }
            else
            {
                btnAllR.ForeColor = Color.Black;
                btnDayR.ForeColor = Color.Black;
                btnWeekR.ForeColor = Color.Black;
                btnMonthR.ForeColor = Color.Black;
                btnYearR.ForeColor = Color.Black;

                btnAllD.ForeColor = Color.Black;
                btnDayD.ForeColor = Color.Black;
                btnWeekD.ForeColor = Color.FromArgb(228,68,50);
                btnYearD.ForeColor = Color.Black;
                btnMonthD.ForeColor = Color.Black;
            }
            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem1.Checked = false;
            заДеньToolStripMenuItem2.Checked = false;
            заНеделюToolStripMenuItem2.Checked = false;
            заМесяцToolStripMenuItem2.Checked = false;
            заГодToolStripMenuItem2.Checked = false;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem.Checked = false;
            заДеньToolStripMenuItem1.Checked = false;
            заНеделюToolStripMenuItem1.Checked = true;
            заМесяцToolStripMenuItem1.Checked = false;
            заГодToolStripMenuItem1.Checked = false;

            button9.Visible = false;
            button10.Visible = true;

            ToolBarLabel.Text = "Доходы";
            btnAllD.Visible = true;
            btnDayD.Visible = true;
            btnWeekD.Visible = true;
            btnMonthD.Visible = true;
            btnYearD.Visible = true;

            btnAllR.Visible = false;
            btnDayR.Visible = false;
            btnWeekR.Visible = false;
            btnMonthR.Visible = false;
            btnYearR.Visible = false;

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Доходы.Код_дохода, Пользователь.Имя_пользователя, Категории_доходов.Название_категории_дохода, Доходы.Сумма, Доходы.Дата FROM Пользователь INNER JOIN (Категории_доходов INNER JOIN Доходы ON Категории_доходов.Код_категории_дохода = Доходы.Код_категории_дохода) ON Пользователь.Код_пользователя = Доходы.Код_пользователя WHERE Доходы.Дата Between Date() and Date()-6 ORDER BY Доходы.Код_дохода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Доходы");
            dataGridView1.DataSource = ds.Tables["Доходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код дохода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Доходы за неделю";
        }

        private void заМесяцToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (night == true)
            {
                btnAllR.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

                btnAllD.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthD.ForeColor = Color.Salmon;
            }
            else
            {
                btnAllR.ForeColor = Color.Black;
                btnDayR.ForeColor = Color.Black;
                btnWeekR.ForeColor = Color.Black;
                btnMonthR.ForeColor = Color.Black;
                btnYearR.ForeColor = Color.Black;

                btnAllD.ForeColor = Color.Black;
                btnDayD.ForeColor = Color.Black;
                btnWeekD.ForeColor = Color.Black;
                btnYearD.ForeColor = Color.Black;
                btnMonthD.ForeColor = Color.FromArgb(228,68,50);
            }
            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem1.Checked = false;
            заДеньToolStripMenuItem2.Checked = false;
            заНеделюToolStripMenuItem2.Checked = false;
            заМесяцToolStripMenuItem2.Checked = false;
            заГодToolStripMenuItem2.Checked = false;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem.Checked = false;
            заДеньToolStripMenuItem1.Checked = false;
            заНеделюToolStripMenuItem1.Checked = false;
            заМесяцToolStripMenuItem1.Checked = true;
            заГодToolStripMenuItem1.Checked = false;

            button9.Visible = false;
            button10.Visible = true;

            ToolBarLabel.Text = "Доходы";
            btnAllD.Visible = true;
            btnDayD.Visible = true;
            btnWeekD.Visible = true;
            btnMonthD.Visible = true;
            btnYearD.Visible = true;

            btnAllR.Visible = false;
            btnDayR.Visible = false;
            btnWeekR.Visible = false;
            btnMonthR.Visible = false;
            btnYearR.Visible = false;

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Доходы.Код_дохода, Пользователь.Имя_пользователя, Категории_доходов.Название_категории_дохода, Доходы.Сумма, Доходы.Дата FROM Пользователь INNER JOIN (Категории_доходов INNER JOIN Доходы ON Категории_доходов.Код_категории_дохода = Доходы.Код_категории_дохода) ON Пользователь.Код_пользователя = Доходы.Код_пользователя WHERE Year([Доходы.Дата]) = Year(Now()) And Month([Доходы.Дата]) = Month(Now()) ORDER BY Доходы.Код_дохода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Доходы");
            dataGridView1.DataSource = ds.Tables["Доходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код дохода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Доходы за месяц";
        }

        private void заГодToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (night == true)
            {
                btnAllR.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

                btnAllD.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearD.ForeColor = Color.Salmon;
                btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
            }
            else
            {
                btnAllR.ForeColor = Color.Black;
                btnDayR.ForeColor = Color.Black;
                btnWeekR.ForeColor = Color.Black;
                btnMonthR.ForeColor = Color.Black;
                btnYearR.ForeColor = Color.Black;

                btnAllD.ForeColor = Color.Black;
                btnDayD.ForeColor = Color.Black;
                btnWeekD.ForeColor = Color.Black;
                btnYearD.ForeColor = Color.FromArgb(228,68,50);
                btnMonthD.ForeColor = Color.Black;
            }
            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem1.Checked = false;
            заДеньToolStripMenuItem2.Checked = false;
            заНеделюToolStripMenuItem2.Checked = false;
            заМесяцToolStripMenuItem2.Checked = false;
            заГодToolStripMenuItem2.Checked = false;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem.Checked = false;
            заДеньToolStripMenuItem1.Checked = false;
            заНеделюToolStripMenuItem1.Checked = false;
            заМесяцToolStripMenuItem1.Checked = false;
            заГодToolStripMenuItem1.Checked = true;

            button9.Visible = false;
            button10.Visible = true;

            ToolBarLabel.Text = "Доходы";
            btnAllD.Visible = true;
            btnDayD.Visible = true;
            btnWeekD.Visible = true;
            btnMonthD.Visible = true;
            btnYearD.Visible = true;

            btnAllR.Visible = false;
            btnDayR.Visible = false;
            btnWeekR.Visible = false;
            btnMonthR.Visible = false;
            btnYearR.Visible = false;

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Доходы.Код_дохода, Пользователь.Имя_пользователя, Категории_доходов.Название_категории_дохода, Доходы.Сумма, Доходы.Дата FROM Пользователь INNER JOIN (Категории_доходов INNER JOIN Доходы ON Категории_доходов.Код_категории_дохода = Доходы.Код_категории_дохода) ON Пользователь.Код_пользователя = Доходы.Код_пользователя WHERE Year([Доходы.Дата]) = Year(Date()) ORDER BY Доходы.Код_дохода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Доходы");
            dataGridView1.DataSource = ds.Tables["Доходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код дохода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Доходы за год";
        }

        private void заДеньToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (night == true)
            {
                btnAllR.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayR.ForeColor = Color.Salmon;
                btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

                btnAllD.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
            }
            else
            {
                btnAllR.ForeColor = Color.Black;
                btnDayR.ForeColor = Color.FromArgb(228,68,50);
                btnWeekR.ForeColor = Color.Black;
                btnMonthR.ForeColor = Color.Black;
                btnYearR.ForeColor = Color.Black;

                btnAllD.ForeColor = Color.Black;
                btnDayD.ForeColor = Color.Black;
                btnWeekD.ForeColor = Color.Black;
                btnYearD.ForeColor = Color.Black;
                btnMonthD.ForeColor = Color.Black;
            }
            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem1.Checked = false;
            заДеньToolStripMenuItem2.Checked = true;
            заНеделюToolStripMenuItem2.Checked = false;
            заМесяцToolStripMenuItem2.Checked = false;
            заГодToolStripMenuItem2.Checked = false;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem.Checked = false;
            заДеньToolStripMenuItem1.Checked = false;
            заНеделюToolStripMenuItem1.Checked = false;
            заМесяцToolStripMenuItem1.Checked = false;
            заГодToolStripMenuItem1.Checked = false;

            button10.Visible = false;
            button9.Visible = true;

            ToolBarLabel.Text = "Расходы";
            btnAllR.Visible = true;
            btnDayR.Visible = true;
            btnWeekR.Visible = true;
            btnMonthR.Visible = true;
            btnYearR.Visible = true;

            btnAllD.Visible = false;
            btnDayD.Visible = false;
            btnWeekD.Visible = false;
            btnMonthD.Visible = false;
            btnYearD.Visible = false;

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Расходы.Код_расхода, Пользователь.Имя_пользователя, Категории_расходов.Название_категории_расхода, Расходы.Сумма, Расходы.Дата FROM Пользователь INNER JOIN (Категории_расходов INNER JOIN Расходы ON Категории_расходов.Код_категории_расхода = Расходы.Код_категории_расхода) ON Пользователь.Код_пользователя = Расходы.Код_пользователя WHERE DATE() = Расходы.Дата  ORDER BY Расходы.Код_расхода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Расходы");
            dataGridView1.DataSource = ds.Tables["Расходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код расхода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Расходы за день";
        }

        private void заНеделюToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (night == true)
            {
                btnAllR.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekR.ForeColor = Color.Salmon;
                btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

                btnAllD.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
            }
            else
            {
                btnAllR.ForeColor = Color.Black;
                btnDayR.ForeColor = Color.Black;
                btnWeekR.ForeColor = Color.FromArgb(228,68,50);
                btnMonthR.ForeColor = Color.Black;
                btnYearR.ForeColor = Color.Black;

                btnAllD.ForeColor = Color.Black;
                btnDayD.ForeColor = Color.Black;
                btnWeekD.ForeColor = Color.Black;
                btnYearD.ForeColor = Color.Black;
                btnMonthD.ForeColor = Color.Black;
            }
            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem1.Checked = false;
            заДеньToolStripMenuItem2.Checked = false;
            заНеделюToolStripMenuItem2.Checked = true;
            заМесяцToolStripMenuItem2.Checked = false;
            заГодToolStripMenuItem2.Checked = false;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem.Checked = false;
            заДеньToolStripMenuItem1.Checked = false;
            заНеделюToolStripMenuItem1.Checked = false;
            заМесяцToolStripMenuItem1.Checked = false;
            заГодToolStripMenuItem1.Checked = false;

            button10.Visible = false;
            button9.Visible = true;

            ToolBarLabel.Text = "Расходы";
            btnAllR.Visible = true;
            btnDayR.Visible = true;
            btnWeekR.Visible = true;
            btnMonthR.Visible = true;
            btnYearR.Visible = true;

            btnAllD.Visible = false;
            btnDayD.Visible = false;
            btnWeekD.Visible = false;
            btnMonthD.Visible = false;
            btnYearD.Visible = false;

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Расходы.Код_расхода, Пользователь.Имя_пользователя, Категории_расходов.Название_категории_расхода, Расходы.Сумма, Расходы.Дата FROM Пользователь INNER JOIN (Категории_расходов INNER JOIN Расходы ON Категории_расходов.Код_категории_расхода = Расходы.Код_категории_расхода) ON Пользователь.Код_пользователя = Расходы.Код_пользователя WHERE Расходы.Дата Between Date() and Date()-6 ORDER BY Расходы.Код_расхода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Расходы");
            dataGridView1.DataSource = ds.Tables["Расходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код расхода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Расходы за неделю";
        }

        private void заМесяцToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (night == true)
            {
                btnAllR.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthR.ForeColor = Color.Salmon;
                btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

                btnAllD.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
            }
            else
            {
                btnAllR.ForeColor = Color.Black;
                btnDayR.ForeColor = Color.Black;
                btnWeekR.ForeColor = Color.Black;
                btnMonthR.ForeColor = Color.FromArgb(228,68,50);
                btnYearR.ForeColor = Color.Black;

                btnAllD.ForeColor = Color.Black;
                btnDayD.ForeColor = Color.Black;
                btnWeekD.ForeColor = Color.Black;
                btnYearD.ForeColor = Color.Black;
                btnMonthD.ForeColor = Color.Black;
            }
            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem1.Checked = false;
            заДеньToolStripMenuItem2.Checked = false;
            заНеделюToolStripMenuItem2.Checked = false;
            заМесяцToolStripMenuItem2.Checked = true;
            заГодToolStripMenuItem2.Checked = false;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem.Checked = false;
            заДеньToolStripMenuItem1.Checked = false;
            заНеделюToolStripMenuItem1.Checked = false;
            заМесяцToolStripMenuItem1.Checked = false;
            заГодToolStripMenuItem1.Checked = false;

            button10.Visible = false;
            button9.Visible = true;

            ToolBarLabel.Text = "Расходы";
            btnAllR.Visible = true;
            btnDayR.Visible = true;
            btnWeekR.Visible = true;
            btnMonthR.Visible = true;
            btnYearR.Visible = true;

            btnAllD.Visible = false;
            btnDayD.Visible = false;
            btnWeekD.Visible = false;
            btnMonthD.Visible = false;
            btnYearD.Visible = false;

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Расходы.Код_расхода, Пользователь.Имя_пользователя, Категории_расходов.Название_категории_расхода, Расходы.Сумма, Расходы.Дата FROM Пользователь INNER JOIN (Категории_расходов INNER JOIN Расходы ON Категории_расходов.Код_категории_расхода = Расходы.Код_категории_расхода) ON Пользователь.Код_пользователя = Расходы.Код_пользователя WHERE Year([Расходы.Дата]) = Year(Now()) And Month([Расходы.Дата]) = Month(Now()) ORDER BY Расходы.Код_расхода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Расходы");
            dataGridView1.DataSource = ds.Tables["Расходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код расхода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Расходы за месяц";
        }

        private void заГодToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (night == true)
            {
                btnAllR.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearR.ForeColor = Color.Salmon;

                btnAllD.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
            }
            else
            {
                btnAllR.ForeColor = Color.Black;
                btnDayR.ForeColor = Color.Black;
                btnWeekR.ForeColor = Color.Black;
                btnMonthR.ForeColor = Color.Black;
                btnYearR.ForeColor = Color.FromArgb(228,68,50);

                btnAllD.ForeColor = Color.Black;
                btnDayD.ForeColor = Color.Black;
                btnWeekD.ForeColor = Color.Black;
                btnYearD.ForeColor = Color.Black;
                btnMonthD.ForeColor = Color.Black;
            }
            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem1.Checked = false;
            заДеньToolStripMenuItem2.Checked = false;
            заНеделюToolStripMenuItem2.Checked = false;
            заМесяцToolStripMenuItem2.Checked = false;
            заГодToolStripMenuItem2.Checked = true;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem.Checked = false;
            заДеньToolStripMenuItem1.Checked = false;
            заНеделюToolStripMenuItem1.Checked = false;
            заМесяцToolStripMenuItem1.Checked = false;
            заГодToolStripMenuItem1.Checked = false;

            button10.Visible = false;
            button9.Visible = true;

            ToolBarLabel.Text = "Расходы";
            btnAllR.Visible = true;
            btnDayR.Visible = true;
            btnWeekR.Visible = true;
            btnMonthR.Visible = true;
            btnYearR.Visible = true;

            btnAllD.Visible = false;
            btnDayD.Visible = false;
            btnWeekD.Visible = false;
            btnMonthD.Visible = false;
            btnYearD.Visible = false;

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Расходы.Код_расхода, Пользователь.Имя_пользователя, Категории_расходов.Название_категории_расхода, Расходы.Сумма, Расходы.Дата FROM Пользователь INNER JOIN (Категории_расходов INNER JOIN Расходы ON Категории_расходов.Код_категории_расхода = Расходы.Код_категории_расхода) ON Пользователь.Код_пользователя = Расходы.Код_пользователя WHERE Year([Расходы.Дата]) = Year(Date()) ORDER BY Расходы.Код_расхода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Расходы");
            dataGridView1.DataSource = ds.Tables["Расходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код расхода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Расходы за год";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //сохр расход

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;

            string sql;
            OleDbCommand myCommand;

            int kod = dataGridView1.RowCount;
            string user = Convert.ToString(comboBox1.SelectedValue);
            string category = Convert.ToString(comboBox2.SelectedValue);
            string sum = Convert.ToString(textBox3.Text);
            string date = Convert.ToString(dateTimePicker1.Text);
            sql = "INSERT INTO Расходы (Код_расхода, Код_пользователя, Код_категории_расхода, Сумма, Дата) " +
              "VALUES (" + kod + "," + user + "," + category + ",'" + sum + "','" + date + "')";
            MessageBox.Show(sql);

            myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            myCommand.ExecuteNonQuery();
            connection.Close();

            connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            sql = "SELECT Расходы.Код_расхода, Пользователь.Имя_пользователя, Категории_расходов.Название_категории_расхода, Расходы.Сумма, Расходы.Дата FROM Пользователь INNER JOIN(Категории_расходов INNER JOIN Расходы ON Категории_расходов.Код_категории_расхода = Расходы.Код_категории_расхода) ON Пользователь.Код_пользователя = Расходы.Код_пользователя  ORDER BY Расходы.Код_расхода; ";
            myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Расходы");
            dataGridView1.DataSource = ds.Tables["Расходы"].DefaultView;
            connection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //редакт расход

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " UPDATE Расходы SET  " +
                         " Код_пользователя = " + comboBox1.SelectedValue + ", " +
                         " Код_категории_расхода  = " + comboBox2.SelectedValue + ", " +
                         " Сумма = '" + textBox3.Text + "', " +
                         " Дата = '" + dateTimePicker1.Text + "' " +
                         " WHERE Код_расхода = " + indexprovider + "";
            MessageBox.Show(sql);
            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            myCommand.ExecuteNonQuery();
            connection.Close();

            connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            sql = " SELECT Расходы.Код_расхода, Пользователь.Имя_пользователя, Категории_расходов.Название_категории_расхода, Расходы.Сумма, Расходы.Дата FROM Пользователь INNER JOIN (Категории_расходов INNER JOIN Расходы ON Категории_расходов.Код_категории_расхода = Расходы.Код_категории_расхода) ON Пользователь.Код_пользователя = Расходы.Код_пользователя  ORDER BY Расходы.Код_расхода;";

            myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Расходы");
            dataGridView1.DataSource = ds.Tables["Расходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код расхода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Расходы за всё время";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //сохр доход

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;

            string sql;
            OleDbCommand myCommand;

            int kod = dataGridView1.RowCount;
            string user = Convert.ToString(comboBox4.SelectedValue);
            string category = Convert.ToString(comboBox3.SelectedValue);
            string sum = Convert.ToString(textBox4.Text);
            string date = Convert.ToString(dateTimePicker2.Text);
            sql = "INSERT INTO Доходы (Код_дохода, Код_пользователя, Код_категории_дохода, Сумма, Дата) " +
              "VALUES (" + kod + "," + user + "," + category + ",'" + sum + "','" + date + "')";
            MessageBox.Show(sql);

            myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            myCommand.ExecuteNonQuery();
            connection.Close();

            connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            sql = "SELECT Доходы.Код_дохода, Пользователь.Имя_пользователя, Категории_доходов.Название_категории_дохода, Доходы.Сумма, Доходы.Дата FROM Пользователь INNER JOIN(Категории_доходов INNER JOIN Доходы ON Категории_доходов.Код_категории_дохода = Доходы.Код_категории_дохода) ON Пользователь.Код_пользователя = Доходы.Код_пользователя  ORDER BY Доходы.Код_дохода; ";
            myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Доходы");
            dataGridView1.DataSource = ds.Tables["Доходы"].DefaultView;
            connection.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //редакт доход

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " UPDATE Доходы SET  " +
                         " Код_пользователя = " + comboBox4.SelectedValue + ", " +
                         " Код_категории_дохода  = " + comboBox3.SelectedValue  + ", " +
                         " Сумма = '" + textBox4.Text + "', " +
                         " Дата = '" + dateTimePicker2.Text + "' " +
                         " WHERE Код_дохода = " + indexprovider + "";
            //MessageBox.Show(sql);
            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            myCommand.ExecuteNonQuery();
            connection.Close();

            connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            sql = " SELECT Доходы.Код_дохода, Пользователь.Имя_пользователя, Категории_доходов.Название_категории_дохода, Доходы.Сумма, Доходы.Дата FROM Пользователь INNER JOIN (Категории_доходов INNER JOIN Доходы ON Категории_доходов.Код_категории_дохода = Доходы.Код_категории_дохода) ON Пользователь.Код_пользователя = Доходы.Код_пользователя  ORDER BY Доходы.Код_дохода;";

            myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Доходы");
            dataGridView1.DataSource = ds.Tables["Доходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код дохода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Доходы за всё время";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //удаление расхода

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
            sql = " SELECT Расходы.Код_расхода, Пользователь.Имя_пользователя, Категории_расходов.Название_категории_расхода, Расходы.Сумма, Расходы.Дата FROM Пользователь INNER JOIN (Категории_расходов INNER JOIN Расходы ON Категории_расходов.Код_категории_расхода = Расходы.Код_категории_расхода) ON Пользователь.Код_пользователя = Расходы.Код_пользователя  ORDER BY Расходы.Код_расхода;";

            myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Расходы");
            dataGridView1.DataSource = ds.Tables["Расходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код расхода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //удаление дохода
            
            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;

            string sql = "DELETE * FROM Доходы WHERE Код_дохода = " + indexprovider + "";
            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            myCommand.ExecuteNonQuery();
            connection.Close();

            connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            sql = " SELECT Доходы.Код_дохода, Пользователь.Имя_пользователя, Категории_доходов.Название_категории_дохода, Доходы.Сумма, Доходы.Дата FROM Пользователь INNER JOIN (Категории_доходов INNER JOIN Доходы ON Категории_доходов.Код_категории_дохода = Доходы.Код_категории_дохода) ON Пользователь.Код_пользователя = Доходы.Код_пользователя  ORDER BY Доходы.Код_дохода;";

            myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Доходы");
            dataGridView1.DataSource = ds.Tables["Доходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код дохода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Доходы за всё время";
        }

        
        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users newUsers = new Users();
            newUsers.Show();
        }

        private void доходыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Income newIncome = new Income();
            newIncome.Show();
        }

        private void категорииДоходовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Category_income newCategory_income = new Category_income();
            newCategory_income.Show();
        }

        private void расходыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Costs newCosts = new Costs();
            newCosts.Show();
        }

        private void категорииРасходовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Category_costs newCategory_costs = new Category_costs();
            newCategory_costs.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutUs newAboutUs = new AboutUs();
            newAboutUs.Show();
        }

        private void ToolBar_Click(object sender, EventArgs e)
        {
            ToolBar.Checked = !ToolBar.Checked;
            toolStrip1.Visible = !toolStrip1.Visible;
        }

        private void btnAllR_Click(object sender, EventArgs e)
        {
            if (night == true)
            {
                btnAllR.ForeColor = Color.Salmon;
                btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

                btnAllD.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
            }
            else
            {
                btnAllR.ForeColor = Color.FromArgb(228,68,50);
                btnDayR.ForeColor = Color.Black;
                btnWeekR.ForeColor = Color.Black;
                btnMonthR.ForeColor = Color.Black;
                btnYearR.ForeColor = Color.Black;

                btnAllD.ForeColor = Color.Black;
                btnDayD.ForeColor = Color.Black;
                btnWeekD.ForeColor = Color.Black;
                btnYearD.ForeColor = Color.Black;
                btnMonthD.ForeColor = Color.Black;
            }
            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem1.Checked = true;
            заДеньToolStripMenuItem2.Checked = false;
            заНеделюToolStripMenuItem2.Checked = false;
            заМесяцToolStripMenuItem2.Checked = false;
            заГодToolStripMenuItem2.Checked = false;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem.Checked = false;
            заДеньToolStripMenuItem1.Checked = false;
            заНеделюToolStripMenuItem1.Checked = false;
            заМесяцToolStripMenuItem1.Checked = false;
            заГодToolStripMenuItem1.Checked = false;

            ToolBarLabel.Text = "Расходы";
            btnAllR.Visible = true;
            btnDayR.Visible = true;
            btnWeekR.Visible = true;
            btnMonthR.Visible = true;
            btnYearR.Visible = true;

            btnAllD.Visible = false;
            btnDayD.Visible = false;
            btnWeekD.Visible = false;
            btnMonthD.Visible = false;
            btnYearD.Visible = false;

            button10.Visible = false;
            button9.Visible = true;
            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Расходы.Код_расхода, Пользователь.Имя_пользователя, Категории_расходов.Название_категории_расхода, Расходы.Сумма, Расходы.Дата FROM Пользователь INNER JOIN (Категории_расходов INNER JOIN Расходы ON Категории_расходов.Код_категории_расхода = Расходы.Код_категории_расхода) ON Пользователь.Код_пользователя = Расходы.Код_пользователя  ORDER BY Расходы.Код_расхода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Расходы");
            dataGridView1.DataSource = ds.Tables["Расходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код расхода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Расходы за всё время";

        }

        private void btnDayR_Click(object sender, EventArgs e)
        {
            if (night == true)
            {
                btnAllR.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayR.ForeColor = Color.Salmon;
                btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

                btnAllD.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
            }
            else
            {
                btnAllR.ForeColor = Color.Black;
                btnDayR.ForeColor = Color.FromArgb(228,68,50);
                btnWeekR.ForeColor = Color.Black;
                btnMonthR.ForeColor = Color.Black;
                btnYearR.ForeColor = Color.Black;

                btnAllD.ForeColor = Color.Black;
                btnDayD.ForeColor = Color.Black;
                btnWeekD.ForeColor = Color.Black;
                btnYearD.ForeColor = Color.Black;
                btnMonthD.ForeColor = Color.Black;
            }

            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem1.Checked = false;
            заДеньToolStripMenuItem2.Checked = true;
            заНеделюToolStripMenuItem2.Checked = false;
            заМесяцToolStripMenuItem2.Checked = false;
            заГодToolStripMenuItem2.Checked = false;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem.Checked = false;
            заДеньToolStripMenuItem1.Checked = false;
            заНеделюToolStripMenuItem1.Checked = false;
            заМесяцToolStripMenuItem1.Checked = false;
            заГодToolStripMenuItem1.Checked = false;

            button10.Visible = false;
            button9.Visible = true;

            ToolBarLabel.Text = "Расходы";
            btnAllR.Visible = true;
            btnDayR.Visible = true;
            btnWeekR.Visible = true;
            btnMonthR.Visible = true;
            btnYearR.Visible = true;

            btnAllD.Visible = false;
            btnDayD.Visible = false;
            btnWeekD.Visible = false;
            btnMonthD.Visible = false;
            btnYearD.Visible = false;

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Расходы.Код_расхода, Пользователь.Имя_пользователя, Категории_расходов.Название_категории_расхода, Расходы.Сумма, Расходы.Дата FROM Пользователь INNER JOIN (Категории_расходов INNER JOIN Расходы ON Категории_расходов.Код_категории_расхода = Расходы.Код_категории_расхода) ON Пользователь.Код_пользователя = Расходы.Код_пользователя WHERE DATE() = Расходы.Дата  ORDER BY Расходы.Код_расхода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Расходы");
            dataGridView1.DataSource = ds.Tables["Расходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код расхода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Расходы за день";
        }

        private void btnWeekR_Click(object sender, EventArgs e)
        {
            if (night == true)
            {
                btnAllR.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekR.ForeColor = Color.Salmon;
                btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

                btnAllD.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
            }
            else
            {
                btnAllR.ForeColor = Color.Black;
                btnDayR.ForeColor = Color.Black;
                btnWeekR.ForeColor = Color.FromArgb(228,68,50);
                btnMonthR.ForeColor = Color.Black;
                btnYearR.ForeColor = Color.Black;

                btnAllD.ForeColor = Color.Black;
                btnDayD.ForeColor = Color.Black;
                btnWeekD.ForeColor = Color.Black;
                btnYearD.ForeColor = Color.Black;
                btnMonthD.ForeColor = Color.Black;
            }

            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem1.Checked = false;
            заДеньToolStripMenuItem2.Checked = false;
            заНеделюToolStripMenuItem2.Checked = true;
            заМесяцToolStripMenuItem2.Checked = false;
            заГодToolStripMenuItem2.Checked = false;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem.Checked = false;
            заДеньToolStripMenuItem1.Checked = false;
            заНеделюToolStripMenuItem1.Checked = false;
            заМесяцToolStripMenuItem1.Checked = false;
            заГодToolStripMenuItem1.Checked = false;

            button10.Visible = false;
            button9.Visible = true;

            ToolBarLabel.Text = "Расходы";
            btnAllR.Visible = true;
            btnDayR.Visible = true;
            btnWeekR.Visible = true;
            btnMonthR.Visible = true;
            btnYearR.Visible = true;

            btnAllD.Visible = false;
            btnDayD.Visible = false;
            btnWeekD.Visible = false;
            btnMonthD.Visible = false;
            btnYearD.Visible = false;

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Расходы.Код_расхода, Пользователь.Имя_пользователя, Категории_расходов.Название_категории_расхода, Расходы.Сумма, Расходы.Дата FROM Пользователь INNER JOIN (Категории_расходов INNER JOIN Расходы ON Категории_расходов.Код_категории_расхода = Расходы.Код_категории_расхода) ON Пользователь.Код_пользователя = Расходы.Код_пользователя WHERE Расходы.Дата Between Date() and Date()-6 ORDER BY Расходы.Код_расхода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Расходы");
            dataGridView1.DataSource = ds.Tables["Расходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код расхода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Расходы за неделю";
        }

        private void btnMonthR_Click(object sender, EventArgs e)
        {
            if (night == true)
            {
                btnAllR.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthR.ForeColor = Color.Salmon;
                btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

                btnAllD.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
            }
            else
            {
                btnAllR.ForeColor = Color.Black;
                btnDayR.ForeColor = Color.Black;
                btnWeekR.ForeColor = Color.Black;
                btnMonthR.ForeColor = Color.FromArgb(228,68,50);
                btnYearR.ForeColor = Color.Black;

                btnAllD.ForeColor = Color.Black;
                btnDayD.ForeColor = Color.Black;
                btnWeekD.ForeColor = Color.Black;
                btnYearD.ForeColor = Color.Black;
                btnMonthD.ForeColor = Color.Black;
            }

            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem1.Checked = false;
            заДеньToolStripMenuItem2.Checked = false;
            заНеделюToolStripMenuItem2.Checked = false;
            заМесяцToolStripMenuItem2.Checked = true;
            заГодToolStripMenuItem2.Checked = false;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem.Checked = false;
            заДеньToolStripMenuItem1.Checked = false;
            заНеделюToolStripMenuItem1.Checked = false;
            заМесяцToolStripMenuItem1.Checked = false;
            заГодToolStripMenuItem1.Checked = false;

            button10.Visible = false;
            button9.Visible = true;

            ToolBarLabel.Text = "Расходы";
            btnAllR.Visible = true;
            btnDayR.Visible = true;
            btnWeekR.Visible = true;
            btnMonthR.Visible = true;
            btnYearR.Visible = true;

            btnAllD.Visible = false;
            btnDayD.Visible = false;
            btnWeekD.Visible = false;
            btnMonthD.Visible = false;
            btnYearD.Visible = false;

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Расходы.Код_расхода, Пользователь.Имя_пользователя, Категории_расходов.Название_категории_расхода, Расходы.Сумма, Расходы.Дата FROM Пользователь INNER JOIN (Категории_расходов INNER JOIN Расходы ON Категории_расходов.Код_категории_расхода = Расходы.Код_категории_расхода) ON Пользователь.Код_пользователя = Расходы.Код_пользователя WHERE Year([Расходы.Дата]) = Year(Now()) And Month([Расходы.Дата]) = Month(Now()) ORDER BY Расходы.Код_расхода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Расходы");
            dataGridView1.DataSource = ds.Tables["Расходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код расхода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Расходы за месяц";
        }

        private void btnYearR_Click(object sender, EventArgs e)
        {
            if (night == true)
            {
                btnAllR.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearR.ForeColor = Color.Salmon;

                btnAllD.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
            }
            else
            {
                btnAllR.ForeColor = Color.Black;
                btnDayR.ForeColor = Color.Black;
                btnWeekR.ForeColor = Color.Black;
                btnMonthR.ForeColor = Color.Black;
                btnYearR.ForeColor = Color.FromArgb(228,68,50);

                btnAllD.ForeColor = Color.Black;
                btnDayD.ForeColor = Color.Black;
                btnWeekD.ForeColor = Color.Black;
                btnYearD.ForeColor = Color.Black;
                btnMonthD.ForeColor = Color.Black;
            }

            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem1.Checked = false;
            заДеньToolStripMenuItem2.Checked = false;
            заНеделюToolStripMenuItem2.Checked = false;
            заМесяцToolStripMenuItem2.Checked = false;
            заГодToolStripMenuItem2.Checked = true;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem.Checked = false;
            заДеньToolStripMenuItem1.Checked = false;
            заНеделюToolStripMenuItem1.Checked = false;
            заМесяцToolStripMenuItem1.Checked = false;
            заГодToolStripMenuItem1.Checked = false;

            button10.Visible = false;
            button9.Visible = true;

            ToolBarLabel.Text = "Расходы";
            btnAllR.Visible = true;
            btnDayR.Visible = true;
            btnWeekR.Visible = true;
            btnMonthR.Visible = true;
            btnYearR.Visible = true;

            btnAllD.Visible = false;
            btnDayD.Visible = false;
            btnWeekD.Visible = false;
            btnMonthD.Visible = false;
            btnYearD.Visible = false;

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Расходы.Код_расхода, Пользователь.Имя_пользователя, Категории_расходов.Название_категории_расхода, Расходы.Сумма, Расходы.Дата FROM Пользователь INNER JOIN (Категории_расходов INNER JOIN Расходы ON Категории_расходов.Код_категории_расхода = Расходы.Код_категории_расхода) ON Пользователь.Код_пользователя = Расходы.Код_пользователя WHERE Year([Расходы.Дата]) = Year(Date()) ORDER BY Расходы.Код_расхода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Расходы");
            dataGridView1.DataSource = ds.Tables["Расходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код расхода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Расходы за год";
        }

        private void btnAllD_Click(object sender, EventArgs e)
        {
            if (night == true)
            {
                btnAllR.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

                btnAllD.ForeColor = Color.Salmon;
                btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
            }
            else
            {
                btnAllR.ForeColor = Color.Black;
                btnDayR.ForeColor = Color.Black;
                btnWeekR.ForeColor = Color.Black;
                btnMonthR.ForeColor = Color.Black;
                btnYearR.ForeColor = Color.Black;

                btnAllD.ForeColor = Color.FromArgb(228,68,50);
                btnDayD.ForeColor = Color.Black;
                btnWeekD.ForeColor = Color.Black;
                btnYearD.ForeColor = Color.Black;
                btnMonthD.ForeColor = Color.Black;
            }

            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem1.Checked = false;
            заДеньToolStripMenuItem2.Checked = false;
            заНеделюToolStripMenuItem2.Checked = false;
            заМесяцToolStripMenuItem2.Checked = false;
            заГодToolStripMenuItem2.Checked = false;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem.Checked = true;
            заДеньToolStripMenuItem1.Checked = false;
            заНеделюToolStripMenuItem1.Checked = false;
            заМесяцToolStripMenuItem1.Checked = false;
            заГодToolStripMenuItem1.Checked = false;

            button9.Visible = false;
            button10.Visible = true;

            ToolBarLabel.Text = "Доходы";
            btnAllD.Visible = true;
            btnDayD.Visible = true;
            btnWeekD.Visible = true;
            btnMonthD.Visible = true;
            btnYearD.Visible = true;

            btnAllR.Visible = false;
            btnDayR.Visible = false;
            btnWeekR.Visible = false;
            btnMonthR.Visible = false;
            btnYearR.Visible = false;


            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Доходы.Код_дохода, Пользователь.Имя_пользователя, Категории_доходов.Название_категории_дохода, Доходы.Сумма, Доходы.Дата FROM Пользователь INNER JOIN (Категории_доходов INNER JOIN Доходы ON Категории_доходов.Код_категории_дохода = Доходы.Код_категории_дохода) ON Пользователь.Код_пользователя = Доходы.Код_пользователя  ORDER BY Доходы.Код_дохода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Доходы");
            dataGridView1.DataSource = ds.Tables["Доходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код дохода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Доходы за всё время";
        }

        private void btnDayD_Click(object sender, EventArgs e)
        {
            if (night == true)
            {
                btnAllR.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

                btnAllD.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayD.ForeColor = Color.Salmon;
                btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
            }
            else
            {
                btnAllR.ForeColor = Color.Black;
                btnDayR.ForeColor = Color.Black;
                btnWeekR.ForeColor = Color.Black;
                btnMonthR.ForeColor = Color.Black;
                btnYearR.ForeColor = Color.Black;

                btnAllD.ForeColor = Color.Black;
                btnDayD.ForeColor = Color.FromArgb(228,68,50);
                btnWeekD.ForeColor = Color.Black;
                btnYearD.ForeColor = Color.Black;
                btnMonthD.ForeColor = Color.Black;
            }

            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem1.Checked = false;
            заДеньToolStripMenuItem2.Checked = false;
            заНеделюToolStripMenuItem2.Checked = false;
            заМесяцToolStripMenuItem2.Checked = false;
            заГодToolStripMenuItem2.Checked = false;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem.Checked = false;
            заДеньToolStripMenuItem1.Checked = true;
            заНеделюToolStripMenuItem1.Checked = false;
            заМесяцToolStripMenuItem1.Checked = false;
            заГодToolStripMenuItem1.Checked = false;

            button9.Visible = false;
            button10.Visible = true;

            ToolBarLabel.Text = "Доходы";
            btnAllD.Visible = true;
            btnDayD.Visible = true;
            btnWeekD.Visible = true;
            btnMonthD.Visible = true;
            btnYearD.Visible = true;

            btnAllR.Visible = false;
            btnDayR.Visible = false;
            btnWeekR.Visible = false;
            btnMonthR.Visible = false;
            btnYearR.Visible = false;
            DateTime dt = DateTime.Now;
            string curDate = dt.ToShortDateString();

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Доходы.Код_дохода, Пользователь.Имя_пользователя, Категории_доходов.Название_категории_дохода, Доходы.Сумма, Доходы.Дата FROM Пользователь INNER JOIN (Категории_доходов INNER JOIN Доходы ON Категории_доходов.Код_категории_дохода = Доходы.Код_категории_дохода) ON Пользователь.Код_пользователя = Доходы.Код_пользователя  WHERE DATE() = Доходы.Дата  ORDER BY Доходы.Код_дохода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Доходы");
            dataGridView1.DataSource = ds.Tables["Доходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код дохода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Доходы за день";
        }

        private void btnWeekD_Click(object sender, EventArgs e)
        {
            if (night == true)
            {
                btnAllR.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

                btnAllD.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekD.ForeColor = Color.Salmon;
                btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
            }
            else
            {
                btnAllR.ForeColor = Color.Black;
                btnDayR.ForeColor = Color.Black;
                btnWeekR.ForeColor = Color.Black;
                btnMonthR.ForeColor = Color.Black;
                btnYearR.ForeColor = Color.Black;

                btnAllD.ForeColor = Color.Black;
                btnDayD.ForeColor = Color.Black;
                btnWeekD.ForeColor = Color.FromArgb(228,68,50);
                btnYearD.ForeColor = Color.Black;
                btnMonthD.ForeColor = Color.Black;
            }

            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem1.Checked = false;
            заДеньToolStripMenuItem2.Checked = false;
            заНеделюToolStripMenuItem2.Checked = false;
            заМесяцToolStripMenuItem2.Checked = false;
            заГодToolStripMenuItem2.Checked = false;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem.Checked = false;
            заДеньToolStripMenuItem1.Checked = false;
            заНеделюToolStripMenuItem1.Checked = true;
            заМесяцToolStripMenuItem1.Checked = false;
            заГодToolStripMenuItem1.Checked = false;

            button9.Visible = false;
            button10.Visible = true;

            ToolBarLabel.Text = "Доходы";
            btnAllD.Visible = true;
            btnDayD.Visible = true;
            btnWeekD.Visible = true;
            btnMonthD.Visible = true;
            btnYearD.Visible = true;

            btnAllR.Visible = false;
            btnDayR.Visible = false;
            btnWeekR.Visible = false;
            btnMonthR.Visible = false;
            btnYearR.Visible = false;

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Доходы.Код_дохода, Пользователь.Имя_пользователя, Категории_доходов.Название_категории_дохода, Доходы.Сумма, Доходы.Дата FROM Пользователь INNER JOIN (Категории_доходов INNER JOIN Доходы ON Категории_доходов.Код_категории_дохода = Доходы.Код_категории_дохода) ON Пользователь.Код_пользователя = Доходы.Код_пользователя WHERE Доходы.Дата Between Date() and Date()-6 ORDER BY Доходы.Код_дохода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Доходы");
            dataGridView1.DataSource = ds.Tables["Доходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код дохода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Доходы за неделю";
        }

        private void btnYearD_Click(object sender, EventArgs e)
        {
            if (night == true)
            {
                btnAllR.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

                btnAllD.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearD.ForeColor = Color.Salmon;
                btnMonthD.ForeColor = Color.FromArgb(222, 222, 224);
            }
            else
            {
                btnAllR.ForeColor = Color.Black;
                btnDayR.ForeColor = Color.Black;
                btnWeekR.ForeColor = Color.Black;
                btnMonthR.ForeColor = Color.Black;
                btnYearR.ForeColor = Color.Black;

                btnAllD.ForeColor = Color.Black;
                btnDayD.ForeColor = Color.Black;
                btnWeekD.ForeColor = Color.Black;
                btnYearD.ForeColor = Color.FromArgb(228,68,50);
                btnMonthD.ForeColor = Color.Black;
            }

            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem1.Checked = false;
            заДеньToolStripMenuItem2.Checked = false;
            заНеделюToolStripMenuItem2.Checked = false;
            заМесяцToolStripMenuItem2.Checked = false;
            заГодToolStripMenuItem2.Checked = false;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem.Checked = false;
            заДеньToolStripMenuItem1.Checked = false;
            заНеделюToolStripMenuItem1.Checked = false;
            заМесяцToolStripMenuItem1.Checked = false;
            заГодToolStripMenuItem1.Checked = true;

            button9.Visible = false;
            button10.Visible = true;

            ToolBarLabel.Text = "Доходы";
            btnAllD.Visible = true;
            btnDayD.Visible = true;
            btnWeekD.Visible = true;
            btnMonthD.Visible = true;
            btnYearD.Visible = true;

            btnAllR.Visible = false;
            btnDayR.Visible = false;
            btnWeekR.Visible = false;
            btnMonthR.Visible = false;
            btnYearR.Visible = false;

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Доходы.Код_дохода, Пользователь.Имя_пользователя, Категории_доходов.Название_категории_дохода, Доходы.Сумма, Доходы.Дата FROM Пользователь INNER JOIN (Категории_доходов INNER JOIN Доходы ON Категории_доходов.Код_категории_дохода = Доходы.Код_категории_дохода) ON Пользователь.Код_пользователя = Доходы.Код_пользователя WHERE Year([Доходы.Дата]) = Year(Date()) ORDER BY Доходы.Код_дохода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Доходы");
            dataGridView1.DataSource = ds.Tables["Доходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код дохода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Доходы за год";
        }

        private void btnMonthD_Click(object sender, EventArgs e)
        {
            if (night == true)
            {
                btnAllR.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayR.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekR.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthR.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearR.ForeColor = Color.FromArgb(222, 222, 224);

                btnAllD.ForeColor = Color.FromArgb(222, 222, 224);
                btnDayD.ForeColor = Color.FromArgb(222, 222, 224);
                btnWeekD.ForeColor = Color.FromArgb(222, 222, 224);
                btnYearD.ForeColor = Color.FromArgb(222, 222, 224);
                btnMonthD.ForeColor = Color.Salmon;
            }
            else
            {
                btnAllR.ForeColor = Color.Black;
                btnDayR.ForeColor = Color.Black;
                btnWeekR.ForeColor = Color.Black;
                btnMonthR.ForeColor = Color.Black;
                btnYearR.ForeColor = Color.Black;

                btnAllD.ForeColor = Color.Black;
                btnDayD.ForeColor = Color.Black;
                btnWeekD.ForeColor = Color.Black;
                btnYearD.ForeColor = Color.Black;
                btnMonthD.ForeColor = Color.FromArgb(228,68,50);
            }

            //расходы
            расходыToolStripMenuItem.BackColor = Color.FromArgb(253, 253, 253);
            заВсёВремяToolStripMenuItem1.Checked = false;
            заДеньToolStripMenuItem2.Checked = false;
            заНеделюToolStripMenuItem2.Checked = false;
            заМесяцToolStripMenuItem2.Checked = false;
            заГодToolStripMenuItem2.Checked = false;
            //доходы
            доходыToolStripMenuItem.BackColor = Color.FromArgb(220, 220, 220);
            заВсёВремяToolStripMenuItem.Checked = false;
            заДеньToolStripMenuItem1.Checked = false;
            заНеделюToolStripMenuItem1.Checked = false;
            заМесяцToolStripMenuItem1.Checked = true;
            заГодToolStripMenuItem1.Checked = false;

            button9.Visible = false;
            button10.Visible = true;

            ToolBarLabel.Text = "Доходы";
            btnAllD.Visible = true;
            btnDayD.Visible = true;
            btnWeekD.Visible = true;
            btnMonthD.Visible = true;
            btnYearD.Visible = true;

            btnAllR.Visible = false;
            btnDayR.Visible = false;
            btnWeekR.Visible = false;
            btnMonthR.Visible = false;
            btnYearR.Visible = false;

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Доходы.Код_дохода, Пользователь.Имя_пользователя, Категории_доходов.Название_категории_дохода, Доходы.Сумма, Доходы.Дата FROM Пользователь INNER JOIN (Категории_доходов INNER JOIN Доходы ON Категории_доходов.Код_категории_дохода = Доходы.Код_категории_дохода) ON Пользователь.Код_пользователя = Доходы.Код_пользователя WHERE Year([Доходы.Дата]) = Year(Now()) And Month([Доходы.Дата]) = Month(Now()) ORDER BY Доходы.Код_дохода;";

            OleDbCommand myCommand = new OleDbCommand(sql, connection);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Доходы");
            dataGridView1.DataSource = ds.Tables["Доходы"].DefaultView;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].HeaderText = "Код дохода";
            dataGridView1.Columns[1].HeaderText = "Имя пользователя";
            dataGridView1.Columns[2].HeaderText = "Категория";
            dataGridView1.Columns[3].HeaderText = "Сумма";
            dataGridView1.Columns[4].HeaderText = "Дата";
            connection.Close();

            label1.Text = "Доходы за месяц";
        }

        private void btnReportAll_Click(object sender, EventArgs e)
        {
            ReportAll newReportAll = new ReportAll();
            newReportAll.Show();

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Расходы.Код_расхода, Пользователь.Имя_пользователя, Категории_расходов.Название_категории_расхода, Расходы.Сумма, Расходы.Дата FROM Пользователь INNER JOIN (Категории_расходов INNER JOIN Расходы ON Категории_расходов.Код_категории_расхода = Расходы.Код_категории_расхода) ON Пользователь.Код_пользователя = Расходы.Код_пользователя ORDER BY Расходы.Код_расхода;";
            OleDbCommand myCommand = new OleDbCommand(sql, connection);

            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Расходы");
            ds.WriteXmlSchema("CReportAllXML.xml");

            CReportAll rpt = new CReportAll();
            rpt.SetDataSource(ds);
            newReportAll.crystalReportViewer1.ReportSource = rpt;
            
            connection.Close();
        }
      
        private void btnReportAllD_Click(object sender, EventArgs e)
        {
            ReportAllD newReportAllD = new ReportAllD();
            newReportAllD.Show();

        }

        private void btnReportDayD_Click(object sender, EventArgs e)
        {
            ReportDayD newReportDayD = new ReportDayD();
            newReportDayD.Show();
        }

        private void btnReportWeekD_Click(object sender, EventArgs e)
        {
            ReportWeekD newReportWeekD = new ReportWeekD();
            newReportWeekD.Show();
        }

        private void btnReportMonthD_Click(object sender, EventArgs e)
        {
            ReportMonthD newReportMonthD = new ReportMonthD();
            newReportMonthD.Show();
        }

        private void btnReportYearD_Click(object sender, EventArgs e)
        {
            ReportYearD newReportYearD = new ReportYearD();
            newReportYearD.Show();
        }

        private void btnReportAllR_Click(object sender, EventArgs e)
        {
            ReportAllR newReportAllR = new ReportAllR();
            newReportAllR.Show();

            string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Database1.mdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConnectionString;
            string sql = " SELECT Расходы.Код_расхода, Пользователь.Имя_пользователя, Категории_расходов.Название_категории_расхода, Расходы.Сумма, Расходы.Дата FROM Пользователь INNER JOIN (Категории_расходов INNER JOIN Расходы ON Категории_расходов.Код_категории_расхода = Расходы.Код_категории_расхода) ON Пользователь.Код_пользователя = Расходы.Код_пользователя ORDER BY Расходы.Код_расхода;";
            OleDbCommand myCommand = new OleDbCommand(sql, connection);

            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            DataSet ds = new DataSet();
            da.Fill(ds, "Расходы");
            ds.WriteXmlSchema("CReportAllXML.xml");

            /*CReportAll rpt = new CReportAll();
            rpt.SetDataSource(ds);
            newReportAll.crystalReportViewer1.ReportSource = rpt;*/

            connection.Close();
        }

        private void btnReportDayR_Click(object sender, EventArgs e)
        {
            ReportDayR newReportDayR = new ReportDayR();
            newReportDayR.Show();
        }

        private void btnReportWeekR_Click(object sender, EventArgs e)
        {
            ReportWeekR newReportWeekR = new ReportWeekR();
            newReportWeekR.Show();
        }

        private void btnReportMonthR_Click(object sender, EventArgs e)
        {
            ReportMonthR newReportMonthR = new ReportMonthR();
            newReportMonthR.Show();
        }

        private void btnReportYearR_Click(object sender, EventArgs e)
        {
            ReportYearR newReportYearR = new ReportYearR();
            newReportYearR.Show();
        }

        private void btnStatisticsMenu_Click(object sender, EventArgs e)
        {
            Statistics newStatistics = new Statistics();
            newStatistics.Show();
        }
    }
}
