using System;
using System.Globalization;

namespace Lab8
{
    class Program10
    {
        private static bool isWorking = true;
        public static Discount_journal journal;

        static void Main(string[] args)
        {
            journal = new Discount_journal("My Discount journal to go shopping");
            Console.WriteLine("WELCOME to the World of Discounts!\n");

            Console.WriteLine("Enter the number of action and press[Enter].Then follow instructions.");

            while (isWorking)
            {
                Console.WriteLine("Menu:\n\t1. Add new discount\n\t2. Delete a discount\n\t3. View all discounts\n\t4. Exit");
                HandleCommand(ReadFromConsole("> "));
            }
        }

        static string ReadFromConsole(string input)
        {
            Console.Write(input);
            return Console.ReadLine();
        }

        static void HandleCommand(string command)
        {
            switch (command)
            {
                case "1":
                    Console.WriteLine("Enter information about a discount:");
                    string shop = ReadFromConsole("\tName of the shop: ");

                    int sizeOfDiscount;
                    while (true)
                    {
                        if (int.TryParse(ReadFromConsole("\tSize of the discount (%): "), out sizeOfDiscount) && (sizeOfDiscount > 0 && sizeOfDiscount < 100)) break;

                        Console.WriteLine("\tAn error: you need to input integer number of percentage (from 1 to 100).");
                    }

                    DateTime expirationDate;
                    while (true)
                    {
                        if (DateTime.TryParseExact(ReadFromConsole("\tExpiration date (dd mm yyyy): "), "dd MM yyyy", new CultureInfo("ru-Ru"), DateTimeStyles.None, out expirationDate)) break;
                        Console.WriteLine("\tAn error: you need to input date properly (dd MM yyyy).");
                    }

                    if (journal.AddNewDiscount(shop, sizeOfDiscount, expirationDate)) Console.WriteLine("The discount was succesfuuly added.");
                    else Console.WriteLine("You have already got a discount in this shop.");
                    break;

                case "2":
                    Console.WriteLine("Enter the name of the shop where you want to delete the discount:");
                    string shop1 = ReadFromConsole("\tName of the shop: ");

                    if (journal.DeleteDiscount(shop1)) Console.WriteLine("The discount was succesfuuly removed.");
                    else Console.WriteLine("Unfortunately, you haven't got a discount in this shop.");
                    break;

                case "3":
                    int dcounter = 1;
                    string response = "";

                    foreach (Discount d in journal.GetSortList())
                    {
                        response += $"\t{dcounter}. The name of shop: {d.GetShop()}\n" +
                            $"\t   Size of discount: {d.GetSizeOfDiscount()}\n" +
                            $"\t   Expiration date: {d.GetExpirationDate():d};\n";
                        dcounter++;
                    }

                    if (response.Length == 0) Console.WriteLine("\tUnfortunately, there are no discounts in your list.");
                    else Console.WriteLine("A list of all your discounts: \n" + response);
                    break;

                case "4":
                    isWorking = false;
                    break;

                default:
                    break;
            }
        }
    }
}