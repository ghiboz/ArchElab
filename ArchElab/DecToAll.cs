using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchElab
{
    public class DecToAll : IOperation
    {
        public DecToAll()
        {
            menuTitle = "Decimale => *";
            welcomeMessage = @"
.Inserire il valore da convertire: (decimale)";
        }

        public override string Operate(string input)
        {
            var ret = "";


            var dec = Convert.ToInt32(input);
            var bin = ToBin(dec, 32);
            var hex = dec.ToString("X");
            var oct = Convert.ToString(dec, 8);

            ret += $"{bin} Conversione binaria \r\n";
            ret += $"{oct} Conversione ottale \r\n";
            ret += $"0x{hex} Conversione esadecimale \r\n";

            return ret;
        }
    }
}