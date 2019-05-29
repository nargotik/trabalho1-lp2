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
        private string descricao;
        public Generico(int _id = 0, string _descricao = "") : base(_id)
        {
            // Informa a base que existe um novo item (para a base ter conhecimento dos filhos :))
            base.InformBase(this);

            this.descricao = _descricao;
        }

        /// <summary>
        /// Devolve a Descrição
        /// </summary>
        public string Descricao
        {

            get { return this.descricao; }
            set { this.descricao = value; }
        }

        /// <summary>
        /// Verifica se é válido o object
        /// </summary>
        /// <returns>true/false</returns>
        public override bool IsValid()
        {
            return (this.Id > 0);
        }

    }
}