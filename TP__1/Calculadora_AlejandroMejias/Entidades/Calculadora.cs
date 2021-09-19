using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        ///     Valida y realiza la operación pedida entre dos números.
        /// </summary>
        /// <param name="num1">Primer operando.</param>
        /// <param name="num2">Segundo operando.</param>
        /// <param name="operador">Operador seleccionado.</param>
        /// <returns>Resultado de la operación solicitada.</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado;
            char operadorValidado = Calculadora.ValidarOperador(operador);

            switch (operadorValidado)
            {
                case '-':
                    resultado = num1 - num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                default:
                    resultado = num1 + num2;
                    break;
            }
            return resultado;
        }
        /// <summary>
        ///     Valida que el operador recibido sea  (+), (-), (/) , (*).
        /// </summary>
        /// <param name="operador">Operador recibo y que sera validado</param>
        /// <returns>De ser valido se retornará el operador solicitado, de no ser posible, retorna automaticamente  "+".</returns>
        private static char ValidarOperador(char operador)
        {
            char retorno = '+';
            if (operador.Equals('+') || operador.Equals('-') || operador.Equals('/') || operador.Equals('*'))
            {
                retorno = operador;
            }
            return retorno;
        }
    }
}
