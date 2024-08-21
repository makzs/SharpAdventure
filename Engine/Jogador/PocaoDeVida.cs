using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class PocaoDeVida : Item
    {
        public int QuantidadeCura { get; set; }

        public PocaoDeVida(int id, string nome, string nomePlural, int quantidadeCura) 
            : base(id, nome, nomePlural)
        {
            QuantidadeCura = quantidadeCura;
        }
    }
}
