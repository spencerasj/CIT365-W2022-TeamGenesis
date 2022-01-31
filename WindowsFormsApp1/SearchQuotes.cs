using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            comboBox1.DataSource = surfaces;
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
        }

        private void goBackToMain(object sender, EventArgs e)
        {
            MainMenu viewmainMenu = (MainMenu)Tag;
            viewmainMenu.Show();
            Close();
        }
    }
}
