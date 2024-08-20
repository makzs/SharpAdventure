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
        private Monstro _monstroAtual;
        public SharpAdventure()
        {
            InitializeComponent();

            // configurações iniciais, sempre que se iniciar o jogo ele vai carregar essas informações
            _jogador = new Jogador(10, 10, 20, 0, 1);
            _jogador.Inventario.Add(new InventarioItens(Mundo.ItemById(Mundo.ITEM_ID_ESPADA_DE_MADEIRA), 1));
            MoveTo(Mundo.LocalizacaosById(Mundo.LOCALIZACAO_ID_CASA));


            lblVida.Text = _jogador.VidaAtual.ToString();
            lblOuro.Text = _jogador.Ouro.ToString();
            lblExperiencia.Text = _jogador.PontosDeExperiencia.ToString();
            lblNivel.Text = _jogador.Nivel.ToString();


        }

        // botões de interação
        private void btnNorte_Click(object sender, EventArgs e)
        {
            MoveTo(_jogador.LocalizacaoAtual.LocalizacaoNorte);
        }

        private void btnLeste_Click(object sender, EventArgs e)
        {
            MoveTo(_jogador.LocalizacaoAtual.LocalizacaoLeste);
        }

        private void btnSul_Click(object sender, EventArgs e)
        {
            MoveTo(_jogador.LocalizacaoAtual.LocalizacaoSul);
        }

        private void btnOeste_Click(object sender, EventArgs e)
        {
            MoveTo(_jogador.LocalizacaoAtual.LocalizacaoOeste);
        }

        private void MoveTo(Localizacao novaLocalizacao)
        {
            if (!_jogador.possuiItemRequerido(novaLocalizacao))
            {
                rtbMensagens.Text += "Voce deve ter " + novaLocalizacao.ItemRequirido.Nome + " para entrar aqui" + Environment.NewLine;
                return;
            }

            // move o jogador para a nova localização
            _jogador.LocalizacaoAtual = novaLocalizacao;

            // deixa os botões disponiveis no local visiveis
            btnNorte.Visible = (novaLocalizacao.LocalizacaoNorte != null);
            btnLeste.Visible = (novaLocalizacao.LocalizacaoLeste != null);
            btnOeste.Visible = (novaLocalizacao.LocalizacaoOeste != null);
            btnSul.Visible = (novaLocalizacao.LocalizacaoSul != null);

            // altera o nome e a descrição do local atual na interface
            rtbLocalizacao.Text = novaLocalizacao.Nome + Environment.NewLine;
            rtbLocalizacao.Text += novaLocalizacao.Descricao + Environment.NewLine;

            // recupera a vida do jogador apos chegar na nova localização
            _jogador.VidaAtual = _jogador.VidaMaxima;

            // atualiza a vida do jogador na interface
            lblVida.Text = _jogador.VidaAtual.ToString();

            // A nova localização tem quest?
            if (novaLocalizacao.QuestLocal != null)
            {
                // verifica se o jogador possui a quest e se ja completou ela
                bool jogadorPossuiQuest = _jogador.possuiEssaQuest(novaLocalizacao.QuestLocal);
                bool jogadorJaCompletouQuest = _jogador.completouEssaQuest(novaLocalizacao.QuestLocal);

                // se o jogador possui a quest
                if (jogadorPossuiQuest)
                {
                    // se o jogador nao completou a quest ainda
                    if (!jogadorJaCompletouQuest)
                    {
                        // verifica se o jogador possui todos os itens para completar a quest
                        bool jogadorPossuiItensParaQuest = _jogador.possuiTodosItensParaCompletar(novaLocalizacao.QuestLocal);

                        // se o jogador possui todos os itens para completar a quest
                        if (jogadorPossuiItensParaQuest)
                        {
                            // mensagem na interface
                            rtbMensagens.Text += Environment.NewLine;
                            rtbMensagens.Text += "Voce completou a " + novaLocalizacao.QuestLocal.Nome + " quest!" + Environment.NewLine;

                            // remove os itens da quest do inventario
                            _jogador.RemoverItensDaQuest(novaLocalizacao.QuestLocal);

                            // da a recompensa da quest
                            rtbMensagens.Text += " Voce recebeu: " + Environment.NewLine;
                            rtbMensagens.Text += novaLocalizacao.QuestLocal.RecompensaExperiencia.ToString() + " pontos de experiencia" + Environment.NewLine;
                            rtbMensagens.Text += novaLocalizacao.QuestLocal.RecompensaOuro.ToString() + " ouros" + Environment.NewLine;
                            rtbMensagens.Text += novaLocalizacao.QuestLocal.RecompensaItem.Nome + Environment.NewLine;
                            rtbMensagens.Text += Environment.NewLine;

                            _jogador.PontosDeExperiencia += novaLocalizacao.QuestLocal.RecompensaExperiencia;
                            _jogador.Ouro += novaLocalizacao.QuestLocal.RecompensaOuro;

                            // adiciona o item da recompensa ao inventario do jogador
                            _jogador.AdicionaItemNoInventario(novaLocalizacao.QuestLocal.RecompensaItem);

                            // marca a quest como completa
                            _jogador.marcarQuestCompleta(novaLocalizacao.QuestLocal);

                        }
                    }
                }
                else
                {
                    // o jogador não possui a quest

                    // manda mensagens na interface
                    rtbMensagens.Text += "Você recebeu a " + novaLocalizacao.QuestLocal.Nome + "quest" + Environment.NewLine;
                    rtbMensagens.Text += novaLocalizacao.QuestLocal.Descricao + Environment.NewLine;
                    rtbMensagens.Text += " Para completa-la retorne com " + Environment.NewLine;
                    foreach(QuestItem questItem in novaLocalizacao.QuestLocal.QuestItem)
                    {
                        if (questItem.Quantidade == 1)
                        {
                            rtbMensagens.Text += questItem.Quantidade.ToString() + " " + questItem.Detalhes.Nome + Environment.NewLine;

                        }
                        else
                        {
                            rtbMensagens.Text += questItem.Quantidade.ToString() + " " + questItem.Detalhes.NomePlural + Environment.NewLine;
                        }
                    }
                    rtbMensagens.Text += Environment.NewLine;

                    // adiciona a quest para a lista de quests do jogador
                    _jogador.Quests.Add(new JogadorQuests(novaLocalizacao.QuestLocal));

                }
            }

            // Essa localização tem um monstro?
            if (novaLocalizacao.MonstroLocal != null)
            {
                rtbMensagens.Text += " Voce ve um " + novaLocalizacao.MonstroLocal.Nome + Environment.NewLine;

                // fazendo o monstro do local
                Monstro monstroPadrao = Mundo.MonstroById(novaLocalizacao.MonstroLocal.Id);

                _monstroAtual = new Monstro(
                    id: monstroPadrao.Id, nome: monstroPadrao.Nome, danoMaximo: monstroPadrao.DanoMaximo,
                    recompensaExperiencia: monstroPadrao.RecompensaExperiencia, recompensaOuro: monstroPadrao.RecompensaOuro, 
                    vidaAtual: monstroPadrao.VidaAtual, vidaMaxima: monstroPadrao.VidaMaxima);

                foreach (LootItem lootItem in monstroPadrao.LootItems)
                {
                    _monstroAtual.LootItems.Add(lootItem);
                }

                cboArmas.Visible = true;
                cboPocoes.Visible = true;
                btnUsarArma.Visible = true;
                btnUsarPocao.Visible = true;
            }
            else
            {
                _monstroAtual = null;

                cboArmas.Visible = false;
                cboPocoes.Visible = false;
                btnUsarArma.Visible = false;
                btnUsarPocao.Visible = false;
            }

            // atualiza a lista de inventario na interface
            atualizarListaInventarioUI();

            // atualiza a lista de quests na interface
            atualizarListaQuestsUI();

            // atualiza a lista de armas na interface
            atualizarListaArmasUI();

            // atualiza a lista de pocoes na interface
            atualizarListaPocoesUI();
        }

        private void atualizarListaArmasUI()
        {
            List<Arma> armas = new List<Arma>();

            foreach (InventarioItens inventarioItens in _jogador.Inventario)
            {
                if (inventarioItens.Detalhes is Arma)
                {
                    if (inventarioItens.Quantidade > 0)
                    {
                        armas.Add((Arma)inventarioItens.Detalhes);
                    }
                }
            }

            if (armas.Count == 0)
            {
                // o jogador nao possui nenhuma arma, por isso esconde o combobox
                cboArmas.Visible = false;
                btnUsarArma.Visible = false;
            }
            else
            {
                cboArmas.DataSource = armas;
                cboArmas.DisplayMember = "Nome";
                cboArmas.ValueMember = "ID";

                cboArmas.SelectedIndex = 0;
            }
        }

        private void atualizarListaInventarioUI()
        {
            dgvInventario.RowHeadersVisible = false;

            dgvInventario.ColumnCount = 2;
            dgvInventario.Columns[0].Name = "Nome";
            dgvInventario.Columns[0].Width = 197;
            dgvInventario.Columns[1].Name = "Quantidade";

            dgvInventario.Rows.Clear();

            foreach (InventarioItens inventarioItens in _jogador.Inventario)
            {
                if (inventarioItens.Quantidade > 0)
                {
                    dgvInventario.Rows.Add(new[] { inventarioItens.Detalhes.Nome, inventarioItens.Quantidade.ToString() });

                }
            }

        }

        private void atualizarListaQuestsUI()
        {
            dgvQuests.RowHeadersVisible = false;

            dgvQuests.ColumnCount = 2;
            dgvQuests.Columns[0].Name = "Nome";
            dgvQuests.Columns[0].Width = 197;
            dgvQuests.Columns[1].Name = "Feito?";

            dgvQuests.Rows.Clear();

            foreach (JogadorQuests jq in _jogador.Quests)
            {
                dgvQuests.Rows.Add(new[] { jq.Detalhes.Nome, jq.IsCompleted.ToString() });
            }

        }

        private void atualizarListaPocoesUI()
        {
            List<PocaoDeVida> pocoesDeVidas = new List<PocaoDeVida>();

            foreach (InventarioItens inventarioItens in _jogador.Inventario)
            {
                if (inventarioItens.Detalhes is PocaoDeVida)
                {
                    if (inventarioItens.Quantidade > 0)
                    {
                        pocoesDeVidas.Add((PocaoDeVida)inventarioItens.Detalhes);
                    }
                }
            }

            if (pocoesDeVidas.Count == 0)
            {
                // o jogador nao possui pocoes de vida
                cboPocoes.Visible = false;
                btnUsarPocao.Visible = false;
            }
            else
            {
                cboPocoes.DataSource = pocoesDeVidas;
                cboPocoes.DisplayMember = "Nome";
                cboPocoes.ValueMember = "ID";

                cboPocoes.SelectedIndex = 0;
            }
        }

        private void btnUsarArma_Click(object sender, EventArgs e)
        {
            // seleciona a arma atual com base no cboArmas
            Arma armaAtual = (Arma)cboArmas.SelectedItem;

            // determina o dano da arma
            int danoAoMonstro = RandomNumberGenerator.NumberBetween(armaAtual.DanoMinimo, armaAtual.DanoMaximo);

            // aplica o dano ao monstro
            _monstroAtual.VidaAtual -= danoAoMonstro;

            // mensagem ao atacar
            rtbMensagens.Text += "Voce atacou o " + _monstroAtual.Nome + " dando " + danoAoMonstro.ToString() + " de dano" + Environment.NewLine;

            // checa se o monstro esta morto
            if (_monstroAtual.VidaAtual <= 0)
            {
                // o monstro esta morto
                rtbMensagens.Text += Environment.NewLine;
                rtbMensagens.Text += "Voce derrotou um " + _monstroAtual.Nome + "! " + Environment.NewLine;

                // dando recompensa de xp ao jogador
                _jogador.PontosDeExperiencia += _monstroAtual.RecompensaExperiencia;
                rtbMensagens.Text += "Voce recebeu " + _monstroAtual.RecompensaExperiencia.ToString() + " pontos de experiencia!" + Environment.NewLine;

                // dando recompensa de ouro ao jogador
                _jogador.Ouro += _monstroAtual.RecompensaOuro;
                rtbMensagens.Text += "Voce recebeu " + _monstroAtual.RecompensaOuro.ToString() + " moedas de ouro!" + Environment.NewLine;

                // definindo loot de forma aleatoria
                List<InventarioItens> lootedItems = new List<InventarioItens>();

                foreach(LootItem lootItem in _monstroAtual.LootItems)
                {
                    if(RandomNumberGenerator.NumberBetween(1, 100) <= lootItem.DropPorcentagem)
                    {
                        lootedItems.Add(new InventarioItens(lootItem.Detalhes, 1));
                    }
                }

                // caso nao for selecionado nenhum loot adicionar o loot default
                if(lootedItems.Count == 0)
                {
                    foreach(LootItem lootItem in _monstroAtual.LootItems)
                    {
                        if (lootItem.IsDefaultItem)
                            lootedItems.Add(new InventarioItens(lootItem.Detalhes, 1));
                    }
                }

                // adiciona os itens de loot ao inventario do jogador
                foreach(InventarioItens ii in lootedItems)
                {
                    _jogador.AdicionaItemNoInventario(ii.Detalhes);

                    if (ii.Quantidade == 1)
                    {
                        rtbMensagens.Text += "Seu loot: " + ii.Quantidade.ToString() + " " + ii.Detalhes.Nome + Environment.NewLine;
                    }
                    else
                    {
                        rtbMensagens.Text += "Seu loot: " + ii.Quantidade.ToString() + " " + ii.Detalhes.NomePlural + Environment.NewLine;
                    }
                }

                // atualiza a interface
                lblVida.Text = _jogador.VidaAtual.ToString();
                lblOuro.Text = _jogador.Ouro.ToString();
                lblExperiencia.Text = _jogador.PontosDeExperiencia.ToString();
                lblNivel.Text = _jogador.Nivel.ToString();

                atualizarListaInventarioUI();
                atualizarListaArmasUI();
                atualizarListaPocoesUI();

                rtbMensagens.Text += Environment.NewLine;

                // move o jogador para o mesmo local para inicar uma nova batalha
                MoveTo(_jogador.LocalizacaoAtual);

            }
            else
            {
                // Monstro ainda esta vivo

                // monstro ataca
                int danoAoPlayer = RandomNumberGenerator.NumberBetween(0, _monstroAtual.DanoMaximo);

                // mensagem ao atacar
                rtbMensagens.Text += _monstroAtual.Nome + " te atacou, dando  " + danoAoPlayer.ToString() + " de dano!" + Environment.NewLine; 

                // tira vida do jogador
                _jogador.VidaAtual -= danoAoPlayer;
                lblVida.Text = _jogador.VidaAtual.ToString();

                // se a vida do jogador zerou
                if(_jogador.VidaAtual <= 0)
                {
                    rtbMensagens.Text += " Um " + _monstroAtual.Nome + " te matou..." + Environment.NewLine;

                    // ele volta para casa
                    MoveTo(Mundo.LocalizacaosById(Mundo.LOCALIZACAO_ID_CASA));
                }


            }

        }

        private void btnUsarPocao_Click(object sender, EventArgs e)
        {
            PocaoDeVida pocao = (PocaoDeVida)cboPocoes.SelectedItem;

            _jogador.VidaAtual += pocao.QuantidadeCura;

            // vida nao pode passar a vida maxima
            if(_jogador.VidaAtual > _jogador.VidaMaxima)
            {
                _jogador.VidaAtual = _jogador.VidaMaxima;
            }

            // remove a poção do inventario
            foreach(InventarioItens ii in _jogador.Inventario)
            {
                if(ii.Detalhes.Id == pocao.Id)
                {
                    ii.Quantidade--;
                    break;
                }
            }

            // aparece uma mensagem
            rtbMensagens.Text += "Voce bebe uma " + pocao.Nome + Environment.NewLine;


            // O monstro recebe o turno dele para atacar

            // monstro ataca
            int danoAoPlayer = RandomNumberGenerator.NumberBetween(0, _monstroAtual.DanoMaximo);

            // mensagem ao atacar
            rtbMensagens.Text += _monstroAtual.Nome + " te atacou, dando  " + danoAoPlayer.ToString() + " de dano!" + Environment.NewLine;

            // tira vida do jogador
            _jogador.VidaAtual -= danoAoPlayer;
            lblVida.Text = _jogador.VidaAtual.ToString();

            // se a vida do jogador zerou
            if (_jogador.VidaAtual <= 0)
            {
                rtbMensagens.Text += " Um " + _monstroAtual.Nome + " te matou..." + Environment.NewLine;

                // ele volta para casa
                MoveTo(Mundo.LocalizacaosById(Mundo.LOCALIZACAO_ID_CASA));
            }

            // atualiza a interface
            lblVida.Text = _jogador.VidaAtual.ToString();
            atualizarListaInventarioUI();
            atualizarListaPocoesUI();

        }


    }
}
