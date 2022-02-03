/*
 * Author: Malek Abdul Sater
 * Mail: malekabdulsater@gmail.com
 * Kurs: L0002B
 * Uppgift 1 Console
 */
namespace Cashier_GUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CashRegister cashReg = new CashRegister();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(cashReg));
        }

    }

}

/*
 * Author: Malek Abdul Sater
 * Mail: malekabdulsater@gmail.com
 * Kurs: L0002B
 * Uppgift 1 Console
 */
public class CashRegister
{
    private int _cost;
    private int _paid;
    private Dictionary<int, int> _dict;

    //Constructor sets key-value pairs and instance variables
    public CashRegister()
    {
        _cost = 0;
        _paid = 0;
        _dict = new Dictionary<int, int>(8);
        _dict.Add(500, 0);
        _dict.Add(200, 0);
        _dict.Add(100, 0);
        _dict.Add(50, 0);
        _dict.Add(20, 0);
        _dict.Add(10, 0);
        _dict.Add(5, 0);
        _dict.Add(1, 0);
    }
    public void setCost(int cost)
    {
        this._cost = cost;
    }
    public int getCost()
    {
        return _cost;
    }
    public void setPaid(int paid)
    {
        this._paid = paid;
    }
    public int getPaid()
    {
        return _paid;
    }
    public Dictionary<int, int> getDict()
    {
        return _dict;
    }

    //Counts the amount of every paper and coin and sets the values in _dict
    public void countMoney(int owed)
    {
        while (owed != 0)
        {
            foreach (int element in _dict.Keys)
            {
                while ((owed - element) >= 0)
                {
                    _dict[element] += 1;
                    owed -= element;
                }
            }
        }
    }

    //Sets the values to _dict to 0
    public void clrNumOfCurrency()
    {
        foreach (int currency in _dict.Keys)
        {
            _dict[currency] = 0;
        }
    }
}