
using SolidEdgeAssembly;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cad
{

    public struct CadPart
    {
        public string JdeNumber;
        public string Revision;
        public string Filename;
    }

    public class Cache
    {
        public static CadPart ParseItem(string partCachePath)
        {
            SolidEdgeFileProperties.PropertySets propertySets = null;
            SolidEdgeFileProperties.Properties properties = null;
            SolidEdgeFileProperties.Property JDE = null;
            SolidEdgeFileProperties.Property REVISION = null;
            //SolidEdgeFileProperties.Property FILENAME = null;

            try
            {
                // Create new instance of the PropertySets object
                propertySets = new SolidEdgeFileProperties.PropertySets();

                // Open a file
                propertySets.Open(partCachePath, true);

                // Get a reference to the SummaryInformation properties
                properties = (SolidEdgeFileProperties.Properties)propertySets["ProjectInformation"];

                //// Jde
                JDE = (SolidEdgeFileProperties.Property)properties["Document Number"];

                //// Revision
                REVISION = (SolidEdgeFileProperties.Property)properties["Revision"];

                //// filename
                string filename = System.IO.Path.GetFileName(partCachePath);

                // formatting for json extraction
                var part = new CadPart
                {
                    JdeNumber = (string)JDE.Value,
                    Revision = (string)REVISION.Value,
                    Filename = filename
                };

                return part;

                //Console.WriteLine(JDE.Value);
                //Console.WriteLine(REVISION.Value);
                //Console.WriteLine(filename);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                var part = new CadPart
                {
                    JdeNumber = null,
                    Revision = null,
                    Filename = null
                };

                return part;
            }
        }
    }
}


