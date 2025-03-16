using System;
using TL2_ItemDatMaker.Components;
using TL2_ItemDatMaker.Models;

namespace TL2_ItemDatMaker
{
    public class InteractiveOptions
    {
        private readonly IInputReader _inputReader;
        public InteractiveOptions(IInputReader inputReader) 
        {
            _inputReader = inputReader ?? throw new ArgumentNullException(nameof(inputReader));
        }

        public Options GetMeshFileOptions(string meshFile)
        {
            if (string.IsNullOrWhiteSpace(meshFile)) throw new ArgumentNullException(nameof(meshFile));

            Console.WriteLine("\n\nMeshfile detected.\n\nBegin Interactive mode.\n\nCtrl-C to exit.\n\n");

            var arguments = new Options
            {
                MeshFile = meshFile
            };

            while (string.IsNullOrWhiteSpace(arguments.ItemRarity))
            {
                Console.WriteLine("Item Rarity: Normal (n), Magic[Blue] (m), Unique (u) or Legendary (l).");
                Rarity r = Rarity.GetByLetter(_inputReader.ReadKey());
                arguments.ItemRarity = r?.Level;
                Console.WriteLine("\n");
            }

            while (string.IsNullOrWhiteSpace(arguments.NameTag))
            {
                Console.WriteLine("Tag to be appended after item type.  (Press ENTER when finished)");
                arguments.NameTag = _inputReader.ReadLine();
                Console.WriteLine();
            }

            while (arguments.ItemLevel < 2)
            {
                Console.WriteLine("Base level of the item. Minimum of 2.");
                _ = int.TryParse(_inputReader.ReadLine(), out int level);
                arguments.ItemLevel = level;
                Console.WriteLine();
            }

            Console.WriteLine("Make Alt Clones. (y/n)?");
            arguments.AltClones = _inputReader.ReadKey().Equals("y", StringComparison.InvariantCultureIgnoreCase);
            Console.WriteLine();

            Console.WriteLine("Make NG Clones. (y/n)?");
            arguments.NgClones = _inputReader.ReadKey().Equals("y", StringComparison.InvariantCultureIgnoreCase);
            Console.WriteLine();

            return arguments;
        }
    }
}
