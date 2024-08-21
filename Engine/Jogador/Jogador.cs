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
        public int Nivel 
        { 
            get { return ((PontosDeExperiencia / 100) + 1); }
        }
        public List<InventarioItens> Inventario { get; set; }
        public List<JogadorQuests> Quests { get; set; }
        public Localizacao LocalizacaoAtual { get; set; }

        public Jogador(int vidaAtual, int vidaMaxima, int ouro, int pontosDeExperiencia)
            :base(vidaAtual, vidaMaxima)
        {
            Ouro = ouro;
            PontosDeExperiencia = pontosDeExperiencia;
            Inventario = new List<InventarioItens>();
            Quests = new List<JogadorQuests>();
        }

        public bool possuiItemRequerido(Localizacao localizacao)
        {
            // se nao tem item requirido para essa localização
            if (localizacao.ItemRequirido == null) 
                return true;

            // ve se o jogador possui o item requirido
            foreach(InventarioItens ii in Inventario)
            {
                if (ii.Detalhes.Id == localizacao.ItemRequirido.Id)
                    return true;
            }

            // não possui o item
            return false;
        }

        public bool possuiEssaQuest(Quest quest)
        {
            foreach(JogadorQuests jq in Quests)
            {
                if(jq.Detalhes.Id == quest.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool completouEssaQuest(Quest quest)
        {
            foreach(JogadorQuests jq in Quests)
            {
                if(jq.Detalhes.Id == quest.Id)
                {
                    return jq.IsCompleted;
                }
            }

            return false;
        }

        public bool possuiTodosItensParaCompletar(Quest quest)
        {
            // verifica se o jogador possui todos os itens para comepltar a quest
            foreach(QuestItem questItem in quest.QuestItem)
            {
                bool itemEstaNoInventario = false;

                // verifica o inventario do jogador
                foreach(InventarioItens ii in Inventario)
                {
                    if (ii.Detalhes.Id == questItem.Detalhes.Id)
                    {
                        itemEstaNoInventario = true;

                        if (ii.Quantidade < questItem.Quantidade)
                            return false;
                    }
                }

                // se o jogador nao possui os itens no inventario
                if (!itemEstaNoInventario)
                    return false;
            }

            // se chegou aqui o jogador possui todos os itens necessarios para quest
            return true;
        }

        public void RemoverItensDaQuest(Quest quest)
        {
            foreach(QuestItem questItem in quest.QuestItem)
            {
                foreach(InventarioItens ii in Inventario)
                {
                    if(ii.Detalhes.Id == questItem.Detalhes.Id)
                    {
                        ii.Quantidade -= questItem.Quantidade;
                        break;
                    }
                }
            }
        }

        public void AdicionaItemNoInventario(Item itemToAdd)
        {
            foreach(InventarioItens ii in Inventario)
            {
                if (ii.Detalhes.Id == itemToAdd.Id)
                {
                    // o jogador ja possui o item, só somar a quantidade
                    ii.Quantidade++;

                    return;
                }
            }

            // se o jogador nao possui o item temos que crialo no inventario
            Inventario.Add(new InventarioItens(itemToAdd, 1));
        }

        public void marcarQuestCompleta(Quest quest)
        {
            // encontra a quest requirida 
            foreach(JogadorQuests jq in Quests)
            {
                if(jq.Detalhes.Id == quest.Id) 
                {
                    // marca como completa
                    jq.IsCompleted = true;

                    return;
                }
            }
        }
    }
}
