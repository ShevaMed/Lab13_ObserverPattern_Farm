using ObserverFarmLib.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverFarmLib.Subjects
{
    public class Farm : AbstractSubject
    {
        private List<Plant> plants = new List<Plant>();
        private Bitmap[] arrPlantsBitmap;
        Random rand = new Random();

        public Farm(Bitmap[] arrPlantsBitmap)
        {
            this.arrPlantsBitmap = arrPlantsBitmap;
        }

        public void AddPlant(Plant plant)
        {
            plants.Add(plant);
            //NotifyObservers();
        }

        public void RemovePlant(Plant plant)
        {
            plants.Remove(plant);
            //NotifyObservers();
        }

        protected override void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(plants);
            }
        }

        public void PassDay()
        {
            for (int i = 0; i < plants.Count; i++)
            {
                if (plants[i].IsHarvestable())
                {
                    Point tempPoint = plants[i].point;

                    RemovePlant(plants[i]);

                    AddPlant(GeneratePlant(tempPoint));
                }
                else
                {
                    plants[i].growthLevel += 1;
                    plants[i].size.Width += 1;
                    plants[i].size.Height += 2;
                }
            }
            NotifyObservers();
        }

        public Plant GeneratePlant(Point point)
        {
            Bitmap randomBitmap = arrPlantsBitmap[rand.Next(0, arrPlantsBitmap.Length)];
            Size size = new Size(20, 40);
            int daysToHarvest = rand.Next(35, 45);

            return new Plant(randomBitmap, size, point, daysToHarvest);
        }
    }
}
