using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITgestao.App;
using ITgestao.ItemsNS;
namespace ITgestao
{


    /// <summary>
    /// 
    /// </summary>
    public class Inventario
    {


        private int empresa;
        List<object> items = new List<object>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="empresa"></param>
        public Inventario(int _empresa = 0)
        {
            if (_empresa < 0)
                throw new IdBadException("Id Inválido");
            this.empresa = _empresa;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_obj"></param>
        /// <returns></returns>
        public bool Adiciona(object _obj)
        {
            if (Config.Instance.AuthorizedType(_obj) == _obj.GetType())
            {
                // Adiciona o item ao inventário de items
                items.Add(_obj);
            }
            else if (!(_obj.GetType().IsAssignableFrom(typeof(Item))))
            {
                // A classe objecto não é ascendente de Equipamento
                throw new InvalidEquipamentoException("Objecto não é um item");
            }
            else
            {
                // Not implemented object
                throw new NotImplementedException("Objecto a adicionar no inventário não implementado");
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_obj"></param>
        /// <returns></returns>
        public bool Remove(object _obj)
        {
            // @todo
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_obj"></param>
        /// <returns></returns>
        public bool Edita(object _obj)
        {
            // @todo
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Empresa
        {
            get
            {
                return empresa;
            }
        }

    }

}
