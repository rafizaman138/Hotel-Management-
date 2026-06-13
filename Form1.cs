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

namespace Hotel_Management_0._2
{
    
    public partial class Form1 : Form
    {
        public SqlConnection con =new SqlConnection( @"Data Source = laptop - 3kt2uc1s\mssqlserver01;Integrated Security = True");


        public Form1()
        {
            InitializeComponent();
        }


        private void bttnLogin_Click(object sender, EventArgs e)
        {

            string JobTitle = "";

            string username = txtusername.Text.ToString();
            string password = txtpassword.Text.ToString();



            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT JobTitle FROM Info_Table WHERE UserName = @UserName AND Password = @Password",con);
           
            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.ExecuteNonQuery();



            SqlDataReader reader = cmd.ExecuteReader();
                    
                        if (reader.Read())
                        {
                MessageBox.Show("Working");

                JobTitle = reader["JobTitle"].ToString();

                        }
                        else
                        {
                            // No matching record found
                        }
                    
            con.Close();

                    

                    if (JobTitle == "Admin")
                    {
                        Form form = new FormAdmin();
                        this.Hide();
                        form.Show();
                    }
                    if (JobTitle == "Manager")
                    {
                        Form form = new Form2();
                        this.Hide();
                        form.Show();
                    }
                    if (JobTitle == "Employe")
                    {
                        Form form = new FormAdmin();
                        this.Hide();
                        form.Show();
                    }


            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
