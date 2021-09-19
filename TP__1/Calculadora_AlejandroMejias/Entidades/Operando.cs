using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        ///     Setea el número recibido como value, el mismo verifica previamente que no sea texto
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }
        /// <summary>
        ///     Convierte un binario a decimal, validando previamente que este compuesto de '0' y '1'. Solo opera con números enteros positivos.
        /// </summary>
        /// <param name="binario">Cadena a convertir.</param>
        /// <returns>De ser posible retornará al número transformado en decimal, de no ser posible, retornará "Valor invalido". Si recibe "0", retornara ese mismo valor</returns>
        public string BinarioDecimal(string binario)
        {
            string retorno = binario;

            if(!retorno.Equals("Valor invalido"))
            {
                int acumulador = 0;
                int longitud = binario.Length;
                bool esEntero = int.TryParse(binario, out int numeroEntero);
                retorno = esEntero ? "" : "Valor invalido";
                char[] binarioCadena = binario.ToCharArray();
                Array.Reverse(binarioCadena);
                if (EsBinario(binario) && numeroEntero > 0)
                {
                    for (int i = 0; i < longitud; i++)
                    {
                        if (binarioCadena[i].Equals('1'))
                        {
                            acumulador += (int)Math.Pow(2, i);
                        }
                    }
                    retorno = acumulador.ToString();
                }
                else if(numeroEntero == 0 && esEntero)
                {
                    retorno += "0";
                }
                else
                {
                    retorno = "";
                    retorno += "Valor invalido";
                }
            }
            return retorno;
        }
        /// <summary>
        ///     Transforma un número decimal a binario. Solo opera con números enteros positivos.
        /// </summary>
        /// <param name="numero">número a convertir.</param>
        /// <returns>De ser posible retornará al número convertido a binario, de no ser posible, retornará "Valor invalido"</returns>
        public string DecimalBinario(double numero)
        {
            string retorno = "";
            int numeroEntero = (int)numero;

            if(numeroEntero > 0)
            {
                while(numeroEntero > 0)
                {
                    retorno = (numeroEntero % 2) + retorno;
                    numeroEntero /= 2;
                }
            }
            else if (numero == 0)
            {
                retorno = "0";
            }
            else
            {
                retorno = "Valor invalido";
            }
            return retorno;
        }
        /// <summary>
        ///     Tranforma un número decimal a binario. Solo opera con números enteros positivos.
        /// </summary>
        /// <param name="numero">número a convertir.</param>
        /// <returns>De ser posible retornará al número convertido a binario, de no ser posible, retornará "Valor invalido"</returns>
        public string DecimalBinario(string numero)
        {
            string retorno = numero;

            if(!retorno.Equals("Valor invalido"))
            {
                bool esEntero = true;
                double doubleBinario;
                int longitud = numero.Length;
                for (int i = 0; i < longitud; i++)
                {
                    if (numero[i].Equals(','))
                    {
                        esEntero = false;
                        break;
                    }
                }
                if (esEntero)
                {
                    doubleBinario = double.Parse(numero);
                    retorno = DecimalBinario(doubleBinario);
                }
                else
                {
                    retorno = "Valor invalido";
                }
            }

            return retorno;
        }
        /// <summary>
        ///     Validará que el valor recibido como parametro sea '0' o '1'
        /// </summary>
        /// <param name="binario">String a validar.</param>
        /// <returns>True si el parametro contiene '0' o '1', False si es distinto a '0' o '1'</returns>
        private static bool EsBinario(string binario)
        {
            bool retorno = false;
            int longitud = binario.Length;

            for(int i = 0; i < longitud; i++)
            {
                if(binario[i].Equals('0') || binario[i].Equals('1'))
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        ///     Constructor por defecto. Asigna 0 al atributo número.
        /// </summary>
        public Operando() => this.numero = 0;

        /// <summary>
        ///     Asigna un valor al atributo número;
        /// </summary>
        /// <param name="numero">Valor a asignar</param>
        public Operando(double numero) => this.numero = numero;

        /// <summary>
        ///     Asigna un valor al atributo número;
        /// </summary>
        /// <param name="strNumero">Valor a asignar.</param>
        public Operando(string strNumero) => this.SetNumero = strNumero;
        /// <summary>
        ///      Encargado de sumar los valores recibidos por parametro.
        /// </summary>
        /// <param name="n1">Primer número.</param>
        /// <param name="n2">Segundo número.</param>
        /// <returns>Resultado de la operación</returns>
        public static double operator +(Operando n1, Operando n2) => n1.numero + n2.numero;
        /// <summary>
        ///      Encargado de restar los valores recibidos por parametro.
        /// </summary>
        /// <param name="n1">Primer número.</param>
        /// <param name="n2">Segundo número.</param>
        /// <returns>Resultado de la operación</returns>
        public static double operator -(Operando n1, Operando n2) => n1.numero - n2.numero;
        /// <summary>
        ///  Encargado de dividir los valores recibidos por parametro. Valida que el segundo número no sea "0". 
        /// </summary>
        /// <param name="n1">Primer número.</param>
        /// <param name="n2">Segundo número.</param>
        /// <returns>De ser posible retornará el resultado de la operación, de no ser posible, retornará double.MinValue (si el segundo operando es 0).</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            double retorno;
            if(n2.numero == 0)
            {
                retorno = double.MinValue;
            }
            else
            {
                retorno = n1.numero / n2.numero;
            }
            return retorno;
        }
        /// <summary>
        ///     Encargado de multiplicar los valores recibidos por parametro.
        /// </summary>
        /// <param name="n1">Primer número.</param>
        /// <param name="n2">Segundo número.</param>
        /// <returns>Resultado de la operación</returns>
        public static double operator *(Operando n1, Operando n2) => n1.numero * n2.numero;
        /// <summary>
        ///     Valida que el valor recibido sea de tipo númerico. Reemplaza el "." por ",",
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>De ser posible retornará el resultado en formato double, de no ser posible retornará 0</returns>
        private static double ValidarOperando(string strNumero)
        {
            bool esValido = double.TryParse(strNumero.Replace(".", ","), out double retorno);

            if (!esValido)
            {
                retorno = 0;
            }
            return retorno;
        }
    }
}
