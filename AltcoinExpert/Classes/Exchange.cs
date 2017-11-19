using System;
using System.Collections.Generic;
using System.Text;

namespace AltcoinExpert.Classes
{
    public class Exchange
    {
        public enum Periodos { Dia = 1, Semana = 7, Mes = 30 };
        protected String name = "";
        protected String baseUrl = "";
        protected List<Moeda> moedas = new List<Moeda>();
        private Double minVolConsider = 0; //Minimo volume para considerar uma moeda e processá-la


        public string BaseUrl { get => baseUrl; set => baseUrl = value; }
        public string Name { get => name; set => name = value; }
        public double MinVolConsider { get => minVolConsider; set => minVolConsider = value; }

        public Moeda getMoeda(int idx)
        {
            return moedas[idx];
        }

        public void addMoeda(Moeda value)
        {
            moedas.Add(value);
        }

        //Ações
        protected virtual void BaixarMoedas() {  }

        public virtual void getTicker(String moeda, char type) { }
        public virtual void getTicker(String moeda) { }

        public virtual double consultaVolume(String pairName, Periodos periodo) { return 0;  }

    }
}
