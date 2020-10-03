using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public class Taller
    {
        #region "Atributos"
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;

        #endregion

        #region "Enumerados"
        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos
        }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor privado. Inicializa la lista de vehiculos.
        /// </summary>
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        /// <summary>
        /// Inicializa una nueva instancia del tipo Taller. 
        /// Asigna la dimension de la lista y la inicializa.
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Taller(int espacioDisponible):this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos en formato string.
        /// Sobreescritura del metodo ToString de la clase Object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", 
                taller.vehiculos.Count, taller.espacioDisponible);
            sb.AppendLine("");
            
            //switch + if: Recorre la lista y muestra solo el tipo pedido o todos segun se solicite.
            foreach (Vehiculo vehiculoDeLaLista in taller.vehiculos)
            {                
                switch (tipo)
                {
                    case ETipo.Ciclomotor:
                        if(vehiculoDeLaLista is Ciclomotor)
                        {
                            sb.AppendLine(vehiculoDeLaLista.Mostrar());
                        }                        
                        break;
                    case ETipo.Sedan:
                        if(vehiculoDeLaLista is Sedan)
                        { 
                            sb.AppendLine(vehiculoDeLaLista.Mostrar());
                        }
                        break;
                    case ETipo.SUV:
                        if(vehiculoDeLaLista is Suv)
                        { 
                            sb.AppendLine(vehiculoDeLaLista.Mostrar());
                        }
                        break;
                    default:
                        sb.AppendLine(vehiculoDeLaLista.Mostrar());
                        break;
                }
            }
            return sb.ToString();
        }

        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista, previa verificacion que el elemento no pertenezca a la lista y que haya lugar disponible.
        /// </summary>
        /// <param name="taller">Objeto de tipo lista donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar de tipo Vehiculo</param>
        /// <returns></returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            if (taller.vehiculos.Count == taller.espacioDisponible)
            {
                return taller;
            }
            
            //Verifico que no se encuentre en la lista.
            foreach (Vehiculo vehiculoLista in taller.vehiculos)
            {
                if (vehiculoLista == vehiculo)
                    return taller;
            }

            taller.vehiculos.Add(vehiculo);
            return taller;
        }

        /// <summary>
        /// Quitará un elemento de la lista.
        /// </summary>
        /// <param name="taller">Objeto de tipo lista donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar de tipo Vehiculo.</param>
        /// <returns></returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            foreach (Vehiculo vehiculoLista in taller.vehiculos)
            {
                if (vehiculoLista == vehiculo)
                {
                    taller.vehiculos.Remove(vehiculoLista);
                    break;
                }
            }

            return taller;
        }
        #endregion
    }
}
