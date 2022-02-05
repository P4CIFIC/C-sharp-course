/*
 * Author: Malek Abdul Sater
 * Mail: malekabdulsater@gmail.com
 * Kurs: L0002B
 * Uppgift 3 GUI
 */

namespace assignment_3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person person = new Person(textBox1.Text, textBox2.Text, textBox3.Text);
            if(person.IsValidPersNumber())
            {
                person.FindGender();
                richTextBox1.Text = person.ToString();
            } else
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                richTextBox1.Text = "Invalid Pers.Number\nTry Again!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
