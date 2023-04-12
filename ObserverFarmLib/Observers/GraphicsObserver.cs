using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObserverFarmLib.Objects;

namespace ObserverFarmLib.Observers
{
    public class GraphicsObserver : FarmObserver
    {
        private PictureBox backgroundReference;
        private Bitmap backgroundImage;

        public GraphicsObserver(PictureBox backgroundReference, Bitmap backgroundImage)
        {
            this.backgroundReference = backgroundReference;
            this.backgroundImage = backgroundImage;
        }

        public void Update(List<Plant> plants)
        {
            Bitmap canva = (Bitmap)backgroundImage.Clone();

            using (Graphics g = Graphics.FromImage(canva))
            {
                foreach (var plant in plants)
                {
                    g.DrawImage(plant.img, new Rectangle(plant.point, plant.size));
                }
                backgroundReference.Image?.Dispose();
                backgroundReference.Image = canva;
            }
        }
    }
}
