using ExamenIntegradorFinal.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenIntegradorFinal
{
    public enum TipoCicloLavado
    {
        Delicado = 1,
        RopaBebe = 2,
        Regular = 3
    }
    public class Lavadora:Electrodomestico
    {
        #region Atributos

        private double capacidadKilos;
        private TipoLavadora tipo;
        private static double FACTOR_CARGA;

        #endregion

        #region Constructores

        static Lavadora()
        {
            FACTOR_CARGA = 0.75;
        }

        public Lavadora(string marca, string modelo, double consumo, double capacidad) : base(marca, modelo, consumo)
        {
            this.capacidadKilos = capacidad;
            this.tipo = TipoLavadora.Domestica;//Se asigna valor por defecto
        }

        public Lavadora(string marca, string modelo, double consumo, double capacidad, TipoLavadora tipo) : this(marca, modelo, consumo, capacidad)
        {
            this.tipo = tipo;
        }

        #endregion

        #region Propiedades

        public override string CategoriaEnergetica
        {
            get
            {
                string mensaje;
                switch (this.tipo)
                {
                    case TipoLavadora.Industrial:
                        mensaje = "Industrial";
                        break;
                        
                    case TipoLavadora.SemiIndustrial:
                        mensaje = "Comercial";
                        break;

                    default:
                        mensaje = "Hogar";
                        break;

                }
                return mensaje;
            }
            
        }

        #endregion

        #region Metodos

        public override double CalcularCostoMensual(int horasDiarias, double costoPorWatt)
        {
            double consumoReal;
            double costoMensual;

            consumoReal = ConsumoBaseWatts + (this.capacidadKilos * FACTOR_CARGA * (int)this.tipo);
            costoMensual = consumoReal*horasDiarias*30*costoPorWatt;

            return costoMensual;
        }

        public string IniciarCicloLavado()
        {
            string mensaje = $"El tipo de ciclo de lavado que esta iniciando es {TipoCicloLavado.Delicado} con 2 Kg de ropa";
            return mensaje;
        }

        #endregion
    }
}
