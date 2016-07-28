using System;
using System.IO;
using System.Threading.Tasks;
using static System.IO.Directory;
using static System.String;

namespace MagicTool
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 3)
            {
                var path = args[0];
                var command = args[1];
                var outputFilePath = args[2];
                Console.WriteLine("Comand line: {0} {1} {2}", path, command, outputFilePath);

                if (Exists(path))
                {
                    if (!IsNullOrEmpty(outputFilePath) || Path.HasExtension(outputFilePath))
                    {
                        Worker worker;
                        try
                        {
                            worker = new Worker(path, outputFilePath, new CollectorFactory(command).MakeAChoise());
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine("{0} {1}", e.Message, e.ParamName);
                            Console.WriteLine("Press Enter to close window");
                            Console.ReadLine();
                            return;
                        }

                        Task.WaitAll(worker.Do());
                        worker.Write();
                        Console.WriteLine("File created by path: {0}", Path.GetFullPath(outputFilePath));
                        Console.WriteLine("Do you want to open this file?\nType: Yes - y, No - n and press enter");

                        var answer = Console.ReadLine();
                        if (!IsNullOrEmpty(answer) && answer.Equals("y", StringComparison.OrdinalIgnoreCase))
                        {
                            System.Diagnostics.Process.Start(Path.GetFullPath(outputFilePath));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid output file argument");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid path argument!");
                }
            }
            else
            {
                Console.WriteLine("Invalid arguments!");
            }
            Console.WriteLine("Press Enter to close window");
            Console.ReadLine();
        }
    }
}
