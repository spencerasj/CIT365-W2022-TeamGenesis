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

            // new code for displayquote - EC
            int width = deskQuote.Desk.Width;
            int depth = deskQuote.Desk.Depth;
            int surfaceArea = width * depth;
            int drawers = deskQuote.Desk.NumberOfDrawers;
            int surfaceCharge = (int)deskQuote.Desk.SurfaceMaterial;
            int rush = deskQuote.RushDays;

            customerLabel.Text = deskQuote.CustomerName.ToString();
            date.Text = deskQuote.QuoteDate.ToString("MMMM dd, yyyy");

            // SURFACE AREA
            totalSqInLabel.Text = surfaceArea.ToString() + " sq in";
            if (surfaceArea <= 1000)
            {
                SqInSurchargeLabel.Text = "$0";
            }
            else if (surfaceArea > 1000)
            {
                SqInSurchargeLabel.Text = "$" + (surfaceArea - 1000).ToString();
            }
            else
            {
                throw (new Exception("Surface Area cannot be less than 0."));
            }

            // DRAWERS
            totalDrawersLabel.Text = "Qty: " + drawers.ToString();
            totalDrawerCostLabel.Text = "$" + (drawers * 50).ToString();

            // SURFACE
            surfaceMaterialLabel.Text = deskQuote.Desk.SurfaceMaterial.ToString();
            surfaceMaterialChargeLabel.Text = "$" + surfaceCharge.ToString();

            // RUSH
            if (deskQuote.RushDays < 14)
            {
                orderSpeedLabel.Text = deskQuote.RushDays.ToString() + " days";
            }
            else
            {
                orderSpeedLabel.Text = "None";
            }
            
            if(rush < 14)
            {
                orderSpeedCostLabel.Text = "$" + deskQuote.RushOrderAdditionalCosts(surfaceArea).ToString();
            }
            else
            {
                orderSpeedCostLabel.Text = "$0";
            }

            // TOTAL
            deskTotalLabel.Text = "$" + deskQuote.DeskQuoteTotal().ToString();


        }

        private void OkBackToHome(object sender, EventArgs e)
        {
            MainMenu viewmainMenu = (MainMenu)Tag;
            viewmainMenu.Show();
            Close();
        }

    }
}
