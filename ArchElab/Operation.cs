using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchElab
{
    public class IOperation
    {
        public int key { get; set; }
        public bool enabled { get; set; } = false;
        public string menuTitle { get; set; }
        public string welcomeMessage { get; set; }

        /// <summary>
        /// stampa il menu iniziale
        /// </summary>
        /// <returns></returns>
        public virtual string Menu()
        {
            return $"{key}: {menuTitle}";
        }

        public virtual string Welcome(string value)
        {
            try
            {
                var command = Convert.ToInt32(value);
                if (command == key)
                {
                    enabled = true;
                    return $"{this.GetType().Name}: {welcomeMessage}";
                }
            }
            catch (Exception ex)
            {
            }
            return "";
        }

        /// <summary>
        /// esegue l'operazione
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual string Operate(string input)
        {
            throw new Exception("Operata not implemented");
        }

        protected virtual string ToBin(int value, int bits)
        {
            return Convert.ToString(Math.Abs(value), 2).PadLeft(bits, '0');
        }

        protected virtual string ToModuleSign(int value, int bits)
        {
            return "1" + Convert.ToString(-value, 2).PadLeft(bits - 1, '0');
        }

        protected virtual string ToComplement2(int value, int bits)
        {
            value = -value;
            value -= 1;
            var ret = Convert.ToString(value, 2).PadLeft(bits, '0');
            var ret2 = "";
            for (int i = 0; i < ret.Length; i++)
            {
                ret2 = ret2 + (ret[i] == '0' ? "1" : "0");
            }
            //ret2 = ret2 + ret.Substring(ret.Length - 1, 1);
            return ret2;
        }

        protected virtual string ToEccesso(int value, int bits, int pow)
        {

            var powWalue = Convert.ToInt32(Math.Pow(2, pow));
            return ToBin(value + powWalue, bits);
        }

        protected virtual int ToDec(string boolean)
        {
            return Convert.ToInt32(boolean, 2);
        }

        protected virtual double BinaryToDecimal(string binary)
        {
            int len = binary.Length;
            // Fetch the radix point
            int point = binary.IndexOf('.');

            // Update point if not found
            if (point == -1)
                point = len;

            double intDecimal = 0,
                   fracDecimal = 0,
                   twos = 1;

            // Convert integral part of binary to decimal
            // equivalent
            for (int i = point - 1; i >= 0; i--)
            {
                intDecimal += (binary[i] - '0') * twos;
                twos *= 2;
            }

            // Convert fractional part of binary to
            // decimal equivalent
            twos = 2;
            for (int i = point + 1; i < len; i++)
            {
                fracDecimal += (binary[i] - '0') / twos;
                twos *= 2.0;
            }

            // Add both integral and fractional part
            return intDecimal + fracDecimal;
        }
    }
}
