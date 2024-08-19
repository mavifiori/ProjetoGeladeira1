using System;
using System.Collections.Generic;


namespace GeladeiraEstrutura
{
    public class Geladeira
    {
        private int limContainer;
        private Dictionary<int, Andar> andares;
        private List<Container> Conts;

        public Geladeira(int limCantainer, int numAndares, int numContsxand)
        {
            this.limContainer = limCantainer;
            andares = new Dictionary<int, Andar>();
            Conts = new List<Container>();

            for (int i = 0; i < numAndares; i++)
            {
                andares[i] = new Andar(i, limCantainer, numContsxand);
            }
        }

        public bool AddItem(int andar, int container, Item item)
        {
            if (andares.ContainsKey(andar))
            {
                return andares[andar].AddItem(container, item);
            }
            else
            {
                Console.WriteLine($"Andar {andar} não encontrado.");
                return false;
            }
        }

        public bool RemoverItem(int andar, int container, string nome)
        {
            if (andares.ContainsKey(andar))
            {
                return andares[andar].RemoverItem(container, nome);
            }
            else
            {
                Console.WriteLine($"Andar {andar} não encontrado.");
                return false;
            }
        }

        public void RemoverTodos(int andar)
        {
            if (andares.ContainsKey(andar))
            {
                andares[andar].RemoverTodos();
            }
            else
            {
                Console.WriteLine($"Não foi encontrado o andar {andar}");
            }
        }

        public void RemoverItensAndar(int andar)
        {
            if (andares.ContainsKey(andar))
            {
                andares[andar].RemoverTodos();
                Console.WriteLine($"Alimentos do andar {andar} foram removidos");
            }
            else
            {
                Console.WriteLine($"Não foi encontrado o andar {andar}");
            }
        }

        public void RemoverItensAndares()
        {
            foreach (var andar in andares.Values)
            {
                andar.RemoverTodos();
            }
            Console.WriteLine("Todos os alimentos foram removidos");
        }

        public void ExibirConteudo()
        {
            foreach (var andar in andares.Values)
            {
                Console.WriteLine($"Andar {andar.num}:");

                foreach (var container in andar.CopiarContainer())
                {
                    Console.WriteLine($"  Container {container.Key}:");
                    foreach (var item in container.Value.CopiarLista())
                    {
                        Console.WriteLine($" Item: {item.Nome}");
                    }
                }
            }
        }

        public bool VerificarCheia()
        {
            foreach (var andar in andares.Values)
            {
                if (!andar.VerificarCheia())
                {
                    return false;
                }
            }
            return true;
        }

       
}
}

