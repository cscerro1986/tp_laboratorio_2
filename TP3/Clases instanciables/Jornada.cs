using Clases_instanciables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;
using EntidadesAbstractas;
using Excepciones;

namespace Clases_instanciables
{

    /// <summary>
    /// Clase Jornada, la misma esta conformada por un Profesor, una EClases y una lista de la clase Alumno.
    /// </summary>
    public class Jornada
    {
        #region atributos

        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #endregion atributos

        #region propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }        
        
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        #endregion propiedades

        #region consturctores

        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        #endregion Constructores

        #region Metodos

        /// <summary>
        /// Guarda en el directorio actual un archivo de texto con el nombre "Jornada.txt"
        /// con la informacion de la jornada pasada por parametro.
        /// De no poder lanza la excepcion "ArchivosExceptio"
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar( Jornada jornada)
        {
            string path = Directory.GetCurrentDirectory() + @"\Jornada.txt";
            try
            {
                string dato = jornada.ToString();
                Texto texto = new Texto();
                texto.Guardar(path, dato);
                return true;

            }
            catch(Exception ex)
            {
                throw new ArchivosException(ex);
            }            
        }


        /// <summary>
        /// Abre el archivo de texto "Jornada.txt" y retorna su contenido en formato string.
        /// De no poder lanza la excepcion "ArchivosException"
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string retorno = string.Empty;
            Archivos.Texto texto = new Texto();
            try
            {
                texto.Leer("Jornada.txt", out retorno);
                return retorno;
            }
            catch(Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }

        /// <summary>
        /// Retorna la informacion completa de la instancia del tipo Jornada en formato string.
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("<-------------------------------------------------->\n");
            sb.Append($"CLASE DE {this.Clase.ToString()}");
            sb.AppendLine(" POR "+(this.Instructor).ToString());
            sb.AppendLine("ALUMNOS:");

            foreach (Alumno item in this.Alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<-------------------------------------------------->\n");
            return sb.ToString();

        }

        #endregion Metodos

        #region Operadores

        /// <summary>
        /// Verifica si el alumno participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno item in j.Alumnos)
            {
                if (item == a)
                    return true;
            }
            return false;
        }


        /// <summary>
        /// Verifica que el alumno no participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }


        /// <summary>
        /// Agrega una instancia del tipo Alumno a la Jornada, previa validacion de que no este incluido.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.Alumnos.Add(a);

            return j;
        }

        #endregion Operadores

    }
}
