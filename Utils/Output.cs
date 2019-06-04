// -------------------------------------------------
// <copyright file="Output.cs" company="IPCA">
// </copyright>
// <summary>
// LP2 - 2018-2019
// <desc></desc>
// </summary>
//-------------------------------------------------

using System;

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
