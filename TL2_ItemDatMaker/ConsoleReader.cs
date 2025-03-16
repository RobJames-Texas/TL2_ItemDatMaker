using System;

namespace TL2_ItemDatMaker
{
    public class ConsoleReader : IInputReader
    {
        public string ReadKey()
        {
            return Console.ReadKey().KeyChar.ToString();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
