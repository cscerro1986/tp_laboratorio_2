using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo  //public sealed class Vehiculo
    {
        #region "Enumerados"
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }

        public enum ETamanio
        {
            Chico, Mediano, Grande
        }

        #endregion

        #region "Atributos"

        private EMarca marca;
        private string chasis;
        private ConsoleColor color;

        #endregion ATRIBUTOS

        #region "Constructores"
        /// <summary>
        /// Constructor public, inicializa la totalidad de los atributos de la clase.
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Vehiculo(string chasis, EMarca marca,ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }

        #endregion "Constructores"

        #region "Propiedades"

        /// <summary>
        /// Propiedad base protegida y abstracta.
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio
        {
            get;
        }

        #endregion "Propiedades"

        #region "Metodos"


        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// Efectua una conversion Explicita del Objeto Vehiculo a string.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        #endregion "Metodos"

        #region "Operadores"
        /// <summary>
        /// Conversion Explicita de tipo Vehiculo a string. La siguiente conversion puede generar perdida de informacion.
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">Atributo de tipo Vehiculo</param>
        /// <param name="v2">Atributo de tipo Vehiculo</param>
        /// <returns>Retorna true si los dos Vehiculos son igual, de lo contrario retorna False</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }

        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">Atributo de tipo Vehiculo</param>
        /// <param name="v2">Atributo de tipo Vehiculo</param>
        /// <returns>Retorna True si los dos Vehiculos son distintos, de lo contrario retornara False</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        #endregion "Operadores"

    }
}
