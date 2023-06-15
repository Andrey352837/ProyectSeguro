using SeguroDeSalud.DAL;
using SeguroDeSalud.Entities;
using SeguroDeSalud.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroDeSalud.BLL
{
    /// <summary>
    /// Clase donde se trabaja la logica de FacturaEncabezado 
    /// </summary>
    class BLLFacturaEncabezado
    {
        public float montoCobertura { get; set; }
        public float montoPoliza { get; set; }
        public float montoTipoPlan { get; set; }
        public float prima { get; set; }
        public float MontoAsegurado { get; set; }
        public float MontoSeguro { get; set; }

        private static readonly log4net.ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        DALFacturaEncabezado nuevoEncabezadoFactura = new DALFacturaEncabezado();
        /// <summary>
        /// Guarda la factura en la base de datos
        /// </summary>
        /// <param name="oFacturaEncabezado"></param>
        /// se envia el objeto tipo factura a al DAL 
        public void GuardarFactura(FacturaEncabezado oFacturaEncabezado)
        {
            nuevoEncabezadoFactura.Insertar(oFacturaEncabezado);
        }

      


        /// <summary>
        /// Se busca cual es el siguiente codigo en la factura para poder cargar el QR         
        /// </summary>
        /// <returns></returns>
        public static int SiguienteCodigoFactura()
        {
            try
            {

                DALFacturaEncabezado nueva = new DALFacturaEncabezado();
                return nueva.SiguienteCodigoFactura();
            }
            catch (Exception er)
            {
                throw;
            }
        }
        /// <summary>
        /// Validador que si la tarjeta es valida o no 
        /// </summary>
        /// <param name="pNumeroTarjeta"></param>
        /// <returns></returns>
        public static bool ValidarNumeroTarjeta(string pNumeroTarjeta)
        {


            StringBuilder digitsOnly = new StringBuilder();

            foreach (char c in pNumeroTarjeta.Where(c => char.IsDigit(c)))
            {
                digitsOnly.Append(c);
            }

            if (digitsOnly.Length > 18 || digitsOnly.Length < 15) return false;

            int suma = 0;
            int digito = 0;
            int sumando = 0;
            bool validar = false;

            for (int i = digitsOnly.Length - 1; i >= 0; i--)
            {
                digito = Int32.Parse(digitsOnly.ToString(i, 1));
                if (validar)
                {
                    sumando = digito * 2;
                    if (sumando > 9)
                        sumando -= 9;
                }
                else
                    sumando = digito;

                suma += sumando;

                validar = !validar;

            }
            return (suma % 10) == 0;
        }
        /// <summary>
        /// SumaTotalBruto() Calcula la suma de todos los montos
        /// </summary>
        /// <returns></returns>
        public float SumaTotalBruto( )
        {
            return montoCobertura + montoPoliza+ MontoSeguro + montoTipoPlan + prima + MontoAsegurado;
        }
        /// <summary>
        ///  CovertidorDolaresBruto() Calcula agarra el monto del metodo anterior y lo obtiene el tipo de cambio 
        /// </summary>
        /// <returns></returns>
        public float CovertidorDolaresBruto()
        {
            return SumaTotalBruto() * ServicioBCCRApi.ObtenerMontoVentaDolar(); 
        }
        /// <summary>
        /// SumaTotalFinal() Calcula la suma de todos los montos mas el monto 
        /// </summary>
        /// <returns></returns>
        public float SumaTotalFinal()
        {
            return (montoCobertura + montoPoliza + MontoSeguro + montoTipoPlan + prima + MontoAsegurado)+((montoCobertura + montoPoliza + MontoSeguro +montoTipoPlan + prima + MontoAsegurado)*(BLLIVA.TraerIVA(1).Porcentaje/100));
        }
        /// <summary>
        /// CovertidorDolaresFinal() Calcula agarra el monto del metodo anterior y lo obtiene el tipo de cambio 
        /// </summary>
        /// <returns></returns>
        public float CovertidorDolaresFinal()
        {
            return SumaTotalFinal() * ServicioBCCRApi.ObtenerMontoVentaDolar();
        }

        /// <summary>
        /// Se obtiene la factura de un clientes con el numero de cedula
        /// </summary>
        /// <param name="id"></param>
        /// Numero de cedula
        /// <returns></returns>
        public List<FacturaEncabezado> FacturasClentes(string id)
        {
            List<FacturaEncabezado> oFac = new List<FacturaEncabezado>();

            foreach (var lista in nuevoEncabezadoFactura.TraerTodos())
            {
                if (id.Equals(lista.Cliente))
                {
                    oFac.Add(lista);
                }

            }
            return oFac;

        }
        /// <summary>
        /// Se elimina la factura si esta en un rango de un del mismo dia
        /// </summary>
        /// <param name="id"></param>
        /// se busca la factura
        /// <returns></returns>
        public String Eliminar(int id)
        {

            if (nuevoEncabezadoFactura.TraerPorId(id).FechaFactura.Date == DateTime.Now.Date)
            {
                nuevoEncabezadoFactura.Eliminar(id);

                return "Eliminada con Exito";
            }
            else {
                return "No se puede eliminar Eliminar ya ha pasado un dia";
            }
        }
        /// <summary>
        /// Se busca cual es el siguiente codigo en la factura para poder cargar el QR         
        /// </summary>
        /// <returns></returns>

        public static int UltimaFactura(string cedula)
        {
            int numero = 0;
            DALFacturaEncabezado nueva = new DALFacturaEncabezado();
            List<int> valor = new List<int>();
            foreach (var lista in nueva.TraerTodos())
            {
                if (lista.Cliente.Equals(cedula))
                {
                    valor.Add(lista.Id);
                }

            }
            numero = valor.Max();           
            return numero;
        }
        /// <summary>
        /// Se actualiza la factura
        /// </summary>
        /// <param name="facturaEncabezado"></param>
        public static  void ActualizarFactura(FacturaEncabezado facturaEncabezado)
        {
            DALFacturaEncabezado nueva = new DALFacturaEncabezado();
            nueva.Actualizar(facturaEncabezado);
        }


    }
}
