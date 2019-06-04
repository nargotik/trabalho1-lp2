// -------------------------------------------------
// <copyright file="Localizacoes.cs" company="IPCA">
// </copyright>
// <summary>
// LP2 - 2018-2019
// <desc>Classe responsável por gerir as localizações</desc>
// </summary>
//-------------------------------------------------

using System.Collections.Generic;


namespace ITgestao.LocalizacoesNS
{
    class Localizacoes
    {
        private List<Localizacao> localizacoes = new List<Localizacao>();
        /// <summary>
        /// Adiciona Localização
        /// </summary>
        /// <param name="_obj"></param>
        /// <returns></returns>
        public bool Adiciona(object _obj)
        {
            // @todo
            return false;
        }
        /// <summary>
        /// Remove Localização
        /// </summary>
        /// <param name="_obj">Localização a remover</param>
        /// <returns>Boolean Value</returns>
        public bool Remove(object _obj)
        {
            // @todo
            return false;
        }
        /// <summary>
        /// Edita Localização
        /// </summary>
        /// <param name="_obj">Localização a editar</param>
        /// <returns>Boolean Value</returns>
        public bool Edita(object _obj)
        {
            // @todo
            return false;
        }

        /// <summary>
        /// Procura por localização
        /// </summary>
        /// <param name="_id">Localização</param>
        /// <returns>Nova instancia de Localização</returns>
        public Localizacao Procura(int _id)
        {
            // @todo
            return new Localizacao();
        }
    }
}
