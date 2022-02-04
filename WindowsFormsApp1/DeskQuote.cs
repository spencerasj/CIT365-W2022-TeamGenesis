using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace MegaDesk2
{
    public class DeskQuote
    {
        private Desk desk;
        private int rushDays;
        private string customerName;
        private DateTime quoteDate;
        private int quoteTotal;

        public DeskQuote()
        {
            quoteDate = DateTime.Now;
        }

        private Array GetRushOrder()
        {
            int[,] rushOrder = new int[3, 3];
            try
            {
                string [] numbers = File.ReadAllLines(@"Data\rushOrderPrices.txt");
                int next = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int t = 0; t < 3; t++)
                    {

                        rushOrder[i, t] = Int32.Parse((string)numbers.GetValue(next));
                        next += 1;

                    }
                }
            }
            catch
            {
                Console.WriteLine("ERROR: File could not be found");
            }
            return rushOrder;

        }
        public int rushOrderAdditionalCosts(int surfaceArea)
        {
            Array rushOrder = GetRushOrder();

            if (surfaceArea< 1000){
                switch (rushDays)
                {
                    case 3:
                        return (int)rushOrder.GetValue(0,0);

                    case 5:
                        return (int)rushOrder.GetValue(1, 0);

                    case 7:
                        return (int)rushOrder.GetValue(2, 0);

                    default: return 0;
                }
            }
            else if (surfaceArea > 1000 && surfaceArea < 2000)
            {
                switch (rushDays)
                {
                    case 3:
                        return (int)rushOrder.GetValue(0, 1);

                    case 5:
                        return (int)rushOrder.GetValue(1, 1);

                    case 7:
                        return (int)rushOrder.GetValue(2, 1);

                    default: return 0;
                }
            }
            else
            {
                switch (rushDays)
                {
                    case 3:
                        return (int)rushOrder.GetValue(0, 2);

                    case 5:
                        return (int)rushOrder.GetValue(1, 2);

                    case 7:
                        return (int)rushOrder.GetValue(2, 2);

                    default: return 0;
                }
            }

        }


        public int deskQuoteTotal()
        {
            int price = 200;
            int surfaceArea = desk.Width * desk.Depth;

            if(surfaceArea > 1000)
            {
                price += (surfaceArea - 1000);
            }
            price += (desk.NumberOfDrawers * 50);
            price += (int)desk.SurfaceMaterial;

            if (rushDays < 14)
            {
                price += rushOrderAdditionalCosts(surfaceArea);
            }
            this.QuoteTotal = price;
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
                    if (value == 14 || value == 3 || value == 5 || value == 7)
                    {
                        rushDays = value;
                    }
                    else
                    {
                    throw (new Exception("Needs to be a Number  3, 5, 7 or 14"));
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

        public int QuoteTotal
        {
            get { return quoteTotal; }
            set { quoteTotal = value; }
        }

    }
}
