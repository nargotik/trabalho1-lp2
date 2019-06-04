using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilsNS
{
    /// <summary>
    /// Classe que lê valores da consola
    /// </summary>
    public static class Input
    {
        /// <summary>
        /// Lê um inteiro entre _min e _max
        /// </summary>
        /// <param name="_texto">Texto a Mostrar</param>
        /// <param name="_min">Valor Minimo</param>
        /// <param name="_max">Valor Máximo</param>
        /// <returns>Inteiro válido lido</returns>
        public static int LeInt(string _texto, int _min, int _max)
        {
            Output.MostraTexto(_texto);
            return LeInt(_min, _max);
        }

        /// <summary>
        /// Lê um inteiro entre _min e _max
        /// </summary>
        /// <param name="_min">Valor Minimo</param>
        /// <param name="_max">Valor Máximo</param>
        /// <returns>Inteiro válido lido</returns>
        public static int LeInt(int _min, int _max)
        {
            int value = LeInt();

            while (value < _min || value > _max)
            {
                Output.MostraTexto($"Insira valor entre {_min} e {_max}!:");
                value = LeInt();
            }

            return value;
        }

        /// <summary>
        /// Lê um inteiro
        /// </summary>
        /// <returns></returns>
        public static int LeInt()
        {
            string input = Console.ReadLine();
            int valor;

            while (!int.TryParse(input, out valor))
            {
                Output.MostraTexto("Valor inválido repita:");
                input = Console.ReadLine();
            }

            return valor;
        }

        /// <summary>
        /// Le uma string
        /// </summary>
        /// <param name="_texto"></param>
        /// <returns></returns>
        public static string LeString(string _texto = "")
        {
            Output.MostraTexto(_texto);
            return Console.ReadLine();
        }

    }
}
