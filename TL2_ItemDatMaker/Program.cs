using coreArgs;
using coreArgs.Model;
using System;
using System.IO;
using TL2_ItemDatMaker.Components;
using TL2_ItemDatMaker.Models;

namespace TL2_ItemDatMaker
{
    class Program
    {
        protected static void Main(string[] args)
        {
            Options options = null;
            var inputReader = new ConsoleReader();

            if (args.Length == 0)
            {
                // No arguments!
                Console.WriteLine("\n\nNothing to do.\n\n");
                ExitMessage();
                return;
            }

            if (args.Length == 1 && File.Exists(args[0]))
            {
                var interactive = new InteractiveOptions(inputReader);
                options = interactive.GetMeshFileOptions(args[0]);
            }
            else
            {
                ParserResult<Options> result = ArgsParser.Parse<Options>(args);
                if (result.Errors.Count > 0)
                {
                    Console.WriteLine("\n\nComputer says no.\n\n");
                    Console.Write(ArgsParser.GetHelpText<Options>());
                    ExitMessage();
                    return;
                }
                else
                {
                    options = result.Arguments;
                }
            }

            if (options == null)
            {
                Console.WriteLine("\n\nNothing to do.\n\n");
                ExitMessage();
                return;
            }

            try
            {
                var units = UnitCreator.GenerateUnits(options);
                var unitWriter = new UnitWriter(options, inputReader);
                unitWriter.WriteUnits(units);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\nComputer says no.\n\n");

                Console.WriteLine(ex.Message);
                Console.WriteLine();

                Console.Write(ArgsParser.GetHelpText<Options>());
            }
            ExitMessage();
        }

        protected static void ExitMessage()
        {
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
    }
}