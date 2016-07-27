using System;
using System.IO;

namespace MagicTool
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <2)
            {
#if DEBUG
                #region test
                var path = @"C:\temp\";
                var command = "cpp";
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
                worker.Do();
                worker.Write();
                #endregion
#endif
                //Console.WriteLine("Invalid arguments!");
            }
            else
            {
                if (Directory.Exists(args[0]))
                {
                    Worker worker;
                    switch (args[1].ToLower())
                    {
                        case "all":
                            worker = new Worker(args[0],new AllMagic());
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

                    worker.Do();
                    worker.Write();
                }
                else
                {
                    Console.WriteLine("Invalid path argument!");
                }
            }

            Console.WriteLine("Press any button to stop process");
            Console.ReadKey();
        }
    }
}
