using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        public SinProfesorException(string mensaje) : base(mensaje)
        {

        }


        public SinProfesorException():base("No se cargo el profesor")
        {

        }
    }
}
