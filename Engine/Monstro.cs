using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Monstro : Criatura
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int DanoMaximo { get; set; }
        public int RecompensaExperiencia { get; set; }
        public int RecompensaOuro { get; set; }

        public Monstro(int vidaAtual, int vidaMaxima, int id, string nome, int danoMaximo, int recompensaExperiencia, int recompensaOuro)
            : base(vidaAtual, vidaMaxima)
        {
            Id = id;
            Nome = nome;
            DanoMaximo = danoMaximo;
            RecompensaExperiencia = recompensaExperiencia;
            RecompensaOuro = recompensaOuro;
        }
    }
}
