﻿/*
 * Author: Malek Abdul Sater
 * Mail: malekabdulsater@gmail.com
 * Kurs: L0002B
 * Uppgift 1 Console
 */

CashRegister cashReg = new CashRegister();
int owed = 0;
string output = "";

while (true)
{
    Console.WriteLine("\n");
    try
    {
        Console.Write("Cost: ");
        cashReg.setCost(Int32.Parse(Console.ReadLine()));
        Console.Write("Paid: ");
        cashReg.setPaid(Int32.Parse(Console.ReadLine()));
        //edge cases 
        if (cashReg.getCost() == 0 || (cashReg.getCost() == cashReg.getPaid()))
        {
            continue;
        }
        else if (cashReg.getCost() > cashReg.getPaid())
        {
            Console.WriteLine("You have paid too little!");
            continue;
        }
    }
    //catches possible exceptions and continues program
    catch (Exception e)
    {
        if (e is InvalidCastException || e is IOException || e is ArgumentNullException)
            Console.WriteLine("Invalid");
        continue;
    }
    owed = cashReg.getPaid() - cashReg.getCost();
    cashReg.countMoney(owed);
    //prints results
    Console.WriteLine("\nYou get: \n" + "(type: amount)\n");
    foreach (KeyValuePair<int, int> entry in cashReg.getDict())
    {
        if (entry.Value > 0)
        {
            output = string.Format("{0}: {1}", entry.Key, entry.Value);
            Console.WriteLine(output);
        }
    }
    cashReg.clrNumOfCurrency();
}


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