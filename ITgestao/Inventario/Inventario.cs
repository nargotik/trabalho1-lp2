using System;
using System.Collections.Generic;
using System.Collections;
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
        private readonly int entidade;

        [NonSerialized]

        Hashtable items = new Hashtable();

        /// <summary>
        /// Construtor que inicializa um inventário
        /// </summary>
        /// <param name="_entidade">Entidade do inventário</param>
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
                try
                {
                    items.Add(((Item)_obj).Id, _obj);
                    SaveData();
                } catch (ArgumentException ex)
                {
                    throw ex;
                } 
                catch (Exception ex)
                {
                    throw ex;
                }

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
            if (Config.Instance.AuthorizedType(_obj) == _obj.GetType())
            {
                // O item existe na hashtable ?
                if (items.Contains(((Item)_obj).Id))
                {

                    // Remove o item ao inventário de items
                    items.Remove(((Item)_obj).Id);
                    SaveData();
                    return true;
                } else
                {
                    return false;
                }
                
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
        /// Devolve um item atravez de um id
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public object GetItemById(int _id)
        {
            if (items.Contains(_id))
            {
                return items[_id];
            } else
            {
                return null;
            }
        }

        /// <summary>
        /// Remove um item do inventário por id
        /// </summary>
        /// <param name="_id">Id do item do inventário a remover</param>
        /// <returns></returns>
        public bool RemoveById(int _id)
        {
            // O item existe na hashtable ?
            if (items.Contains(_id))
            {
                // Remove o item ao inventário de items
                items.Remove(_id);
                SaveData();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Guarda a informação da lista de items no ficheiro presistente
        /// </summary>
        /// <returns></returns>
        private bool SaveData()
        {
            // Console.WriteLine($"DEBUG: {this.InventoryFile} Criado");
            try
            {
                Utils.SerializeHashtable(items, this.InventoryFile);
                return true;
            } catch (Exception ex)
            {
                throw ex;
            }  
        }

        /// <summary>
        /// Carrega o inventário que existe em ficheiro para a memória
        /// </summary>
        /// <returns>verdadeiro ou falso</returns>
        private bool LoadData()
        {
            if (File.Exists(this.InventoryFile))
            {
                // Limpa a hashtable
                this.items.Clear();
                // Load existing data
                this.items = Utils.DeserializeHashtable(this.InventoryFile);
                return true;
            } else
            {
                // Inicializa um novo ficheiro uma vez que não existe
                //SaveData();
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
                return $"{Config.Instance.DataPath}\\inventario_{entidade}.dat";
            }
           
        }

        /// <summary>
        /// Edita um objecto
        /// </summary>
        /// <param name="_obj"></param>
        /// <returns></returns>
        public bool Edita(object _obj)
        {
            if (Config.Instance.AuthorizedType(_obj) == _obj.GetType())
            {
                // O item existe na hashtable ?
                if (this.Remove(_obj))
                {
                    // Caso o objecto seja removido existe logo volta a adicionar
                    this.Adiciona(_obj);
                } else
                {
                    throw new NotExists("Item não encontrado");
                }
            }
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
