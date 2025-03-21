using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TL2_ItemDatMaker.Components;

namespace TL2_ItemDatMaker.Models
{
    public class PathInfo
    {
        public PathInfo(string fullPath)
        {
            if (string.IsNullOrWhiteSpace(fullPath))
            {
                throw new ArgumentException("Invalid Path");
            }

            MeshFile = Path.GetFileNameWithoutExtension(fullPath);

            if (string.IsNullOrWhiteSpace(MeshFile))
            {
                throw new ArgumentException("Invalid File");
            }

            List<string> folders = Path.GetDirectoryName(fullPath).ToUpperInvariant().Split(Path.DirectorySeparatorChar).ToList();
            int index = folders.IndexOf("MEDIA");

            Root = String.Join(Path.DirectorySeparatorChar.ToString(), folders.Take(index));
            Resource = String.Join("/", folders.Skip(index));

            ItemType = folders.Last();

            if (string.IsNullOrWhiteSpace(Root) || string.IsNullOrWhiteSpace(Resource) || string.IsNullOrWhiteSpace(ItemType))
            {
                throw new ArgumentException("Invalid Path");
            }

            if (UnitType.List().Where(u => u.MeshFolder == ItemType).Count() == 0)
            {
                throw new ArgumentException("Invalid Item Type Path");
            }

            BaseDatPath = string.Join(Path.DirectorySeparatorChar.ToString(), new [] { "MEDIA", "UNITS", "ITEMS" });

        }

        private string Root { get; set; }

        public string Resource { get; private set; }

        public string ItemType { get; private set; }

        public string MeshFile { get; private set; }

        private string BaseDatPath { get; set; }

        public string CreateFullDatPath(UnitType unitType, string name)
        {
            string[] pieces = new string[] { Root, BaseDatPath, unitType.UnitFolder, name + ".DAT" };
            return string.Join(Path.DirectorySeparatorChar.ToString(), pieces).ToUpper();
        }
    }
}
