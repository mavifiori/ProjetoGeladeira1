using System;
using GeladeiraEstrutura; 


namespace GeladeiraExibir
{
    public class Mostrar
    {

        static void Main(string[] args)
        {
            var geladeira = new Geladeira(4, 2, 3);

            bool continuar = true;

            while (continuar)
            {
                if (geladeira.VerificarCheia())
                {
                    Console.WriteLine("Geladeira cheia. Finalizando...");
                    break;
                }

                Console.WriteLine("Seja bem-vindo(a) à geladeira inteligente");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Adicionar item");
                Console.WriteLine("2 - Remover item");
                Console.WriteLine("3 - Remover todos os itens de um andar");
                Console.WriteLine("4 - Remover todos os itens da geladeira");
                Console.WriteLine("5 - Exibir conteúdo");
                Console.WriteLine("6 - Sair");

                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Selecione a categoria do alimento:");
                        Console.WriteLine("0 - hortifruti");
                        Console.WriteLine("1 - laticínios e enlatados");
                        Console.WriteLine("2 - charcutaria, carnes e ovos");
                        int andar = int.Parse(Console.ReadLine());

                        if (andar != 0 && andar != 1 && andar != 2)
                        {
                            Console.WriteLine("Andar inválido!!");
                            continue;
                        }

                        Console.WriteLine("Informe a posição do container 0 ou 1:");
                        int cont = int.Parse(Console.ReadLine());

                        if (cont != 0 && cont != 1)
                        {
                            Console.WriteLine("Posição do container inválida!!");
                            continue;
                        }

                        Console.WriteLine("Informe o alimento que você quer adicionar:");
                        string alimento = Console.ReadLine();

                        var item = new Item(alimento);

                        if (geladeira.AddItem(andar, cont, item))
                        {
                            Console.WriteLine("Alimento adicionado com sucesso.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Selecione a categoria do alimento:");
                        Console.WriteLine("0 - hortifruti");
                        Console.WriteLine("1 - laticínios e enlatados");
                        Console.WriteLine("2 - charcutaria, carnes e ovos");
                        andar = int.Parse(Console.ReadLine());

                        if (andar != 0 && andar != 1 && andar != 2)
                        {
                            Console.WriteLine("Andar inválido!!");
                            continue;
                        }

                        Console.WriteLine("Informe a posição do container 0 ou 1:");
                        cont = int.Parse(Console.ReadLine());

                        if (cont != 0 && cont != 1)
                        {
                            Console.WriteLine("Posição do container inválida!!");
                            continue;
                        }

                        Console.WriteLine("Informe o alimento que você quer remover:");
                        alimento = Console.ReadLine();

                        if (geladeira.RemoverItem(andar, cont, alimento))
                        {
                            Console.WriteLine("Alimento removido com sucesso.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Informe o número do andar para remover todos os itens:");
                        andar = int.Parse(Console.ReadLine());

                        geladeira.RemoverItensAndar(andar);
                        break;

                    case 4:
                        geladeira.RemoverItensAndares();
                        break;

                    case 5:
                        geladeira.ExibirConteudo();
                        break;

                    case 6:
                        continuar = false;
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!! Tente novamente...");
                        break;
                }
            }
        }
    }
}
