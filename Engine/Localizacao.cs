using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Localizacao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Item ItemRequirido { get; set; }
        public Quest QuestLocal { get; set; }
        public Monstro MonstroLocal { get; set; }
        public Localizacao LocalizacaoNorte { get; set; }
        public Localizacao LocalizacaoSul { get; set; }
        public Localizacao LocalizacaoLeste { get; set; }
        public Localizacao LocalizacaoOeste { get; set; }

        public Localizacao(int id, string nome, string descricao, Item itemrequirido = null, 
            Quest questlocal = null, Monstro monstrolocal = null)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            ItemRequirido = itemrequirido;
            QuestLocal = questlocal;
            MonstroLocal = monstrolocal;
        }
    }
}
