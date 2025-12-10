using ExamenIntegradorFinal.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenIntegradorFinal
{
    public class Televisor:Electrodomestico
    {
        #region Atributos

        private int pulgadas;
        private ResolucionTv resolucion;
        private static double FACTOR_PANTALLA;

        #endregion

        #region Constructores

        static Televisor()
        {
            FACTOR_PANTALLA = 0.05;
        }

        public Televisor(string marca, string modelo, double consumo, int pulgadas) : base(marca, modelo, consumo)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.consumoBaseWatts = consumo;
            this.pulgadas = pulgadas;
            resolucion = ResolucionTv.FullHD;
        }

        public Televisor(string marca, string modelo, double consumo, int pulgadas, ResolucionTv resolucion) :this(marca, modelo, consumo, pulgadas)
        {
            this.resolucion = resolucion;
        }
        #endregion

        #region Propiedades

        public override string CategoriaEnergetica
        {
            get
            {
                if (this.pulgadas > 55)
                {
                    return "B";
                }
                else
                {
                    return "A";
                }
            }

        }

        #endregion

        #region Metodos

        public override double CalcularCostoMensual(int horasDiarias, double costoPorWatt)
        {
            double consumoTotal;

            consumoTotal = ConsumoBaseWatts + (this.pulgadas * FACTOR_PANTALLA * (int)this.resolucion);
            
            return consumoTotal;
        }

        public string ConfigurarCanales()
        {
            string mensaje;

            mensaje = $"Las pulgadas de este TV son {this.pulgadas} y la resolucion {this.resolucion}";

            return mensaje;
        }

        #endregion
    }
}
