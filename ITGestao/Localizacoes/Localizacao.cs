// -------------------------------------------------
// <copyright file="Localizacao.cs" company="IPCA">
// </copyright>
// <summary>
// LP2 - 2018-2019
// <desc>Classe responsável pela identificação de uma Localização</desc>
// </summary>
//-------------------------------------------------

namespace ITgestao.LocalizacoesNS
{
    class Localizacao
    {
        private int id;
        private double lat;
        private double lon;

        /// <summary>
        /// Define qual o valor de ID
        /// </summary>
        public int Id
        {
            set
            {
                id = value;
            }
        }
    }
}
