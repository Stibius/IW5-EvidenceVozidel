using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections;
using DataLayer;

namespace BusinessLayer
{
    public static class XMLS
    {
        /// <summary>
        /// Serializuje tridu col a vytvori soubor Vehicle.xml
        /// </summary>
        public static bool Save(VehicleCollection col)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(VehicleCollection));
            try
            {
                TextWriter writer = new StreamWriter("Vehicles.xml");
                serializer.Serialize(writer, col);
                writer.Close();
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (IOException)
            {
                return false;
            }
            catch (System.Security.SecurityException)
            {
                return false;
            }
            
        }
        
        /// <summary>
        /// Vytvori instanci tridy VehicleCollection a naplni ji udaji ze souboru Vehicles.xml, pokud existuje
        /// </summary>
        public static VehicleCollection Load()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(VehicleCollection));

            serializer.UnknownNode += new XmlNodeEventHandler(serializer_UnknownNode);
            serializer.UnknownAttribute += new XmlAttributeEventHandler(serializer_UnknownAttribute);

            VehicleCollection col = new VehicleCollection(); 

            FileStream fs = XMLFileAccess.Open("Vehicles.xml");
            if (fs != null)
            {
                col = (VehicleCollection)serializer.Deserialize(fs);
                fs.Close();
            }
            
            return col;
        }

        private static void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            Console.WriteLine("Unknown Node:" + e.Name + "\t" + e.Text);
        }

        private static void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            System.Xml.XmlAttribute attr = e.Attr;
            Console.WriteLine("Unknown attribute " +
            attr.Name + "='" + attr.Value + "'");
        }
    }
}
