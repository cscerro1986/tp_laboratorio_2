using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase Derivada Suv, hereda de la clase base abstracta Vehiculo.
    /// </summary>
    public class Suv: Vehiculo
    {
        #region "Constructores"

        /// <summary>
        /// Inicializa una nueva instancia de la clase Suv.
        /// </summary>
        /// <param name="marca">Atributo de tipo enumerado EMarca</param>
        /// <param name="chasis">Atributo string que hace referencia al numero de chasis</param>
        /// <param name="color">Atributo de tipo enumerado ConsoleColor.</param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }

        #endregion "Constructores"

        #region "Propiedades"
        /// <summary>
        /// Propiedad que retorna el tamaño del SUV
        /// SUV son 'Grande'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        #endregion "Propiedades"

        #region "Metodos"

        /// <summary>
        /// Retorna string con la informacion del objeto SUV.
        /// Sobreescribe el metodo Mostrar de la clase Vehiculo. 
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}" );
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion "Metodos"
    }
}
