using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum TipoItem { Rede, Computador, Generico }

namespace ITgestao
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    public sealed class Config
    {
        private Config()
        {
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
        /// 
        /// </summary>
        /// <param name="_obj"></param>
        public void AddAuthorizedType(object _obj)
        {
            // Adiciona o tipo de objecto aos permitidos desde que não exista na lista
            if (AuthorizedType(_obj) != _obj.GetType())
                allowedtypes.Add(_obj.GetType());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_obj"></param>
        /// <returns></returns>
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
    }
}