using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.IO;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        #region ENUMERADOS
        
        public enum ETipo { CuatroPuertas, CincoPuertas }
        
        #endregion ENUMERADOS

        #region ATRIBUTOS
        
        private ETipo tipo;

        #endregion ATRIBUTOS

        #region CONSTRUCTORES
        /// <summary>
        /// Inicializa una nueva instancia de la clase Sedan. Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            :this(marca,chasis,color,ETipo.CuatroPuertas)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Sedan. Recibe los 4 atributos del objeto.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }

        #endregion CONSTRUCTORES

        #region PROPIEDADES
        /// <summary>
        /// Retorna el tamanio del Sedan, el cual es 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        #endregion PROPIEDADES

        #region METODOS

        /// <summary>
        /// Retorna la informacion del objeto de tipo Sendan en formato string.
        /// Metodo sellado que sobreescribe el metodo Mostrar de la clase base Vehiculo.
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion METODOS
    }
}
