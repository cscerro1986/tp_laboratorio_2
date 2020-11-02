using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clases_instanciables
{
    
    public class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region constructores

        private Profesor()
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        static Profesor()
        {
            random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        #endregion Constructores

        #region metodos

        /// <summary>
        /// Asigna dos clases aleatorias a la coleccion clasesDelDia.
        /// </summary>
        private void _randomClases()
        {
            int len = Enum.GetValues(typeof(Universidad.EClases)).Length;
            
            clasesDelDia.Enqueue((Universidad.EClases)(random.Next(0, len)));
            
            clasesDelDia.Enqueue((Universidad.EClases)(random.Next(0, len)));
        }


        /// <summary>
        /// Retorna la informacion de la instancia de tipo Profesor.
        /// Sobreescribe el metodo heredado de la clase Universitario.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());            

            return sb.ToString();
        }

        /// <summary>
        /// Retorna un string con la informacion de la clases en las que participa 
		/// Implementación del método abstracto hederado de la clase Universitario.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASES DEL DÍA: \n");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.Append(clase.ToString()+"\n");
            }
            return sb.ToString();
        }

        /// <summary>
		/// Sobrescritura del método ToString de la clase Object retornando
        /// los la informacion de la instancia que lo implementa a traves del método MostrarDatos().
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion metodos

        #region Operadores
        /// <summary>
        /// Compara un Profesor con una EClases determinando si el mismo da la clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase )
        {
            return !(i == clase);
        }


        /// <summary>
        /// Compara una instancia del Profesor con una EClase y determina si el mismo da la clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
                    return true;
            }
            return false;
        }
        #endregion Operadores


    }
}
