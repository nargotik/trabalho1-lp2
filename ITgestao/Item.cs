using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITgestao
{
    [Serializable]
    public class Item
    {
        private int id;

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
        public Item(TipoItem _tipo, int _id = 10)

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

        

    }
}
