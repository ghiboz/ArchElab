using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchElab
{
    public class Iee754 : IOperation
    {
        public Iee754()
        {
            menuTitle = "binario => IEE 754";
            welcomeMessage = @"
.Inserire il valore da convertire: (binario, n bit segno, n bit esponente, n bit mantissa)
.Inserire il valore da convertire: (0xesadecimale, n bit segno, n bit esponente, n bit mantissa)
";
        }

        public override string Operate(string input)
        {
            var tmp = input.Split(',');
            if (tmp.Length != 4) return $"Errore nella stringa {input}";

            string bin = tmp[0];

            if(bin.StartsWith("0x"))
            {
                bin = bin.Replace("0x", "");
                bin = HexToBin(bin);
            }

            int nSign = Convert.ToInt32(tmp[1]);
            int nExp = Convert.ToInt32(tmp[2]);
            int nMant = Convert.ToInt32(tmp[3]);

            string binSign = bin.Substring(0, nSign);
            string binExp = bin.Substring(nSign, nExp);
            string binMant = bin.Substring(nSign + nExp, nMant);

            int eccessoEsponente = Convert.ToInt32(Math.Pow(2, nExp) / 2 - 1);
            int exp = ToDec(binExp) - eccessoEsponente;

            var mant = BinaryToDecimal($"1.{binMant}");
            if (nSign > 0 && binSign == "1") mant = -mant;

            return $"{mant * Math.Pow(2, exp)}";
        }
    }
}
