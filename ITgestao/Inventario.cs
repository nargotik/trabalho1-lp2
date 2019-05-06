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
    class Equipamento
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
        public Equipamento(int _id = 10)

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

    }

    /// <summary>
    /// 
    /// </summary>
    class Rede:Equipamento
    {
        public string serial;
        public Rede(int _id = 0, string _serial="123") : base(_id)
        {
            serial = _serial;
        }

        public bool Adiciona()
        {
            return true;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class Computador:Equipamento
    {

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
        int empresa;
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
        public bool Add(object _obj)
        {
            if (_obj is Rede) {
                Console.WriteLine("Rede a Adicionar...");
            } else if (_obj is Computador) {
                Console.WriteLine("Computador a Adicionar...");
            } else {
                throw new NotImplementedException("Objecto a adicionar no inventário não implementado");
            }
            
            return true;
        }
    }

}
