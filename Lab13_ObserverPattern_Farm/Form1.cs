using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObserverFarmLib.Observers;
using ObserverFarmLib.Subjects;

namespace Lab13_ObserverPattern_Farm
{
    public partial class Form1 : Form
    {
        private Bitmap[] arrPlantsBitmap =
        {
            new Bitmap("..\\..\\images\\corn.png"),
            new Bitmap("..\\..\\images\\wheat.png"),
            new Bitmap("..\\..\\images\\grass.png"),
            new Bitmap("..\\..\\images\\pumpkin.png"),
            new Bitmap("..\\..\\images\\onion.png"),
            new Bitmap("..\\..\\images\\beetroot.png"),
            new Bitmap("..\\..\\images\\bush.png"),
            new Bitmap("..\\..\\images\\carrot.png")
        };

        private Farm farm;
        private FarmObserver observer;
        
        public Form1()
        {
            InitializeComponent();

            farm = new Farm(arrPlantsBitmap);
            observer = new GraphicsObserver(pictureBox1, new Bitmap("..\\..\\images\\background.jpg"));
            farm.AddObserver(observer);

            int width = 30, height = Height + 200;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    farm.AddPlant(farm.GeneratePlant(new Point(width, height)));
                    width += 150;
                }
                width = 30;
                height -= 120;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            farm.PassDay();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
