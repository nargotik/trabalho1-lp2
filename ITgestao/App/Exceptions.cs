using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITgestao
{
    public class IdDuplicatedException : ApplicationException
    {
        public IdDuplicatedException(string _s = "Id Duplicado") : base(_s)
        {

        }
    }

    public class IdBadException : ApplicationException
    {
        public IdBadException(string _s = "Id não válido") : base(_s)
        {

        }
    }

    public class InitBadException : ApplicationException
    {
        public InitBadException(string _s = "Inicialização do objecto com argumentos em falta") : base(_s)
        {

        }
    }

    public class NotImplementedException : ApplicationException
    {
        public NotImplementedException(string _s = "Não implementado") : base(_s)
        {

        }
    }

    public class InvalidEquipamentoException : ApplicationException
    {
        public InvalidEquipamentoException(string _s = "Não implementado") : base(_s)
        {

        }
    }
}
