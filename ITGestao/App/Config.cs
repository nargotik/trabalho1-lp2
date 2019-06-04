// -------------------------------------------------
// <copyright file="Item.cs" company="IPCA">
// </copyright>
// <summary>
// LP2 - 2018-2019
// <desc>Classe cujo objetivo é armazenar informação necessária para o runtime da aplicação/desc>
// </summary>
//-------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ITgestao.App
{
    /// <summary>
    /// Classe que gere o armanezamento da informação necessária para o runtime da aplicação
    /// </summary>
    /// 
    public sealed class Config
    {
        private string path; // Localização do ficheiro

        private Config()
        {
            this.path = Directory.GetCurrentDirectory();
        }
        private static Config instance = null;
        public static Config Instance
        {
            get
            {
                if (instance == null)
                    instance = new Config();
                return instance;
            }
        }

        private List<Type> allowedtypes = new List<Type>();

        /// <summary>
        /// Permite verificar se o objeto está autorizado a ser adicionado
        /// </summary>
        /// <param name="_obj">Objeto a adicionar</param>
        public void AddAuthorizedType(object _obj)
        {
            // Adiciona o tipo de objecto aos permitidos desde que não exista na lista
            if (AuthorizedType(_obj) != _obj.GetType())
                allowedtypes.Add(_obj.GetType());
        }

        /// <summary>
        /// verifica se o objeto é de um tipo permitido
        /// </summary>
        /// <param name="_obj">Objeto a adicionar</param>
        /// <returns>Tipo permitivo ou NULL</returns>
        public Type AuthorizedType(object _obj)
        {
            // Adiciona o tipo de objecto aos permitidos desde que não exista na lista
            if (allowedtypes.Contains(_obj.GetType()))
            {
                return _obj.GetType();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Retorna o caminho para os ficheiros de dados
        /// </summary>
        public string DataPath
        {
            get
            {
                return this.path;
            }
        } 
    }
}