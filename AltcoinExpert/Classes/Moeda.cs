using System;
using System.Collections.Generic;
using System.Text;

namespace AltcoinExpert.Classes
{
    public class Moeda
    {
        private String nome = "";
        private List<Tick> orderHistory = new List<Tick>();

        public Moeda(String n)
        {
            this.Nome = n;
        }

        public string Nome { get => nome; set => nome = value; }
        public void printMoeda() { Console.WriteLine(nome); }

        public void OrderHistory() { }
    }
}
