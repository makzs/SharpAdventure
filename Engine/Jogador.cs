using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Jogador : Criatura
    {
        public int Ouro { get; set; }
        public int PontosDeExperiencia { get; set; }
        public int Nivel { get; set; }

        public Jogador(int vidaAtual, int vidaMaxima, int ouro, int pontosDeExperiencia, int nivel)
            :base(vidaAtual, vidaMaxima)
        {
            Ouro = ouro;
            PontosDeExperiencia = pontosDeExperiencia;
            Nivel = nivel;
        }
    }
}
