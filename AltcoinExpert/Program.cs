using AltcoinExpert.Classes;
using AltcoinExpert.Util;
using System;

namespace AltcoinExpert
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitfinex b = new Bitfinex();
            b.MinVolConsider = 10000;
            //Console.WriteLine(b.GetMoedas()[0]);
            //b.getTicker(b.GetMoedas()[4]);
            b.consultaVolume("ZECBTC", Exchange.Periodos.Dia);


            Console.ReadLine();
        }
    }
}
