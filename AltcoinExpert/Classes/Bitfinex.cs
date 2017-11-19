using AltcoinExpert.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AltcoinExpert.Classes
{
    class Bitfinex : Exchange
    {
        
        public Bitfinex()
        {
            this.Name = "Bitfinex";
            this.BaseUrl = "https://api.bitfinex.com/";
            this.BaixarMoedas();
            this.MinVolConsider = 0;
        }
        
        protected override void BaixarMoedas()
        {
            String url = this.BaseUrl + "v1/symbols";
            String resultado = Requests.getRequest(url);

            //Remove aspas
            resultado = Regex.Replace(resultado, "\"", "");

            //Remove primeira parte
            List<String> strMoeda = resultado.ToUpper().Split('[')[1].Split(']')[0].Split(',').ToList();

            //Verifica volume moeda
            
            foreach (String moeda in strMoeda)
            {
                Moeda m = new Moeda(moeda);
                addMoeda(m);

                Console.WriteLine(moeda);
            }
            
        }
        //Type = t para Trading, f para funding
        //Resultado
        // on trading pairs (ex. tBTCUSD)
       /* [
          SYMBOL,
          BID,
          BID_SIZE,
          ASK,
          ASK_SIZE,
          DAILY_CHANGE,
          DAILY_CHANGE_PERC,
          LAST_PRICE,
          VOLUME,
          HIGH,
          LOW
        ],
      // on funding currencies (ex. fUSD)
          [
            SYMBOL,
            FRR,
            BID,
            BID_SIZE,
            BID_PERIOD,
            ASK,
            ASK_SIZE,
            ASK_PERIOD,
            DAILY_CHANGE,
            DAILY_CHANGE_PERC,
            LAST_PRICE,
            VOLUME,
            HIGH,
            LOW
          ],*/
        public override void getTicker(string moeda, char type)
        {
            String url = this.BaseUrl + "v2/tickers?symbols=" + type + moeda;
            String resultado = Requests.getRequest(url);

            Console.WriteLine(resultado);
        }

        //Pega ticker do tipo Trading por default
        public override void getTicker(string moeda)
        {
            String url = this.BaseUrl + "v2/tickers?symbols=t" + moeda;
            String resultado = Requests.getRequest(url);

            Console.WriteLine(resultado);
        }

        public override double consultaVolume(string pairName, Periodos periodo)
        {
            String url = this.BaseUrl + "v1/stats/" + pairName;
            String resultado = Requests.getRequest(url);

            

            resultado = Regex.Replace(resultado, "\\[", "");
            resultado = Regex.Replace(resultado, "\"", "");
            resultado = Regex.Replace(resultado, "]", "");
            resultado = Regex.Replace(resultado, "{", "");
            
            List <String> teste = new List<String>(Regex.Split(resultado, "},"));

            foreach (String t in teste)
            {
                Console.WriteLine(Regex.Replace(t,"}",""));
            }
          //Terminar aqui, verificar a possibilidade de usar uma lib para JSon
        }

    }
}
