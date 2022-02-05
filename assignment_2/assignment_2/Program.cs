/*
 * Author: Malek Abdul Sater
 * Mail: malekabdulsater@gmail.com
 * Kurs: L0002B
 * Uppgift 2 Console
 */

string fileName = "Seller_Data.txt";
int numberOfPeople;
string name;
long personNr;
string district;
int itemsSold;
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
        Console.Write("\nName: ");
        name = Console.ReadLine();
        if(name == null)
        {
            continue;
        }
        Console.Write("Pers.nr: ");
        if (!long.TryParse(Console.ReadLine().Trim(), out personNr))
        {
            continue;
        }
        Console.Write("District: ");
        district = Console.ReadLine();
        if (district == null)
        {
            continue;
        }
        Console.Write("amount of sold items: ");
        if (!int.TryParse(Console.ReadLine().Trim(), out itemsSold))
        {
            continue;
        }
        sellers.AddSeller(new Seller(name, personNr, district, itemsSold), i);
    }
    sellers.SortSellers();
    sellers.SetTiers();
    Console.WriteLine(sellers.ToString());
    using (StreamWriter sw = new StreamWriter(fileName, true))
    {
        sw.Write(sellers.ToString());
    }
}

/// <summary>
/// Class <c>Sellers</c> is composed of <c>Seller</c> objects with relevant methods to abstract some of the logic.
/// </summary>
public class Sellers
{
    private Seller[] _sellerArr;
    private Dictionary<int, List<Seller>> _tiers;

    public Sellers(int numberOfSellers)
    {
        _sellerArr = new Seller[numberOfSellers];
        _tiers = new Dictionary<int, List<Seller>>();
        _tiers.Add(1, new List<Seller>());
        _tiers.Add(2, new List<Seller>());
        _tiers.Add(3, new List<Seller>());
        _tiers.Add(4, new List<Seller>());
    }

    /// <summary>
    /// method <c>AddSeller</c> Adds Seller to array according to index.
    /// </summary> 
    public void AddSeller(Seller seller, int index)
    {
        _sellerArr[index] = seller;
    }

    /// <summary>
    /// method <c>SortSellers</c> 
    /// sorts <c>Seller</c> objects according to <c>_itemsSold attribute</c>.
    /// BubbleSort is utilized as a sorting algorithm.
    /// </summary>
    /// <returns>void</returns>
    public void SortSellers()
    {
        int length = _sellerArr.Length;
        Seller temp = _sellerArr[0];

        for (int i = 0; i < length; i++)
        {
            for (int j = i + 1; j < length; j++)
            {
                if (_sellerArr[i]._itemsSold > _sellerArr[j]._itemsSold)
                {
                    temp = _sellerArr[i];
                    _sellerArr[i] = _sellerArr[j];
                    _sellerArr[j] = temp;
                }
            }
        }
    }
    /// <summary>
    /// method <c>SetTiers</c> 
    /// checks <c>_numberOfItemsSold</c> in <c>Seller</c> objects from <c>_sellerArr</c>,
    /// and increments a the value of a tier when <c>_itemsSold</c> attribute coincides
    /// within a valid interval.
    /// </summary>
    /// <returns>void</returns>
    public void SetTiers()
    {
        for(int i = 0; i < _sellerArr.Length; i++)
        {
            if (_sellerArr[i]._itemsSold < 50)
            {
                _tiers[1].Add(_sellerArr[i]);
            } else if (_sellerArr[i]._itemsSold >= 50 && _sellerArr[i]._itemsSold <= 99)
            {
                _tiers[2].Add(_sellerArr[i]);
            } else if (_sellerArr[i]._itemsSold >= 100 && _sellerArr[i]._itemsSold <= 199)
            {
                _tiers[3].Add(_sellerArr[i]);
            }
            else if (_sellerArr[i]._itemsSold > 199)
            {
                _tiers[4].Add(_sellerArr[i]);
            }
        }
    }

    public override string ToString()
    {
        string output = "\n\nname: pers.nr: district: items sold\n";
        foreach(KeyValuePair<int, List<Seller>> entry in _tiers)
        {
            if (entry.Value.Count > 0)
            {
                for (int i = 0; i < entry.Value.Count; i++)
                {
                    output += entry.Value[i].ToString();
                }
                if (entry.Value.Count > 1)
                {
                    output += entry.Value.Count + " sellers have reached tier " + entry.Key + "\n\n";
                } else
                {
                    output += entry.Value.Count + " seller has reached tier " + entry.Key + "\n\n";
                }
            }
        }
        return output;
    }
}

public class Seller
{
    public string _name { get; set; }
    public long _persNr { get; set; }
    public string _district { get; set; }
    public int _itemsSold { get; set; }
    public Seller(string name, long persNr, string district, int numberOfItemsSold)
    {
        _name = name;
        _persNr = persNr;
        _district = district;
        _itemsSold = numberOfItemsSold;
    }
    public override string ToString()
    {
        return string.Format("{0}:{1}:{2}:{3}\n",
            _name, _persNr, _district, _itemsSold);
    }
}