using System;
using System.Collections.Generic;
using System.Linq;

namespace SumofIntegers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> print = new List<int>();
            int exceptions = 0;
            while (exceptions != 3)
            {
                string[] command = Console.ReadLine().Split();
                string typeCommand = command[0];
                try
                {
                    if (typeCommand == "Replace")
                    {
                        IsIndexOutOf(input, command[1]);
                        int index = int.Parse(command[1]);
                        int element = int.Parse(command[2]);

                        input[index] = element;
                    }
                    else if (typeCommand == "Print")
                    {
                        IsPrintAvalable(input, command[1], command[2]);
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);
                        for (int i = input[startIndex] - 1; i <= endIndex; i++)
                        {
                            print.Add(input[i]);
                        }

                        Console.WriteLine(string.Join(", ", print));
                        print.Clear();

                    }
                    else if (typeCommand == "Show")
                    {
                        IsIndexOutOf(input, command[1]);
                        int index = int.Parse(command[1]);
                        Console.WriteLine(input[index]);

                    }

                }
                catch (InvalidIndex ii)
                {
                    exceptions++;
                    Console.WriteLine(ii.Message);

                }

                catch (InvalidVariable iv)
                {
                    exceptions++;
                    Console.WriteLine(iv.Message);

                }

            }

            Console.WriteLine(string.Join(", ", input));

        }
        public static void IsIndexOutOf(int[] input, string index)
        {
            int number;
            bool success = int.TryParse(index, out number);
           

            if (!success)
            {
                throw new InvalidVariable("The variable is not in the correct format!");
            }
            if (number < 0 || number > input.Length - 1)
            {
                
                throw new InvalidIndex("The index does not exist!");
            }
           
           
        }
        public static void IsPrintAvalable(int[] input, string index, string input2)
        {
            int number;
            bool success = int.TryParse(index, out number);
            int number2;
            bool success2 = int.TryParse(input2, out number2);


            if (!success || !success2)
            {
                throw new InvalidVariable("The variable is not in the correct format!");
            }
            if (number < 0 || number2 > input.Length - 1)
            {

                throw new InvalidIndex("The index does not exist!");
            }


        }


    }
    public class InvalidIndex : Exception
    {
        public InvalidIndex(string message)
            : base(message)
        {

        }
    }
    public class InvalidVariable : Exception
    {
        public InvalidVariable(string message)
            : base(message)
        {

        }
    }

}



