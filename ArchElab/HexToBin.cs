using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchElab
{
    public class HexToBin : IOperation
    {
        public HexToBin()
        {
            menuTitle = "Esadecimale => binario";
            welcomeMessage = "Inserire il valore da convertire: (esadecimale,numero di bit) oppure per l'eccesso (esadecimale, numero di bit,potenza 2^n di eccesso)";
        }

        public override string Operate(string input)
        {
            var tmp = input.Split(',');
            if (tmp.Length != 2 && tmp.Length != 3) return $"Errore nella stringa {input}";

            int value = int.Parse(tmp[0], System.Globalization.NumberStyles.HexNumber);
            int bits = Convert.ToInt32(tmp[1]);
            int pow = 0;
            if (tmp.Length == 3)
            {
                pow = Convert.ToInt32(tmp[2]);
            }

            var ret = $"{ToBin(value, bits)} binario + \r\n";
            if (value < 0)
            {
                ret += $"{ToModuleSign(value, bits)} modulo e segno\r\n";
                ret += $"{ToComplement2(value, bits)} complemento a 2\r\n";
            }
            if (tmp.Length == 3)
            {
                ret += $"{ToEccesso(value, bits, pow)} in eccesso di 2^{pow}\r\n";
            }

            return ret;
        }
    }
}
