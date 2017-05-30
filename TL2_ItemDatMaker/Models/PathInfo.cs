﻿using System;
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

            MeshFile = Path.GetFileName(fullPath);

            if (string.IsNullOrWhiteSpace(MeshFile))
            {
                throw new ArgumentException("Invalid File");
            }

            List<string> folders = Path.GetDirectoryName(fullPath).ToUpper().Split(Path.DirectorySeparatorChar).ToList();
            int index = folders.IndexOf("MEDIA");

            Root = String.Join(Path.DirectorySeparatorChar.ToString(), folders.Take(index));
            Resource = String.Join("/", folders.Skip(index));

            ItemType = folders.Last();

            BaseDatPath = string.Join(Path.DirectorySeparatorChar.ToString(), new string[] { "MEDIA", "UNITS", "ITEMS" });
        }

        private string Root { get; set; }

        public string Resource { get; private set; }

        public string ItemType { get; private set; }

        public string MeshFile { get; private set; }

        private string BaseDatPath { get; set; }

        public string CreateFullDatPath(UnitType unitType, string name)
        {
            string[] pieces = new string[] { Root, BaseDatPath, unitType.Type, name + ".DAT" };
            return string.Join(Path.DirectorySeparatorChar.ToString(), pieces);
        }
    }
}