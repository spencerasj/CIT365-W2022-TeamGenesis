﻿using System;
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
            //desktopMaterialDropDown.DataSource = Enum.GetValues(typeof(DesktopMaterial));
        }
        
 
        private void addQuote(object sender, EventArgs e)
        {
            //Before setting variables and going to next form make sure that the feilds are not empty
            if(!(textDeskWidth.Text == "" || textDeskDepth.Text == "" || textNumberOfDrawers.Text == "" || textName.Text== "" || rushOrderDropDown.SelectedItem == null || desktopMaterialDropDown.SelectedItem == null))
            {
                //Remove error message
                labelError.Visible = false;

                //set variables as well as object variables
                int width = Int32.Parse(textDeskWidth.Text);
                int depth = Int32.Parse(textDeskDepth.Text);
                int numberOfDrawers = Int32.Parse(textNumberOfDrawers.Text);
                string surfaceType = desktopMaterialDropDown.SelectedItem as String;
                deskQuote.CustomerName = textName.Text;
                deskQuote.RushDays = Int32.Parse(rushOrderDropDown.SelectedItem as String);

                //Create desk object and send it to the deskquote
                Desk desk = new Desk(width, depth,numberOfDrawers,surfaceType);
                deskQuote.Desk = desk;

                String jsonFromFile = File.ReadAllText(@"./quotes.json");
                
                if (!(String.IsNullOrEmpty(jsonFromFile)))
                {
                    List<DeskQuote> deskQuotes = JsonConvert.DeserializeObject<List<DeskQuote>>(jsonFromFile);
                    deskQuotes.Add(deskQuote);
                    string json = JsonConvert.SerializeObject(deskQuotes, Formatting.Indented);

                    File.WriteAllText(@"./quotes.json", json);


                }
                else
                {
                    List <DeskQuote> deskQuotes = new List<DeskQuote>();
                    deskQuotes.Add(deskQuote);
                    string json = JsonConvert.SerializeObject(deskQuotes, Formatting.Indented);

                    File.WriteAllText(@"./quotes.json", json);
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

        //https://www.youtube.com/watch?v=9Zs3Ls4odP0
        //Checks the value of the width using validating Event
        private void checkWidthValue(object sender, CancelEventArgs e)
        {
            try
            {
                int width = Int32.Parse(textDeskWidth.Text);
                checkCorrectValue(width,Desk.MINWIDTH,Desk.MAXWIDTH, textDeskWidth);
                addQuoteButton.Click += addQuote;
            }
            catch
            {
                addQuoteButton.Click -= addQuote;
                textDeskWidth.Focus();
                errorProvider.SetError(textDeskWidth, "Please enter a number");
            }
        }

        //Very messy but makes it so only a number, tab, backspace, and enter can be pressed. Then checks values if tab or enter are hit
        private void checkDepthValue(object sender, KeyPressEventArgs e)
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
            else if (e.KeyChar == (Char)Keys.Return || e.KeyChar == (Char)Keys.Tab)
            {
                e.Handled = false;
                try
                {
                    int depth =Int32.Parse(textDeskDepth.Text);
                    checkCorrectValue(depth,Desk.MINDEPTH,Desk.MAXDEPTH,textDeskDepth);
                }
                catch 
                {
                    addQuoteButton.Click -= addQuote;
                    textDeskDepth.Focus();
                    errorProvider.SetError(textDeskDepth, "Please enter a number");
                }
               
            }
            else
            {
                errorProvider.SetError(textDeskDepth, "Please enter a number");
                e.Handled = true;
            };
        }

        //Code I was copy and pasting so made a method.  
        private void checkCorrectValue(int value, int lowest, int highest, TextBox textBox)
        {
            //Checks that numbers are within a certain range
            if (!(lowest <= value && highest >= value))
            {
                //https://stackoverflow.com/questions/34284232/disable-click-button-event-c-sharp
                addQuoteButton.Click -= addQuote;
                textBox.Focus();
                errorProvider.SetError(textBox, "Number needs to be between " + lowest + " and " + highest);

            }
            //If not sets an error and makes button not active
            else
            {
                addQuoteButton.Click += addQuote;
                errorProvider.SetError(textBox, null);
            }

        }

        //Checks the value of drawers using validating Event
        private void checkDrawerValue(object sender, CancelEventArgs e)
        {
            try
            {
                int numberOfDrawers = Int32.Parse(textNumberOfDrawers.Text);
                checkCorrectValue(numberOfDrawers, Desk.MINDRAWERS, Desk.MAXDRAWERS, textNumberOfDrawers);
                addQuoteButton.Click += addQuote;

            }
            catch
            {
                addQuoteButton.Click -= addQuote;
                textNumberOfDrawers.Focus();
                errorProvider.SetError(textNumberOfDrawers, "Please enter a number");
            }
        }

    }
}