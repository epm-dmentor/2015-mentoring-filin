using System;

namespace Self_Recovering
{
    public class Program
    {
        public static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please make your choice:\n");
                Console.WriteLine("\tPress 1 to create self recovering object");
                Console.WriteLine("\tPress 2 to Exit app\n");
                
                int caseSwitch;
                Int32.TryParse(Console.ReadLine(), out caseSwitch);

                switch (caseSwitch)
                {
                    case 1:
                        var c = new SelfRecoveringObj();
                        Console.WriteLine("Object was created. Press Enter");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}