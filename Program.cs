using System;
using System.Collections.Generic;

namespace bancaria
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcao();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
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
                        SacarConta();
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
                
                opcaoUsuario = obterOpcao();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
            
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem : ");
            int contaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta Destino : ");
            int contaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido : R$ ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[contaOrigem].Transferir(valorTransferencia, listaContas[contaDestino]);
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta : ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor que você deseja depositar : R$ ");
            double indiceDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(indiceDeposito);
        }

        private static void SacarConta()
        {
            Console.WriteLine("Sacar valor da conta");
            Console.WriteLine();
            Console.Write("Digite o número da conta : ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Digite o valor do saque : R$ ");
            double saque = double.Parse(Console.ReadLine());

            Console.Clear();

            listaContas[indiceConta].Sacar(saque);

        }

        private static void ListarContas()
        {
            if(listaContas.Count == 0){

                Console.WriteLine("Nenhuma conta registrada");
                return;
            } 

            for(int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.Write(conta);
                Console.WriteLine();
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir Nova conta");
            Console.WriteLine();

            Console.Write("Digite 1 para Conta Física ou 2 para Conta Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            if(entradaTipoConta != 1 && entradaTipoConta != 2){

                throw new ArgumentOutOfRangeException("Número inválido para opção.");
            } 

            Console.Write("Digite o nome do Cliente : ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o seu Saldo Inicial : R$ ");
            double entradaSaldo = Convert.ToDouble(Console.ReadLine());

            if(entradaSaldo < 0){

                throw new ArgumentOutOfRangeException("Seu saldo inicial não pode ser negativo ");

            }

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, saldo: entradaSaldo, nome: entradaNome);

            listaContas.Add(novaConta);

            Console.Clear();
            Console.WriteLine("Conta criada com sucesso");
            Console.WriteLine();
            Console.WriteLine(novaConta.ToString());
                                        
        }

        private static string obterOpcao()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao Banco Digital guobank");
            Console.WriteLine();
            Console.WriteLine("Crédito de 2x o seu saldo.");
            Console.WriteLine();
            
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            Console.ResetColor();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}
