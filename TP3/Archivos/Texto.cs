using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excepciones;

namespace Archivos
{
    /// <summary>
    /// Implementacion de la interfaz IArchivo
    /// </summary>
   public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Implementacion del metodo Guardar de la Interfaz IArchivo
        /// Guarda en un archivo de texto con nombre archivo la informacion pasada como dato.
        /// De no poder lanza la excepcion ArchivosException.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {            
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(archivo);
                sw.Write(datos);
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if (!ReferenceEquals(sw,null))
                    sw.Close();
            }
            return true;
        }


        /// <summary>
        /// Abre y retorna la informacion guardada en el archivo de texto pasado por parametro.
        /// De no poder lanza la excepcion ArchivosException.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {

            StreamReader lectura = null;
            datos = string.Empty;

            try
            {
                lectura = new StreamReader(archivo);
                datos = lectura.ReadToEnd();
                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if (!(lectura is null))
                    lectura.Close();
            }
        }

    }
}
