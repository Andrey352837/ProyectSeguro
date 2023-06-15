using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.Servicios
{
    class ServicioBCCRApi
    {
        /// <summary>
        /// Metodo de obtencion del valor del dolar de un dia en especifico
        /// </summary>
        /// <returns></returns>
        public static float ObtenerMontoVentaDolar()
        {
            try
            {
                HttpClient client = new HttpClient();
                string path = "";
                string json = "";

                path = @"https://tipodecambio.paginasweb.cr/api";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                json = sr.ReadToEnd();

                return GenericJSON<DatosJSON>.JSONToObject(json).venta;
            }
            catch (Exception er)
            {
                throw er;
            }
        }
    }
}
