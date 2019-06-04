using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilsNS;

namespace UI.Cli
{
    public class MenuOpcao
    {
        public string Nome { get; private set; }
        public Action Callback { get; private set; }

        public MenuOpcao(string _nome, Action _callback)
        {
            Nome = _nome;
            Callback = _callback;
        }
    }
}
