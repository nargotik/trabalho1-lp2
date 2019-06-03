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
    class MenuItem
    {
        public string description { get; set; }
        public Action callback { get; set; }

        public MenuItem(string _text, Action _callback)
        {
            callback = _callback;
            description = _text;
        }
    }
    class Menus
    {

        public static int RendeMenu(Dictionary<int, MenuItem> _menu)
        {
            MostraMenu(_menu);
            return LeOpcaoMenu(_menu);
        }

        static void MostraMenu(Dictionary<int, MenuItem> _menu)
        {
            foreach (KeyValuePair<int, MenuItem> menuItem in _menu)
            {
                Console.WriteLine("{0} - {1}", menuItem.Key, menuItem.Value.description);
            }
        }

        static int LeOpcaoMenu(Dictionary<int, MenuItem> _menu)
        {
            int opcao;
            MenuItem value;
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

            _menu.TryGetValue(opcao, out value);

            if (value.callback != null)
                value.callback();

            return opcao;
        }
        
     }
}
