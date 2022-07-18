using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Interfaces;

namespace VendingMachine.Modules.AcceptMoney
{
    public class AcceptMoney : IAcceptMoney
    {
        public int AcceptCoins(int totalProductPrice)
        {
            int totalInsertedPence = 0;

            Console.WriteLine("Please select relevant options from below:");
            Console.WriteLine("1 for Pence only\n2 for Pound only\n3 for both");

            //Parsing the user Input
            ParseInputs parseInput = new ParseInputs();
            int result = parseInput.AcceptNumberInput();
            //Accepting user coins, validating them and calculating their total value in pence 
            switch (result)
            {
                case 1:
                    while (totalProductPrice > totalInsertedPence)
                    {
                        InsertPence(ref totalInsertedPence);
                        Console.WriteLine("Your Balance: £" + totalInsertedPence / 100 + " and " + (totalInsertedPence) % 100 + "p. " + ((totalProductPrice > totalInsertedPence) ? "Insufficient balance: " + (totalProductPrice - totalInsertedPence) +"p" : "Excess balance: " + (totalInsertedPence-totalProductPrice) + "p\n"));
                    }
                    break;

                case 2:
                    while (totalProductPrice > totalInsertedPence)
                    {
                        InsertPound(ref totalInsertedPence);
                        Console.WriteLine("Your Balance: £" + totalInsertedPence / 100 + " and " + (totalInsertedPence) % 100 + "p. " + ((totalProductPrice > totalInsertedPence) ? "Insufficient balance: " + (totalProductPrice - totalInsertedPence) + "p" : "Excess balance: " + (totalInsertedPence - totalProductPrice) + "p\n"));
                    }
                    break;
                case 3:
                    while (totalProductPrice > totalInsertedPence)
                    {
                        InsertPence(ref totalInsertedPence);
                        InsertPound(ref totalInsertedPence);
                        Console.WriteLine("Your Balance: £" + totalInsertedPence / 100 + " and " + (totalInsertedPence) % 100 + "p. " + ((totalProductPrice > totalInsertedPence) ? "Insufficient balance: " + (totalProductPrice - totalInsertedPence) + "p" : "Excess balance: " + (totalInsertedPence - totalProductPrice) + "p\n"));
                    }
                    break;
                default:
                    Console.WriteLine("Select a valid option for currency");
                    break;
            }

            return totalInsertedPence;
        }

        private void InsertPound(ref int totalInsertedPence)
        {
            bool isValid = true;
            int inValidCount = 0;

            ParseInputs parseInput = new ParseInputs();
            Console.WriteLine("Insert pound coins (Valid coins are:1,2)");
            int pound = parseInput.AcceptNumberInput();

            if (pound > 0)
                isValid = IsValidPound(pound, ref totalInsertedPence);

            while (!isValid)
            {
                Console.WriteLine("Collect the invalid pound coin: £" + (pound * 100) / 100 + " and " + (pound * 100) % 100 + "p\n");

                if (inValidCount == 2)
                {
                    ParseInputs input = new ParseInputs();
                    if (!input.AcceptYesNoInput())
                    {
                        Environment.Exit(0);
                    }
                }

                Console.WriteLine("Insert valid pound coins (Valid coins are:1,2)");
                pound = parseInput.AcceptNumberInput();

                if (pound > 0)
                    isValid = IsValidPound(pound, ref totalInsertedPence);

                inValidCount += 1;

            }
        }
        public bool IsValidPound(int pound, ref int totalInsertedPence)
        {
            int[] validPound = { 1, 2 }; //This should be move to Configuration
            List<int> Pound = new List<int>();
            Pound.AddRange(validPound);

            if (Pound.FindIndex(x => x == pound) == -1)
            {
                return false;
            }
            else totalInsertedPence += pound * 100;

            return true;
        }

        private void InsertPence(ref int totalInsertedPence)
        {
            bool isValid = true;
            int inValidCount = 0;

            ParseInputs parseInput = new ParseInputs();
            Console.WriteLine("Insert pence coins (Valid coins are: 5, 10, 20, 50)");
            int pence = parseInput.AcceptNumberInput();

            if (pence > 0)
                isValid = IsValidPence(pence, ref totalInsertedPence);

            while (!isValid)
            {
                Console.WriteLine("Collect the invalid pence coin: £" + pence / 100 + " and " + pence % 100 + "p\n");

                if (inValidCount == 2)
                {
                    ParseInputs input = new ParseInputs();
                    if (!input.AcceptYesNoInput())
                    {
                        Environment.Exit(0);
                    }

                }

                Console.WriteLine("Insert valid pence coins (Valid coins are: 5, 10, 20, 50)");
                pence = parseInput.AcceptNumberInput();

                if (pence > 0)
                    isValid = IsValidPence(pence, ref totalInsertedPence);

                inValidCount += 1;
            }
        }

        public bool IsValidPence(int pence, ref int totalInsertedPence)
        {
            int[] validPence = { 5, 10, 20, 50 };//This should be move to Configuration
            List<int> Pence = new List<int>();
            Pence.AddRange(validPence);

            if (Pence.FindIndex(x => x == pence) == -1)
            {
                return false;
            }
            else totalInsertedPence += pence;

            return true;
        }
    }
}
