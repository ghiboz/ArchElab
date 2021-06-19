using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchElab
{
    public class HexToAll : IOperation
    {
        public HexToAll()
        {
            menuTitle = "Esadecimale => *";
            welcomeMessage = "Inserire il valore da convertire: (decimale)";
        }

        public override string Operate(string input)
        {
            var ret = "";
            if (input.Contains("."))
            {
                var val = input.Split('.');

                var hexInt = val[0];
                var hexDec = val[1];

                // binario
                var binInt = HexToBin(hexInt).TrimStart('0');
                var binDec = HexToBin(hexDec).TrimEnd('0');
                ret += $"{binInt}.{binDec} Conversione binaria \r\n";

                // ottale
                var octInt = HexToOct(hexInt);
                // ottale:
                var lenOct = CeilN(binDec.Length, 3);
                var binOct = binDec.PadRight(lenOct, '0');
                ret += $"{octInt}.{BinToOct(binOct)} Conversione ottale \r\n";

                // decimale
                // decimale:
                ret += $"{HexToInt(hexInt)}.{ConvertDecimalPart(binDec)} decimale\r\n";
            }
            else
            {
                var dec = int.Parse(input, System.Globalization.NumberStyles.HexNumber);
                var bin = ToBin(dec, 32);
                var oct = Convert.ToString(dec, 8);

                ret += $"{bin} Conversione binaria \r\n";
                ret += $"{oct} Conversione ottale \r\n";
                ret += $"{dec} Conversione decimale \r\n";
            }

            return ret;
        }
    }
}