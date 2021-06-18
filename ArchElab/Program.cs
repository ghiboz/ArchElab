﻿using System;
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
            op.Add(new BinToDec() { key = 2 });
            op.Add(new HexToBin() { key = 3 });
            op.Add(new HexToDec() { key = 4 });
            op.Add(new Iee754() { key = 5 });

        MENU:
            Console.Clear();
            Console.WriteLine("ArchElab");
            foreach (var o in op)
            {
                Console.WriteLine(o.Menu());
            }
            Console.WriteLine("exit per chiudere");

            // scrivo l'elemento attivo
            var elm = Console.ReadLine();
            while (elm != "exit" && elm != "\\")
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
                if (oper == "\\")
                {
                    goto MENU;
                }
                Console.WriteLine(op.Where(x => x.enabled).FirstOrDefault().Operate(oper));
            }

            //Console.Read();
        }
    }
}