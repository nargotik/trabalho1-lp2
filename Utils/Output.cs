using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilsNS
{
    /// <summary>
    /// Classe que escreve valores para a consola
    /// </summary>
    public static class Output
    {
        /// <summary>
        /// Mostra um texto na consola (Sem nova linha)
        /// </summary>
        /// <param name="_texto">Texto a mostrar</param>
        public static void MostraTexto(string _texto)
        {
            Console.Write(_texto);
        }

        /// <summary>
        /// Mostra um texto na consola em uma nova linha
        /// </summary>
        /// <param name="_texto">Texto a Mostrar</param>
        public static void MostraLinha(string _texto)
        {
            Console.WriteLine(_texto);
        }
    }
}
