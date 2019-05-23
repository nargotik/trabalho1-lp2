using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITgestao.ItemsNS
{
    [Serializable]
    public sealed class Generico : Item
    {
        private string serial;
        public Generico(int _id = 0, string _serial = "123") : base(_id)
        {
            // Informa a base que existe um novo item (para a base ter conhecimento dos filhos :))
            base.InformBase(this);

            this.serial = _serial;
        }

        public string Serial
        {

            get { return this.serial; }
            set { this.serial = value; }
        }

        

    }
}