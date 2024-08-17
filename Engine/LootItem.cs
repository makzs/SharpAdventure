using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class LootItem
    {
        public Item Detalhes { get; set; }
        public int DropPorcentagem { get; set; }
        public bool IsDefaultItem { get; set; }
        public LootItem(Item detalhes, int droporcentagem, bool isdefaultitem)
        {
            Detalhes = detalhes;
            DropPorcentagem = droporcentagem;
            IsDefaultItem = isdefaultitem;
        }
    }
}
