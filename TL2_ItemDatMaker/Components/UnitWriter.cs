using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TL2_ItemDatMaker.Models;

namespace TL2_ItemDatMaker.Components
{
    public class UnitWriter
    {
        private readonly PathInfo _pathInfo;
        private readonly IInputReader _inputReader;
        
        public UnitWriter(Options options, IInputReader inputReader)
        {
            _pathInfo = new PathInfo(options.MeshFile);
            _inputReader = inputReader ?? throw new ArgumentNullException(nameof(inputReader));
        }

        public void WriteUnits(IEnumerable<Unit> units)
        {
            if (units == null)
            {
                return;
            }
            foreach (var unit in units)
            {
                WriteUnit(unit);
            }
        }

        private void WriteUnit(Unit unit)
        {
            var destination = _pathInfo.CreateFullDatPath(unit.UnitType, unit.Name);

            Console.WriteLine(destination);

            Console.WriteLine(unit.ToDat());

            var folder = Path.GetDirectoryName(destination);
            if (!Directory.Exists(folder))
            {
                Console.WriteLine("\n\nDestination folder does not exist.  Create it now? (y/n)");
                if (!_inputReader.ReadKey().Equals("y", StringComparison.CurrentCultureIgnoreCase))
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
