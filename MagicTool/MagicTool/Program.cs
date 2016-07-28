using System;
using System.IO;
using System.Threading.Tasks;
using static System.String;

namespace MagicTool
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
#if DEBUG
                #region DebugCode
                var path = @"C:\temp\";
                var command = "reversed2";
                var resultFilePath = @"result.txt";
                Worker worker;
                try
                {
                    worker = new Worker(path, resultFilePath, new MagicFactory(command).MakeMagicChoise());
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message + " " + e.ParamName);
                    Console.WriteLine("Press Enter to close window");
                    Console.ReadLine();
                    return;
                }
                Task.WaitAll(worker.Do());
                worker.Write();
                Console.WriteLine("File created by path: " + Path.GetFullPath(resultFilePath));
                Console.WriteLine("Do you want to open this file?\nType: Yes - y, No - n and press enter");
                var answer = Console.ReadLine();
                if (!IsNullOrEmpty(answer) && answer.ToLower() == "y")
                {
                    System.Diagnostics.Process.Start(Path.GetFullPath(resultFilePath));
                }
                #endregion
#else
                Console.WriteLine("Invalid arguments!");
#endif
                }
            else
            {
                if (Directory.Exists(args[0]))
                {
                    if (IsNullOrEmpty(args[2]) && !Path.HasExtension(args[2]))
                    {
                        Console.WriteLine("Invalid output file argument");
                    }
                    else
                    {
                        Worker worker;
                        try
                        {
                            worker = new Worker(args[0], args[2], new MagicFactory(args[1]).MakeMagicChoise());
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message + " " + e.ParamName);
                            Console.WriteLine("Press Enter to close window");
                            Console.ReadLine();
                            return;
                        }

                        Task.WaitAll(worker.Do());
                        worker.Write();
                        Console.WriteLine("File created by path: " + Path.GetFullPath(args[2]));
                        Console.WriteLine("Do you want to open this file?\nType: Yes - y, No - n and press enter");

                        var answer = Console.ReadLine();
                        if (!IsNullOrEmpty(answer) && answer.ToLower() == "y")
                        {
                            System.Diagnostics.Process.Start(Path.GetFullPath(args[2]));
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid path argument!");
                }
            }

            Console.WriteLine("Press Enter to close window");
            Console.ReadLine();
        }
    }
}
