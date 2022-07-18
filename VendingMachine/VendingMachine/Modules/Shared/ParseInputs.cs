using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Modules
{
    internal class ParseInputs
    {
        internal int AcceptNumberInput()
        {
            //Parsing the input
            bool isValid = false;
            int input=0;
            while (!isValid)
            {
                isValid = int.TryParse(Console.ReadLine(), out int result);
                if (isValid)
                    input= result;
                else
                {
                    Console.WriteLine("Select a valid input");
                }
            }
            return input;
        }
        internal bool AcceptYesNoInput()
        {
            //Accepting and parsing the user input for next shopping 
            bool isValid = false;
            bool isValidSelection = false;
            bool loopCount = false;
            Console.WriteLine("Do you want to purchase again (Y/N)?");

            while (!isValidSelection)
            {
                if (loopCount)
                {
                    Console.WriteLine("Select a valid input");
                }
                loopCount = true;

                string userInput = Console.ReadLine();
                if (userInput.ToUpper().Equals("Y"))
                {
                    isValid = true;
                    isValidSelection = true;
                }
                else if (userInput.ToUpper().Equals("N"))
                {
                    isValid = false;
                    isValidSelection = true;
                }
                else
                {
                    isValidSelection = false;
                }


            }
            return isValid;
        }
    }
}

