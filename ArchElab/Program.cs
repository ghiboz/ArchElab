using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchElab
{
    class Program
    {
        static List<IOperation> op = new List<IOperation>();
        static void Main(string[] args)
        {
            // aggiungo le operazioni
            op.Add(new DecToBin() { key = 1 });
            op.Add(new HexToBin() { key = 2 });
            op.Add(new HexToDec() { key = 3 });
            op.Add(new Iee754() { key = 4 });

            Console.WriteLine("ArchElab: exit per uscire");
            foreach (var o in op)
            {
                Console.WriteLine(o.Menu());
            }

            // scrivo l'elemento attivo
            var elm = Console.ReadLine();
            while (elm != "exit")
            {
                foreach (var o in op)
                {
                    Console.WriteLine(o.Welcome(elm));
                }
                var oper = Console.ReadLine();
                if (oper == "exit")
                {
                    return;
                }
                Console.WriteLine(op.Where(x => x.enabled).FirstOrDefault().Operate(oper));
            }

            //Console.Read();
        }
    }
}
