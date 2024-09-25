using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Program
    {
        static Paciente[] filaPacientes = new Paciente[10];
        static int totalPacientes = 0;
        static Paciente pacienteCadastrado;

        static void Main(string[] args)
        {
            string opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1. Cadastrar paciente");
                Console.WriteLine("2. Inserir paciente na fila");
                Console.WriteLine("3. Listar pacientes na fila");
                Console.WriteLine("4. Atender paciente");
                Console.WriteLine("q. Sair");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarPaciente();
                        break;
                    case "2":
                        InserirPacienteNaFila();
                        break;
                    case "3":
                        ListarPacientesNaFila();
                        break;
                    case "4":
                        AtenderPaciente();
                        break;
                }

            } while (opcao != "q");
        }

        static void CadastrarPaciente()
        {
            Paciente paciente = new Paciente();
            paciente.CadastrarPessoa();
            paciente.definirPrioridade();
            pacienteCadastrado = paciente;
            Console.WriteLine("Paciente cadastrado com sucesso!\nPressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        static void InserirPacienteNaFila()
        {
            if (pacienteCadastrado != null)
            {
                if (totalPacientes < filaPacientes.Length)
                {
                    if (pacienteCadastrado.IsPrioritario)
                    {
                        for (int i = totalPacientes; i > 0; i--)
                        {
                            filaPacientes[i] = filaPacientes[i - 1]; 
                        }
                        filaPacientes[0] = pacienteCadastrado;
                        Console.WriteLine("Paciente prioritário inserido no início da fila!");
                    }
                    else
                    {
                        filaPacientes[totalPacientes] = pacienteCadastrado;
                        Console.WriteLine("Paciente inserido no final da fila!");
                    }

                    totalPacientes++;
                    pacienteCadastrado = null;
                }
                else
                {
                    Console.WriteLine("A fila está cheia. Não é possível inserir mais pacientes.");
                }
            }
            else
            {
                Console.WriteLine("Nenhum paciente cadastrado disponível para inserir na fila.");
            }
            Console.ReadKey();
        }

        static void ListarPacientesNaFila()
        {
            Console.WriteLine("Pacientes na fila:");
            for (int i = 0; i < totalPacientes; i++)
            {
                Console.WriteLine($"{i + 1}. {filaPacientes[i].nome} (Prioritário: {filaPacientes[i].IsPrioritario})");
            }
            Console.ReadKey();
        }

        static void AtenderPaciente()
        {
            if (totalPacientes > 0)
            {
                Console.WriteLine($"Atendendo o paciente: {filaPacientes[0].nome}");
                for (int i = 1; i < totalPacientes; i++)
                {
                    filaPacientes[i - 1] = filaPacientes[i];
                }
                filaPacientes[totalPacientes - 1] = null;
                totalPacientes--;

                Console.WriteLine("Paciente atendido.\nPressione qualquer tecla para continuar.");
            }
            else
            {
                Console.WriteLine("Nenhum paciente na fila.");
            }
            Console.ReadKey();
        }
    }
}