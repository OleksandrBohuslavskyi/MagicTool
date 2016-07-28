using System;
using System.IO;
using System.Threading.Tasks;

namespace MagicTool
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
#if DEBUG
                #region DebugCode
                var path = @"C:\temp\";
                var command = "reversed2";
                Worker worker;
                switch (command)
                {
                    case "all":
                        worker = new Worker(path, new AllMagic());
                        break;
                    case "cpp":
                        worker = new Worker(path, new CppMagic());
                        break;
                    case "reversed1":
                        worker = new Worker(path, new Reverse1Magic());
                        break;
                    case "reversed2":
                        worker = new Worker(path, new Reverse2Magic());
                        break;
                    default:
                        Console.WriteLine(command);
                        Console.WriteLine("Invalid command argument!");
                        return;
                }
                Task.WaitAll( worker.Do());
                var resultFile = worker.Write();
                Console.WriteLine("File created by path: " + resultFile);
                Console.WriteLine("Do you want to open this file?\nType: Yes - y, No - n and press enter");
                var answer = Console.ReadLine();
                if (!string.IsNullOrEmpty(answer) && answer.ToLower() == "y")
                {
                    System.Diagnostics.Process.Start(resultFile);
                }
                #endregion
#endif
                Console.WriteLine("Invalid arguments!");
            }
            else
            {
                if (Directory.Exists(args[0]))
                {
                    Worker worker;
                    switch (args[1].ToLower())
                    {
                        case "all":
                            worker = new Worker(args[0], new AllMagic());
                            break;
                        case "cpp":
                            worker = new Worker(args[0], new CppMagic());
                            break;
                        case "reversed1":
                            worker = new Worker(args[0], new Reverse1Magic());
                            break;
                        case "reversed2":
                            worker = new Worker(args[0], new Reverse2Magic());
                            break;
                        default:
                            Console.WriteLine(args[1]);
                            Console.WriteLine("Invalid command argument!");
                            return;
                    }

                    Task.WaitAll(worker.Do());
                    var resultFile = worker.Write();
                    Console.WriteLine("File created by path: " + resultFile);
                    Console.WriteLine("Do you want to open this file?\nType: Yes - y, No - n and press enter");

                    var answer = Console.ReadLine();
                    if (!string.IsNullOrEmpty(answer) && answer.ToLower() == "y")
                    {
                        System.Diagnostics.Process.Start(resultFile);
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
