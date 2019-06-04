using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITgestao;
using ITgestao.ItemsNS;
using UtilsNS;


namespace UI.Cli
{
    class Program
    {

        static void Main(string[] args)
        {
            InicializaMenus();
            Run();
            Console.ReadKey();
        }

        static void InicializaMenus()
        {
            Menu principal  = Menu.getInstance(0);
            Menu inventario = Menu.getInstance(1);
            Menu localizacoes = Menu.getInstance(2);

            #region MENU INICIAL
            principal.Descricao = "Menu Inicial";

            principal
                .Add("- Inventário", () => inventario.RendeMenu())
                .Add("- Localizacoes", () => localizacoes.RendeMenu())
                .Add("+ Sair")
            ;
            #endregion

            #region MENU INVENTARIO
            inventario.Descricao = "Menu INVENTARIO";
            inventario
                .Add("Adicionar Item", () => AdicionaItem())
                .Add("Editar Item", () => EditaItem())
                .Add("Remover Item")
                .Add("Listar Items")
                .Add("Eliminar tudo" , () => Inventario.getInstance().RemoveAll() )
                .Add("< Voltar", () => principal.RendeMenu())
            ;
            #endregion

            #region MENU LOCALIZACOES
            localizacoes.Descricao = "Menu LOCALIZACOES";
            localizacoes
                .Add("Adicionar Localizacao")
                .Add("Remover Localizacao")
                .Add("< Voltar", () => principal.RendeMenu())
                .Add("+ texto2")
            ;
            #endregion

        }

        static void Run()
        {
            // Arranca com o menu inicial
            Menu.getInstance(0).RendeMenu();
        }

        static void AdicionaItem()
        {
            // Codigo para adicao de um item
        }

        static void EditaItem()
        {
            // Codigo para Edicao de um item
        }
    }
}