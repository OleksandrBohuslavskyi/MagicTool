using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTool
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <2)
            {
                Console.WriteLine("Invalid arguments!");
            }
            else
            {
                if (Directory.Exists(args[0]))
                {
                    switch (args[1])
                    {
                        case "all":
                            Console.WriteLine(args[1]);
                            break;
                        case "срр":
                            Console.WriteLine(args[1]);
                            break;
                        case "reversed1":
                            Console.WriteLine(args[1]);
                            break;
                        case "reversed2":
                            Console.WriteLine(args[1]);
                            break;
                        default:
                            Console.WriteLine(args[1]);
                            Console.WriteLine("Invalid command argument!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid path argument!");
                }
            }
        }
    }
}
