using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;

using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Enumerados
        public enum ENacionalidad { Argentino, Extranjero}

        #endregion

        #region atributos

        private string apellido;
        private string nombre;
        private int dni;
        private ENacionalidad nacionalidad;


        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad que asigna el atributo apellido, previa validacion.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad que asigna el atributo nombre, previa validacion.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad que asigna el atributo dni recibido en formato int, previa validacion.
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = Persona.ValidarDni(this.nacionalidad,value);
            }
        }

        /// <summary>
        /// Propiedad que asigna el atributo nacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propieadd que asigna el atributo dni recibido en formato string, previa validacion.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Inicializa un nueva estancia de la clase Persona. Constructor publico sin parametros.
        /// </summary>
        public Persona()
        {
            
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase Persona.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Persona.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo privado estatico que valida que el numero de DNI proporcionado se encuentre dentro del rango admitido para la nacionalidad de la Persona.
        /// En caso de corresponder retornara el numero de DNI
        /// De no corresponder lanzara al excepcion NacionalidadInvalidaException.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            //Verificacion para Argentino

            if (nacionalidad == Persona.ENacionalidad.Argentino)
            {
                    if (dato >= 1 && dato <= 89999999)
                        return dato;
                
                    throw new NacionalidadInvalidaException("El numero de DNI no corresponde a una persona argentina");
                   
            }
            //Verificacion para Extranjero
            else
            {
                    if (dato >= 90000000 && dato <= 99999999)
                        return dato;
                
                    throw new NacionalidadInvalidaException("El numero de DNI no corresponde a una persona extranjera");
                
            }
        }

        /// <summary>
        /// Comprueba que el String dato pueda convertirse a numero, de no poder lanza la Exception DniInvalidoException.
        /// Si puede convertirlo llama al metodo estatico ValidarDni para corroborar si el numero corresponde con la nacionalidad
        /// de la Persona.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int datoAux;

            if(int.TryParse(dato,out datoAux))
            {
                return Persona.ValidarDni(nacionalidad, datoAux);
            }

            throw new DniInvalidoException("Dni invalido Exception");
        }



        /// <summary>
        /// Comprueba que el texto recibido sean solo letras o espacios. La primera posicion no puede ser un espacio.
        /// De no complir retornara un string vacio.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static string ValidarNombreApellido(string dato)
        {            
           string substring = dato.Substring(0, 1);
           if (substring == " ")
                return "";

            foreach (char item in dato)
            {
                if (!(Char.IsLetter(item)))
                {
                    if(!Char.IsWhiteSpace(item))
                        return string.Empty;
                }                    
            }

            return dato;
        }


        /// <summary>
        /// Sobreescritura del metodo ToString de la clase Object
        /// Retorna la informacion de la persona, Nombre, Apellido y Nacionalidad.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}");
            sb.AppendLine($"NACIONALIDAD: {this.Nacionalidad}");
            
            return sb.ToString();            
        }

        #endregion

    }
}
