using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Numero
    {

        #region ATRIBUTOS
        private double numero;

        #endregion ATRIBUTOS

        #region CONSTRUCTORES

        public Numero()
        {

        }

        public Numero (string srtNumero)
        {
            this.SetNumero = srtNumero;
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }

        #endregion CONSTRUCTORES

        #region PROPIEDADES

        /// <summary>
        /// Propiedad de asignacion del atributo numero.
        /// </summary>
        public string SetNumero 
        { 
            set
            {
                this.numero = ValidarNumero(value);
            }
        }


        #endregion PROPIEDADES

        #region METODOS

        /// <summary>
        /// Valida que el string pasado por parametro se pueda convertir a Double.
        /// Si se pudo convertir lo retorna, de lo contrario retornara 0
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retorna el numero numero convertido, si no pudo retornara 0</returns>
        private double ValidarNumero (string numero)
        {
            double aux;
            if(double.TryParse(numero, out aux))
            {
                return aux;
            }

            return 0;
        }



        /// <summary>
        /// Valida que el string recibido por parametro sea un numero binario.
        /// retorna true si es Binario, False si no lo es
        /// </summary>
        /// <param name="binario">numero binario de tipo string</param>
        /// <returns>Retorna true si el numero es binario, de lo constrario retorna false </returns>
        private static bool EsBinario(string binario)
        {
            foreach (char item in binario)
            {
                if(!(item=='0'||item=='1'))
                {
                    return false;
                }
            }

            return true;
        }



        /// <summary>
        /// Convierte un numero Binario a numero Decimal
        /// Recibo como parametro un numero Binario de tipo String, retorna un numero Decimal de tipo String.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Retorna el numero decimal en formato string, si no lo pudo convertir retorna "Valor invalido"</returns>
        public static string BinarioDecimal(string binario)
        {

            int retorno = 0;
            int enteroAux = 0;
            double auxDouble = 0;

            if(EsBinario(binario))
            {
                for (int i = 0; i < binario.Length; i++)
                {
                    enteroAux = int.Parse(binario.Substring(i, 1));
                    auxDouble = Math.Pow(2, binario.Length - i - 1);
                    retorno = retorno + (Convert.ToInt32(auxDouble) * enteroAux);
                }
            }
            else
            {
                return "Valor Invalido";
            }
            return retorno.ToString();
        }

        /// <summary>
        /// Convierte un numero Decimal a numero Binario
        /// Recibo como parametro un numero Decima de tipo String, retorna un numero Binario de tipo String.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>retorna el numero binario convertido </returns>
        public static string  DecimalBinario( string numero)
        {
            double aux;
            if(double.TryParse(numero, out aux))
            {
                return DecimalBinario(aux);
            }

            return "Valor Invalido";
        }



        /// <summary>
        /// Convierte un numero Decima a numero Binario
        /// Recibe un numero Decimal de tipo Double, retorna un numero Binario de tipo String.
        /// </summary>
        /// <param name="numero">Numero double que sera convertido a string </param>
        /// <returns>Retorna un numero binario de tipo String, Si no lo pudo convertir 
        /// retorna la leyenda " imposible converti" </returns>
        public static string DecimalBinario(double numero)
        {
            if(numero>int.MaxValue||numero<=int.MinValue)
            {
                return "Imposible convertir";
            }

            //tomo la parte Entera y Positiva del numero Double.
            int numeroInt = (int)numero;
            numeroInt= Math.Abs((int)numeroInt);

            return Convert.ToString(numeroInt, 2);
        }



        #endregion METODOS

        #region OPERADORES

        /// <summary>
        /// Sobrecarga del operador ´+ 
        /// </summary>
        /// <param name="n1"> Objeto de tipo Numero</param>
        /// <param name="n2"> Objeto de tipo Numero</param>
        /// <returns>Retona la suma de los atributos numero de los objetos de tipo Numero 
        /// pasados por parametro </returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }


        /// <summary>
        /// Sobrecarga del operador - 
        /// </summary>
        /// <param name="n1"> Objeto de tipo Numero</param>
        /// <param name="n2"> Objeto de tipo Numero</param>
        /// <returns>Retona la resta de los atributos numero de los objetos de tipo Numero 
        /// pasados por parametro </returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }


        /// <summary>
        /// Sobrecarga del operador / 
        /// </summary>
        /// <param name="n1"> Objeto de tipo Numero</param>
        /// <param name="n2"> Objeto de tipo Numero</param>
        /// <returns>Retona el cociente de los atributos numero de los objetos de tipo Numero 
        /// pasados por parametro, si el dividende es igual a 0 retorna el double.MinValue </returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if(n2.numero==0)
            {
                return double.MinValue;
            }
            return n1.numero / n2.numero;
        }



        /// <summary>
        /// Sobrecarga del operador * 
        /// </summary>
        /// <param name="n1"> Objeto de tipo Numero</param>
        /// <param name="n2"> Objeto de tipo Numero</param>
        /// <returns>Retona el producto de los atributos numero de los objetos de tipo Numero 
        /// pasados por parametro </returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }


        #endregion OPERADORES

    }
}
