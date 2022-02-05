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
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace MegaDesk2
{
    public partial class AddQuote : Form
    {
        public readonly DeskQuote deskQuote = new DeskQuote();
        public Desk desk = new Desk();
        public bool widthCheck = false;
        public bool depthCheck = false;
        public bool drawerCheck = false;
        public AddQuote()
        {
            InitializeComponent();
            InitSurfaceMaterials();

            addQuoteButton.Enabled = false;
            rushOrderDropDown.SelectedItem = "14";
        }


        private void InitSurfaceMaterials()
        {
            List<KeyValuePair<string, string>> surfaces = new List<KeyValuePair<string, string>>();
            Array materials = Enum.GetValues(typeof(DesktopMaterial));
            foreach (DesktopMaterial material in materials)
            {
             surfaces.Add(new KeyValuePair<string, string>(material.ToString(), ((int)material).ToString()));
            }
            desktopMaterialDropDown.DataSource = surfaces;
            desktopMaterialDropDown.DisplayMember = "Key";
            desktopMaterialDropDown.ValueMember = "Value";
        }

        private void ValidateInfo()
        {
            if (!(textDeskWidth.Text == "" || textDeskDepth.Text == "" || textNumberOfDrawers.Text == "" ||
                  textName.Text == "" ))
            {
                if (widthCheck && depthCheck && drawerCheck)
                {
                    addQuoteButton.Enabled = true;
                }
            }
            else
            {
                labelError.Visible = true;
            }

        }
        private void AddNewQuote(object sender, EventArgs e)
        {
           
                //Remove error message
                labelError.Visible = false;

                
                DesktopMaterial surfaceType = (DesktopMaterial)Enum.Parse(typeof(DesktopMaterial),
                    desktopMaterialDropDown.SelectedValue.ToString());
                deskQuote.CustomerName = textName.Text;
                deskQuote.RushDays = Int32.Parse(rushOrderDropDown.SelectedItem as String);
                desk.SurfaceMaterial = surfaceType;
                deskQuote.Desk = desk;
                deskQuote.DeskQuoteTotal();

                //This saves the object to a json file
                try
                {
                    String jsonFromFile = File.ReadAllText(@"Data/quotes.json");
                
                    if (!(String.IsNullOrEmpty(jsonFromFile)))
                    {
                        List<DeskQuote> deskQuotes = JsonConvert.DeserializeObject<List<DeskQuote>>(jsonFromFile);
                        deskQuotes.Add(deskQuote);
                        string json = JsonConvert.SerializeObject(deskQuotes, Formatting.Indented);

                        File.WriteAllText(@"Data/quotes.json", json);


                    }
                    else
                    {
                        List <DeskQuote> deskQuotes = new List<DeskQuote>();
                        deskQuotes.Add(deskQuote);
                        string json = JsonConvert.SerializeObject(deskQuotes, Formatting.Indented);

                        File.WriteAllText(@"Data/quotes.json", json);
                    }

                }
                catch
                {
                    Console.WriteLine("ERROR: File could not be found");
                    MessageBox.Show("ERROR: Quote could not be saved");
                }

                //Create new form and show it
                DisplayQuote viewDisplayQuote = new DisplayQuote(deskQuote);
                MainMenu viewmainMenu = (MainMenu)Tag;
                viewDisplayQuote.Tag = viewmainMenu;
                viewDisplayQuote.Show();
                Close();
        }

        //Checks the value of the width 
        private void CheckWidthValue(object sender, CancelEventArgs e)
        {
            try
            {
                deskWidthErr.Text = "";
                desk.Width = Int32.Parse(textDeskWidth.Text);
                widthCheck = true;
                ValidateInfo();
            }
           
            catch (ValidationException)
            {
                deskWidthErr.Text = "Number needs to be between " + Desk.MINWIDTH + " and " + Desk.MAXWIDTH;
            }
            catch
            {
                deskWidthErr.Text = "Please enter a number";
            }
          
        }

        //Very messy but makes it so only a number, tab, backspace, and enter can be pressed. Then checks values if tab or enter are hit

        private void TextDeskDepth_Leave(object sender, EventArgs e)
        {
            try
            {
                deskDepthErr.Text = "";
                desk.Depth = Int32.Parse(textDeskDepth.Text);
                depthCheck = true;
                ValidateInfo();
            }
            catch (ValidationException)
            {
                deskDepthErr.Text = "Number needs to be between " + Desk.MINDEPTH + " and " + Desk.MAXDEPTH;

            }
            catch
            {
                deskDepthErr.Text = "Please enter a number";
            }
        }

        private void CheckDepthValue(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.CapsLock)
            {
                e.Handled = true;
            }
            else if (Char.IsDigit(e.KeyChar) && !(Char.IsControl(e.KeyChar)))
            {
                e.Handled = false;
            }
            else if(e.KeyChar == (Char)Keys.Back){
                e.Handled = false;
            }
            else
            {
                deskDepthErr.Text = "Please enter a number";
                e.Handled = true;
            };
        }
        
        //Checks the value of drawers using validating Event
        private void CheckDrawerValue(object sender, CancelEventArgs e)
        {
            try
            {
                deskDrawerErr.Text = "";
                desk.NumberOfDrawers = Int32.Parse(textNumberOfDrawers.Text);
                drawerCheck = true;
                ValidateInfo();
            }
            catch (ValidationException)
            {
                deskDrawerErr.Text = "Number needs to be between " + Desk.MINDRAWERS + " and " + Desk.MAXDRAWERS;
            }
            catch
            {
                deskDrawerErr.Text = "Please enter a number";
            }
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            MainMenu viewmainMenu = (MainMenu)Tag;
            viewmainMenu.Show();
            Close();
        }

    }
}
