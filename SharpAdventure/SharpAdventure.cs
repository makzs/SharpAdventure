using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace SharpAdventure
{
    public partial class SharpAdventure : Form
    {
        private Jogador _jogador;
        public SharpAdventure()
        {
            InitializeComponent();

            Localizacao locazalizao1 = new Localizacao(1, "Casa", "Essa é a sua casa!");

            _jogador = new Jogador(10, 10, 20, 0, 1);

            lblVida.Text = _jogador.VidaAtual.ToString();
            lblOuro.Text = _jogador.Ouro.ToString();
            lblExperiencia.Text = _jogador.PontosDeExperiencia.ToString();
            lblNivel.Text = _jogador.Nivel.ToString();

            
        }
       
    }
}
