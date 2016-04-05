using Labores.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace Labores.Context
{
    public class XMLContext
    {
        private XmlSerializer _serializerLabores;
        private string _contextString;

        public XMLContext(string contextString) { 
           _serializerLabores =new  XmlSerializer(typeof(List<Labor>),"Labores");
           _contextString = contextString;
           if (System.IO.File.Exists(contextString))
           {
               using (var stream = System.IO.File.OpenRead(contextString))
               {
                   Labores = (List<Labor>)_serializerLabores.Deserialize(stream);
               }
           }
           else {
               Labores = new List<Labor>();
           }
        }

        public void SaveChanges() {
            using (var writer = new System.IO.StreamWriter(_contextString))
            {
                _serializerLabores.Serialize(writer,Labores);
              
                writer.Flush();
            }
        }
        public List<Labor> Labores;
    }
}
