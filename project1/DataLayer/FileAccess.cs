using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;

namespace DataLayer
{
    public static class XMLFileAccess 
    {
        /// <summary>
        /// Otevreni souboru
        /// </summary>
        public static FileStream Open(string filename)
        {
            if (File.Exists(filename))
            {
                try
                {
                    FileStream fs = new FileStream(filename, FileMode.Open);
                    return fs;
                }
                catch (ArgumentException)
                {
                    return null;
                }
                catch (NotSupportedException)
                {
                    return null;
                }
                
                catch (System.Security.SecurityException)
                {
                    return null;
                }
                catch (IOException)
                {
                    return null;
                }
            }
            return null;
        }
      
    }

    


    
}
