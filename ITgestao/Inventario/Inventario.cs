using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ITgestao.App;
using ITgestao.ItemsNS;
using UtilsNS;

namespace ITgestao
{


    /// <summary>
    /// Classe que irá conter o inventário de uma determinada entidade/empresa
    /// </summary>
    [Serializable]
    public class Inventario
    {


        private int entidade;

        [NonSerialized]
        private string data;

        List<object> items = new List<object>();

        /// <summary>
        /// Construtor que inicializa um inventário
        /// </summary>
        /// <param name="_entidade">Entidade do inevtário</param>
        public Inventario(int _entidade = 0)
        {
            if (_entidade < 0)
            {
                throw new IdBadException("Entidade Inválida");
            } else
            {
                // Verifica se a entidade já contem dados armazenados em ficheiro serialized
                LoadData();
                this.entidade = _entidade;
            }
                
            
        }

        /// <summary>
        /// Adiciona um item ao inventário
        /// </summary>
        /// <param name="_obj">Objecto a adicionar</param>
        /// <returns>boolean value</returns>
        public bool Adiciona(object _obj)
        {
            if (Config.Instance.AuthorizedType(_obj) == _obj.GetType())
            {
                // Adiciona o item ao inventário de items
                items.Add(_obj);
                SaveData();
                return true;
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
        }

        /// <summary>
        /// Remove um item do inventário
        /// </summary>
        /// <param name="_obj"></param>
        /// <returns></returns>
        public bool Remove(object _obj)
        {
            // @todo
            return true;
        }

        private bool SaveData()
        {
            // Console.WriteLine($"DEBUG: {this.InventoryFile} Criado");
            try
            {
                Utils.SerializeList(items, this.InventoryFile);
            } catch (InvalidOperationException ex)
            {
                throw ex;
            }
            
            return true;
        }

        /// <summary>
        /// Carrega o inventário que existe em ficheiro para a memória
        /// </summary>
        /// <returns>verdadeiro ou falso</returns>
        private bool LoadData()
        {
            if (File.Exists(this.InventoryFile))
            {
                Console.WriteLine($"DEBUG: {this.InventoryFile} Lido");
                // Load existing data
                Utils.DeserializeList(this.items, this.InventoryFile);
                return true;
            } else
            {
                // Inicializa um novo ficheiro uma vez que não existe
                SaveData();
                return false;
            }
            
            
            
        }

        /// <summary>
        /// Devolve o nome do ficheiro que irá armazenar o inventário da entidade
        /// </summary>
        /// <returns>Caminho do ficheiro</returns>
        private string InventoryFile
        {
            get {
                return $"{Config.Instance.Path}\\inventario_{entidade}.dat";
            }
           
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
                return entidade;
            }
        }

    }

}
