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
        else if (cashier.getAmount() > cashier.getPaid())
        {
            Console.WriteLine("Du har betalt för lite. Prova igen!");
            continue;
        }
    }
    catch (Exception e)
    {
        if (e is InvalidCastException || e is IOException || e is ArgumentNullException)
        Console.WriteLine("Ogiltigt");
        continue;
    }
    diff = cashier.getPaid() - cashier.getAmount();
    cashier.countMoney(diff);

    string output = "";
    Console.WriteLine("Du får tillbaka: ");
    foreach (KeyValuePair<int, int> entry in cashier.getDict())
    {
        if (entry.Value > 0)
        {
            output = string.Format("{0}: {1}", entry.Key, entry.Value);
            Console.WriteLine(output);
        }
    }
    cashier.clrNumOfCurrency();
}


public class Cashier
{
    private int amount;
    private int paid;
    private Dictionary<int, int> dict;

    public Cashier(int amount, int paid)
    {
        this.amount = amount;
        this.paid = amount;
        dict = new Dictionary<int, int>(8);
        dict.Add(500, 0);
        dict.Add(200, 0);
        dict.Add(100, 0);
        dict.Add(50, 0);
        dict.Add(20, 0);
        dict.Add(10, 0);
        dict.Add(5, 0);
        dict.Add(1, 0);
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
    public Dictionary<int,int> getDict()
    {
        return dict;
    }
    public void countMoney(int diff)
    {
        while(diff != 0)
        {
            foreach (int element in dict.Keys)
            {
                while ((diff-element) >= 0)
                {
                    dict[element] += 1;
                    diff -= element;
                }
            }
        }
    }
    public void clrNumOfCurrency()
    {
        foreach (int currency in dict.Keys)
        {
            dict[currency] = 0;
        }
    }
}