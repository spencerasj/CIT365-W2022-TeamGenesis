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
            //textDeskDepth.Text = deskQuote.Desk.Depth.ToString() +" inches"; // EC
            //textDeskWidth.Text = deskQuote.Desk.Width.ToString() + " inches"; // EC

            // new code for displayquote - EC
            int width = deskQuote.Desk.Width;
            int depth = deskQuote.Desk.Depth;
            int surfaceArea = width * depth;
            int drawers = deskQuote.Desk.NumberOfDrawers;
            int surfaceCharge = (int)deskQuote.Desk.SurfaceMaterial;
            int rush = deskQuote.RushDays;

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
                orderSpeedCostLabel.Text = "$" + deskQuote.rushOrderAdditionalCosts(surfaceArea).ToString();
            }
            else
            {
                orderSpeedCostLabel.Text = "$0";
            }

            // TOTAL
            deskTotalLabel.Text = "$" + deskQuote.deskQuoteTotal().ToString();



            //textDesktopMaterial.Text = deskQuote.Desk.SurfaceMaterial.ToString(); // EC
            //textNumberOfDrawers.Text = deskQuote.Desk.NumberOfDrawers.ToString(); // EC
            //textDeskQuote.Text = "$"+deskQuote.deskQuoteTotal().ToString(); //EC
            customerLabel.Text = deskQuote.CustomerName.ToString();
            date.Text = deskQuote.QuoteDate.ToString("MMMM dd, yyyy");
            /*if (deskQuote.RushDays > 0)
            {
                textRushOrder.Text = deskQuote.RushDays.ToString() + " days";
            }
            else
            {
                textRushOrder.Text = "None";
            }*/ // EC
        }

        private void okBackToHome(object sender, EventArgs e)
        {
            MainMenu viewmainMenu = (MainMenu)Tag;
            viewmainMenu.Show();
            Close();
        }

    }
}
