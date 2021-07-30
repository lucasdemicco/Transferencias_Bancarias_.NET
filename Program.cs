using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            
           string opcaoUsuario = obterOpcaoUsuario();

           while (opcaoUsuario.ToUpper() != "X")
           {
               switch(opcaoUsuario)
               {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
               }

               opcaoUsuario = obterOpcaoUsuario();
           }

            Console.WriteLine("Obrigado por utilizar nossos serviços!");

        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para Conta Física ou 2 para Conta Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo, 
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listaContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Lsitar contas");

            if(listaContas.Count == 0 )
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for(int i=0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int entradaNumeroContaUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorDoSaque = double.Parse(Console.ReadLine());

            listaContas[entradaNumeroContaUsuario].Sacar(valorDoSaque);
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int entradaNumeroDaConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[entradaNumeroDaConta].Depositar(valorDeposito);
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o número da conta de origem: ");
            int entradaNumeroDaContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de destino: ");
            int entradaNumeroDaContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferido = double.Parse(Console.ReadLine());

            listaContas[entradaNumeroDaContaOrigem].Transferir(valorTransferido, listaContas[entradaNumeroDaContaDestino]);
        }



        public static string obterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            string obterOpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return obterOpcaoUsuario;
        }
    }
}
