using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MegaDesk2
{
    public partial class ViewAllQuotes : Form
    {
        public ViewAllQuotes()
        {
            InitializeComponent();
        }


        private void ViewAllQuotes_Load(object sender, EventArgs e)
        {
            /* string[,] rows = new string[,]
            {
                {"1", "AAA", "BBB"},
                {"2", "CCC", "DDD"},
                {"3", "EEE", "FFF"},
                {"4", "GGG", "HHH"},
                {"5", "III", "JJJ"},
                {"6", "KKK", "LLL"},
                {"7", "MMM", "NNN"}
            }; 
               for (int i = 0; i < rows.GetLength(0); i++)
            {
                string[] row = new string[rows.GetLength(1)];
                for(int j = 0; j < rows.GetLength(1); j++)
                {
                    row[j] = rows[i, j];
                }

                dataGridView1.Rows.Add(row);
            }*/

            //string[,] quoteRows = new string[,];

            string jsonFromFile = File.ReadAllText(@"Data\quotes.json");

            if (!(string.IsNullOrEmpty(jsonFromFile)))
            {
                List<DeskQuote> quoteRows = JsonConvert.DeserializeObject<List<DeskQuote>>(jsonFromFile);
                //for (int i = 0; i < quoteRows.Count; i++)
                foreach (var quote in quoteRows)
                {
                    string[] row = new string[] { quote.CustomerName, quote.QuoteDate.ToString(), quote.QuoteTotal.ToString() };
                    
                    dataGridView1.Rows.Add(row);
                    //string[] row = new string[quote.Length ;
                    //for (int j = 0; j < quote.Count; j++)
                    //foreach (var row in quote)
                    {
                        //var row = quote[j];
                        //var row2[j] = quoteRows[i, j];

                        //dataGridView1.Rows.Add(row);
                        //dataGridView1.Rows.Add(row2);
                    }
                    //dataGridView1.Rows.Add(row);
                }
                
                
                //foreach (var row in quoteRows)
                /*foreach (var quote in quoteRows)
                {
                    //dataGridView1.Rows.Add(row);
                    //Console.WriteLine(row);
                    foreach (var row in quote)
                    {
                        dataGridView1.Rows.Add(row);
                    }
                } */
            }
            //string[] row = File.ReadAllLines(@"Data\quotes.json");
            //for (int i = 0; i < quoteRows.GetLength(0); i++)
            //{
                //string[] row = File.ReadAllLines(@"Data\quotes.json");
            //}
                
        }


        private void goBackToMain(object sender, EventArgs e)
        {
            MainMenu viewmainMenu = (MainMenu)Tag;
            viewmainMenu.Show();
            Close();
        }
    }
}
