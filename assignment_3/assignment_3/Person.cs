/*
 * Author: Malek Abdul Sater
 * Mail: malekabdulsater@gmail.com
 * Kurs: L0002B
 * Uppgift 3 GUI
 */

namespace assignment_3
{   
    /// <summary>
    /// class <c>Person</c> encapsulates the needed methods and instance variables for a person.
    /// </summary>
    public class Person
    {
        public string PersNum { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Gender { get; set; }
        
        public Person(string firstName, string surName, string persNum)
        {
            PersNum = persNum;
            FirstName = firstName;
            SurName = surName;
            Gender = string.Empty;
        }
        /// <summary>
        /// Method <c>IsValidPersNumber</c>iterate through the characters of <c>persNum</c>, multiplying 
        /// the digit with 2 and 1. If the multiplied number is higher than 9, 
        /// it separates and adds the digits to <c>sum</c>.Else it will just add digits below 9 to <c>sum</c>.
        /// </summary>
        /// <returns>bool true/false</returns>
        public bool IsValidPersNumber()
        {
            string numberString;
            int temp;
            int sum = 0;
            int a = 2;

            for (int i = 0; i < PersNum.Length; i++)
            {
                temp = int.Parse(PersNum.ElementAt(i).ToString());
                temp = temp * a;
                if (temp > 9)
                {
                    numberString = Convert.ToString(temp);
                    sum += int.Parse(numberString[0].ToString()) + int.Parse(numberString[1].ToString());
                }
                else
                {
                    sum += temp;
                }
                if (a == 2)
                {
                    a = 1;
                } else
                {
                    a = 2;
                }
            }
            if ((sum%10) == 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// method <c>FindGender</c> looks at the second last number in
        /// <c>PersNum</c>, which defines whether the person is a man(odd) or a female(even).
        /// </summary>
        public void FindGender()
        {
            int temp = int.Parse(PersNum.ElementAt(8).ToString());
            if (temp%2 == 0)
            {
                Gender = "female";
            } else
            {
                Gender = "male";
            }
        }

        public override string ToString()
        {
            return string.Format("First name: {0}\n" +
                "Surname: {1}\nPers.Number: {2}\n" +
                "Gender: {3}", FirstName, SurName, PersNum, Gender);
        }
    }
}
