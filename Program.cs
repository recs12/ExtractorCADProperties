using System;
using System.IO;
using shortid;
using shortid.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SolidEdgeFileProperties;
using Cad;
using Newtonsoft.Json.Linq;

namespace Extractor
{
    class Program
    {
        [STAThread]
        //[Obsolete]
        static void Main()
        {
            try
            {

                //args
                //timing

                // Path to cad
                string cadFiles = @"C:\Users\recs\Desktop\fasteners_downloaded_from_TC";

                //Short ID for the file name
                string id = Guid.NewGuid().ToString();
                string path = @"C:\Users\recs\Desktop\Report_fasteners_" + id + ".txt";

                var jArray = new JArray();

                // Create a file to write to.
                foreach (var itemPath in Directory.GetFiles(cadFiles))
                {
                    var screw = Cache.ParseItem(itemPath);
                    if (Path.GetExtension(itemPath).ToLower() == ".par")
                    {
                        var jObject = JObject.FromObject(screw);

                        var screwJObject = new JObject();

                        screwJObject.Add(screw.JdeNumber, jObject);
                        jArray.Add(screwJObject);

                    }
                }

                File.WriteAllText(path, jArray.ToString());

                //Console.ReadKey();

            }
            catch (Exception e)
            {

            }
        }
    }
}

