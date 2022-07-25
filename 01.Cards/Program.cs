using System;
using System.Collections.Generic;
using System.Text;

namespace Cards
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            string[] input = Console.ReadLine().Split(", ");
            List<Card> cards = new List<Card>();
            Card card = null;
            for (int i = 0; i < input.Length; i++)
            {

                string[] cardinfo = input[i].Split();
                string face = cardinfo[0].ToUpper();
                string suite = cardinfo[1].ToUpper();

                try
                {

                   
                    
                    CreateCard(face, suite);
                    if (suite == "S")
                    {
                        string s = "\u2660";
                        byte[] bytes = Encoding.Default.GetBytes(s);
                        s = Encoding.UTF8.GetString(bytes);

                        suite = s;

                    }
                    if (suite == "H")
                    {
                        string h = "\u2665";
                        byte[] bytes = Encoding.Default.GetBytes(h);
                        h = Encoding.UTF8.GetString(bytes);

                        suite = h;

                    }
                    if (suite == "D")
                    {
                        string d = "\u2666";
                        byte[] bytes = Encoding.Default.GetBytes(d);
                        d = Encoding.UTF8.GetString(bytes);

                        suite = d;

                    }
                    if (suite == "C")
                    {
                        string c = "\u2663";
                        byte[] bytes = Encoding.Default.GetBytes(c);
                        c = Encoding.UTF8.GetString(bytes);

                        suite = c;

                    }

                    card = new Card(face, suite);
                    
                    cards.Add(card);
                }
                catch (Exception ae)
                {

                    Console.WriteLine(ae.Message);
                }
               

            }

            foreach (var item in cards)
            {
                Console.Write(item.ToString());
            }

        }
        public static void CreateCard(string face, string suite)
        {
            

            if (face != "2" && face != "3" && face != "4" && face != "5" && face != "6" && face != "7" && face != "8" && face != "9" && face != "10" && face != "J" && face != "A" && face != "K" && face != "Q")
            {
                throw new Exception("Invalid card!");
            }
            if ((suite != "S") && (suite != "H") && (suite != "D") && (suite != "C"))
            {
                throw new Exception("Invalid card!");
            }

        }
    }

    public class Card
    {
        
        public Card(string face, string suite)
        {
            this.Face = face;
            this.Suite = suite;
        }

        public string  Face { get; set; }
        public string  Suite { get; set; }

        public override string ToString()
        {
            return $"[{this.Face}{this.Suite}]" + " ";
        }
    }
}
