using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchElab
{
    public class OctToAll : IOperation
    {
        public OctToAll()
        {
            menuTitle = "Ottale => *";
            welcomeMessage = @"
Inserire il valore da convertire: (ottale)";
        }

        public override string Operate(string input)
        {
            var ret = "";
            if (input.Contains("."))
            {
                var val = input.Split('.');

                var octInt = val[0];
                var octDec = val[1];

                // binario
                var binInt = OctToBin(octInt);
                var binDec = OctToBin(octDec).TrimEnd('0');
                ret += $"{binInt}.{binDec} Conversione binaria \r\n";

                // decimale
                var intPart = OctToDec(octInt);
                ret += $"{intPart}.{ConvertDecimalPart(binDec)} decimale\r\n";

                // esadecimale:
                var lenHex = CeilN(binDec.Length, 4);
                var binHex = binDec.PadRight(lenHex, '0');
                ret += $"0x{intPart.ToString("X")}.{BinToHex(binHex)} esadecimale\r\n";
            }
            else
            {
                var dec = OctToDec(input);
                var bin = ToBin(dec, 32);
                var hex = BinToHex(bin);
                ret += $"{bin} Conversione binaria \r\n";
                ret += $"{dec} Conversione decimale \r\n";
                ret += $"0x{hex} Conversione esadecimale \r\n";
            }

            return ret;
        }
    }
}