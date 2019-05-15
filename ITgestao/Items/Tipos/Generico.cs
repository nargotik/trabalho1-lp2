using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITgestao.ItemsNS
{
    public sealed class Generico : Item
    {

        public Generico(int _id = 0, string _serial = "123") : base(TipoItem.Generico, _id)
        {
            Item.AddAuthorizedType(this);
        }

    }
}