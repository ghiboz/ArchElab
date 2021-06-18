using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchElab
{
    public class BinToDec : IOperation
    {
        public BinToDec()
        {
            menuTitle = "Binario => decimale";
            welcomeMessage = "Inserire il valore da convertire: (binario,eccesso) eccesso: numero decimale per l'eccesso";
        }

        public override string Operate(string input)
        {
            var ret = "";
            var tmp = input.Split(',');
            if (tmp.Length != 1 && tmp.Length != 2) return $"Errore nella stringa {input}";

            string bin = tmp[0];
            int ecc = 0;
            var nrm = ToDec(tmp[0]);
            if (tmp.Length == 2)
            {
                ecc = Convert.ToInt32(tmp[1]);
                // conversione normale
                ret += $"{nrm} Conversione normale \r\n";
                ret += $"{nrm-ecc} Conversione in eccesso {ecc}\r\n";
            }
            else
            {
                if (bin.StartsWith("0"))
                {
                    // conversione normale
                    ret += $"{nrm} Conversione normale \r\n";
                }
                else
                {
                    ret += $"{nrm} Conversione normale \r\n";
                    var sc1 = bin.Replace("0", "2").Replace("1", "0").Replace("2", "1");
                    var c1 = ToDec(sc1);
                    ret += $"-{c1} Conversione complemento 1 \r\n";
                    ret += $"-{c1+1} Conversione complemento 2 \r\n";
                }

            }

            /*
            var ret = $"{ToDec(ToBin(value, bits))} + \r\n";
            if (value < 0)
            {
                ret += $"{ToDec(ToModuleSign(value, bits))} modulo e segno\r\n";
                ret += $"{ToDec(ToComplement2(value, bits))} complemento a 2\r\n";
            }
            if (tmp.Length == 3)
            {
                ret += $"{ToDec(ToEccesso(value, bits, pow))} in eccesso di 2^{pow}\r\n";
            }
            */
            return ret;
        }
    }
}