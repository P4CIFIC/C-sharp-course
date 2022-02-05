/*
 * Author: Malek Abdul Sater
 * Mail: malekabdulsater@gmail.com
 * Kurs: L0002B
 * Uppgift 3 GUI
 */

namespace assignment_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void checkPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }
    }
}
