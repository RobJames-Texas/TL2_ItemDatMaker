using coreArgs;
using coreArgs.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TL2_ItemDatMaker.Components;
using TL2_ItemDatMaker.Models;

namespace TL2_ItemDatMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            Options arguments = null;

            if (args.Length == 1 && File.Exists(args[0]))
            {
                Console.WriteLine("\n\nMeshfile detected.\n\nBegin Interactive mode.\n\nCtrl-C to exit.\n\n");

                arguments = InteractiveOptions(args[0]);
            }
            else
            {
                ParserResult<Options> result = ArgsParser.Parse<Options>(args);
                if (result.Errors.Count > 0)
                {
                    Console.WriteLine("\n\nComputer says no.\n\n");
                    Console.Write(ArgsParser.GetHelpText<Options>());
                }
                else
                {
                    arguments = result.Arguments;
                }
            }

            if (arguments != null)
            {
                try
                {
                    CreateUnits(arguments);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("\n\nComputer says no.\n\n");

                    Console.WriteLine(ex.Message);
                    Console.WriteLine();

                    Console.Write(ArgsParser.GetHelpText<Options>());
                }
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        private static Options InteractiveOptions(string meshFile)
        {
            Options arguments = new Options();
            arguments.MeshFile = meshFile;

            while (string.IsNullOrWhiteSpace(arguments.ItemRarity))
            {
                Console.WriteLine("Item Rarity: Normal (n), Magic[Blue] (m), Unique (u) or Legendary (l).");
                Rarity r = Rarity.GetByLetter(Console.ReadKey().KeyChar.ToString());
                arguments.ItemRarity = r?.Level;
                Console.WriteLine("\n");
            }

            while (string.IsNullOrWhiteSpace(arguments.NameTag))
            {
                Console.WriteLine("Tag to be appended after item type.  (Press ENTER when finished)");
                arguments.NameTag = Console.ReadLine();
                Console.WriteLine();
            }

            while (arguments.ItemLevel < 2)
            {
                Console.WriteLine("Base level of the item. Minimum of 2.");
                int level = 0;
                int.TryParse(Console.ReadLine(), out level);
                arguments.ItemLevel = level;
                Console.WriteLine();
            }

            Console.WriteLine("Make Alt Clones. (y/n)?");
            arguments.AltClones = Console.ReadKey().KeyChar.ToString().ToLower() == "y";
            Console.WriteLine();

            Console.WriteLine("Make NG Clones. (y/n)?");
            arguments.NgClones = Console.ReadKey().KeyChar.ToString().ToLower() == "y";
            Console.WriteLine();

            return arguments;
        }

        private static void CreateUnits(Options arguments)
        {
            PathInfo pathInfo = new PathInfo(arguments.MeshFile);

            UnitType unitType = UnitType.GetByMeshFolder(pathInfo.ItemType);

            Rarity rarity = Rarity.GetByLevel(arguments.ItemRarity);

            if (rarity == null)
            {
                throw new ArgumentException("Invalid Rarity Level.");
            }

            if (unitType == null)
            {
                throw new ArgumentException("Invalid UnitType detected.");
            }

            string name = ItemNameGenerator.Create(unitType, rarity, arguments.NameTag, arguments.ItemLevel);

            IEnumerable<Unit> units = Unit.GenerateVariations(pathInfo, unitType, rarity, arguments.ItemLevel, name, arguments.AltClones, arguments.NgClones);

            foreach (Unit unit in units)
            {
                WriteUnit(pathInfo, unit);
            }
        }

        private static void WriteUnit(PathInfo pathInfo, Unit unit)
        {
            string destination = pathInfo.CreateFullDatPath(unit.UnitType, unit.Name);

            Console.WriteLine(destination);

            Console.WriteLine(unit.ToDat());

            string folder = Path.GetDirectoryName(destination);
            if (!Directory.Exists(folder))
            {
                Console.WriteLine("\n\nDestination folder does not exist.  Create it now? (y/n)");
                if (Console.ReadKey().KeyChar.ToString().ToLower() != "y")
                {
                    Console.WriteLine("\n\nCreation of unit file skipped.");
                    return;
                }
                Directory.CreateDirectory(folder);
                Console.WriteLine("\n\nUnit folder created.");
            }

            File.WriteAllText(destination, unit.ToDat(), Encoding.Unicode);
        }
    }
}