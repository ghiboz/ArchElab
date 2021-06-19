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
            welcomeMessage = @"
.Inserire il valore da convertire: (es: 3.14)
.IEEE 754: valore,segno,esponente,mantissa (es:3.14,1,8,12)";
        }

        public override string Operate(string input)
        {
            var ret = "";
            if (input.Contains(","))
            {
                var inputSp = input.Split(',');
                if (inputSp.Length != 4) return $"Errore nella stringa {input}";

                bool neg = false;
                if (inputSp[0].StartsWith("-"))
                {
                    neg = true;
                    inputSp[0] = inputSp[0].TrimStart('-');
                }

                // primo: converto in binario
                var val = inputSp[0].Split('.');
                var intPart = Convert.ToInt32(val[0]);
                var decPart = Convert.ToInt32(val[1]);

                var binInt = ToBin(intPart);
                var binDec = ConvertDecimalPart(decPart);

                var intLen = binInt.Length;
                // the exponent should be len -1
                var expPow = intLen -1;
                var sign = Convert.ToInt32(inputSp[1]);
                var excess = Convert.ToInt32(inputSp[2]);
                var mant = Convert.ToInt32(inputSp[3]);
                int exessExp = Convert.ToInt32(Math.Pow(2, excess) / 2 - 1);
                var exp = ToBin(expPow + exessExp, excess);
                var mantix = (binInt.Substring(1, expPow) + binDec).PadRight(mant, '0');

                var binRet = $"{(neg ? "1" : "0")}{exp}{mantix}";
                ret += $"{binRet} binario\r\n";
                ret += $"0x{BinToHex(binRet)} esadecimale\r\n";
            }
            else
            {
                var val = input.Split('.');
                var intPart = Convert.ToInt32(val[0]);
                var decPart = Convert.ToInt32(val[1]);

                var binInt = ToBin(intPart);
                var binDec = ConvertDecimalPart(decPart);

                ret += $"{binInt}.{binDec} binario\r\n";
                // ottale:
                var lenOct = CeilN(binDec.Length, 3);
                var binOct = binDec.PadRight(lenOct, '0');

                ret += $"{Convert.ToString(intPart, 8)}.{BinToOct(binOct)} ottale\r\n";
                // esadecimale:
                var lenHex = CeilN(binDec.Length, 4);
                var binHex = binDec.PadRight(lenHex, '0');
                ret += $"0x{intPart.ToString("X")}.{BinToHex(binHex)} esadecimale\r\n";
            }
            return ret;

        }
    }
}
