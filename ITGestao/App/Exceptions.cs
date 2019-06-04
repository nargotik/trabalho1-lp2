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
            // Exeption
        }
    }

    public class IdBadException : ApplicationException
    {
        public IdBadException(string _s = "Id não válido") : base(_s)
        {
            // Exeption
        }
    }

    public class InitBadException : ApplicationException
    {
        public InitBadException(string _s = "Inicialização do objecto com argumentos em falta") : base(_s)
        {
            // Exeption
        }
    }

    public class ItemInvalido : ApplicationException
    {
        public ItemInvalido(string _s = "Item Inválido") : base(_s)
        {
            // Exeption
        }
    }

    public class NotImplementedException : ApplicationException
    {
        public NotImplementedException(string _s = "Não implementado") : base(_s)
        {
            // Exeption
        }
    }

    public class InvalidEquipamentoException : ApplicationException
    {
        public InvalidEquipamentoException(string _s = "Não implementado") : base(_s)
        {
            // Exeption
        }
    }

    public class NotExists : ApplicationException
    {
        public NotExists(string _s = "Item não existe") : base(_s)
        {
            // Exeption
        }
    }
}
