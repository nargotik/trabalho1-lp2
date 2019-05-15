using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGestao.ClientesNS
{
    class Cliente
    {
        private int id;
        private string nome;
        private string apelido;

        public int Id
        {
            set
            {
                id = value;
            }
        }
    }
}
