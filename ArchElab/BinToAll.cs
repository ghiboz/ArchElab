using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchElab
{
    public class BinToAll : IOperation
    {
        public BinToAll()
        {
            menuTitle = "Binario => *";
            welcomeMessage = "Inserire il valore da convertire: (binario)";
        }

        public override string Operate(string input)
        {
            var ret = "";

            if(input.Contains("."))
            {
                var val = input.Split('.');

                var binInt = val[0];
                var binDec = val[1];

                var intPart = ToDec(binInt);

                // ottale:
                var lenOct = CeilN(binDec.Length, 3);
                var binOct = binDec.PadRight(lenOct, '0');
                ret += $"{Convert.ToString(intPart, 8)}.{BinToOct(binOct)} ottale\r\n";

                // decimale:
                ret += $"{intPart}.{ConvertDecimalPart(binDec)} decimale\r\n";

                // esadecimale:
                var lenHex = CeilN(binDec.Length, 4);
                var binHex = binDec.PadRight(lenHex, '0');
                ret += $"0x{intPart.ToString("X")}.{BinToHex(binHex)} esadecimale\r\n";
            }
            else
            {
                var dec = ToDec(input);
                var hex = dec.ToString("X");
                var oct = Convert.ToString(dec, 8);

                ret += $"{oct} Conversione ottale \r\n";
                ret += $"{dec} Conversione decimale \r\n";
                ret += $"0x{hex} Conversione esadecimale \r\n";
            }

            return ret;
        }
    }
}