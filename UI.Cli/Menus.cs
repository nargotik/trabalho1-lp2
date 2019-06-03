// -------------------------------------------------
// <copyright file="UI.Cli.cs" company="IPCA">
// </copyright>
// <summary>
//	LP2 - 2018-2019
// <desc></desc>
// </summary>
//-------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Cli
{
    class Menus
    {

        public static int RendeMenu(Dictionary<int, string> _menu)
        {
            MostraMenu(_menu);


            return LeOpcaoMenu(_menu);
        }

        static void MostraMenu(Dictionary<int, string> _menu)
        {
            foreach (KeyValuePair<int, string> menuItem in _menu)
            {
                Console.WriteLine("{0} - {1}", menuItem.Key, menuItem.Value);
            }

            Console.ReadKey();
        }

        static int LeOpcaoMenu(Dictionary<int, string> _menu)
        {
            int opcao;
            string value;

            do
            {
                Console.Write("Opção:");
                opcao = Console.Read();
            }
            while (!_menu.TryGetValue(opcao, out value) == true);

            return opcao;
        }
        
     }
}
