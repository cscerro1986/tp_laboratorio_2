using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {

        public FormCalculadora()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Evento que cierra el Formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Evento que limpia los numeros, el operandor, dejando el resultado en 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = string.Empty;
            txtNumero2.Text = string.Empty;
            cmbOperador.Text = string.Empty;
            lblResultado.Text = "0";

        }


        /// <summary>
        /// Evento que ejecuta la conversion del numero del binario del label a numero Decimal
        /// Bloque el boton ConvertirADecimal para impedir ejecutarlo dos veces seguidas.
        /// Habilita el boton ConvertirABinario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != string.Empty)
            {
                string numAux = lblResultado.Text;
                lblResultado.Text = Numero.BinarioDecimal(numAux);
                btnConvertirADecimal.Enabled = false;
                btnConvertirABinario.Enabled = true;
            }

        }


        /// <summary>
        /// Evento que ejecuta la conversion del numero del Decimal del label a numero Binario
        /// Bloque el boton ConvertirABinario para impedir ejecutarlo dos veces seguidas.
        /// Habilita el boton ConvertirADecimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if(lblResultado.Text!=string.Empty)
            {
                string numAux = lblResultado.Text;
                lblResultado.Text = Numero.DecimalBinario(numAux);
                btnConvertirABinario.Enabled = false;
                btnConvertirADecimal.Enabled = true;
            }
        }


        /// <summary>
        /// Metodo Estatico que ejecuta el metodo Operar de la Clase Calculadora y retorna su resultado
        /// Realiza una operacion aritmetica segun los numeros y el operador ingresado.
        /// </summary>
        /// <param name="numero1">Primero numero que sera operado</param>
        /// <param name="numero2">Segundo numero que sera operado</param>
        /// <param name="operador">signo correspondiente a la operacion artimetica que se desea realizar</param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            return Calculadora.Operar(new Numero(numero1), new Numero(numero2), operador);
           
        }


        /// <summary>
        /// Evento que llama al metodo Estatico Operar del la clase FormCalculadora y muestra su
        /// resultado en el labelResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if(txtNumero1.Text!=string.Empty && cmbOperador.Text!=string.Empty&&txtNumero2.Text!=string.Empty)
            {
                lblResultado.Text = (Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text)).ToString();
                btnConvertirADecimal.Enabled = false;
                btnConvertirABinario.Enabled = true;
            }
            
        }


        /// <summary>
        /// Evento que impide que el usuario deje el cmbOperador vacio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbOperador_Leave(object sender, EventArgs e)
        {
            if(cmbOperador.Text==string.Empty)
            {
                cmbOperador.Focus();
            }
        }
    }
}
