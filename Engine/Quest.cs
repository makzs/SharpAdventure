using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Quest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int RecompensaExperiencia { get; set; }
        public int RecompensaOuro { get; set; }
        public Item RecompensaItem { get; set; }
        public List<QuestItem> QuestItem {  get; set; }

        public Quest(int id, string nome, string descricao, int recompensaExperiencia, int recompensaOuro, Item recompensaItem)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            RecompensaExperiencia = recompensaExperiencia;
            RecompensaOuro = recompensaOuro;
            RecompensaItem = recompensaItem;
            QuestItem = new List<QuestItem>();
        }
    }
}
