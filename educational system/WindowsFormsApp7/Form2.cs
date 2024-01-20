using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        int count = 0;
        string study_feild = "";
        string course = "D:\\asd.txt";
        string assigment_file = "D:\\assignment.txt";
        string filepath = "D:\\asd.txt";
        string student_assigment = "D:\\student_assigment.txt";
        string student_degree = "D:\\student_degree.txt";
        string StudentName="", emptystring="", emptystring3="";
        private void click_list_course(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }
        private void click_create_course(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = true;
        }

        private void add(string n , string p ,string t , string file2)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@file2, true))
                {
                    file.WriteLine(n + ',' + p + ',' + t);
                    MessageBox.Show("course created succesfully");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException();
            }
        }
        private void display(string file2)
        {
            
            try
            {
                textBox1.Text = "";
                string[] lines = System.IO.File.ReadAllLines(@file2);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] feilds = lines[i].Split(',');
                    textBox1.Text += "Taught by doctor : " + feilds[1] + ' ' + " code of course : " + feilds[2] + ' '+ "" + Environment.NewLine;
                    if (i == lines.Length - 1)
                        return;
                }
                MessageBox.Show("no courses to display");
            }
            catch (Exception ex)
            {
                throw new ApplicationException();
            }
            MessageBox.Show("no elements to show");
            return;
        }
        private void add_course(object sender, EventArgs e)
        {
            add(textBox2.Text, textBox3.Text, textBox4.Text,course);
        }

        private void close_create_course(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel3.Visible = false;
        }

        private void close_list_course(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void display_courses(object sender, EventArgs e)
        {
            display(course);
        }

        private void click_create_assigments(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel4.Visible = true;
        }
        private void addasigment(string code,string question,string path)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@path, true))
                {
                    file.WriteLine("code of course " + code +',' + "name of course " + study_feild + ',' + question );
                    MessageBox.Show("assigment added succesfully");
                    panel5.Visible = false;
                    panel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException();
            }
        }
        string code;
        private void check_course_btn(object sender, EventArgs e)
        {
            code = textBox5.Text;
            if(code=="")
            {
                MessageBox.Show("error");
                return;
            }
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@course);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(',');
                    if(fields[2]==code)
                    {
                        panel4.Visible = false;
                        panel5.Visible = true;
                        study_feild = fields[0];
                        return;
                    }
                }
                MessageBox.Show("course not found");
                panel4.Visible = false;
                panel5.Visible = false;
                panel1.Visible = true;
                code = "";
                return;
            }
            catch (Exception ex)
            {
                throw new ApplicationException();
            }
        }

        private void btn_add_assignment(object sender, EventArgs e)
        {
            string question = "";
            question = textBox6.Text;
            if(question=="")
            {
                MessageBox.Show("error");
                panel5.Visible = false;
                panel1.Visible = true;
                return;
            }
            addasigment(code,question,assigment_file);
        }

        private void click_veiw_assigment(object sender, EventArgs e)
        {
            panel6.Visible = true;
            panel1.Visible = false;
        }
        private void display_assignment(string des)
        {
            textBox1.Text = "";
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@des);
                for (int i = 0; i < lines.Length; i++)
                {
                    //string[] feilds = lines[i].Split(',');
                    textBox7.Text += lines[i] + Environment.NewLine;
                        //feilds[0] + "  " + feilds[1] + Environment.NewLine;
                    if (i == lines.Length - 1)
                        return;
                }
                MessageBox.Show("no assigments to display");
            }
            catch(Exception ex)
            {
                throw new ApplicationException();
            }
            MessageBox.Show("no elements to show");
            return;
        }
        private void veiw_assigment_btn(object sender, EventArgs e)
        {
            display_assignment(assigment_file);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            panel1.Visible = true;
        }
        

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
       
        private void veiw_degree(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel7.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            veiw_degree_doctor_portal(textBox11.Text,textBox10.Text,textBox9.Text);
        }

        private void veiw_degree_doctor_portal(string namecourse , string namedoctor , string idcourse)
        {
            count = 0;
            using (StreamReader reader = new StreamReader(@filepath))
            {

                string line;

                while ((line = reader.ReadLine()) != null)
                {


                    foreach (var j in line.Split(','))
                    {
                        if (namecourse == j || namedoctor == j || idcourse == j)
                            count++;
                    }
                    
                }


            }
            if (count == 3)
            {
                panel8.Visible = true;
                panel7.Visible = false;
            }
            else
            {
                MessageBox.Show("student does not exist");
                panel7.Visible = false;
                panel1.Visible = true;
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            student_assigment_checker(textBox13.Text,textBox12.Text,textBox8.Text);
        }

        

        private void student_assigment_checker(string student_name , string id_student , string id_assigment)
        {
            StudentName = student_name;
            emptystring = id_student;
            emptystring3 = id_assigment;

            using (StreamReader reader = new StreamReader(@student_assigment))
            {

                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    count = 0;

                    foreach (var j in line.Split(','))
                    {

                        foreach (var i in j.Split(' '))
                        {
                            if (i == student_name || i == id_student || i == id_assigment)
                                count++;
                        }

                    }

                }
            }
            if (count == 3)
            {
                panel8.Visible = false;
                panel9.Visible = true;
            }
            else
            {
               MessageBox.Show("data is wrong ");
                panel8.Visible = false;
                panel1.Visible = true; 
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel8.Visible = false;
            panel1.Visible = true;
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel7.Visible = false;
        }

        

        private void button12_Click(object sender, EventArgs e)
        {
            write_student_degree(textBox14.Text);
            MessageBox.Show("degree saved");
            panel9.Visible = false;
            panel1.Visible = true;
        }
        private void write_student_degree(string degree)
        {
            List<string> arr = new List<string>(File.ReadAllLines(@student_degree));
            using (StreamWriter student_assignmentEnter = new StreamWriter(@student_degree))
            {

                if (student_degree.Length != 0)
                {
                    foreach (var i in arr)
                    {
                        student_assignmentEnter.Write(i);

                        student_assignmentEnter.WriteLine();
                    }
                }

                student_assignmentEnter.Write("student name " + StudentName + ',');
                student_assignmentEnter.Write(" student id " + emptystring + ',');
                student_assignmentEnter.Write(" assignment id " + emptystring3 + ',');
                student_assignmentEnter.Write(" student degree " + degree + ',');
                student_assignmentEnter.Write(" / 100 ");
                student_assignmentEnter.WriteLine();
            }
        }    
    }
}
