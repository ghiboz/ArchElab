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
                    return $"{this.GetType().Name}: {welcomeMessage}\r\npremi \\ per tornare al menu";
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

        protected string ToBin(int value, int bits)
        {
            return Convert.ToString(Math.Abs(value), 2).PadLeft(bits, '0');
        }
        protected string ToBin(int value)
        {
            return Convert.ToString(Math.Abs(value), 2);
        }

        protected string ToModuleSign(int value, int bits)
        {
            return "1" + Convert.ToString(-value, 2).PadLeft(bits - 1, '0');
        }

        protected string ToComplement2(int value, int bits)
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

        protected string ToEccesso(int value, int bits, int pow)
        {
            var powWalue = Convert.ToInt32(Math.Pow(2, pow));
            return ToBin(value + powWalue, bits);
        }

        protected int ToDec(string boolean)
        {
            return Convert.ToInt32(boolean, 2);
        }

        protected double BinaryToDecimal(string binary)
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

        protected string FloatToBinary(float f)
        {
            StringBuilder sb = new StringBuilder();
            Byte[] ba = BitConverter.GetBytes(f);
            foreach (Byte b in ba)
                for (int i = 0; i < 8; i++)
                {
                    sb.Insert(0, ((b >> i) & 1) == 1 ? "1" : "0");
                }
            string s = sb.ToString();
            string r = s.Substring(0, 1) + " " + s.Substring(1, 8) + " " + s.Substring(9); //sign exponent mantissa
            return r;
        }

        /// <summary>
        /// convert decimal part to binary
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLoop"></param>
        /// <returns></returns>
        protected string ConvertDecimalPart(int value, int maxLoop = 20)
        {
            var val = Convert.ToSingle($"0.{value}", System.Globalization.CultureInfo.InvariantCulture);
            var resList = new List<int>();
            int cnt = 0;
            while (val != 0f && cnt < maxLoop)
            {
                var ris = val * 2;
                if (ris >= 1f)
                {
                    val = ris - 1f;
                    resList.Add(1);
                }
                else
                {
                    val = ris;
                    resList.Add(0);
                }
                cnt++;
            }
            return string.Join("", resList.ToArray());
        }

        /// <summary>
        /// convert decimal part from binary to int
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLoop"></param>
        /// <returns></returns>
        protected int ConvertDecimalPart(string value)
        {
            int exp = -1;
            double res = 0;
            foreach (char item in value)
            {
                if (item == '1')
                {
                    res += Math.Pow(2, exp);
                }
                exp -= 1;
            }
            var resStr = res.ToString().Replace(",", ".");

            return Convert.ToInt32(resStr.Split('.')[1]);
        }

        protected int CeilN(int x, int n)
        {
            return ((x + n - 1) / n) * n;
        }

        protected string BinToOct(string binary)
        {
            int dec = ToDec(binary);
            return Convert.ToString(dec, 8);
        }

        protected string BinToHex(string binary)
        {
            int dec = ToDec(binary);
            return dec.ToString("X");
        }

        protected int HexToInt(string hex)
        {
            return int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
        }

        protected string HexToBin(string hex)
        {
            return PadLeft(ToBin(HexToInt(hex)), 4);
        }

        protected string HexToOct(string hex)
        {
            int value = HexToInt(hex);
            return Convert.ToString(value, 8);

        }

        protected int OctToDec(string oct)
        {
            return Convert.ToInt32(oct, 8);
        }

        protected string OctToBin(string oct)
        {
            return PadLeft(ToBin(OctToDec(oct)), 3);
        }

        protected string PadLeft(string value, int chunk)
        {
            var len = CeilN(value.Length, chunk);
            return value.PadLeft(len, '0');
        }
    }
}
