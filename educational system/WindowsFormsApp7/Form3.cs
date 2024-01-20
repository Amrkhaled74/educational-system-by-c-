using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp7
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
        }
        int countposition = 0, count = 0, position = 0;
        string code123 = "";
        string filepath = "D:\\asd.txt";
        string student_file = "D:\\studentcourse.txt";
        string assignmentfile = "D:\\assignment.txt";
        string student_assigment = "D:\\student_assigment.txt";
        string student_degree = "D:\\student_degree.txt";
        string StudentName="", emptystring="", courseName="", emptystring3="", answerqustion="";






        private void display_availble_courses(string file2)
        {
            try
            {
                textBox1.Text = "";
                string[] lines = System.IO.File.ReadAllLines(@file2);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] feilds = lines[i].Split(',');
                    textBox1.Text += feilds[0] + Environment.NewLine;
                    if (i == lines.Length - 1)
                        return;
                }
                MessageBox.Show("no courses to display");
            }
            catch (Exception ex)
            {
                throw new ApplicationException();
            }
            //MessageBox.Show("no elements to show");
            return;
        }
        private void click_register_course(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            display_availble_courses(filepath);
        }
        private void add_student_course(string n, string i, string file3)
        {

            //////////////////////////////////////////////////////////////
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@file3, true))
            {
                file.WriteLine(n + ',' + i + ',' + code123);
                MessageBox.Show("your course added succesfully");
                panel3.Visible = false;
                panel1.Visible = true;
            }
        }
        private void checker(string code, string file2)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@file2);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] feilds = lines[i].Split(',');
                    if (code == feilds[0])
                    {
                        MessageBox.Show("course found");
                        panel3.Visible = true;
                        panel2.Visible = false;
                        code123 = code;
                        return;
                    }
                    if (i == lines.Length - 1)
                        return;
                }
                MessageBox.Show("course not availble");
            }
            catch (Exception ex)
            {
                throw new ApplicationException();
            }
            //MessageBox.Show("no elements to show");
            return;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("enter valid input");
                panel2.Visible = false;
                panel1.Visible = true;
            }
            else
            {
                checker(textBox2.Text, filepath);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("type valid inputs");
                panel1.Visible = true;
                panel3.Visible = false;
            }
            else
            {
                add_student_course(textBox3.Text, textBox4.Text, student_file);
            }

        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void click_list_my_courses(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel4.Visible = true;
        }
        private void list_my_courses_id_checker(string id)
        {
            panel4.Visible = false;
            panel5.Visible = true;
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@student_file);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(',');
                    if (id == fields[1])
                    {
                        textBox7.Text += fields[2] + Environment.NewLine;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("ID not availbe");
            }
            else
            {
                MessageBox.Show("id found");
                list_my_courses_id_checker(textBox5.Text);
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void click_unregister_in_course(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel6.Visible = true;
        }

        private void click_unregister_in_course_checker(string name, string id, string course)
        {

            countposition = 1;
            using (StreamReader reader = new StreamReader(@student_file))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    count = 0;
                    foreach (var j in line.Split(','))
                    {
                        if (id == j || course == j || name == j)
                        {
                            count++;
                        }
                    }
                    if (count == 3)
                    {
                        break;
                    }
                    else
                    { countposition++; }
                }

            }
            if (count == 3)
            {
                List<string> arr = new List<string>(File.ReadAllLines(@student_file));
                using (StreamWriter studentfile = new StreamWriter(@student_file))
                {
                    position = 1;

                    foreach (var i in arr)
                    {
                        if (position == countposition)
                        {
                            position++;
                            continue;
                        }
                        studentfile.Write(i);

                        studentfile.WriteLine();
                        position++;
                    }
                    MessageBox.Show("unregistered from course");

                }
            }
            else
            { MessageBox.Show("you are unregistered actually"); }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            click_unregister_in_course_checker(textBox8.Text, textBox6.Text, textBox9.Text);
        }



        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void label5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel7.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            veiw_assigment(textBox12.Text, textBox11.Text, textBox10.Text);
        }

       

        private bool check_student_in_course(string id, string coursename)
        {
            string[] lines = System.IO.File.ReadAllLines(@student_file);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');
                if (fields[1] == id && fields[2] == coursename)
                {
                    MessageBox.Show("course found");
                    return true;
                }
            }
            return false;
        }

        

        private void checker_assigments(string coursename)
        {
            bool ff = false;

            using (StreamReader reader = new StreamReader(@assignmentfile))
            {

                string line;
                int count = 0;
                while ((line = reader.ReadLine()) != null)
                {

                    foreach(var j in line.Split(','))
                    {
                        foreach(var i in j.Split(' '))
                        {
                            if (i == coursename)
                            {
                                ff = true;
                                panel7.Visible = false;
                                panel8.Visible = true;
                                count++;
                                continue;
                            }
                            if(count>0)
                            {
                                textBox14.Text += i + Environment.NewLine;
                            }
                        }
                    }
                    
                }
                if(!ff)
                {
                    MessageBox.Show("no assigments yet");
                    panel8.Visible = false;
                    panel1.Visible = true;
                }
            }
        }

       

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel10.Visible = false;
        }

        private void veiw_assigment(string name , string id , string coursename)
        {
            if(check_student_in_course(id , coursename)==true)
            {
                StudentName = name;
                emptystring = id;
                courseName = coursename;
                checker_assigments(coursename);
            }
            else
            {
                MessageBox.Show("you are not registered "+ coursename +" course");
                panel1.Visible = true;
                panel7.Visible = false;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string courseid = textBox13.Text;
            answerqustion= textBox15.Text;
            add_assigment_solution(courseid);
            MessageBox.Show("soulution submited");
            panel8.Visible = false;
            panel1.Visible = true;
        }
        private void add_assigment_solution(string courseid)
        {
            emptystring3 = courseid;
            List<string> arr = new List<string>(File.ReadAllLines(@student_assigment));
            using (StreamWriter studentAssignment = new StreamWriter(@student_assigment))
            {

                if (student_assigment.Length != 0)
                {
                    foreach (var i in arr)
                    {
                        studentAssignment.Write(i);

                        studentAssignment.WriteLine();
                    }
                }
                
                studentAssignment.Write("sudent name " + StudentName + ',');
                studentAssignment.Write(" sudent id " + emptystring + ',');
                studentAssignment.Write(" course Name " + courseName + ',');
                studentAssignment.Write(" assignment id " + emptystring3 + ',');
                studentAssignment.Write(" qusetion answer " + answerqustion);



                studentAssignment.WriteLine();
                

            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void label7_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel9.Visible = true;
        }
        
        
        private void button7_Click(object sender, EventArgs e)
        {
            student_degree_function(textBox18.Text,textBox17.Text,textBox16.Text);
        }
        private void student_degree_function(string n , string r , string e)
        {
            using (StreamReader reader = new StreamReader(@student_degree))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    count = 0;

                    foreach (var j in line.Split(','))
                    {

                        foreach (var i in j.Split(' '))
                        {
                            if (i == n || i == e || i == r)
                                count++;
                        }

                    }

                }
            }

            if (count == 3)
            {
                using (StreamReader reader = new StreamReader(@student_degree))
                {
                    panel10.Visible = true;
                    panel9.Visible = false;
                    string line;
                    countposition = 0;
                    while ((line = reader.ReadLine()) != null)
                    {

                        foreach (var j in line.Split(','))
                        {
                            countposition++;
                            if(countposition==4)
                                  textBox19.Text+=(j + " ");
                        }
                        textBox19.Text += Environment.NewLine;
                    }


                }

            }
            else
            {
                MessageBox.Show("degree may be later");
            }
        }
    }   
}
