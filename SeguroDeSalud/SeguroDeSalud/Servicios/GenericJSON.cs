using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.Servicios
{
    class GenericJSON<T>
    {
        /// <summary>
        /// El Generic para la deserializacion del API
        /// </summary>
        /// <param name="JSON"></param>
        /// Recibe un JSON 
        /// <returns></returns>
        public static T JSONToObject(string JSON)
        {
            return JsonConvert.DeserializeObject<T>(JSON);
        }
    }
}