using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class QuestItem
    {
        public Item Detalhes { get; set; }
        public int Quantidade { get; set; }
        public QuestItem(Item detalhes, int quantidade) 
        {
            Detalhes = detalhes;
            Quantidade = quantidade;
        }
    }
}
