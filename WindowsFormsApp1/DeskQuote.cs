using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk2
{
     public class DeskQuote
    {
        private Desk desk;
        private int rushDays;
        private string customerName;
        private DateTime quoteDate;
        public static Dictionary<int, int> LessThanThousand = new Dictionary<int, int>()
        {
            {3,60},
            {5,40},
            {7,30}

        };
        public static Dictionary<int, int> BetweenThousandAndTwoThousand = new Dictionary<int, int>()
        {
            {3,70},
            {5,50},
            {7,35}

        };
        public static Dictionary<int, int> OverTwoThousand = new Dictionary<int, int>()
        {
            {3, 80},
            {5, 60},
            {7, 40}

        };
        public static int [] rushOrderCost = { };

        /*
        public DeskQuote(Desk desk, string customerName, int rushDays)
        {
            this.desk = desk;
            this.customerName = customerName;
            this.rushDays = rushDays;
            quoteDate = DateTime.Now;
        }
        */
        public DeskQuote()
        {
            quoteDate = DateTime.Now;
        }
        

        public int rushOrderAdditionalCosts(int surfaceArea)
        {
            int additionalRushOrderCost = 0;
            if(surfaceArea < 1000)
            {
                additionalRushOrderCost += LessThanThousand[rushDays];
            }else if (surfaceArea > 1000 && surfaceArea < 2000)
            {
                additionalRushOrderCost += BetweenThousandAndTwoThousand[rushDays];
            }else
            {
                additionalRushOrderCost += OverTwoThousand[rushDays];
            }
            return additionalRushOrderCost;
        }

        public int rushOrderAdditionalCosts()
        {
            int surfaceArea = desk.Width * desk.Depth;
            int additionalRushOrderCost = 0;
            if (surfaceArea < 1000)
            {
                additionalRushOrderCost += LessThanThousand[rushDays];
            }
            else if (surfaceArea > 1000 && surfaceArea < 2000)
            {
                additionalRushOrderCost += BetweenThousandAndTwoThousand[rushDays];
            }
            else
            {
                additionalRushOrderCost += OverTwoThousand[rushDays];
            }
            return additionalRushOrderCost;
        }
        public int deskQuoteTotal()
        {
            int price = 200;
            int surfaceArea = desk.Width * desk.Depth;
            if(surfaceArea > 1000)
            {
                price += (surfaceArea - 100);
            }
            price += (desk.NumberOfDrawers * 50);
            switch (desk.SurfaceMaterial)
            {
                case "Oak":
                    price += 200;
                    break;
                case "Laminate":
                    price += 100;
                    break;
                case "Pine":
                    price += 50;
                    break;
                case "Rosewood":
                    price += 300;
                    break;
                case "Veneer":
                    price += 125;
                    break;
            }
            if (rushDays > 0)
            {
                price += rushOrderAdditionalCosts(surfaceArea);
            }
            return price;

        }



        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public int RushDays
        {
            get { return rushDays; }
            set { 
                    if (value == 0 || value == 3 || value == 5 || value == 7)
                    {
                        rushDays = value;
                    }
                    else
                    {
                    throw (new Exception("Needs to be a Number 0, 3, 5 or 7"));
                    }
                }
        }

        public DateTime QuoteDate
        {
            get { return quoteDate; }
        }

        public Desk Desk
        {
            get { return desk; }
            set { desk = value; }
        }

    }
}
