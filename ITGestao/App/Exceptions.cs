// -------------------------------------------------
// <copyright file="Item.cs" company="IPCA">
// </copyright>
// <summary>
// LP2 - 2018-2019
// <desc>Classes que permitem lidar com erros que ocorrem durante a execução da aplicação</desc>
// </summary>
//-------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITgestao
{
    /// <summary>
    /// Impede a existência de ID duplicados
    /// </summary>
    public class IdDuplicatedException : ApplicationException
    {
        public IdDuplicatedException(string _s = "Id Duplicado") : base(_s)
        {
            // Exeption
        }
    }

    /// <summary>
    /// Evita a inserção de ID inválido
    /// </summary>
    public class IdBadException : ApplicationException
    {
        public IdBadException(string _s = "Id não válido") : base(_s)
        {
            // Exeption
        }
    }

    /// <summary>
    /// Impede a iniciação de objetos com argumentos em falta
    /// </summary>
    public class InitBadException : ApplicationException
    {
        public InitBadException(string _s = "Inicialização do objecto com argumentos em falta") : base(_s)
        {
            // Exeption
        }
    }

    /// <summary>
    /// Evita a inserção de Itens inválidos
    /// </summary>
    public class ItemInvalido : ApplicationException
    {
        public ItemInvalido(string _s = "Item Inválido") : base(_s)
        {
            // Exeption
        }
    }

    /// <summary>
    /// Indica que não foi possível efetuar o pedido solicitado
    /// </summary>
    public class NotImplementedException : ApplicationException
    {
        public NotImplementedException(string _s = "Não implementado") : base(_s)
        {
            // Exeption
        }
    }

    /// <summary>
    /// Impede a manipulação de um Equipamento inválido
    /// </summary>
    public class InvalidEquipamentoException : ApplicationException
    {
        public InvalidEquipamentoException(string _s = "Não implementado") : base(_s)
        {
            // Exeption
        }
    }

    /// <summary>
    /// Informa que o item não existe
    /// </summary>
    public class NotExists : ApplicationException
    {
        public NotExists(string _s = "Item não existe") : base(_s)
        {
            // Exeption
        }
    }
}
