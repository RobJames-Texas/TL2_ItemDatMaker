using System;
using System.Collections.Generic;
using TL2_ItemDatMaker.Models;

namespace TL2_ItemDatMaker.Components
{
    public static class UnitCreator
    {
        public static IEnumerable<Unit> GenerateUnits(Options options)
        {
            _ = options ?? throw new ArgumentNullException(nameof(options));

            var pathInfo = new PathInfo(options.MeshFile);

            var unitType = UnitType.GetByMeshFolder(pathInfo.ItemType) ?? throw new ArgumentException("Invalid UnitType detected");

            var rarity = Rarity.GetByLevel(options.ItemRarity) ?? throw new ArgumentException("Invalid Rarity Level.");

            string name = ItemNameGenerator.Create(unitType, rarity, options.NameTag, options.ItemLevel);

            var units = Unit.GenerateVariations(pathInfo, unitType, rarity, options.ItemLevel, name, options.AltClones, options.NgClones);

            return units;
        }
    }
}
