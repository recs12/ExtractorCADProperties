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

namespace Extractor
{
    class Program
    {
        [STAThread]
        [Obsolete]
        static void Main()
        {
            try
            {

                //Refactoring
                //
                //GetFiles
                //Structure
                //args
                //timing
                //short ID for name file

                string id = ShortId.Generate();
                string path = @"C:\Users\Slimane\Desktop\dev\fasteners"+ id +".txt";
                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(path))
                    {

                        foreach (var itemPath in Directory.GetFiles(@"C:\Users\Slimane\Desktop\It's here\solidedge\Hardware\Washer"))
                        {
                            //string itemPath = @"C:\Users\Slimane\Desktop\It's here\solidedge\Hardware\Nuts\E_AB_0.138-32_SS.par";
                            var screw = Cache.ParseItem(itemPath);
                            if (Path.GetExtension(itemPath).ToLower() == ".par")
                            {
                                sw.WriteLine($"{0}:{current:{0}, revision:{1}, filename:{2}},", screw.JdeNumber, screw.Revision, screw.Filename);

                            }
                        }
                    }
                }


            }
            finally
            {
                Console.ReadKey();
            }

        }
    }
}

