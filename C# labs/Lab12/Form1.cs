using Microsoft.Data.SqlClient;


namespace Lab12
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        bool flag = false;
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=localhost;Initial Catalog=test;Integrated Security=True;TrustServerCertificate=True");
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }

        private void ExcuteQuery(string query, string msg)
        {
            try
            {
                cmd.CommandText = query;
                if (!flag)
                {
                    MessageBox.Show("Please connect to the database first.", "IMPORTANT");
                    return;
                }
                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                    MessageBox.Show($"Record {msg} successfully", "Success");
                else
                    MessageBox.Show($"Failed to {msg} record", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
            finally
            {
                loadData();
                clearFields();
            }
        }

        private void loadData()
        {
            displayBtn.PerformClick();
        }


        private void fieldsToggle()
        {
            displayBtn.Enabled = flag;
            insertBtn.Enabled = flag;
            updateBtn.Enabled = flag;
            deleteBtn.Enabled = flag;
            idTxt.Enabled = flag;
            nameTxt.Enabled = flag;
            deptTxt.Enabled = flag;
        }

        private void clearFields()
        {
            idTxt.Clear();
            nameTxt.Clear();
            deptTxt.Clear();
        }

        private void displayBtn_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                MessageBox.Show("Please connect to the database first.", "IMPORTANT");
                return;
            }
            cmd.CommandText = "SELECT * FROM employees";
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
            {
                listBox1.Items.Add($"{reader["ID"]} - {reader["Name"]} - {reader["DeptID"]}");
            }
            reader.Close();
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            string query = $"insert into employees values ('{nameTxt.Text}', {deptTxt.Text})";
            ExcuteQuery(query, "inserted");
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            string query = $"update employees set Name = '{nameTxt.Text}', DeptID = {deptTxt.Text} where ID = {idTxt.Text}";
            ExcuteQuery(query, "updated");
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            string query = $"delete from employees where ID = {idTxt.Text}";
            ExcuteQuery(query, "deleted");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //loadData();
        }

        private void ConnectDB_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Connection successful", "Success");
                    ConnectDB.Text = "Disconnect";
                    flag = true;
                    fieldsToggle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Connection failed: {ex.Message}", "Error");
                }
            }
            else
            {
                try
                {
                    ConnectDB.Text = "Connect DB";
                    conn.Close();
                    MessageBox.Show("Disconnection successful", "Success");
                    flag = false;
                    fieldsToggle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Disconnection failed: {ex.Message}", "Error");
                }
            }
        }
    }
}
