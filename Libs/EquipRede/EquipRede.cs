﻿// -------------------------------------------------
// <copyright file="EquipRede.cs" company="IPCA">
// </copyright>
// <summary>
// LP2 - 2018-2019
// <desc>Classe extendida de Item. Permite criar itens do tipo Equipamento de Rede</desc>
// </summary>
//-------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;


namespace ITgestao.ItemsNS
{
    /// <summary>
    /// Classe que trata da informação de um computador
    /// </summary>
    [Serializable]
    public sealed class EquipRede : Item
    {
        #region ==================== ATRIBUTOS ====================
        List<IPAddress> ips = new List<IPAddress>(); // endereços ip
        List<string> macs = new List<string>(); // endereços mac
        private string serial; // Numero de serie
        private DateTime fabrico; // Data de fabrico
        private DateTime aquisicao; // Data de aquisição
        private string descricao;
        private string marca; // Futuramente utilizar um objecto marcas
        private EquipRedeTipos tipoequip;

        public enum EquipRedeTipos { Router, Switch };
        #endregion

        #region ==================== GETTERS/SETTERS ====================
        #endregion

        #region ==================== CONSTRUCTORS ====================
        /// <summary>
        /// Default constructor
        /// </summary>
        public EquipRede() : base(-1)
        {
            base.InformBase(this);
        }
        /// <summary>
        /// Construtor de Computador
        /// </summary>
        /// <param name="_id">Id do equipamento</param>
        /// <param name="_descricao">Descrição do equipamento</param>
        public EquipRede(int _id, EquipRedeTipos _tipo, string _descricao = "") : base(_id)
        {
            // Informa a base que existe um novo item (para a base ter conhecimento dos filhos :))
            base.InformBase(this);

            this.tipoequip = _tipo;
            this.descricao = _descricao;
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

        /// <summary>
        /// Setter/Getter Descricao
        /// </summary>
        public string Descricao
        {
            get
            {
                return descricao;
            }
            set
            {
                descricao = value;
            }
        }

        /// <summary>
        /// Permite verificar a data de aquisição do equipamento
        /// </summary>
        /// <param name="_aquisicao">Data da aquisição do equipamento</param>
        /// <returns>Erro caso a data de aquisição seja superior à data atual senão retorna booleano True</returns>
        public bool DataAquisicaoSet(DateTime _aquisicao)
        {
            if (_aquisicao > DateTime.Now)
            {
                throw new ArgumentException("Data de Aquisicao Inválida");
            }
            else
            {
                aquisicao = _aquisicao;
                return true;
            }
        }

        /// <summary>
        /// Permite a leitura da data de aquisição do equipamento
        /// </summary>
        public DateTime DataAquisicaoGet
        {
            get
            {
                return aquisicao;
            }
        }

        /// <summary>
        /// Permite verificar a data de fabrico do equipamento
        /// </summary>
        /// <param name="_fabrico">Data do fabrico do equipamento</param>
        /// <returns>Erro caso a data de aquisição seja superior à data atual senão retorna booleano True</returns>
        public bool DataFabricoSet(DateTime _fabrico)
        {
            if (_fabrico > DateTime.Now)
            {
                throw new ArgumentException("Data de Fabrico Inválida");
            }
            else
            {
                fabrico = _fabrico;
                return true;
            }
        }

        /// <summary>
        /// Permite a leitura da data de fabrico do equipamento
        /// </summary>
        public DateTime DataFabricoGet
        {
            get
            {
                return fabrico;
            }
        }

        /// <summary>
        /// Setter/Getter Serial
        /// </summary>
        public string Serial
        {
            get
            {
                return serial;
            }
            set
            {
                serial = value;
            }
        }

        /// <summary>
        /// Setter/Getter Marca
        /// </summary>
        public string Marca
        {
            get
            {
                return marca;
            }
            set
            {
                marca = value;
            }
        }

        /// <summary>
        /// Remove um Mac
        /// </summary>
        /// <param name="_mac">MAC Address do equipamento</param>
        /// <returns>Booleano True caso consiga remover mac, senão lança exceção</returns>
        public bool MacRemove(string _mac)
        {
            var _convertedmac = MacConvert(_mac);
            if (MacValid(_convertedmac) && (MacExiste(_convertedmac)))
            {
                macs.Remove(_convertedmac);
                return true;
            }
            else
            {
                throw new ArgumentException("IP Inválido");
            }
        }

        /// <summary>
        /// Insere um MacAddress
        /// </summary>
        /// <param name="_mac">MAC Address do equipamento</param>
        /// <returns>Booleano True caso consiga adicionar mac, senão lança exceção</returns>
        public bool MacInsere(string _mac)
        {
            var _convertedmac = MacConvert(_mac);
            if (MacValid(_convertedmac) && !MacExiste(_convertedmac))
            {
                macs.Add(_convertedmac);
                return true;
            }
            else
            {
                throw new ArgumentException("Mac Inválido");
            }
        }

        /// <summary>
        /// Converte um mac
        /// </summary>
        /// <param name="_mac">Mac Address do equipamento</param>
        /// <returns>Mac convertido</returns>
        private string MacConvert(string _mac)
        {
            _mac.Replace(@"-", string.Empty);
            _mac.Replace(@":", string.Empty);
            return _mac;
        }

        /// <summary>
        /// Valida se um mac Address é válido
        /// </summary>
        /// <param name="_mac">MAC Address do equipamento</param>
        /// <returns>Booleano True caso seja válido, senão booleano False</returns>
        private bool MacValid(string _mac)
        {
            Regex reg = new Regex("^(?:[0-9a-fA-F]{2}:){5}[0-9a-fA-F]{2}|(?:[0-9a-fA-F]{2}-){5}[0-9a-fA-F]{2}|(?:[0-9a-fA-F]{2}){5}[0-9a-fA-F]{2}$");
            if (reg.IsMatch(_mac))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica se um mac existe
        /// </summary>
        /// <param name="_mac">MAC Address do equipamento</param>
        /// <returns>Booleano true caso exista, senão lança exception</returns>
        public bool MacExiste(string _mac)
        {
            var _convertedmac = MacConvert(_mac);
            if (MacValid(_convertedmac))
            {
                return (macs.Contains(_convertedmac));
            }
            else
            {
                throw new ArgumentException("MAC Inválido");
            }
        }

        /// <summary>
        /// Conta o número de MACs existentes
        /// </summary>
        public int MacCount
        {
            get { return macs.Count(); }
        }

        /// <summary>
        /// Insere um ip
        /// </summary>
        /// <param name="_ip">IP</param>
        /// <returns>Booleano true caso inserido, senão lança exception</returns>
        public bool IpInsere(string _ip)
        {
            IPAddress addr;
            if (IpValid(_ip) && ((addr = IpConvert(_ip)) != null) && (!IpExiste(_ip)))
            {
                ips.Add(addr);
                return true;
            }
            else
            {
                throw new ArgumentException("IP Inválido");
            }
        }

        /// <summary>
        /// Remove um Mac
        /// </summary>
        /// <param name="_mac">MAC Address do equipamento</param>
        /// <returns>Booleano True caso removido, senão lança exceção</returns>
        public bool IpRemove(string _ip)
        {
            IPAddress addr;
            if (IpValid(_ip) && ((addr = IpConvert(_ip)) != null) && (IpExiste(_ip)))
            {
                ips.Remove(addr);
                return true;
            }
            else
            {
                throw new ArgumentException("IP Inválido");
            }
        }

        /// <summary>
        /// Conta o numero de ips
        /// </summary>
        public int IpCount
        {
            get { return ips.Count(); }
        }
        
        /// <summary>
        /// Atributo que devolve o tipo de equipamento possivel
        /// </summary>
        public EquipRedeTipos Tipoequip { get => tipoequip; set => tipoequip = value; }

        /// <summary>
        /// Verifica se um ip é valido
        /// </summary>
        /// <param name="_ip">IP</param>
        /// <returns>Booleano True ou False</returns>
        private bool IpValid(string _ip)
        {
            IPAddress addr;
            return (IPAddress.TryParse(_ip, out addr));
        }

        /// <summary>
        /// Converte um IP
        /// </summary>
        /// <param name="_ip">IP</param>
        /// <returns>IP convertido</returns>
        private IPAddress IpConvert(string _ip)
        {
            IPAddress addr;
            IPAddress.TryParse(_ip, out addr);
            return addr;
        }

        /// <summary>
        /// Verifica se um ip existe
        /// </summary>
        /// <param name="_ip">IP</param>
        /// <returns>Booleano True caso exista, senão lança exceção</returns>
        public bool IpExiste(string _ip)
        {
            IPAddress addr;
            if (IpValid(_ip) && ((addr = IpConvert(_ip)) != null))
            {
                return (ips.Contains(addr));
            }
            else
            {
                throw new ArgumentException("IP Inválido");
            }
        }

        /// <summary>
        /// Verifica se é válido o object
        /// </summary>
        /// <returns>true/false</returns>
        public override bool IsValid()
        {
            return (
                (this.IpCount > 0) 
                )
            ;
        }
    }
}