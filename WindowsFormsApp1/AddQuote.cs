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
using Newtonsoft.Json;

namespace MegaDesk2
{
    public partial class AddQuote : Form
    {
        public readonly DeskQuote deskQuote = new DeskQuote();
        public AddQuote()
        {
            InitializeComponent();
            InitSurfaceMaterials();

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
        private void AddNewQuote(object sender, EventArgs e)
        {
            //Before setting variables and going to next form make sure that the fields are not empty
            if(!(textDeskWidth.Text == "" || textDeskDepth.Text == "" || textNumberOfDrawers.Text == "" || textName.Text== "" || rushOrderDropDown.SelectedItem == null || desktopMaterialDropDown.SelectedItem == null))
            {
                //Remove error message
                labelError.Visible = false;

                //set variables as well as object variables
                int width = Int32.Parse(textDeskWidth.Text);
                int depth = Int32.Parse(textDeskDepth.Text);
                int numberOfDrawers = Int32.Parse(textNumberOfDrawers.Text);
                DesktopMaterial surfaceType = (DesktopMaterial)Enum.Parse(typeof(DesktopMaterial),
                    desktopMaterialDropDown.SelectedValue.ToString());
                deskQuote.CustomerName = textName.Text;
                deskQuote.RushDays = Int32.Parse(rushOrderDropDown.SelectedItem as String);

                //Create desk object and send it to the deskquote
                Desk desk = new Desk(width, depth,numberOfDrawers,surfaceType);
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
            //If any of the fields are empty display error message
            else
            {
                labelError.Visible = true;
            }
        }

        //Checks the value of the width 
        private void CheckWidthValue(object sender, CancelEventArgs e)
        {
            try
            {
                int width = Int32.Parse(textDeskWidth.Text);
                addQuoteButton.Click += AddNewQuote;
                CheckCorrectValue(width,Desk.MINWIDTH,Desk.MAXWIDTH, textDeskWidth);
            }
            catch
            {
                addQuoteButton.Click -= AddNewQuote;
                deskWidthErr.Text = "Please enter a number";
            }
        }

        //Very messy but makes it so only a number, tab, backspace, and enter can be pressed. Then checks values if tab or enter are hit

        private void TextDeskDepth_Leave(object sender, EventArgs e)
        {
            try
            {
                int depth = Int32.Parse(textDeskDepth.Text);
                addQuoteButton.Click += AddNewQuote;
                CheckCorrectValue(depth, Desk.MINDEPTH, Desk.MAXDEPTH, textDeskDepth);
            }
            catch
            {
                addQuoteButton.Click -= AddNewQuote;
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

        //Code I was copy and pasting so made a method.  
        private void CheckCorrectValue(int value, int lowest, int highest, TextBox textBox)
        {
            //Checks that numbers are within a certain range
            if (!(lowest <= value && highest >= value))
            {
                //https://stackoverflow.com/questions/34284232/disable-click-button-event-c-sharp
                addQuoteButton.Click -= AddNewQuote;

                if (textBox.Name == "textDeskWidth")
                {
                    deskWidthErr.Text = "Number needs to be between " + lowest + " and " + highest;
                }
                else if (textBox.Name == "textDeskDepth")
                {
                    deskDepthErr.Text = "Number needs to be between " + lowest + " and " + highest;
                } else if (textBox.Name == "textNumberOfDrawers")
                {
                    deskDrawerErr.Text = "Number needs to be between " + lowest + " and " + highest;
                }

            }
            //If not sets an error and makes button not active
            else
            {
                addQuoteButton.Click += AddNewQuote;

                if (textBox.Name == "textDeskWidth")
                {
                    deskWidthErr.Text = "";
                }
                else if (textBox.Name == "textDeskDepth")
                {
                    deskDepthErr.Text = "";
                }
                else if (textBox.Name == "textNumberOfDrawers")
                {
                    deskDrawerErr.Text = "";
                }
            }

        }

        //Checks the value of drawers using validating Event
        private void CheckDrawerValue(object sender, CancelEventArgs e)
        {
            try
            {
                int numberOfDrawers = Int32.Parse(textNumberOfDrawers.Text);
                addQuoteButton.Click += AddNewQuote;
                CheckCorrectValue(numberOfDrawers, Desk.MINDRAWERS, Desk.MAXDRAWERS, textNumberOfDrawers);
              

            }
            catch
            {
                addQuoteButton.Click -= AddNewQuote;
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
