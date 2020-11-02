using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_instanciables
{
    /// <summary>
    /// Clase sellada Alumno.
    /// </summary>
    public sealed class Alumno: Universitario
    {

        #region atributos
        public enum EEstadoCuenta { AlDia, Deudor, Becado}

        private EEstadoCuenta estadoCuenta;
        private Universidad.EClases clasesQueToma;

        #endregion atributos
                
        #region Constructores
        
        /// <summary>
        /// Inicializa una nueva instancia de la clase Alumno.
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Alumno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesQueToma=claseQueToma;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Alumno.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }


        
        #endregion Constructores

        #region Propiedades


        /// <summary>
        /// Propiedad de tipo EClases
        /// </summary>
        public Universidad.EClases ClasesQueToma
        {
            get
            {
                return this.clasesQueToma;
            }
            set
            {
                this.clasesQueToma = value;
            }
        }

        /// <summary>
        /// Propiedad de tipo EEstadoCuenta.
        /// </summary>
        public EEstadoCuenta EstadoCuenta
        {
            get
            {
                return this.estadoCuenta;
            }
            set
            {
                this.estadoCuenta = value;
            }
        }

        #endregion Propiedades

        /// <summary>
        /// Retorna un string con la informacion de la clase tomada por la instancia del Alumno.
        /// Sobreescribe el metodo Abstracto heredado.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE: " + this.clasesQueToma.ToString();
        }

        /// <summary>
        /// Suministra los datos de la instancia del tipo Alumno que lo invoque.
        /// </summary>
        /// <returns> Un string con la informacion de la instancia.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");
            sb.AppendLine($"TOMA CLASE DE: {this.clasesQueToma}");

            return sb.ToString();

        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }


        #region Operadores


        /// <summary>
        /// Valida que el Alumno curse la EClase y que su estado de cuenta no sea Deudor.
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator == (Alumno a, Universidad.EClases clase)
        {
            if (a.clasesQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
                return true;

            return false;
        }

        /// <summary>
        /// Valida que el alumno no tome la clase, o que su estado de cuenta sea Deudor.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator != (Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }

        #endregion Operadores


    }
}
