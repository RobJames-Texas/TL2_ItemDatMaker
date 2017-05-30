using coreArgs;
using coreArgs.Model;
using System;
using System.Linq;
using TL2_ItemDatMaker.Components;
using TL2_ItemDatMaker.Models;

namespace TL2_ItemDatMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            ParserResult<Options> result = ArgsParser.Parse<Options>(args);

            if (result.Errors.Count > 0)
            {
                Console.WriteLine("Computer says no.\n");
                Console.Write(ArgsParser.GetHelpText<Options>());
            }
            else
            {
                Options arguments = result.Arguments;
                PathInfo pathInfo = new PathInfo(arguments.MeshFile);

                UnitType unitType = UnitType.List().Where(u => u.MeshFolder == pathInfo.ItemType).First();

                Rarity rarity = Rarity.List().Where(r => r.Level.ToLower() == arguments.ItemRarity.ToLower()).FirstOrDefault();

                string name = unitType.NamePrefix + arguments.NameTag + rarity.NameLetter + arguments.ItemLevel;

                Unit unit = new Unit(pathInfo.Resource, pathInfo.MeshFile, unitType, name, arguments.ItemLevel, rarity);

                string destination = pathInfo.CreateFullDatPath(unitType, name);

                Console.WriteLine(destination);

                Console.WriteLine(unit.ToDat());

                System.IO.File.WriteAllText(destination, unit.ToDat());
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
    }
}