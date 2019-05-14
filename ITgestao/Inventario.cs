using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

        public void AddAuthorizedType(object _tipo)
        {
            // Adiciona o tipo de objecto aos permitidos desde que não exista na lista
            if (AuthorizedType(_tipo) != _tipo.GetType())
                allowedtypes.Add(_tipo.GetType());
        }

        public Type AuthorizedType(object _tipo)
        {
            // Adiciona o tipo de objecto aos permitidos desde que não exista na lista
            if (allowedtypes.Contains(_tipo.GetType()))
            {
                return _tipo.GetType();
            } else
            {
                return null;
            }
        }
    }

    public enum TipoEquipamento { Rede, Computador }
    [Serializable]
    public class Equipamento
    {
        

        int id;
        int localizacao;

        /// <summary>
        /// 
        /// </summary>
        public Equipamento()
        {
            throw new InitBadException("Inicialização do objecto em falha");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_id"></param>
        public Equipamento(TipoEquipamento _tipo, int _id = 10)

        {

            if (_id <= 0)
            {
                throw new IdBadException("Id Inválido");
            }
            else
            {
                id = _id;
            }
        }

        public TipoEquipamento Tipo
        {
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        [Serializable]
        public class Rede : Equipamento
        {
            public string serial;
            public Rede(int _id = 0, string _serial = "123") : base(TipoEquipamento.Rede, _id)
            {
                serial = _serial;
            }

        }

    }

    /// <summary>
    /// 
    /// </summary>


    /// <summary>
    /// 
    /// </summary>
    public sealed class Computador : Equipamento
    {

        public Computador(int _id = 0, string _serial = "123") : base(TipoEquipamento.Computador, _id)
        {
            Config.Instance.AddAuthorizedType(this);

            this.Serial = _serial;

        }

        public string Serial
        {
            get; private set;
        }

    }

    public sealed class Periferico : Equipamento
    {
        public Periferico(int _id = 0, string _serial = "123") : base(TipoEquipamento.Computador, _id)
        {
            Serial = _serial;
        }

        public string Serial
        {
            get; private set;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class Impressora:Equipamento
    {

    }

    /// <summary>
    /// 
    /// </summary>
    class Inventario
    {
        

        private int empresa;
        List<Equipamento> equipamentos = new List<Equipamento>();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="empresa"></param>
        public Inventario(int empresa = 0)
        {
  
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
                Console.WriteLine("Adicionar algo...");
            } else
            {
                // Not implemented object
                throw new NotImplementedException("Objecto a adicionar no inventário não implementado");
            }


            if (!(_obj.GetType().IsAssignableFrom(typeof(Equipamento))))
            {
                // A classe objecto não é ascendente de Equipamento
                throw new InvalidEquipamentoException("Objecto não é um equipamento");

            } else if (_obj is Equipamento.Rede) {
                // O objecto passado é de rede
                Console.WriteLine("Rede a Adicionar...");
            } else if (_obj is Computador) {
                // Adiciona na lista de Computadores
                Console.WriteLine("Computador a Adicionar...");
            } else {
                
            }
            
            return true;
        }
    }

}
