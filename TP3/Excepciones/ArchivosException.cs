using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase ArchivosException con el mensaje de error especificado. 
        /// La misma hereda de la clase Exception
        /// </summary>
        /// <param name="mensaje"></param>
        public ArchivosException(string mensaje)
            : base(mensaje)
        {

        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase AlumnoRepetidoException.
        /// La misma hereda de la clase Exception
        /// </summary>
        public ArchivosException()
            :this("Error, no se pudo completar la operacion con el archivo.")
        {

        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase AlumnoRepetidoException con una referencia interna que representa la causa de la excepcion.
        /// La misma hereda de la clase Exception
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException)
            : base("Error, no se pudo completar la operacion con el archivo.", innerException)
        {

        }


    }
}
