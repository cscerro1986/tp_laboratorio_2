using Clases_instanciables;
using Excepciones;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml;
using System.IO;

namespace Clases_instanciables
{
    /// <summary>
    /// Clase publica con 3 listas como atributos, Alumno, Jornada y Profesor.
    /// </summary>
    public class Universidad
    {
        #region Enumerados
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD}

        #endregion Enumerados

        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #endregion Atributos

        #region Propiedades
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

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        public List<Profesor> Profesores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return Jornadas[i];
            }
            set
            {
                Jornadas[i] = value;
            }
        }


        #endregion Propiedades

        #region constructor
        
        /// <summary>
        /// Inicializa una nueva instancia del tipo Universidad
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Profesores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }

        #endregion constructor

        #region Operadores
        /// <summary>
        /// Valida que el alumno se encuentre inscripto en la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator==(Universidad g, Alumno a)
        {
           //Valido que universidad no sea null
           if(ReferenceEquals(g,null))
           {
                return false;
           }
            
            //Valido la igualdad entre alumnos.
            foreach (Alumno item in g.Alumnos)
            {
                if (item == a)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica que el alumno no se encuentre inscripto en la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }


        /// <summary>
        /// Verifica que el Profesor se encuentre dando clases en la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            //valido que g no sea null
            if(ReferenceEquals(g,null))
            {
                return false;
            }

            //verifico que el profesor de clases en la universidad
            foreach (Profesor item in g.Profesores)
            {
                if (item == i)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica que el Profesor no de clases en la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }


        /// <summary>
        /// Metodo estatico que retorna el primer profesor inscripto en la Universidad capaz de dar la EClase.
        /// Si ningun profesor puede dar la clase se arroja una Exception del tipo SinProfesorException.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clases"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, Universidad.EClases clases)
        {
            foreach (Profesor profesor in u.profesores)
            {
                if (profesor == clases)
                {
                    return profesor;
                }
            }            
            throw new SinProfesorException($"No hay profesor que pueda dar la clase.\n");
        }



        /// <summary>
        /// Metodo estatico que retorna el primer profesor inscripto en la Universidad incapaz de dar la clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clases"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, Universidad.EClases clases)
        {
            Profesor retornoProfesor = null;

            foreach (Profesor item in u.Profesores)
            {
                if(item!=clases)
                {
                    retornoProfesor = item;
                }
            }

            if(ReferenceEquals(retornoProfesor,null))
            {
                throw new SinProfesorException("Todos los profesores pueden dar la clase");
            }

            return retornoProfesor;
        }

        /// <summary>
        /// Agregaa un alumno a la universidad
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u!=a)
            {
                u.Alumnos.Add(a);
                return u;
            }
            throw new AlumnoRepetidoException("El alumno ya se encuentra anotado en la universidad");

        }

        /// <summary>
        /// Agrega una instancia de Profesor P a la universidad u, previa validacion de que no
        /// no se encuentre en la lista.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor p)
        {
            if(u!=p)
            {
                u.Profesores.Add(p);                
            }
            return u;            
        }


        /// <summary>
        /// Metodo estatico que agrega una nueva EClases a la Universidad.
        /// Agrega una nueva instancia de Jornada, asignando un profesor, y todos los Alumnos que tomen esa clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Universidad.EClases clase)
        {
            //operador== retorna el primer profesor que puede dar la clase. - Si no encuentra lanza excepcion.
            Profesor profesorAAgregar = u == clase;
            Jornada jornadaAAgregar = new Jornada(clase, profesorAAgregar);
            List<Alumno> alumnosParaLaClase = new List<Alumno>();

            //Agrega aquellos alumnos de la Universidad que Tomen la clase que se quiere agregar.
            foreach (Alumno alumnoEnUniversidad in u.Alumnos)
            {
                if (alumnoEnUniversidad.ClasesQueToma == clase)
                    alumnosParaLaClase.Add(alumnoEnUniversidad);
            }

            jornadaAAgregar.Alumnos = alumnosParaLaClase;
            u.Jornadas.Add(jornadaAAgregar);

            return u;


        }

        #endregion Operadores

        #region Metodos
        /// <summary>
        /// Retorna de forma privada la informacion de la universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad u)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            foreach (Jornada item in u.Jornadas)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();

        }

        /// <summary>
        /// Sobreescritura del mestodo ToString de la clase Object.
        /// retorna de forma publica la informacion de la universidad.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }


        /// <summary>
        /// Abre y lee un archivo XML con nombre "Universidad.xml", convierte su informacion a 
        /// objetos de tipo Universidad y lo retorna.
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            //string archivo = @"C:\Users\Gisel Morel\Desktop\Universidad.xml";
            string path = Directory.GetCurrentDirectory() + @"\Universidad.xml";
            Universidad uni = new Universidad();
            Archivos.Xml<Universidad> archivoXml = new Archivos.Xml<Universidad>();
            archivoXml.Leer(path, out uni);
            
            return uni;
        }


        /// <summary>
        /// Convierte el objeto de tipo Universidad a archivo XML y lo guarda.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            string path = Directory.GetCurrentDirectory() + @"\Universidad.xml";
            Archivos.Xml<Universidad> universidadXml = new Archivos.Xml<Universidad>();
            
            if(universidadXml.Guardar(path, uni))
            {
                return true;
            }

            return false;
        }

        #endregion Metodos
    }
}
