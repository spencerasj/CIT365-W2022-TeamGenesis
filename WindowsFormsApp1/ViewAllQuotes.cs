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

            string jsonFromFile = File.ReadAllText(@"Data\quotes.json");

            if (!(string.IsNullOrEmpty(jsonFromFile)))
            {
                List<DeskQuote> quoteRows = JsonConvert.DeserializeObject<List<DeskQuote>>(jsonFromFile);
                foreach (var quote in quoteRows)
                {
                    string[] row = new string[] { quote.CustomerName, quote.QuoteDate.ToString(), quote.Desk.SurfaceMaterial.ToString(), quote.QuoteTotal.ToString() };

                    dataGridView1.Rows.Add(row);
                }
            }
        }

        private void goBackToMain(object sender, EventArgs e)
        {
            MainMenu viewmainMenu = (MainMenu)Tag;
            viewmainMenu.Show();
            Close();
        }
    }
}
