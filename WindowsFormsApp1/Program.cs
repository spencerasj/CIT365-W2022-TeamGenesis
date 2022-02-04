using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace MegaDesk2
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]


        /*
        private static Globals _globals;
        private const string JsonQuotesFile = @"Data\quotes.json";
         */


        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());

            /*
            _globals = new Globals();

            // Read in the existing people list
            ReadFromJsonFile();
            */


        }

        /*
        private static void ReadFromJsonFile()
        {
            if (File.Exists(JsonQuotesFile))
            {
                try
                {
                    var jsonData = File.ReadAllText(JsonQuotesFile);

                    if (jsonData.Length > 0)
                    {
                        _globals.Quotes = JsonConvert.DeserializeObject<List<DeskQuote>>(jsonData);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                Console.WriteLine("ERRORL Could not find JSON file.");
            }
        } */


    }
}
