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


        #region ANTES DO MENU
        //static Item[] _equip;
        //public static void ShowEquipamento(Item pub)
        //{
        //    int pubDate = pub.Id;
        //    Console.WriteLine($"{pub.Id}");

        //    Console.WriteLine($"{pub.ToString()}");

        //}
        #endregion
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
                .Add("Adicionar Item")
                .Add("Editar Item")
                .Add("Remover Item")
                .Add("Listar Items")
                .Add("Eliminar tudo")
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
    }
}