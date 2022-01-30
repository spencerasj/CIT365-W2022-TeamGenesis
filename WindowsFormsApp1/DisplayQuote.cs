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
    public partial class DisplayQuote : Form
    {
        private DeskQuote deskQuote;
        public DisplayQuote(DeskQuote deskQuote)
        {
            this.deskQuote = deskQuote;
            InitializeComponent();
            textDeskDepth.Text = deskQuote.Desk.Depth.ToString() +" inches";
            textDeskWidth.Text = deskQuote.Desk.Width.ToString() + " inches";
            textDesktopMaterial.Text = deskQuote.Desk.SurfaceMaterial.ToString();
            textNumberOfDrawers.Text = deskQuote.Desk.NumberOfDrawers.ToString();
            textDeskQuote.Text = "$"+deskQuote.deskQuoteTotal().ToString();
            date.Text = deskQuote.QuoteDate.ToString("MMMM dd, yyyy");
            if (deskQuote.RushDays > 0)
            {
                textRushOrder.Text = deskQuote.RushDays.ToString() + " days";
            }
            else
            {
                textRushOrder.Text = "None";
            }
        }

        private void okBackToHome(object sender, EventArgs e)
        {
            MainMenu viewmainMenu = (MainMenu)Tag;
            viewmainMenu.Show();
            Close();
        }
    }
}
