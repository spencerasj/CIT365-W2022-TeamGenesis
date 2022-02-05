using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk2
{
   

    public enum DesktopMaterial
    {
        Laminate = 100,
        Oak = 200,
        Rosewood = 300,
        Veneer = 125,
        Pine = 50
    }
    public class Desk
    {
        public static int MAXWIDTH = 96;
        public static int MINWIDTH = 24;
        public static int MAXDEPTH = 48;
        public static int MINDEPTH = 12;
        public static int MINDRAWERS = 0;
        public static int MAXDRAWERS = 7;

        private int width;
        private int depth;
        private int numberOfDrawers;
        private DesktopMaterial surfaceMaterial;
        
        public Desk(int width, int depth, int numberOfDrawers, DesktopMaterial surfaceMaterial)
        {
            this.width = width;
            this.depth = depth;
            this.numberOfDrawers = numberOfDrawers;
            this.surfaceMaterial = surfaceMaterial;
        }
        public int Width
        {
            get { return width; }
            set { 
                if (MINWIDTH <= value && MAXWIDTH >= value) { 
                    width = value;
                }
                else
                {
                    throw new ValidationException("Number cannot be less than "+MINWIDTH+" or greater than "+MAXWIDTH);
                } 
            }
        }
        public int Depth
        {
            get { return depth; }
            set {
                if (MINDEPTH <= value && MAXDEPTH >= value)
                {
                    depth = value;
                }
                else
                {
                    throw new ValidationException("Number cannot be less than " + MINDEPTH + " or greater than " + MAXDEPTH);
                }
            }
        }
        public int NumberOfDrawers
        {
            get { return numberOfDrawers; }
            set
            {
                if (MINDRAWERS <= value && MAXDRAWERS >= value)
                {
                    numberOfDrawers = value;
                }
                else
                {
                    throw new ValidationException("Number cannot be less than " + MINDRAWERS + " or greater than " + MAXDRAWERS);
                }
            }
        }
        public DesktopMaterial SurfaceMaterial
        {
            get { return surfaceMaterial; }
            set { surfaceMaterial = value; }
        }

    }
}
