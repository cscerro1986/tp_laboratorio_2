using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException: Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase DniInvalidoException
        /// </summary>
        public DniInvalidoException():this("Dni invalido")
        {

        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase DniInvalidoException con una referencia interna que representa la causa de la excepcion.
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(Exception e):base(e.Message,e)
        {

        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase DniInvalidoException con el mensaje de error especificado. 
        /// </summary>
        /// <param name="message"></param>
        public DniInvalidoException(string message):base(message)
        {

        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase DniInvalidoException con el mensaje de error especificado
        /// y con una referencia interna que representa la causa de la excepcion.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception e):base(message,e)
        {

        }
    }
}
