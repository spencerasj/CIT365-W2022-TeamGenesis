using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk2
{
    public partial class SearchQuotes : Form
    {
        public SearchQuotes()
        {
            InitializeComponent();
            InitSurfaceMaterials();
        }

        private void InitSurfaceMaterials()
        {
            List<KeyValuePair<string, string>> surfaces = new List<KeyValuePair<string, string>>();
            Array materials = Enum.GetValues(typeof(DesktopMaterial));
            foreach (DesktopMaterial material in materials)
            {
                surfaces.Add(new KeyValuePair<string, string>(material.ToString(), ((int)material).ToString()));
            }
            searchBMT.DataSource = surfaces;
            searchBMT.DisplayMember = "Key";
            searchBMT.ValueMember = "Value";
        }

        private void GoBackToMain(object sender, EventArgs e)
        {
            MainMenu viewmainMenu = (MainMenu)Tag;
            viewmainMenu.Show();
            Close();
        }

        private void SearchBMT_SelectedValueChanged(object sender, EventArgs e)
        {
            SearchDataGridView.Rows.Clear();
            string SelectedMaterial = searchBMT.Text;
            string jsonFromFile = File.ReadAllText(@"Data\quotes.json");

            if (!(string.IsNullOrEmpty(jsonFromFile)))
            {
                List<DeskQuote> quoteRows = JsonConvert.DeserializeObject<List<DeskQuote>>(jsonFromFile);
                foreach (var quote in quoteRows)
                {
                    var date = quote.QuoteDate.ToString("MMM dd, yyyy");
                    var price = $"${quote.QuoteTotal.ToString()}";
                    string[] row = new string[] { quote.CustomerName, date, quote.Desk.SurfaceMaterial.ToString(), price };
                    if(quote.Desk.SurfaceMaterial.ToString() == SelectedMaterial) {
                        SearchDataGridView.Rows.Add(row);
                    }
                }
            }
        }
    }
}
