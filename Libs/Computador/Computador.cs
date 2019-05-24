using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITgestao.ItemsNS;

namespace ITgestao.ItemsNS
{

    /// <summary>
    /// Classe que trata da informação de um computador
    /// </summary>
    [Serializable]
    public sealed class Computador : Item
    {


        #region ==================== ATRIBUTOS ====================

        private int ram; // MB
        private int disco; // MB
        private string[] ips; // endereços ip
        private string[] macs; // enderecos mac

        #endregion

        #region ==================== GETTERS/SETTERS ====================
        #endregion

        #region ==================== CONSTRUCTORS ====================
        /// <summary>
        /// Construtor de um Computador
        /// </summary>
        public Computador(int _id = 0, string _serial = "123") : base(_id)
        {
            // Informa a base que existe um novo item (para a base ter conhecimento dos filhos :))
            base.InformBase(this);

            this.Serial = _serial;

        }
        #endregion

        #region ==================== PUBLIC METHODS ====================
        #endregion

        #region ==================== PRIVATE METHODS ====================
        #endregion

        #region ==================== OVERIDES ====================
        #endregion

        #region @@@@@@@@@@@@@@@@@@@@ TODO @@@@@@@@@@@@@@@@@@@@
        #endregion



        public string Serial
        {
            get; private set;
        }

    }
}