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
    static public class Utils
    {
        public static bool HasMethod(this object objectToCheck, string methodName)
        {
            try
            {
                var type = objectToCheck.GetType();
                return type.GetMethod(methodName) != null;
            }
            catch (Exception ex)
            {
                return true;
            }
        }



        public static void SerializeHashtable(this Hashtable list, string fileName)
        {
            var serializador = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            serializador.Serialize(stream, list);
            stream.Close();
        }

        /// <summary>
        /// Serializador 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Hashtable DeserializeHashtable(string fileName)
        {
            using (Stream stream = File.Open(fileName, FileMode.Open))
            {
                var serializador = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (Hashtable)serializador.Deserialize(stream);
            }
            
        }
    }
}
