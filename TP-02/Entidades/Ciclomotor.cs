using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase derivada Ciclomotor, hereda de la clase base Abstracta Vehiculo.
    /// </summary>
    public class Ciclomotor : Vehiculo
    {

        #region "Constructores"
        /// <summary>
        /// Inicializa una nueva instancia tipo Ciclomotor. Recibe y asigna los 3 atributos del objeto.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color)
            :base(chasis,marca,color)
        {
        }

        #endregion "Constructores"

        #region "Propiedades"


        /// <summary>
        /// Propiedad que retorna el tamaño del Ciclomotor.
        /// Ciclomotor son 'Chico'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        #endregion "Propiedades"

        #region "Metodos"
        /// <summary>
        /// Retorna string con la informacion del Ciclomotor.
        /// Sobreescribe el metodo Mostrar de la clase base Vehiculo.
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion "Metodos"
    }
}
