﻿// -------------------------------------------------
// <copyright file="Item.cs" company="IPCA">
// </copyright>
// <summary>
// LP2 - 2018-2019
// <desc>Classe com função de armazenar e tratar objetos do tipo Item/desc>
// </summary>
//-------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
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
        #region ==================== ATRIBUTOS ====================
        private readonly int entidade;

        private const int entidadePredefinida = 0;

        /// <summary>
        /// Hashtable que guarda as instancias da classe inicializadas
        /// </summary>
        static Dictionary<int, Inventario> instancias = new Dictionary<int, Inventario>();

        /// <summary>
        /// Hashtable que guarda os items
        /// </summary>
        Dictionary<int, Object> items = new Dictionary<int, Object>();
        #endregion

        #region ==================== GETTERS/SETTERS ====================
        /// <summary>
        /// Devolve o total de items no inventario
        /// </summary>
        public int TotalItems
        {
            get { return items.Count(); }
        }

        /// <summary>
        /// Getter de Entidade
        /// </summary>
        public int Empresa
        {
            get
            {
                return entidade;
            }
        }
        #endregion

        #region ==================== CONSTRUCTORS ====================

        /// <summary>
        /// Construtor que inicializa um inventário
        /// </summary>
        /// <param name="_entidade">Entidade do inventário</param>
        private Inventario(int _entidade = entidadePredefinida)
        {
            if (_entidade < 0)
            {
                throw new IdBadException("Entidade Inválida");
            }
            else
            {
                // Verifica se a entidade já contem dados armazenados em ficheiro serialized
                LoadData();
                this.entidade = _entidade;
            }
        }

        /// <summary>
        /// Metodo de implementação singleton de instancias com um parametro
        /// O parametro deve ser o id da entidade do inventario
        /// </summary>
        /// <param name="_entidade">Entidade do inventário</param>
        /// <returns>Entidade do inventário</returns>
        public static Inventario getInstance(int _entidade = entidadePredefinida)
        {
            if (!instancias.ContainsKey(_entidade))
            {
                instancias.Add(
                    _entidade,
                    new Inventario(_entidade)
                    );
            }
            return (instancias[_entidade] as Inventario);
        }
        #endregion

        #region ==================== PUBLIC METHODS ====================

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
                    if (!(_obj as Item).IsValid())
                    {
                        throw new ItemInvalido("Item a adicionar inválido");
                    }
                    items.Add(((Item)_obj).Id, (Item)_obj);
                    SaveData();
                }
                catch (ArgumentException ex)
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
        /// <param name="_obj">Objeto a a remover</param>
        /// <returns>boolean Value</returns>
        public bool Remove(object _obj)
        {
            if (Config.Instance.AuthorizedType(_obj) == _obj.GetType())
            {
                // O item existe na hashtable ?
                if (items.ContainsKey(((Item)_obj).Id))
                {
                    // Remove o item ao inventário de items
                    items.Remove(((Item)_obj).Id);
                    SaveData();
                    return true;
                }
                else
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
        /// Devolve um item atraves de um id
        /// </summary>
        /// <param name="_id">ID do item</param>
        /// <returns>Item correspondente ao ID ou NULL</returns>
        public object GetItemById(int _id)
        {
            if (items.ContainsKey(_id))
            {
                return items[_id];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Remove um item do inventário por id
        /// </summary>
        /// <param name="_id">Id do item do inventário a remover</param>
        /// <returns>Boolean Value</returns>
        public bool RemoveById(int _id)
        {
            // O item existe na hashtable ?
            if (items.ContainsKey(_id))
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
        /// Remove todos os items do inventário
        /// </summary>
        public void RemoveAll()
        {
            items.Clear();
            SaveData();
        }

        /// <summary>
        /// Edita um objecto
        /// </summary>
        /// <param name="_obj">Objeto a editar</param>
        /// <returns>Boolean Value or exception</returns>
        public bool Edita(Item _obj)
        {
            if (Config.Instance.AuthorizedType(_obj) == _obj.GetType())
            {
                // O item existe na hashtable ?
                if (this.Remove(_obj))
                {
                    // Caso o objecto seja removido existe logo volta a adicionar
                    this.Adiciona(_obj);
                    return true;
                }
                else
                {
                    throw new NotExists("Item não encontrado");
                }
            }
            else
            {
                throw new NotImplementedException("Objecto a adicionar no inventário não implementado");
            }
        }
        #endregion

        #region ==================== PRIVATE METHODS ====================
        /// <summary>
        /// Guarda a informação da lista de items no ficheiro presistente
        /// </summary>
        /// <returns>Boolean Value</returns>
        private bool SaveData()
        {
            // Console.WriteLine($"DEBUG: {this.InventoryFile} Criado");
            try
            {
                //Utils.SerializeHashtable(items, this.InventoryFile);
                Utils.Serialize(items, this.InventoryFile);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Carrega o inventário que existe em ficheiro para a memória
        /// </summary>
        /// <returns>Boolean Value</returns>
        private bool LoadData()
        {
            if (File.Exists(this.InventoryFile))
            {
                // Limpa a hashtable
                this.items.Clear();
                // Load existing data
                Dictionary<int, object> deserializeObject = 
                    Utils.Deserialize<Dictionary<int, object>>(
                        this.InventoryFile
                        );
                //this.items = Utils.DeserializeHashtable(this.InventoryFile);
                return true;
            }
            else
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
            get
            {
                return Config.Instance.DataPath + "\\inventario_" + entidade + ".dat";
            }
        }
        #endregion

        #region ==================== OVERIDES ====================
        #endregion

        #region @@@@@@@@@@@@@@@@@@@@ TODO @@@@@@@@@@@@@@@@@@@@
        #endregion
    }
}