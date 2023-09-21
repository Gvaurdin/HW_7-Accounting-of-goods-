using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7_Accounting_of_goods_
{
    internal class Sources
    {
        public static int SetCount()
        {
            int number = 0;

            Console.Write("Enter to count number for current operation  : ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out number) && number > 0 || number < 100)
            {
                return number;

            }
            else
            {
                Console.WriteLine("Error input number count");
                return 0;
            }
        }
        
        public static string GetLine()
        {
            string line = "";
            for (int i = 0; i < 150; i++)
            {
                if (i == 0) line += "\n";
                else if (i == 149) line += "\n";
                else line += "=";
            }
            return line;
        }

        public static string MenuHeader()
        {
            string menu_header = ($"{GetLine()}{"ID",-4}{"Description",-27}{"Name",-15}{"Weight",-10}{"Price",-10}{"Count",-10}{"Manufacturer(country of origin)",-35}" +
            $"{"Production date",-20}{"Expiration date",-20}{GetLine()}");
            return menu_header;
        }

        public static void InterfaceMenu(Commodity obj)
        {
            List<string> MenuItems = new List<string>
            {
                "Adding commodity",
                "Realisation commodity",
                "Despose commodity",
                "Transfer commodity",
                "Exit"
            };
            int selected_item_index = 0;

            while (true)
            {
                Console.Clear();

                Console.WriteLine(MenuHeader() + obj + GetLine() +
                    "Select action :");
                for (int i = 0; i < MenuItems.Count; i++)
                {
                    if (i == selected_item_index)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine(MenuItems[i]);
                }
                Console.BackgroundColor = ConsoleColor.Black;

                Console.WriteLine(GetLine());

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selected_item_index > 0)
                        {
                            selected_item_index--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (selected_item_index < MenuItems.Count - 1)
                        {
                            selected_item_index++;
                        }
                        break;

                    case ConsoleKey.Enter:
                        if (selected_item_index == MenuItems.Count-1)
                        {
                            return;
                        }
                        else
                        {
                            switch (selected_item_index)
                            {
                                case 0:
                                    {
                                        int number = SetCount();
                                        if (number != 0)
                                        {
                                            if (obj is ICommodityManagement)
                                            {
                                                ((ICommodityManagement)obj).Add(number);
                                            }
                                            Console.ReadKey();
                                        }
                                    }
                                    break;
                                case 1:
                                    {
                                        int number = SetCount();
                                        if(number != 0)
                                        {
                                            if (obj is ICommodityManagement)
                                            {
                                                ((ICommodityManagement)obj).Sell(number);
                                            }
                                            Console.ReadKey();
                                        }
                                    }
                                    break;
                                case 2:
                                    {
                                        int number = SetCount();
                                        if (number != 0)
                                        {
                                            if (obj is ICommodityManagement)
                                            {
                                                ((ICommodityManagement)obj).Dispose(number);
                                            }
                                            Console.ReadKey();
                                        }
                                    }
                                    break;
                                case 3:
                                    {
                                        int number = SetCount();
                                        string destination = "Shop";
                                        if (number != 0)
                                        {
                                            if (obj is ICommodityManagement)
                                            {
                                                ((ICommodityManagement)obj).Transfer(number,destination);
                                            }
                                            Console.ReadKey();
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                }
                Console.BackgroundColor = ConsoleColor.Black;
            }

        }

        public static void Menu()
        {
            List<Commodity> list = new List<Commodity>
            {
                new CandyCommodity("Candy","Snikers",0.1,50.5,10,"USA",new DateTime(2023,9,20),new DateTime(2024,9,20)),
                new DetergentCommodity("Detergent","Fairy",1.8,198.7,20,"Germany",new DateTime(2023,5,6), new DateTime(2025,5,6)),
                new BakeryCommodity("Sunflower oil","Sloboda",0.9, 140.5,10,"Russia",new DateTime(2023,5,20),new DateTime(2024,5,20)),
                new MilkCommodity("Milk","Prostokvashino",0.9,120.5,30,"Russia",new DateTime(2023,9,21),new DateTime(2023,10,5)),
                new LaundryCommodity("Washing powder","Tide",0.5,150.5,30,"Germany",new DateTime(2023,1,1),new DateTime(2025,10,5)),
                new SanitaryCommodity("Floor cleaning agent","Mr.Proper",1.0,215.3,20,"USA",new DateTime(2023,5,23),new DateTime(2025,5,23) )
            };

            int selected_item_index = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\tOrder list commodity\t Click escape if you need to exit the program\n" +
                    "Select action :");
                Console.Write(MenuHeader());
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == selected_item_index)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine(list[i]);
                }
                Console.BackgroundColor = ConsoleColor.Black;

                Console.WriteLine(GetLine());

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selected_item_index > 0)
                        {
                            selected_item_index--;
                        }
                        else selected_item_index = list.Count;
                        break;

                    case ConsoleKey.DownArrow:
                        if (selected_item_index < list.Count)
                        {
                            selected_item_index++;
                        }
                        if (selected_item_index == list.Count)
                        {
                            selected_item_index = 0;
                        }
                        break;
                    case ConsoleKey.Escape:
                        {
                            Environment.Exit(0);
                        }
                        break;

                    case ConsoleKey.Enter:
                        {
                            InterfaceMenu(list.ElementAt(selected_item_index));
                        }
                        break;
                }
                Console.BackgroundColor = ConsoleColor.Black;
            }

        }
    }
}
