// -------------------------------------------------
// <copyright file="UI.Cli.cs" company="IPCA">
// </copyright>
// <summary>
// LP2 - 2018-2019
// <desc></desc>
// </summary>
//-------------------------------------------------

using ITgestao;
using UtilsNS;


namespace UI.Cli
{
    class Program
    {

        static void Main(string[] args)
        {
            ConstroiMenus();
            RunMenu(0);
            Input.LeString("Prima qualquer tecla para terminar.");
        }

        /// <summary>
        /// Constroi os menus e respectivos callbacks
        /// </summary>
        static void ConstroiMenus()
        {
            Menu menuprincipal  = Menu.getInstance(0);
            Menu menuinventario0 = Menu.getInstance(1);
            Menu menulocalizacoes = Menu.getInstance(2);
            Menu menuinventario1 = Menu.getInstance(3);
            Menu menupesquisa0 = Menu.getInstance(4);
            Menu menupesquisa1 = Menu.getInstance(5);

            #region MENU INICIAL
            menuprincipal.Descricao = "======================= Menu Inicial =======================";

            menuprincipal
                .Add("- Inventário Armazem 0", () => menuinventario0.RendeMenu())
                .Add("- Inventário Armazem 1", () => menuinventario1.RendeMenu())
                .Add("- Localizacoes", () => menulocalizacoes.RendeMenu())
                .Add("+ Sair");
            #endregion

            #region MENU INVENTARIO
            menuinventario1.Descricao = "======================= INVENTARIO: Armazem 1 =======================";
            menuinventario1
                .Add("Adicionar Item", () => AdicionaItem(1,menuinventario1))
                .Add("Editar Item", () => EditaItem(1, menuinventario1))
                .Add("Remover Item", () => RemoveItem(1, menuinventario1))
                .Add("Listar Items", () => ListaItems(1, menuinventario1))
                .Add("Mostra Total de Items", () => ContaItems(1, menuinventario1))
                .Add("Eliminar tudo", () => RemoveItems(1, menuinventario1))
                .Add("+ Pesquisa Filtros", () => menupesquisa1.RendeMenu() )
                .Add("< Voltar", () => menuprincipal.RendeMenu());
            #endregion

            #region MENU INVENTARIO Empresa 0
            menuinventario0.Descricao = "======================= INVENTARIO: Armazem 0 =======================";
            menuinventario0
                .Add("Adicionar Item", () => AdicionaItem(0, menuinventario0))
                .Add("Editar Item", () => EditaItem(0, menuinventario0))
                .Add("Remover Item", () => RemoveItem(0, menuinventario0))
                .Add("Listar Items", () => ListaItems(0, menuinventario0))
                .Add("Mostra Total de Items", () => ContaItems(0, menuinventario0))
                .Add("Eliminar tudo" , () => RemoveItems(0, menuinventario0) )
                .Add("+ Pesquisa Filtros", () => menupesquisa0.RendeMenu())
                .Add("< Voltar", () => menuprincipal.RendeMenu());
            #endregion

            #region MENU LOCALIZACOES
            menulocalizacoes.Descricao = "======================= LOCALIZACOES =======================";
            menulocalizacoes
                .Add("Adicionar Localizacao", () => AdicionaLocalizacao())
                .Add("Remover Localizacao", () => RemoveLocalizacao())
                .Add("Edita Localizacao", () => AlteraLocalizacao())
                .Add("Lista Localizacoes", () => ListaLocalizacao())
                .Add("< Voltar", () => menuprincipal.RendeMenu());
            #endregion

            #region MENU PESQUISA
            menupesquisa0.Descricao = "======================= PESQUISA: Armazem 0 =======================";
            menupesquisa0
                .Add("Pesquisa por Nome", () => PesquisaNome(0, menupesquisa0))
                .Add("Perquisar por Id", () => PesquisaId(0, menupesquisa0))
                .Add("Perquisar por Data de Fabrico", () => PesquisaFabrico(0, menupesquisa0))
                .Add("Perquisar por Tipo", () => PesquisaTipo(0, menupesquisa0))
                .Add("< Voltar", () => menuinventario0.RendeMenu());
            #endregion
            #region MENU PESQUISA
            menupesquisa1.Descricao = "======================= PESQUISA: Armazem 1 =======================";
            menupesquisa1
                .Add("Pesquisa por Nome", () => PesquisaNome(0, menupesquisa1))
                .Add("Perquisar por Id", () => PesquisaId(0, menupesquisa1))
                .Add("Perquisar por Data de Fabrico", () => PesquisaFabrico(0, menupesquisa1))
                .Add("Perquisar por Tipo", () => PesquisaTipo(0, menupesquisa1))
                .Add("< Voltar", () => menuinventario1.RendeMenu());
            #endregion
        }

