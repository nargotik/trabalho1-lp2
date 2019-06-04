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

        static void ConstroiMenus()
        {
            Menu principal  = Menu.getInstance(0);
            Menu inventario0 = Menu.getInstance(1);
            Menu localizacoes = Menu.getInstance(2);
            Menu inventario1 = Menu.getInstance(3);
            Menu pesquisa0 = Menu.getInstance(4);

            #region MENU INICIAL
            principal.Descricao = "======================= Menu Inicial =======================";

            principal
                .Add("- Inventário Armazem 0", () => inventario0.RendeMenu())
                .Add("- Inventário Armazem 1", () => inventario1.RendeMenu())
                .Add("- Localizacoes", () => localizacoes.RendeMenu())
                .Add("+ Sair");
            #endregion

            #region MENU INVENTARIO
            inventario1.Descricao = "======================= INVENTARIO: Armazem 1 =======================";
            inventario1
                .Add("Adicionar Item", () => AdicionaItem(1))
                .Add("Editar Item", () => EditaItem(1))
                .Add("Remover Item", () => RemoveItem(1))
                .Add("Listar Items", () => ListaItems(1))
                .Add("Pesquisa Items", () => ListaItems(1))
                .Add("Mostra Total de Items", () => ContaItems(1))
                .Add("Eliminar tudo", () => RemoveItems(1))
                .Add("< Voltar", () => principal.RendeMenu());
            #endregion

            #region MENU INVENTARIO Empresa 0
            inventario0.Descricao = "======================= INVENTARIO: Armazem 0 =======================";
            inventario0
                .Add("Adicionar Item", () => AdicionaItem(0))
                .Add("Editar Item", () => EditaItem(0))
                .Add("Remover Item", () => RemoveItem(0))
                .Add("Listar Items", () => ListaItems(0))
                .Add("Mostra Total de Items", () => ContaItems(0))
                .Add("Eliminar tudo" , () => RemoveItems(0) )
                .Add("< Voltar", () => principal.RendeMenu());
            #endregion

            #region MENU LOCALIZACOES
            localizacoes.Descricao = "======================= LOCALIZACOES =======================";
            localizacoes
                .Add("Adicionar Localizacao")
                .Add("Remover Localizacao")
                .Add("< Voltar", () => principal.RendeMenu());
            #endregion

            #region MENU PESQUISA
            pesquisa0.Descricao = "======================= PESQUISA: Armazem 0 =======================";
            pesquisa0
                .Add("Pesquisa por Nome")
                .Add("Perquisar por Id")
                .Add("Perquisar por Data de Fabrico")
                .Add("Perquisar por Tipo")
                .Add("< Voltar", () => principal.RendeMenu());
            #endregion
            #region MENU PESQUISA
            pesquisa0.Descricao = "======================= PESQUISA: Armazem 0 =======================";
            pesquisa0
                .Add("Pesquisa por Nome")
                .Add("Perquisar por Id")
                .Add("Perquisar por Data de Fabrico")
                .Add("Perquisar por Tipo")
                .Add("< Voltar", () => principal.RendeMenu());
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

        static void AdicionaItem(int _entidade)
        {
            Output.MostraLinha("======================= Adiciona Item =======================");
            Menu.getInstance(1).RendeMenu();
        }

        static void EditaItem(int _entidade)
        {
            Output.MostraLinha("======================= Edita Item =======================");
            Menu.getInstance(1).RendeMenu();
        }
        static void RemoveItem(int _entidade)
        {
            Output.MostraLinha("======================= Remove Item =======================");
            Menu.getInstance(1).RendeMenu();
        }
        static void ListaItems(int _entidade)
        {
            Output.MostraLinha("======================= Lista Items =======================");
            Menu.getInstance(1).RendeMenu();
        }

        /// <summary>
        /// Mostra a cotnagem de Items
        /// </summary>
        /// <param name="_entidade">Armazem</param>
        static void ContaItems(int _entidade)
        {
            Output.MostraLinha("======================= Contagem Items =======================");
            Output.MostraLinha($"Total de Items: {Inventario.getInstance(_entidade).TotalItems}");
            Menu.getInstance(1).RendeMenu();
        }
        
        /// <summary>
        /// Remove todos os Items do Armazem
        /// </summary>
        /// <param name="_entidade">Armazem</param>
        static void RemoveItems(int _entidade)
        {
            Output.MostraLinha("======================= Remove Items =======================");
            Inventario.getInstance(_entidade).RemoveAll();
            Input.LeString("Todos os Items foram Removidos ... \nPrima enter para continuar...");
            Menu.getInstance(1).RendeMenu();
        }
    }
}