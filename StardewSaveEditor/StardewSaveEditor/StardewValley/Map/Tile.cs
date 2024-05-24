using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StardewSaveEditor.StardewValley.Map
{
    internal class Tile
    {
        List<Image> images;

        public Tile()
        {
            this.images = new List<Image>();
        }

        public void drawTile(Graphics g)
        {
            foreach(Image image in images)
            {
                g.DrawImage(image, 0, 0);
            }
        }

        public void addImage(Image img)
        {
            images.Add(img);
        }

        public Image getImage()
        {
            Bitmap imageToDraw = new Bitmap(16,16);
            using(Graphics g = Graphics.FromImage(imageToDraw))
            {
                foreach (Image image in images)
                {
                    g.DrawImage(image,new Rectangle(0,0,16,16));
                }
            }
            return imageToDraw;
        }
        public List<Image> getImages()
        {
            return images;
        }
    }
}
