using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Interfaces;
using VendingMachine.Modules;

namespace VendingMachine.Modules.Products
{
    public class Products : IProducts
    {
        public int SelectProduct()
        {
            int item;
            int productValueInPence = 0;

            //Display the Items on screen
            item = this.DisplayProduct();
            
            //Product price calculation
            if (item > 0)
            {
                if (item == 1)
                {
                    productValueInPence = 100;
                }
                else if (item == 2)
                {
                    productValueInPence = 50;
                }
                else if (item == 3)
                    productValueInPence = 65;
                else
                    Console.WriteLine("Select a valid input for product");
            }

            return productValueInPence;
        }

        public int DisplayProduct()
        {
            //Displaying the product
            Console.WriteLine("Please select 1 for " + DefineProducts.Cola + ". Price £1.00");
            Console.WriteLine("Please select 2 for " + DefineProducts.Crisps + ". Price 50p");
            Console.WriteLine("Please select 3 for " + DefineProducts.Chocolate + ". Price 65p");
            //Parse the Input
            ParseInputs parseInput = new ParseInputs();
            return parseInput.AcceptNumberInput();
        }


    }
}
