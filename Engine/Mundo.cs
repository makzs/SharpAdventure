using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class Mundo
    {

        static Mundo()
        {
            PreencherItens();
            PreencherMonstros();
            PreencherQuests();
            PreencherLocalizacoes();
        }

        // Listas Estaticas
        public static readonly List<Item> Itens = new List<Item>();
        public static readonly List<Monstro> Monstros = new List<Monstro>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Localizacao> Localizacoes = new List<Localizacao>();

        // IDs da lista de itens
        public const int ITEM_ID_ESPADA_DE_MADEIRA = 1;
        public const int ITEM_ID_POCAO_DE_CURA = 2;
        public const int ITEM_ID_DENTE_DE_COBRA = 3;
        public const int ITEM_ID_PEDACO_DE_COURO = 4;
        public const int ITEM_ID_ASAS_DE_MORCEGO = 5;
        public const int ITEM_ID_SEDA_DE_ARANHA = 6;
        public const int ITEM_ID_VENENO_DE_ARANHA = 7;
        public const int ITEM_ID_CARNE_DE_JAVALI = 8;
        public const int ITEM_ID_COGUMELO_VERMELHO = 9;
        public const int ITEM_ID_COGUMELO_VERDE = 10;
        public const int ITEM_ID_MACHADO_DE_FERRO = 11;
        public const int ITEM_ID_PASSAPORTE_DE_AVENTUREIRO = 12;

        // IDs da lista de monstros
        public const int MONSTRO_ID_JAVALI = 1;
        public const int MONSTRO_ID_COBRA = 2;
        public const int MONSTRO_ID_MORCEGO = 3;
        public const int MONSTRO_ID_ARANHA_GIGANTE = 4;

        // IDs da lista de quests
        public const int QUEST_ID_LIMPAR_CAVERNA = 1;
        public const int QUEST_ID_AJUDAR_FAZENDEIROS = 2;

        // IDs da lista de localizacoes
        public const int LOCALIZACAO_ID_CASA = 1;
        public const int LOCALIZACAO_ID_CENTRO_DA_CIDADE = 2;
        public const int LOCALIZACAO_ID_CABANA_NAS_COLINAS = 3;
        public const int LOCALIZACAO_ID_CAVERNA_COLINAS = 4;
        public const int LOCALIZACAO_ID_FAZENDA_COLINAS = 5;
        public const int LOCALIZACAO_ID_PLANTACAO_COLINAS = 6;
        public const int LOCALIZACAO_ID_PONTE_DE_PEDRAS = 7;
        public const int LOCALIZACAO_ID_ESCONDERIJO_DA_PONTE = 8;
        public const int LOCALIZACAO_ID_ESTRADA_REAL = 9;

        // Metodo para preencher Itens
        private static void PreencherItens()
        {
            Itens.Add(new Arma(ITEM_ID_ESPADA_DE_MADEIRA, "Espada de madeira", "espadas de madeira", 0, 5));
            Itens.Add(new Arma(ITEM_ID_MACHADO_DE_FERRO, "Machado de ferro", "machados de ferro", 3, 10));
            Itens.Add(new PocaoDeVida(ITEM_ID_POCAO_DE_CURA, "Poção de cura", "poções de cura", 5));
            Itens.Add(new Item(ITEM_ID_DENTE_DE_COBRA, "dente de cobra", "dentes de cobra"));
            Itens.Add(new Item(ITEM_ID_PEDACO_DE_COURO, "pedaço de couro", "pedaços de couro"));
            Itens.Add(new Item(ITEM_ID_ASAS_DE_MORCEGO, "asa de morcego", "asas de morcego"));
            Itens.Add(new Item(ITEM_ID_SEDA_DE_ARANHA, "seda de aranha", "sedas de aranha"));
            Itens.Add(new Item(ITEM_ID_VENENO_DE_ARANHA, "veneno de aranha", "venenos de aranha"));
            Itens.Add(new Item(ITEM_ID_CARNE_DE_JAVALI, "carne de javali", "carnes de javali"));
            Itens.Add(new Item(ITEM_ID_COGUMELO_VERMELHO, "cogumelo vermelho", "cogumelos vermelhos"));
            Itens.Add(new Item(ITEM_ID_COGUMELO_VERDE, "cogumelo verde", "cogumelos verde"));
            Itens.Add(new Item(ITEM_ID_PASSAPORTE_DE_AVENTUREIRO, "passaporte de viagem", "passaportes de viagem"));
        }

        // Metodo para preencher monstros
        private static void PreencherMonstros()
        {
            Monstro javali = new Monstro(id: MONSTRO_ID_JAVALI, nome: "Javali", 
                vidaAtual: 6, vidaMaxima: 6, danoMaximo: 4, recompensaExperiencia: 5, recompensaOuro: 8);
            javali.LootItems.Add(new LootItem(ItemById(ITEM_ID_PEDACO_DE_COURO), 75, false));
            javali.LootItems.Add(new LootItem(ItemById(ITEM_ID_CARNE_DE_JAVALI), 75, true));

            Monstro morcego = new Monstro(id: MONSTRO_ID_MORCEGO, nome: "Morcego",
                vidaAtual: 4, vidaMaxima: 4, danoMaximo: 5, recompensaExperiencia: 9, recompensaOuro: 10);
            morcego.LootItems.Add(new LootItem(ItemById(ITEM_ID_ASAS_DE_MORCEGO), 75, true));
            morcego.LootItems.Add(new LootItem(ItemById(ITEM_ID_COGUMELO_VERMELHO), 75, false));

            Monstro cobra = new Monstro(id: MONSTRO_ID_COBRA, nome: "Cobra",
                vidaAtual: 8, vidaMaxima: 8, danoMaximo: 10, recompensaExperiencia: 12, recompensaOuro: 16);
            cobra.LootItems.Add(new LootItem(ItemById(ITEM_ID_DENTE_DE_COBRA), 75, true));
            cobra.LootItems.Add(new LootItem(ItemById(ITEM_ID_COGUMELO_VERDE), 75, false));

            Monstro aranhaGigante = new Monstro(id: MONSTRO_ID_ARANHA_GIGANTE, nome: "Aranha",
                vidaAtual: 15, vidaMaxima: 15, danoMaximo: 16, recompensaExperiencia: 25, recompensaOuro: 32);
            aranhaGigante.LootItems.Add(new LootItem(ItemById(ITEM_ID_VENENO_DE_ARANHA), 75, true));
            aranhaGigante.LootItems.Add(new LootItem(ItemById(ITEM_ID_SEDA_DE_ARANHA), 25, false));

            Monstros.Add(javali);
            Monstros.Add(morcego);
            Monstros.Add(cobra);
            Monstros.Add(aranhaGigante);
        }

        // metodo para preencher as quests
        private static void PreencherQuests()
        {
            Quest limparCaverna =
                new Quest(
                    id: QUEST_ID_LIMPAR_CAVERNA,
                    nome: "Tirando a poeira da caverna",
                    descricao: "Mate os morcegos que infestaram a caverna proximo a minha cabana e me traga 3 asas de morcegos." +
                    " Voce ira receber uma poção de cura e 10 ouros por isso",
                    recompensaExperiencia: 20,
                    recompensaItem: ItemById(ITEM_ID_MACHADO_DE_FERRO),
                    recompensaOuro: 10);

            limparCaverna.QuestItem.Add(new QuestItem(ItemById(ITEM_ID_ASAS_DE_MORCEGO), 3));

            Quest ajudarFazendeiros =
                new Quest(
                    id: QUEST_ID_AJUDAR_FAZENDEIROS,
                    nome: "Colhendo monstros",
                    descricao: "Ajude os fazendeiros a eliminar as ameaças da plantação proxima." +
                    " Voce ira receber um passaporte de aventureiro e 15 ouros por isso",
                    recompensaExperiencia: 30,
                    recompensaItem: ItemById(ITEM_ID_PASSAPORTE_DE_AVENTUREIRO),
                    recompensaOuro: 15);

            ajudarFazendeiros.QuestItem.Add(new QuestItem(ItemById(ITEM_ID_PEDACO_DE_COURO), 3));


            Quests.Add(limparCaverna);
            Quests.Add(ajudarFazendeiros);
        }

        private static void PreencherLocalizacoes()
        {
            // cria cada localização
            Localizacao casa = new Localizacao(LOCALIZACAO_ID_CASA, "casa", "Sua casa! Você realmente deveria limpar ela... mas a aventura não pode esperar!");

            Localizacao centroCidade = new Localizacao(LOCALIZACAO_ID_CENTRO_DA_CIDADE, "centro da cidade", "Centro da cidade! você está no meio do mercado central");

            Localizacao cabanaColina = new Localizacao(LOCALIZACAO_ID_CABANA_NAS_COLINAS, "cabana nas colinas", "Uma cabana no alto das colinas, provavelmente pertence a um lenhador");
            cabanaColina.QuestLocal = QuestsById(QUEST_ID_LIMPAR_CAVERNA);

            Localizacao cavernaColina = new Localizacao(LOCALIZACAO_ID_CAVERNA_COLINAS, "Caverna das colinas", "Uma escura caverna, você consegue ouvir barulhos sinistros vindo de dentro");
            cavernaColina.MonstroLocal = MonstroById(MONSTRO_ID_MORCEGO);

            Localizacao fazendaColina = new Localizacao(LOCALIZACAO_ID_FAZENDA_COLINAS, "Fazenda das colinas", "Uma amigavel fazenda, parece estar tendo uma reunião de fazendeiros ali proximo");
            fazendaColina.QuestLocal = QuestsById(QUEST_ID_AJUDAR_FAZENDEIROS);

            Localizacao plantacaoColina = new Localizacao(LOCALIZACAO_ID_PLANTACAO_COLINAS, "Plantação nas colinas", "Parece crescer muitas batatas aqui");
            plantacaoColina.MonstroLocal = MonstroById(MONSTRO_ID_JAVALI);

            Localizacao estradaReal = new Localizacao(LOCALIZACAO_ID_ESTRADA_REAL, "Estrada real", "Uma longa e acentuada estrada de pedras, parece perigoso");
            estradaReal.MonstroLocal = MonstroById(MONSTRO_ID_COBRA);

            Localizacao ponte = new Localizacao(LOCALIZACAO_ID_PONTE_DE_PEDRAS, "Ponte de pedras", "Uma enorme ponte, parece ter guardas a frente", ItemById(ITEM_ID_PASSAPORTE_DE_AVENTUREIRO));

            Localizacao esconderijoPonte = new Localizacao(LOCALIZACAO_ID_ESCONDERIJO_DA_PONTE, "Esconderijo da ponte de pedras", "Um sombrio esconderijo subterraneo, existem muitas teias pelo caminho");
            esconderijoPonte.MonstroLocal = MonstroById(MONSTRO_ID_ARANHA_GIGANTE);

            // conecta as localizações
            casa.LocalizacaoNorte = centroCidade;

            centroCidade.LocalizacaoNorte = cabanaColina;
            centroCidade.LocalizacaoSul = casa;
            centroCidade.LocalizacaoLeste = estradaReal;
            centroCidade.LocalizacaoOeste = fazendaColina;

            fazendaColina.LocalizacaoNorte = cabanaColina;
            fazendaColina.LocalizacaoLeste = centroCidade;
            fazendaColina.LocalizacaoOeste = plantacaoColina;

            plantacaoColina.LocalizacaoLeste = fazendaColina;

            cabanaColina.LocalizacaoNorte = cavernaColina;
            cabanaColina.LocalizacaoSul = centroCidade;
            cabanaColina.LocalizacaoOeste = fazendaColina;

            cavernaColina.LocalizacaoSul = cabanaColina;

            estradaReal.LocalizacaoLeste = ponte;
            estradaReal.LocalizacaoOeste = centroCidade;

            ponte.LocalizacaoLeste = esconderijoPonte;
            ponte.LocalizacaoOeste = estradaReal;

            esconderijoPonte.LocalizacaoOeste = ponte;

            // adiciona as localizações para a lista estatica
            Localizacoes.Add(casa);
            Localizacoes.Add(centroCidade);
            Localizacoes.Add(cabanaColina);
            Localizacoes.Add(cavernaColina);
            Localizacoes.Add(fazendaColina);
            Localizacoes.Add(plantacaoColina);
            Localizacoes.Add(estradaReal);
            Localizacoes.Add(ponte);
            Localizacoes.Add(esconderijoPonte);
        }

        // função para pegar IDs de itens
        public static Item ItemById(int id)
        {
            foreach (Item item in Itens )
            {
                if (item.Id == id)
                    return item;
            }

            return null;
        }

        // função para pegar IDs de monstros
        public static Monstro MonstroById(int id)
        {
            foreach (Monstro monstro in Monstros)
            {
                if (monstro.Id == id)
                    return monstro;
            }

            return null;
        }
        
        // função para pegar IDs de quests
        public static Quest QuestsById(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.Id == id)
                    return quest;
            }

            return null;
        }
        
        // função para pegar IDs de localizações
        public static Localizacao LocalizacaosById(int id)
        {
            foreach (Localizacao localizacao in Localizacoes)
            {
                if (localizacao.Id == id)
                    return localizacao;
            }

            return null;
        }

    }
}
