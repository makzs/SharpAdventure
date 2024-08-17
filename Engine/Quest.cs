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

        public Quest(int id, string nome, string descricao, int recompensaExperiencia, int recompensaOuro)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            RecompensaExperiencia = recompensaExperiencia;
            RecompensaOuro = recompensaOuro;
        }
    }
}
