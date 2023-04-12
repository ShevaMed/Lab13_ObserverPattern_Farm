using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverFarmLib.Objects
{
    public class Plant
    {
        public Bitmap img;
        public Size size;
        public Point point;
        private int daysToHarvest;
        public int growthLevel;

        public Plant(Bitmap img, Size size, Point point, int daysToHarvest)
        {
            this.img = img;
            this.size = size;
            this.point = point;
            this.daysToHarvest = daysToHarvest;
            this.growthLevel = 0;
        }

        public bool IsHarvestable()
        {
            return growthLevel >= daysToHarvest;
        }
    }
}
