int numberOfPeople;
string name;
int personNr;
string district;
int numberOfItemsSold;
Sellers sellers;
while (true)
{
    Console.Write("Number of sellers: ");
    if (!int.TryParse(Console.ReadLine().Trim(), out numberOfPeople))
    {
        continue;
    }
    sellers = new Sellers(numberOfPeople);
    for (int i = 0; i < numberOfPeople; i++)
    {
        Console.Write("Name: ");
        name = Console.ReadLine();
        if(name == null)
        {
            continue;
        }
        Console.Write("Pers.nr: ");
        if (!int.TryParse(Console.ReadLine().Trim(), out personNr))
        {
            continue;
        }
        Console.Write("District: ");
        district = Console.ReadLine();
        if (district == null)
        {
            continue;
        }
        Console.Write("Number of sold items: ");
        if (!int.TryParse(Console.ReadLine().Trim(), out numberOfItemsSold))
        {
            continue;
        }
        sellers.AddPerson(new Person(name, personNr, district, numberOfItemsSold), i);
    }
}

public class Sellers
{
    private Person[] _personArr;

    public Sellers(int numberOfSellers)
    {
        _personArr = new Person[numberOfSellers];
    }
    public void AddPerson(Person person, int index)
    {
        _personArr[index] = person;
    }
    public void SortPeople()
    {
        int length = _personArr.Length;
        Person temp = _personArr[0];

        for (int i = 0; i < length; i++)
        {
            for (int j = i + 1; j < length; j++)
            {
                if (_personArr[i]._numberOfItemsSold > _personArr[j]._numberOfItemsSold)
                {
                    temp = _personArr[i];
                    _personArr[i] = _personArr[j];
                    _personArr[j] = temp;
                }
            }
        }
    }
}

public class Person
{
    public string _name { get; private set; }
    public int _persNr { get; private set; }
    public string _district { get; private set; }
    public int _numberOfItemsSold { get; private set; }
    public Person(string name, int persNr, string district, int numberOfItemsSold)
    {
        _name = name;
        _persNr = persNr;
        _district = district;
        _numberOfItemsSold = numberOfItemsSold;
    }
}