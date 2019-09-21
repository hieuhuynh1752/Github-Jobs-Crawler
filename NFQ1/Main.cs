using System;


namespace NFQ1
{
    class MainProgram
    {
        static void Main()
        {
            bool operation = true; int n;
            while (operation == true)
            {
                Console.WriteLine("\n=== Github Job crawler program ===");
                Console.WriteLine("Please choose your operation:");
                Console.WriteLine("[1] Grab all jobs information that having specific description");
                Console.WriteLine("[2] Grab Part-time jobs information that having specific description");
                Console.WriteLine("[0] Exit");
                Console.WriteLine("\n Your Operation is:");
                try
                {
                   n = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                   Console.WriteLine("Invalid operation!");
                   n = 3;
                }
                switch (n)
                        {
                            case 0:
                                operation = false;
                        Console.WriteLine("Thank you!");
                                break;
                            case 1:
                                Console.WriteLine("Please input the job description:");
                                string x = Console.ReadLine();
                                Crawler.CrawlAll(x);
                                break;
                            case 2:
                                Console.WriteLine("Please input the job description:");
                                string y = Console.ReadLine();
                                Crawler.CrawlParttime(y);
                                break;
                            case 3:
                                break;
                        }
                    }
            Console.WriteLine("\n Made by Huynh Thai Hieu");
            Console.ReadKey();
        }
                    
 
        }
    }

