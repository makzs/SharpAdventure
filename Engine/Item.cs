using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Item
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomePlural { get; set; }

        public Item(int id, string nome, string nomePlural)
        {
            Id = id;
            Nome = nome;
            NomePlural = nomePlural;
        }
    }
}
