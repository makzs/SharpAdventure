using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Criatura
    {
        public int VidaAtual { get; set; }
        public int VidaMaxima { get; set; }

        public Criatura(int vidaAtual, int vidaMaxima)
        {
            VidaAtual = vidaAtual;
            VidaMaxima = vidaMaxima;
        }
    }
}
