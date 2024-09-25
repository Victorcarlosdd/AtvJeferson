using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{

    public class Pessoa
    {
        public string nome;
        public string cpf;
        public string telefone;
        public string endereço;
        public string dataNasc;

        public void CadastrarPessoa()
        {
            Console.WriteLine("Cadastro do paciente\n");
            Console.WriteLine("Digite seu nome completo:");
            nome = Console.ReadLine();
            cpf = LerCpf();
            telefone = LerTelefone();
            Console.WriteLine("Digite seu endereço:");
            endereço = Console.ReadLine();
            dataNasc = LerDataNasc();
        }

        private string LerCpf()
        {
            string cpf;
            while (true)
            {
                Console.WriteLine("Digite seu CPF (somente números):");
                cpf = Console.ReadLine();
                if (cpf.Length == 11 && long.TryParse(cpf, out _))
                {
                    return VerificarCpf(cpf);
                }
                else
                {
                    Console.WriteLine("CPF inválido. O CPF deve conter exatamente 11 dígitos numéricos.");
                }
            }
        }

        private string VerificarCpf(string cpf)
        {
            return $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
        }

        private string LerTelefone()
        {
            string telefone;
            while (true)
            {
                Console.WriteLine("Digite seu telefone (somente números, 11 dígitos):");
                telefone = Console.ReadLine();
                if (telefone.Length == 11 && long.TryParse(telefone, out _))
                {
                    return VerificarTelefone(telefone);
                }
                else
                {
                    Console.WriteLine("Telefone inválido. O telefone deve conter exatamente 11 dígitos numéricos.");
                }
            }
        }

        private string VerificarTelefone(string telefone)
        {
            return $"({telefone.Substring(0, 2)}) {telefone.Substring(2, 5)}-{telefone.Substring(7, 4)}";
        }

        private string LerDataNasc()
        {
            string dataNasc;
            while (true)
            {
                Console.WriteLine("Digite sua data de nascimento (formato DDMMYYYY):");
                dataNasc = Console.ReadLine();
                if (dataNasc.Length == 8 && long.TryParse(dataNasc, out _))
                {
                    return VerificarDataNasc(dataNasc);
                }
                else
                {
                    Console.WriteLine("Data de nascimento inválida. A data deve conter exatamente 8 dígitos numéricos.");
                }
            }
        }

        private string VerificarDataNasc(string dataNasc)
        {
            return $"{dataNasc.Substring(0, 2)}/{dataNasc.Substring(2, 2)}/{dataNasc.Substring(4, 4)}";
        }

        public void MostrarDados()
        {
            Console.WriteLine("\nDados Cadastrados:\n");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"CPF: {cpf}");
            Console.WriteLine($"Telefone: {telefone}");
            Console.WriteLine($"Endereço: {endereço}");
            Console.WriteLine($"Data de Nascimento: {dataNasc}");
            Console.ReadKey();
        }
    }
}