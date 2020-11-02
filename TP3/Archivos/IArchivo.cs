using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Interfaz
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IArchivo<T>
    {
        bool Guardar(string archivo, T datos);

        bool Leer(string archivo, out T datos);
    }
}
