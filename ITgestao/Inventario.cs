using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITgestao
{
    class Inventario
    {
        List<Equipamento> equipamentos = new List<Equipamento>();
        Inventario ()
        {

        }
    }

    public class Equipamento
    {
        public int id;
        public int localizacao;

    }

    class Rede:Equipamento
    {

    }

    class Computador:Equipamento
    {

    }

    class Impressora:Equipamento
    {

    }

}
