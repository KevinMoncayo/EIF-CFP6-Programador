using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenIntegradorFinal
{
    public abstract class Electrodomestico
    {
        #region Atributos

        protected int id;
        protected string marca;
        protected string modelo;
        protected double consumoBaseWatts;

        #endregion

        #region Constructores

        public Electrodomestico(string marca, string modelo, double consumo)
        {
            Marca = marca;
            Modelo = modelo;
            ConsumoBaseWatts = consumo;
        }

        #endregion

        #region Propiedades

        public abstract string CategoriaEnergetica 
        {
            get;
        }

        public int Id 
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Marca 
        {
            get
            {
                return marca;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El campo no puede estar vacío!");
                }
                this.marca = value;
            }
        }

        public string Modelo
        {
            get
            {
                return modelo;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El campo no puede estar vacío!");
                }
                this.modelo = value;
            }
        }

        public double ConsumoBaseWatts 
        {
            get
            {
                return consumoBaseWatts;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("El valor no puede ser negativo!");
                }
                this.consumoBaseWatts = value;
            }
        }

        #endregion

        #region Metodos

        public abstract double CalcularCostoMensual(int horasDiarias, double costoPorWatt);
        
        public string ObtenerInformacionBase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Marca: {Marca}");
            sb.AppendLine($"Modelo: {Modelo}");
            sb.Append($"Consumo base: {ConsumoBaseWatts}\n");
            return sb.ToString();
        }

        #endregion
    }
}
