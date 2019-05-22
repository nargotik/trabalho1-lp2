using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// App subclasses
using ITgestao.App;

namespace ITgestao.ItemsNS
{
    [Serializable]
    public abstract class Item
    {
        private int id;
        private int idlocalizacao;
        private int idcliente;

        /// <summary>
        /// 
        /// </summary>
        public Item()
        {
            throw new InitBadException("Inicialização do objecto em falha");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_id"></param>
        public Item(TipoItem _tipo, int _id = 0)

        {

            if (_id <= 0)
            {
                throw new IdBadException("Id Inválido");
            }
            else
            {
                id = _id;
            }
        }

        public TipoItem Tipo
        {
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public int IdLocalizacao
        {
            get
            {
                return this.id;
            }
        }

        static public void AddAuthorizedType(object _obj)
        {
            Config.Instance.AddAuthorizedType(_obj);
        }

        static public Type AuthorizedType(object _obj)
        {
            return Config.Instance.AuthorizedType(_obj);
        }

        public sealed override string ToString()
        {
            return this.Id.ToString();
        }

        


    }
}
