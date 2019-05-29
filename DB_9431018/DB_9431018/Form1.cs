using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DB_9431018
{
    public partial class Form1 : Form
    {
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public Form1()
        {
            InitializeComponent();
        }
        
 

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            this.peopleTableTableAdapter.Fill(this.peopleDataSet.PeopleTable);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9PKS9O4;Initial Catalog=People;Integrated Security=True");


            using (con)
                {

                    con.Open();

                    using (SqlCommand com = con.CreateCommand())
                    {
                        com.CommandText =
                          "delete from PeopleTable \n" +
                          "  where EmpID = @prm_Id";

                    
                        com.Parameters.Add("@prm_Id", SqlDbType.Int, 80).Value = textBox1.Text;



                        com.ExecuteNonQuery();
                    }

                    con.Close();
                }


            FillDataGridView();


        }



        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9PKS9O4;Initial Catalog=People;Integrated Security=True");


            using (con)
            {
                
               con.Open();

                using (SqlCommand com = con.CreateCommand())
                {
                    com.CommandText =
                      "insert into PeopleTable(\n" +
                      "  EmpID,\n" +
                      "  FirstName,\n" +
                      "  LastName,\n" +
                      "  JobRule,\n" +
                      "  Employment)\n" +
                      "values(\n" +
                      "  @prm_Id,\n" +
                      "  @prm_First_Name,\n" +
                      "  @prm_Last_Name,\n" +
                      "  @prm_Rule,\n" +
                      "  @prm_Emp)";

         
                    com.Parameters.Add("@prm_Id", SqlDbType.Int, 80).Value = textBox1.Text;
                    com.Parameters.Add("@prm_First_Name", SqlDbType.NChar, 80).Value = textBox2.Text;
                    com.Parameters.Add("@prm_Last_Name", SqlDbType.NChar, 80).Value = textBox3.Text;
                    com.Parameters.Add("@prm_Rule", SqlDbType.NChar, 80).Value = textBox4.Text;
                    com.Parameters.Add("@prm_Emp", SqlDbType.NChar, 80).Value = textBox5.Text;


                    com.ExecuteNonQuery();
                }
            }


            con.Close();

            FillDataGridView();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9PKS9O4;Initial Catalog=People;Integrated Security=True");


            using (con)
            {

                con.Open();

                using (SqlCommand com = con.CreateCommand())
                {
                    com.CommandText =
                      "UPDATE PeopleTable \n" +
                      "  SET FirstName=@prm_First_Name,\n" +
                      "  LastName=@prm_Last_Name,\n" +
                      "  JobRule=@prm_Rule,\n" +
                      "  Employment=@prm_Emp\n" +
                      "  where EmpID = @prm_Id";

                    com.Parameters.Add("@prm_Id", SqlDbType.Int, 80).Value = textBox1.Text;
                    com.Parameters.Add("@prm_First_Name", SqlDbType.NChar, 80).Value = textBox2.Text;
                    com.Parameters.Add("@prm_Last_Name", SqlDbType.NChar, 80).Value = textBox3.Text;
                    com.Parameters.Add("@prm_Rule", SqlDbType.NChar, 80).Value = textBox4.Text;
                    com.Parameters.Add("@prm_Emp", SqlDbType.NChar, 80).Value = textBox5.Text;


                    com.ExecuteNonQuery();
                }
            }


            con.Close();

            FillDataGridView();

        }

        protected void FillDataGridView()
        {

            this.peopleTableTableAdapter.Fill(this.peopleDataSet.PeopleTable);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DataBind()
        {
            // Bind your datagridview with the datasource
        }
    }
}
