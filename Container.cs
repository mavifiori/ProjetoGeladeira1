using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace GeladeiraEstrutura    
{
    public class Container
    {
        public int Id { get; }

        private int limite;
        public List<Item> alimentos;


        public Container(int id, int limite)
        {
            this.Id = id;
            this.limite = limite;
            alimentos = new List<Item>();

        }

        public bool AddItem(Item item)
        {
            if (alimentos.Count < limite)
            {
                alimentos.Add(item);
                return true;
            }

            else
            {
                Console.WriteLine($"A posição do container {Id} está cheia");

                return false;
            }
        }
        public bool RemoverItem(string nome)
        {
            Item RemoverI = null;

            foreach (var item in alimentos)
            {
                if (item.Nome == nome)
                {
                    RemoverI = item;
                    break;
                }
            }
            if (RemoverI != null)
                {
                alimentos.Remove(RemoverI);
                return true;
                }
             else
                {
                    Console.WriteLine($"Alimento{nome} não foi localizado no container");
                    return false;
            } 
            
            }
           
        public void RemoverTudo()
        {
            alimentos.Clear();
        }
        public bool VerificarVazio()
        {
            return alimentos.Count >= limite;
        }
        public List<Item> CopiarLista()
        {
            return alimentos.ToList();
        }

    }
}