        /// <summary>
        /// Corre o menu com o id passado por parametro
        /// </summary>
        /// <param name="_id">Id do menu</param>
        static void RunMenu(int _id)
        {
            Menu.getInstance(_id).RendeMenu();
        }

        #region ===============================================INVENTARIO
        static void AdicionaItem(int _entidade, Menu _back)
        {
            Output.MostraLinha("======================= Adiciona Item =======================");
            GoBack(_back);
        }

        static void EditaItem(int _entidade, Menu _back)
        {
            Output.MostraLinha("======================= Edita Item =======================");
            GoBack(_back);

        }
        static void RemoveItem(int _entidade, Menu _back)
        {
            Output.MostraLinha("======================= Remove Item =======================");
            GoBack(_back);
        }
        static void ListaItems(int _entidade, Menu _back)
        {
            Output.MostraLinha("======================= Lista Items =======================");
            GoBack(_back);
        }

        /// <summary>
        /// Mostra a cotnagem de Items
        /// </summary>
        /// <param name="_entidade">Armazem</param>
        static void ContaItems(int _entidade, Menu _back)
        {
            Output.MostraLinha("======================= Contagem Items =======================");
            Output.MostraLinha($"Total de Items: {Inventario.getInstance(_entidade).TotalItems}");
            GoBack(_back);
        }
        
        /// <summary>
        /// Remove todos os Items do Armazem
        /// </summary>
        /// <param name="_entidade">Armazem</param>
        static void RemoveItems(int _entidade, Menu _back)
        {
            Output.MostraLinha("======================= Remove Items =======================");
            Inventario.getInstance(_entidade).RemoveAll();
            Input.LeString("Todos os Items foram Removidos ...");
            GoBack(_back);
        }
        #endregion

        #region ===============================================LOCALIZACOES
        static void AdicionaLocalizacao()
        {
            Output.MostraLinha("======================= Adiciona Localização =======================");
            GoBack(Menu.getInstance(2));
        }
        static void RemoveLocalizacao()
        {
            Output.MostraLinha("======================= Remove Localização =======================");
            GoBack(Menu.getInstance(2));
        }
        static void AlteraLocalizacao()
        {
            Output.MostraLinha("======================= Altera Localização =======================");
            GoBack(Menu.getInstance(2));
        }
        static void ListaLocalizacao()
        {
            Output.MostraLinha("======================= Altera Localização =======================");
            GoBack(Menu.getInstance(2));
        }
        #endregion

        #region ===============================================PESQUISAS
        static void PesquisaNome(int _entidade, Menu _back)
        {
            Output.MostraLinha($"======================= Pesquisa Por Nome; Armazem:{_entidade} =======================");
            GoBack(_back);
        }
        static void PesquisaId(int _entidade, Menu _back)
        {
            Output.MostraLinha($"======================= Pesquisa Por ID; Armazem:{_entidade} =======================");
            GoBack(_back);
        }
        static void PesquisaFabrico(int _entidade, Menu _back)
        {
            Output.MostraLinha($"======================= Pesquisa Por Fabrico; Armazem:{_entidade} =======================");
            GoBack(_back);
        }
        static void PesquisaTipo(int _entidade, Menu _back)
        {
            Output.MostraLinha($"======================= Pesquisa Por Tipo; Armazem:{_entidade} =======================");
            GoBack(_back);
        }
        #endregion

        static void GoBack(Menu _back, string _texto= "Prima qualquer tecla para terminar.")
        {
            Input.LeString(_texto);
            _back.RendeMenu();
        }
    }
}