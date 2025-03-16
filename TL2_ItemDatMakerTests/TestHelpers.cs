using System.Collections.Generic;
using System.IO;

namespace TL2_ItemDatMakerTests
{
    public static class TestHelpers
    {
        public static string BuildGoodMeshPath()
        {
            // ".\MEDIA\MODELS\WEAPONS\_STAVES\staff_model_01.MESH";
            List<string> pathParts =
            [
                ".",
                "MEDIA",
                "MODELS",
                "WEAPONS",
                "_STAVES",
                "staff_model_01.MESH"
            ];
            string meshFile = Path.Combine([.. pathParts]);
            return meshFile;
        }
    }
}
