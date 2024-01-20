using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
   
    public partial class Form1 : Form
    {
        


        public Form1()
        {
            InitializeComponent();
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void student_method(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel1.Visible = false;
        }

        private void student_portal_signup(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel2.Visible = true;
        }

        private void student_portal_login(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel4.Visible = false;
        }

        private void close_student(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel3.Visible = false;
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void switch_signup_student(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void switch_login_student(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void close_signup_student(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel4.Visible = true;
        }

        private void close_login_student(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = true;
        }

        private void doctor_method(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel5.Visible = true;
        }

        private void doctor_portal_signup(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel7.Visible = true;
        }

        private void doctor_portal_login(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel6.Visible = true;
        }

        private void close_signin_doctor(object sender, EventArgs e)
        {
            panel5.Visible = true;
            panel7.Visible = false;
        }

        private void close_login_doctor(object sender, EventArgs e)
        {
            panel5.Visible = true;
            panel6.Visible = false;
        }

        private void switch_signin_doctor(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel6.Visible = true;
        }

        private void switch_login_doctor(object sender, EventArgs e)
        {
            panel7.Visible = true;
            panel6.Visible = false;
        }

        private void close_doctor(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel5.Visible = false;
        }
        
        public class data
        {
            
           public void Signup_Student(string name, string password, string filepath)
            {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
                    {
                        file.WriteLine(name + ',' + password);
                    }
            }
            public void Login_Student(string name, string password, string filepath)
            {
                bool record_matches(string n, string p, string[] feild)
                {
                    if (n == feild[0] && p == feild[1])
                        return true;
                    else
                        return false;
                }
               
                
                    string[] lines = System.IO.File.ReadAllLines(@filepath);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string[] fields = lines[i].Split(',');
                        if (record_matches(name, password, fields))
                        {
                            MessageBox.Show("login succes");
                            Form3 student_form = new Form3();
                            student_form.Show();
                            return;
                        }
                    }
                    MessageBox.Show("username not found. please sign up");
                    return;
                
                
            }
            public void Login_Doctor(string name, string password, string filepath)
            {
                bool record_matches(string n, string p, string[] feild)
                {
                    if (n == feild[0] && p == feild[1])
                        return true;
                    else
                        return false;
                }
                
                    string[] lines = System.IO.File.ReadAllLines(@filepath);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string[] fields = lines[i].Split(',');
                        if (record_matches(name, password, fields))
                        {
                            MessageBox.Show("login succes");
                            Form2 doctor_form = new Form2();
                            doctor_form.Show();
                            return;
                        }
                    }
                    MessageBox.Show("username or password incorrect. please sign up");
                    return;
            }
            
            public void Signup_doctor(string name, string password, string filepath)
            {
                try
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
                    {
                        file.WriteLine(name + ',' + password);
                        MessageBox.Show("sign up succes");
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("data added succesfully");
                }
            }
          
        }
        data obj = new data();

        private void signin_btn_student(object sender, EventArgs e)
        {
            obj.Signup_Student(textBox1.Text,textBox2.Text,"D:student");
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void login_btn_student(object sender, EventArgs e)
        {
            obj.Login_Student(textBox3.Text, textBox4.Text,"D:student");
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void signup_btn_doctor(object sender, EventArgs e)
        {
            obj.Signup_doctor(textBox8.Text, textBox7.Text, "D:doctor");
            textBox8.Text = "";
            textBox7.Text = "";
        }

        private void login_btn_doctor(object sender, EventArgs e)
        {
            obj.Login_Doctor(textBox6.Text,textBox5.Text,"D:doctor");
            textBox6.Text = "";
            textBox5.Text = "";
        }

        
    }
}
