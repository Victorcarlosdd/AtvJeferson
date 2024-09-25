using Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Paciente : Pessoa
    {
        public bool IsPrioritario { get; private set; }

        public void definirPrioridade()
        {
            Console.WriteLine("Você é um paciente prioritário? - SIM ou NÃO");
            string resposta = Console.ReadLine().ToLower();

            IsPrioritario = resposta == "sim";
        }
    }
}