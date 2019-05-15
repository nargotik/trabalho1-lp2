using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
