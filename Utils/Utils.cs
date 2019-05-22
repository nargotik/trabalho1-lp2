using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace UtilsNS
{
    /// <summary>
    /// Classe com utilitários a serem usados pelo programa
    /// </summary>
    static public class Utils
    {
        /// <summary>
        /// Metodo que verifica se um determinado metodo dando uma string existe.
        /// </summary>
        /// <param name="objectToCheck">Objecto a ser verificado</param>
        /// <param name="methodName">Nome do método (string)</param>
        /// <returns></returns>
        public static bool HasMethod(this object _objectToCheck, string _methodName)
        {
            try
            {
                var type = _objectToCheck.GetType();
                return type.GetMethod(_methodName) != null;
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        /// <summary>
        /// Serializa uma hashtable e grava em ficheiro
        /// </summary>
        /// <param name="list">Hashtable a serializar</param>
        /// <param name="fileName">Nome do ficheiro a gravar</param>
        public static void SerializeHashtable(this Hashtable _list, string _fileName)
        {
            var serializador = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            Stream stream = new FileStream(_fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            serializador.Serialize(stream, _list);
            stream.Close();
        }

        /// <summary>
        /// DesSerializador de Hashtable
        /// </summary>
        /// <param name="_fileName">Nome do ficheiro</param>
        /// <returns></returns>
        public static Hashtable DeserializeHashtable(string _fileName)
        {
            using (Stream stream = File.Open(_fileName, FileMode.Open))
            {
                var serializador = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (Hashtable)serializador.Deserialize(stream);
            }
            
        }
    }
}
