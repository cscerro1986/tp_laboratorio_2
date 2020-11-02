using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException: Exception
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase AlumnoRepetidoException con el mensaje de error especificado. 
        /// La misma hereda de la clase Exception        /// 
        /// </summary>
        /// <param name="mensaje"></param>
        public AlumnoRepetidoException(string mensaje) : base(mensaje)
        {

        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase AlumnoRepetidoException. 
        /// La misma hereda de la clase Exception
        /// </summary>
        public AlumnoRepetidoException():this("Alumno ya ingresado")
        {

        }
    }
}
