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

        #region ==================== ATRIBUTOS ====================

        private int id;
        //private int idlocalizacao;
        //private int idcliente;
        //private int tipo;

        // @var passa a true quando o filho informa a base
        private bool initialized = false;
        
        // Armazena o tipo de Item
        private Type tipo;

        #endregion

        #region ==================== GETTERS/SETTERS ====================
        public TipoItem Tipo
        {
            get;
        }

        /// <summary>
        /// Getter de Id
        /// </summary>
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        /// <summary>
        /// Getter de initialized
        /// </summary>
        public bool Initialized
        {
            get
            {
                return this.initialized;
            }
        }

        public int IdLocalizacao
        {
            get
            {
                return this.id;
            }
        }
        #endregion

        #region ==================== CONSTRUCTORS ====================
        /// <summary>
        /// Construtor por defeito
        /// </summary>
        public Item()
        {
            throw new InitBadException("Inicialização do objecto em falha");
        }

        /// <summary>
        /// Construtor de item
        /// </summary>
        /// <param name="_id"></param>
        public Item(int _id = 0)
        {
            if (_id <= 0)
                throw new IdBadException("Id Inválido");
            else
                id = _id;
        }

        #endregion

        #region ==================== PUBLIC METHODS ====================
        /// <summary>
        /// Adiciona um tipo de objecto a ser tratado à class item
        /// </summary>
        /// <param name="_obj">Objecto</param>
        static public void AddAuthorizedType(object _obj)
        {
            Config.Instance.AddAuthorizedType(_obj);
        }

        /// <summary>
        /// Retorna o tipo do objecto inserido caso seja autorizado
        /// </summary>
        /// <param name="_obj">Objecto a testar</param>
        /// <returns>Tipo do objecto inserido / null</returns>
        static public Type AuthorizedType(object _obj)
        {
            return Config.Instance.AuthorizedType(_obj);
        }

        /// <summary>
        /// Adiciona um item a um inventario
        /// </summary>
        /// <param name="_inv">Instancia do Inventário</param>
        /// <returns>True/False</returns>
        public bool AddToInventario(Inventario _inv)
        {
            return _inv.Adiciona(this);
        }

        /// <summary>
        /// Adiciona um item a um inventario
        /// </summary>
        /// <param name="_inv">Id da Instancia do Inventário</param>
        /// <returns>True/False</returns>
        public bool AddToInventario(int _entidade)
        {
            return Inventario.getInstance(_entidade).Remove(this);
        }

        /// <summary>
        /// Remove o item de um inventário
        /// </summary>
        /// <param name="_inv">Instancia do Inventário</param>
        /// <returns>True/False</returns>
        public bool RemoveFromInventario(Inventario _inv)
        {
            return _inv.Remove(this);
        }
        /// <summary>
        /// Remove o item de um inventário
        /// </summary>
        /// <param name="_entidade">Id da Instancia do Inventário</param>
        /// <returns>True/False</returns>
        public bool RemoveFromInventario(int _entidade)
        {
            return Inventario.getInstance(_entidade).Remove(this);
        }

        public void InformBase(Item _item)
        {
            this.tipo = _item.GetType();
            Item.AddAuthorizedType(_item);
            this.initialized = true;
            //Console.WriteLine($"--- {_item.GetType()}");
        }

        #endregion

        #region ==================== PRIVATE METHODS ====================.

        #endregion

        #region ==================== OVERIDES ====================
        /*public sealed override string ToString()
        {
            return this.Id.ToString();
        }*/
        #endregion

        #region @@@@@@@@@@@@@@@@@@@@ TODO @@@@@@@@@@@@@@@@@@@@

        #endregion



    }
}
