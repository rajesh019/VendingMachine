using Gremlin.Net.Process.Traversal;
using System;
using System.Collections.Generic;
using VendingMachine.Interfaces;
using VendingMachine.Modules;
using VendingMachine.Modules.AcceptMoney;
using VendingMachine.Modules.DispenseProducts;
using VendingMachine.Modules.Products;

namespace VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Products products = new Products();
            bool cont = true;

            while (cont)
            {
                try
                {
                    //Display the Items
                    int productValueInPence = products.SelectProduct();

                    if (productValueInPence > 0)
                    {
                        //Accepting, parsing, validating and calculating total value of the coins
                        AcceptMoney acceptMoney = new AcceptMoney();
                        int totalCoinValueInPence = acceptMoney.AcceptCoins(productValueInPence);

                        //Returning the change
                        if (totalCoinValueInPence >= productValueInPence)
                        {
                            Console.WriteLine("Poduct is dispensed. Thank You!\n");

                            int change = totalCoinValueInPence - productValueInPence;
                            Console.WriteLine("Collect change: £" + change / 100 + " and " + change % 100 + "p\n");
                        }
                    }
                    //Accepting user input and checking if he wants shopping again
                    ParseInputs parseInput = new ParseInputs();
                    cont = parseInput.AcceptYesNoInput();
                    if (!cont)
                    {
                        Console.WriteLine("Thanks for your shopping with us!");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}

