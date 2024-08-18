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

            Localizacao locazalizao1 = new Localizacao(1, "Casa", "Essa é a sua casa!", null, null, null);

            _jogador = new Jogador(10, 10, 20, 0, 1);

            lblVida.Text = _jogador.VidaAtual.ToString();
            lblOuro.Text = _jogador.Ouro.ToString();
            lblExperiencia.Text = _jogador.PontosDeExperiencia.ToString();
            lblNivel.Text = _jogador.Nivel.ToString();


        }

        private void btnNorte_Click(object sender, EventArgs e)
        {

        }

        private void btnLeste_Click(object sender, EventArgs e)
        {

        }

        private void btnSul_Click(object sender, EventArgs e)
        {

        }

        private void btnOeste_Click(object sender, EventArgs e)
        {

        }

        private void btnUsarArma_Click(object sender, EventArgs e)
        {

        }

        private void btnUsarPocao_Click(object sender, EventArgs e)
        {

        }
    }
}
