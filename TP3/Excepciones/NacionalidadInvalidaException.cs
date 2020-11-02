using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
   public class NacionalidadInvalidaException:Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase NacionalidadInvalidaException. 
        /// La misma hereda de la clase Exception
        /// </summary>
        public NacionalidadInvalidaException():this("Nacionalidad invalida")
        {

        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase NacionalidadInvalidaException con el mensaje de error especificado.
        /// La misma hereda de la clase Exception
        /// </summary>
        /// <param name="mensaje"></param>
        public NacionalidadInvalidaException(string mensaje):base(mensaje)
        {

        }

       

    }
}
