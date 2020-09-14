using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que el char ingresado sea "+" "-" "*" o "/" y lo retorna
        /// De lo contrario retornara "+"
        /// </summary>
        /// <param name="operador"></param>
        /// <returns> Retorna el operador </returns>
        private static string ValidarOperador(char operador)
        {    
            if (operador == '+' || operador == '-' || operador == '*' || operador == '/')
            {
                return operador.ToString();
            }

            return "+";
        }


        /// <summary>
        /// Metodo estatido que recibe dos numeros y realiza una operacion aritmetica segun el operador recibido.
        /// Se retorna su resultado.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            if(operador==string.Empty)
            {
                operador = " ";
            }

            switch (ValidarOperador(Convert.ToChar(operador)))
            {
                case "/":
                    return num1 / num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                default:
                    return num1 + num2;
            }
            
        }
        
    }


}
