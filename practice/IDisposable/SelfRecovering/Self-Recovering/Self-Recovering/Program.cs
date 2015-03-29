using System;

namespace Self_Recovering
{
    public class Program
    {
        public static void Main()
        {
            Random r = null;
            SelfRecoveringObj c = null;

            while (true)
            {
                Console.WriteLine("Please make your choice:\n");
                Console.WriteLine("\tPress 1 to create self recovering object");
                Console.WriteLine("\tPress 2 to run GC");
                Console.WriteLine("\tPress 3 to check reference to object");
                Console.WriteLine("\tPress 4 to Exit app\n");
                int caseSwitch;
                Int32.TryParse(Console.ReadLine(), out caseSwitch);


                switch (caseSwitch)
                {
                    case 1:
                        const int cacheSize = 50;
                        r = new Random();
                        c = new SelfRecoveringObj(cacheSize);
                        Console.WriteLine("Object was created. Press Enter");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        GC.Collect();
                        Console.WriteLine("GC has run. Press Enter");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        if (c != null)
                        {
                            for (int i = 0; i < c.Count; i++)
                            {
                                int index = r.Next(c.Count);

                                //Simulating access to the object by getting a property value.
                                string dataName = c[index].Name;
                            }
                            //Show results. 
                            double regenPercent = c.RegenerationCount/(double) c.Count;
                            Console.WriteLine("Total size: {0}, Recreated: {1:P2}", c.Count, regenPercent);
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Create object first");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 4:
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