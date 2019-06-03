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
        }

        static int LeOpcaoMenu(Dictionary<int, string> _menu)
        {
            int opcao;
            string value;
            bool valid = false;
            do
            {
                Console.Write("Opção:");
                valid = int.TryParse(Console.ReadLine(), out opcao);

                if (valid == false)
                {
                    Console.WriteLine("Opção Inválida");
                } else
                {
                    valid = _menu.ContainsKey(opcao);
                }
                    
            }
            while (valid == false);

            return opcao;
        }
        
     }
}
