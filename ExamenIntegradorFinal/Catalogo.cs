using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExamenIntegradorFinal
{
    public class Catalogo
    {
        #region Atributos

        private List<Electrodomestico> electrodomesticos;

        #endregion

        #region Constructores

        private Catalogo()
        {
            this.electrodomesticos = new List<Electrodomestico>();
        }

        public Catalogo(List<Electrodomestico> electrodomesticos):this()
        {
            this.electrodomesticos = electrodomesticos;
        }

        #endregion

        #region Propiedades
        #endregion

        #region Metodos

        public void AnadirElectrodomestico(Electrodomestico electro)
        {
            if (BuscarElectrodomestico(electro) == false)
            {

                this.electrodomesticos.Add(electro);
            }
            //podría crear un else y lanzar una excepción de datoInvalidoException.
        }

        private bool BuscarElectrodomestico(Electrodomestico electro)
        {
            bool existe = false;
            foreach (Electrodomestico electrodomestico in this.electrodomesticos)
            {
                if (electrodomestico.Id == electro.Id && electrodomestico.Marca == electro.Marca && electrodomestico.Modelo == electro.Modelo)
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }
        /*
        public string MostrarEmpleados()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Empleado emp in this.listaEmpleados)
            {
                sb.Append(emp.MostrarInformacion());
            }
            return sb.ToString();
        }
        */

        #endregion
    }
}
