/*
 * Author: Malek Abdul Sater
 * Mail: malekabdulsater@gmail.com
 * Kurs: L0002B
 * Uppgift 1 Console
 */

namespace Cashier_GUI
{
    public partial class Form1 : Form
    {
        private CashRegister cashReg;
        
        public Form1(CashRegister cashReg)
        {
            InitializeComponent();
            this.cashReg = cashReg;
        }

        private void calculate_Btn(object sender, EventArgs e)
        {
            int owed = 0;
            string output = "";
            if (this.textBox1.Text.Length != 0 && this.textBox2.Text.Length != 0)
            {
                try
                {
                    cashReg.setCost(Int32.Parse(this.textBox1.Text));
                    cashReg.setPaid(Int32.Parse(this.textBox2.Text));
                    
                    //Taking care of edge cases
                    if (cashReg.getCost() == 0 || (cashReg.getCost() == cashReg.getPaid()))
                    {
                        cashReg.clrNumOfCurrency();
                        this.textBox1.Clear();
                        this.textBox2.Clear();
                        this.richTextBox1.Clear();

                    }
                    else if (cashReg.getCost() > cashReg.getPaid())
                    {
                        this.richTextBox1.Text = "You have paid too little."+"\nTry again!";
                        cashReg.clrNumOfCurrency();
                        this.textBox1.Clear();
                        this.textBox2.Clear();
                        return;
                    }
                    else
                    {
                        //Takes difference 
                        owed = cashReg.getPaid() - cashReg.getCost();
                        cashReg.countMoney(owed);
                        output = "You get: \n" + "(type: amount)";
                        
                        //Prints amount of coin and paper 
                        foreach (KeyValuePair<int, int> entry in cashReg.getDict())
                        {
                            if (entry.Value > 0)
                            {
                                output += string.Format("\n{0}: {1}", entry.Key, entry.Value);
                                this.richTextBox1.Text = output;
                            }
                        }
                        cashReg.clrNumOfCurrency();
                        owed = 0;
                    }
                }
                catch (Exception ex)
                {
                    if (ex is InvalidCastException || ex is IOException || ex is ArgumentNullException)
                    {
                        this.richTextBox1.Text = "Invalid";
                    }
                    cashReg.clrNumOfCurrency();
                    this.textBox1.Clear();
                    this.textBox2.Clear();
                }
            }
        }

        private void clear_Btn(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.richTextBox1.Clear();
            cashReg.clrNumOfCurrency();
        }

        private void exit_Btn(object sender, EventArgs e)
        {
            Close();
        }
    }
}