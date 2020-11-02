using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Globalization;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T> where T : new() 
    {
        public bool Guardar(string archivo, T dato)
        {
           
            XmlTextWriter xmlTextWriter = null;
            XmlSerializer xmlSerializer = null;

            try
            {
                xmlTextWriter = new XmlTextWriter(archivo, Encoding.UTF8);
                xmlSerializer = new XmlSerializer(typeof(T));

                xmlTextWriter.Formatting = Formatting.Indented;
                xmlSerializer.Serialize(xmlTextWriter, dato);
                return true;

            }
            catch(Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if(!(xmlTextWriter is null))
                    xmlTextWriter.Close();
            }

        }




        public bool Leer(string archivo, out T dato)
        {
            XmlTextReader xmlTextReader = null;
            XmlSerializer xmlSerializer = null;

            try
            {                
                xmlTextReader = new XmlTextReader(archivo);
                xmlSerializer = new XmlSerializer(typeof(T));
                dato =(T)xmlSerializer.Deserialize(xmlTextReader);

                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if (!(xmlTextReader is null))
                    xmlTextReader.Close();
            }
        }
    }
}
