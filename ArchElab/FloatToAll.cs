using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchElab
{
    public class FloatToAll : IOperation
    {
        public FloatToAll()
        {
            menuTitle = "float => *";
            welcomeMessage = "Inserire il valore da convertire: (es: 3.14)";
        }

        public override string Operate(string input)
        {
            var val = input.Split('.');
            var intPart = Convert.ToInt32(val[0]);
            var decPart = Convert.ToInt32(val[1]);

            var binInt = ToBin(intPart);
            var binDec = ConvertDecimalPart(decPart);

            var ret = $"{binInt}.{binDec} binario\r\n";
            // ottale:
            var lenOct = CeilN(binDec.Length, 3);
            var binOct = binDec.PadRight(lenOct, '0');

            ret += $"{Convert.ToString(intPart, 8)}.{BinToOct(binOct)} ottale\r\n";
            // esadecimale:
            var lenHex= CeilN(binDec.Length, 4);
            var binHex = binDec.PadRight(lenHex, '0');
            ret += $"0x{intPart.ToString("X")}.{BinToHex(binHex)} esadecimale\r\n";
            return ret;
        }
    }
}
