using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    /// <summary>
    /// Clase base que hereda de Persona.
    /// </summary>
    public abstract class Universitario : Persona
    {
        #region atributos

        private int legajo;

        #endregion atributos

        #region constructores

        /// <summary>
        /// Instancia un nuevo objeto de tipo Universitario
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// Instancia un nuevo objeto de tipo Universitario
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion constructores

        #region operadores

        /// <summary>
        /// Sobreescritura del metodo Equals de la clase Object
        /// Compara que el objeto que lo instance sea del mismo tipo que el pasado por parametro.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.GetType() == obj.GetType();
        }


        /// <summary>
        /// Comprueba si las dos instancias de Universitario son iguales.
        /// Valida si son del mismo tipo, y en caso de serlo si el numero de DNI o
        /// el numero de legajo son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator==(Universitario pg1, Universitario pg2 )
        {
           //Valido que sean del mismo tipo
            if(pg1.GetType()==pg2.GetType())
            {
                //valido que dni 0 los legajos sean iguales.
                if((pg1.DNI==pg2.DNI)||(pg1.legajo==pg2.legajo))
                {
                    return true;
                }                    
            }
            return false;
        }

        /// <summary>
        /// Comprueba si dos instancias de la clase Universitario son distintas.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion operadores


        /// <summary>
        /// Retorna la informacion de la instancia Universitario que lo invoque.
        /// Metodo virtual que permite ser sobreescrito por las clase que hereden de Universitario.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"LEJAGO NUMERO: {this.legajo}");

            return sb.ToString();
        }

        /// <summary>
        /// Firma del metodo abstracto para ser implementado obligatoriamente por las clases que
        /// hereden de Universitario.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();


    }
}
