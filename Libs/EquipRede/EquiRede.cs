using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITgestao.ItemsNS
{
    /// <summary>
    /// Classe que trata da informação de um computador
    /// </summary>
    [Serializable]
    public sealed class Rede : Item
    {
        public Rede(int _id = 0, string _serial = "0") : base(_id)
        {
            // Informa a base que existe um novo item (para a base ter conhecimento dos filhos :))
            base.InformBase(this);

            this.Serial = _serial;
        }

        public string Serial
        {
            get; private set;
        }
    }
}