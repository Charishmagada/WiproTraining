using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ExtensionLibrary;

namespace ExtensionExample2
{
    internal static class MissingData
    {
        public static string MileStone3(this Operations op)
        {
            return "Databases";
        }
        public static string MileStone4(this Operations op)
        {
            return "Azure";
        }
        public static string MileStone5(this Operations op)
        {
            return "Capstone project";
        }
    }
}
