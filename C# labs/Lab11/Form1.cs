using Microsoft.Data.SqlClient;
using System.Data;


namespace Lab11
{
    public partial class Form1 : Form
    {
        SqlDataAdapter adapter;
        SqlConnection conn;
        DataSet ds;

        SqlCommand select_cmd;
        SqlCommand insert_cmd;
        SqlCommand update_cmd;
        SqlCommand delete_cmd;


        public Form1()
        {
            InitializeComponent();
            adapter = new SqlDataAdapter();
            ds = new DataSet();
            string connectionString = "Data Source=localhost;Initial Catalog=test;Integrated Security=True;TrustServerCertificate=True";
            conn = new SqlConnection(connectionString);


            select_cmd = new SqlCommand("select * from employees", conn);
            adapter.SelectCommand = select_cmd;



            insert_cmd = new SqlCommand("INSERT INTO employees (name, deptID) VALUES (@Name, @deptID)", conn);
            SqlParameter nameParam = new SqlParameter("@Name", SqlDbType.VarChar, 0, "Name");
            SqlParameter idParam = new SqlParameter("@deptID", SqlDbType.Int, 0, "deptID");
            insert_cmd.Parameters.Add(nameParam);
            insert_cmd.Parameters.Add(idParam);
            adapter.InsertCommand = insert_cmd;


            update_cmd = new SqlCommand("UPDATE employees SET name = @Name, deptID = @deptID WHERE id = @id", conn);
            SqlParameter nameParam2 = new SqlParameter("@Name", SqlDbType.VarChar, 0, "Name");
            SqlParameter deptParam2 = new SqlParameter("@deptID", SqlDbType.Int, 0, "deptID");
            SqlParameter idParam3 = new SqlParameter("@id", SqlDbType.Int, 0, "id");
            update_cmd.Parameters.Add(nameParam2);
            update_cmd.Parameters.Add(deptParam2);
            update_cmd.Parameters.Add(idParam3);
            adapter.UpdateCommand = update_cmd;


            delete_cmd = new SqlCommand("DELETE FROM employees WHERE id = @id", conn);
            SqlParameter idParam4 = new SqlParameter("@id", SqlDbType.Int, 0, "id");
            delete_cmd.Parameters.Add(idParam4);
            adapter.DeleteCommand = delete_cmd;
        }


        private void LoadData()
        {
            ds.Clear();
            adapter.Fill(ds);
            dataView.DataSource = ds.Tables[0];
        }

        private void displayBtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            LoadData();
            conn.Close();
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            //conn.Open();
            DataRow row = ds.Tables[0].NewRow();
            row["Name"] = nameTxt.Text;
            row["deptID"] = int.Parse(deptTxt.Text);
            ds.Tables[0].Rows.Add(row);
            //adapter.Update(ds);
            //conn.Close();
            //LoadData();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {

            DataRow row = ds.Tables[0].Rows.Find(int.Parse(idTxt.Text));
            if (row != null)
            {
                row["Name"] = nameTxt.Text;
                row["deptID"] = int.Parse(deptTxt.Text);
                //adapter.Update(ds);
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Record not found");
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].Rows.Find(int.Parse(idTxt.Text));
            if (row != null)
            {
                row.Delete();
                //adapter.Update(ds);
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Record not found");
            }
        }

        private void updateDbBtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            adapter.Update(ds);
            MessageBox.Show("Database updated successfully");
            conn.Close();
        }
    }
}
