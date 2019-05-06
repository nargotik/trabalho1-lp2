using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITgestao
{
    class IdDuplicatedException : ApplicationException
    {
        public IdDuplicatedException(string _s = "Id Duplicado") : base(_s)
        {

        }
    }

    class IdBadException : ApplicationException
    {
        public IdBadException(string _s = "Id não válido") : base(_s)
        {

        }
    }

    class InitBadException : ApplicationException
    {
        public InitBadException(string _s = "Inicialização do objecto com argumentos em falta") : base(_s)
        {

        }
    }

    class NotImplementedException : ApplicationException
    {
        public NotImplementedException(string _s = "Não implementado") : base(_s)
        {

        }
    }

    class InvalidEquipamentoException : ApplicationException
    {
        public InvalidEquipamentoException(string _s = "Não implementado") : base(_s)
        {

        }
    }
}
