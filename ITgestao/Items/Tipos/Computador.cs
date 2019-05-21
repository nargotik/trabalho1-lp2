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
    public sealed class Computador : Item
    {

        /// <summary>
        /// teste
        /// </summary>
        public Computador(int _id = 0, string _serial = "123") : base(TipoItem.Computador, _id)
        {
            Item.AddAuthorizedType(this);
            this.Serial = _serial;

        }

        public string Serial
        {
            get; private set;
        }

    }
}