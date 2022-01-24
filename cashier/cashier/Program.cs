Cashier cashier = new Cashier(0, 0);
int diff = 0;

while (true)
{
    try
    {
        Console.Write("Ange kostnad: ");
        cashier.setAmount(Int32.Parse(Console.ReadLine()));
        Console.Write("Betalt: ");
        cashier.setPaid(Int32.Parse(Console.ReadLine()));
        if (cashier.getAmount() == 0 || (cashier.getAmount() == cashier.getPaid()))
        {
            continue;
        }
    }
    catch (Exception e)
    {
        if (e is InvalidCastException || e is IOException)
        Console.WriteLine("Ogiltigt");
        continue;
    }
    diff = cashier.getPaid() - cashier.getAmount();
    
}

public class Cashier
{
    private int amount;
    private int paid;
    private Dictionary<string, int> dict;

    public Cashier(int amount, int paid)
    {
        this.amount = amount;
        this.paid = amount;
        dict = new Dictionary<string, int>(8);
        dict.Add("500", 0);
        dict.Add("200", 0);
        dict.Add("100", 0);
        dict.Add("50", 0);
        dict.Add("20", 0);
        dict.Add("10", 0);
        dict.Add("5", 0);
        dict.Add("1", 0);
    }
    public void setAmount(int amount)
    {
        this.amount=amount;
    }
    public int getAmount() 
    { 
        return amount; 
    }
    public void setPaid(int paid)
    {
        this.paid = paid;
    }
    public int getPaid()
    {
        return paid;
    }
    public void clrNumOfCurrency()
    {
        foreach (string currency in dict.Keys)
        {
            dict[currency] = 0;
        }
    }
}