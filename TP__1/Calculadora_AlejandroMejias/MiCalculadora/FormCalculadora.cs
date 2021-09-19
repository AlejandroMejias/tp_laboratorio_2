using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        ///     Evento de carga del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <return>Al iniciar el formulario el cmbOperador tendrá como valor por defecto "Vacio"</return>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.cmbOperador.SelectedIndex = 0;
        }
        /// <summary>
        ///     Evento para ejecutar el cierre del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        ///     Convierte a binario el resultado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>Incluye en el lblResultado el número transformado a binario, o "Valor invalido" en caso de no ser posible.</returns>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = new Operando().DecimalBinario(this.lblResultado.Text);
        }
        /// <summary>
        ///     Convierte a decimal el resultado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>Incluye en el lblResultado el número transformado a decimal, o "Valor invalido" en caso de no ser posible.</returns>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = new Operando().BinarioDecimal(this.lblResultado.Text);
        }
        /// <summary>
        ///     Encargado de llamar al metodo limpiar() para restablecer los valores de los campos: txtNumero1 , txtNumero2 , cmbOperador y lblResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        /// <summary>
        ///     Encargado de llamar al metodo Operar(), el cual realizara la operacion solicitada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>De posible devolvera el resultado Validando:
        /// 1) Que los txtNumero1 y txtNumero2 no contengan letras, de contener, se guardara "0" en su respectiva variable txtNumeroUnoString o txtNumeroDosString respectivamente
        /// 2) Que el cmcOperador no traiga como valor "Vacio", de ser asi, guardará "+" en su respectiva variable cmcOperadorString
        /// 3) La variable formatoResultado servirá como plantilla y será agregada a los items del lstOperaciones
        /// </returns>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            string cmbOperadorString = cmbOperador.Text == "Vacio" ? "+" : cmbOperador.Text;

            bool txtNumeroUnoValidado = double.TryParse(txtNumero1.Text, out _);
            string txtNumeroUnoString = txtNumeroUnoValidado ? txtNumero1.Text : "0";

            bool txtNumeroDosValidado = double.TryParse(txtNumero2.Text, out _);
            string txtNumeroDosString = txtNumeroDosValidado ? txtNumero2.Text : "0";

            string formatoResultado = String.Format("{0} {1} {2} = {3}", txtNumeroUnoString, cmbOperadorString, txtNumeroDosString, resultado);
            this.lblResultado.Text = resultado.ToString();
            this.lstOperaciones.Items.Add(formatoResultado);
        }
        /// <summary>
        ///     Encargado de borrar y restablecer los valores de los campos: txtNumero1 , txtNumero2 , cmbOperador y lblResultado
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = null;
            this.cmbOperador.Text = "Vacio";
            this.txtNumero2.Text = null;
            this.lblResultado.Text = "0";
        }
        /// <summary>
        ///     Encargado de realizar la operación solicitada generando dos nuevas instancias de la clase Operando y pasandole al metodo de la Calculadora dichas 
        ///     instancias para realizar la operación
        /// </summary>
        /// <param name="numero1">Primer número</param>
        /// <param name="numero2">Segundo número</param>
        /// <param name="operador">Operador a utilizar</param>
        /// <returns>Resultado de la operación.</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando operandoUno = new Operando(numero1);
            Operando operandoDos = new Operando(numero2);
            char comboBox = operador[0];
            double resultado = Calculadora.Operar(operandoUno, operandoDos, comboBox);
            return resultado;
        }
        /// <summary>
        ///     Encargado de manejar el cierre del formulario, dicho manejador mostrará un mensaje al usuario indicandole si desea cerrar o no . 
        ///     Dicho cierre puede hacerse desde el boton Cerrar , o desde  la "X" del formulario.
        /// </summary>
        /// <param name="sender">Primer valor.</param>
        /// <param name="e">Segundo valor.</param>
        /// <returns>Cierre de la aplicación</returns>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
                switch (MessageBox.Show(this, "¿Estás seguro que deseas salir?", "Salir",MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
        }

    }
}
