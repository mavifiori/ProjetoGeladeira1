using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace GeladeiraEstrutura
{
    public class Andar
    {
        public int num { get; }
        public Dictionary<int, Container> Conts;

        public Andar(int num, int nCantainer, int limCantainer)
        {
            this.num = num;
            Conts = new Dictionary<int, Container>();

            for (int i = 0; i < nCantainer; i++)
            {
                Conts[i] = new Container(i, limCantainer);

            }
        }
        public bool AddItem(int ContId, Item item)
        {
            if (Conts.ContainsKey(ContId))
            {
                return Conts[ContId].AddItem(item);
            }
            else
            {

                Console.WriteLine($"A posição do container{ContId} não foi encontrada no andar {num}");
                return false;
            }
        }
        public bool RemoverItem(int ContId, string Nome)
        {
            if (Conts.ContainsKey(ContId))
            {
                return Conts[ContId].RemoverItem(Nome);
            }
            else
            {

                Console.WriteLine($"A posição do container{ContId} não foi encontrada no andar {num}");
                return false;
            }

        }
        public void RemoverTodos()
        {
            foreach (var Container in Conts.Values)
            {

                Container.RemoverTudo();
            }

        }
        public bool VerificarCheia()
        {
            foreach (var Container in Conts.Values)
            {
                if(!Container.VerificarVazio())
                {
                    return false;
                }
            }
            return true;
        }
        public Dictionary<int,Container> CopiarContainer()
        {
            return new Dictionary<int, Container>(Conts);
        }
    }
}
