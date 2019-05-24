using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace UtilsNS
{
    /// <summary>
    /// Classe com utilitários a serem usados pelo programa
    /// </summary>
    static public class Utils
    {
        public enum MedidasMemoria
        {
            B, MB, GB, TB
        }

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
        /// Serializador de Dictionary
        /// </summary>
        /// <typeparam name="Object"></typeparam>
        /// <param name="_dictionary">Dictionary</param>
        /// <param name="_fileName">Nome do Ficheiro</param>
        public static void Serialize<Object>(Object _dictionary, string _fileName)
        {
            Stream stream = new FileStream(_fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            try 
            {
                using (stream)
                {
                    // create BinaryFormatter
                    BinaryFormatter bin = new BinaryFormatter();
                    // serialize the collection (dictionary) to file (stream)
                    bin.Serialize(stream, _dictionary);
                }
            }
            catch (IOException)
            {
            }
        }

        /// <summary>
        /// DesSerializador de Dictionary
        /// </summary>
        /// <typeparam name="Object"></typeparam>
        /// <param name="_fileName">Nome do Ficheiro</param>
        public static Object Deserialize<Object>(string _fileName) where Object : new()
        {
            Object ret= (Object)Activator.CreateInstance(typeof(Object));
            try
            {
                using (Stream stream = File.Open(_fileName, FileMode.Open))
                {
                    // create BinaryFormatter
                    BinaryFormatter bin = new BinaryFormatter();
                    // deserialize the collection (Employee) from file (stream)
                    ret = (Object)bin.Deserialize(stream);
                }
            }
            catch (IOException)
            {
            }
            return ret;
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

        /// <summary>
        /// Converte entre bases de memória em Bytes
        /// </summary>
        /// /// <param name="_valor">Valor a converter </param>
        /// <param name="_from">Medida de entreda</param>
        /// <param name="_to">Medida de Saída (Default MB)</param>
        /// <returns>Valor inteiro na medido de saida</returns>
        public static int ConverteMemoria(
            int _valor, 
            MedidasMemoria _from, 
            MedidasMemoria _to = MedidasMemoria.MB
            )
        {
            if (_valor == 0)
                return 0;
            int re = (int)_to - (int)_from;
            int conv = (int)Math.Pow(1024, re);
            if (re == 0)
            {
                // Não ha conversao
                return _valor;
            } else if (re > 0)
            {
                // Conversao para cima (multiplica)
                return _valor / conv;
            } else
            {
                // Conversao para baixo (divide)
                return _valor * conv;
            }
        }
    }
}