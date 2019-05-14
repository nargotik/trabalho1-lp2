using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITgestao
{
    /// <summary>
    /// Objecto que trata da informação de um equipamento de Rede
    /// </summary>
    public sealed class Rede : Item
    {

        public Rede(int _id = 0, string _serial = "123") : base(TipoItem.Rede, _id)
        {
            Config.Instance.AddAuthorizedType(this);

            this.Serial = _serial;

        }

        public string Serial
        {
            get; private set;
        }

    }
}
