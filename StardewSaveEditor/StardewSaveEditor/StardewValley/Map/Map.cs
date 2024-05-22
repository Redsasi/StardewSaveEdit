using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StardewSaveEditor.StardewValley.Map
{
    internal class Map
    {
        Tile[][] tileMap;

        #region XML map
        private void ConstructFromID(int farmId)
        {
            XmlDocument xmlMap = new XmlDocument();

        }

        #endregion
        public static List<Image> SplitImage(Image img, int subImageLarge, int subImageHaut)
        {
            List<Image> images = new List<Image>();

            int xCount = img.Width / subImageLarge;
            int yCount = img.Height / subImageHaut;

            for (int x = 0; x < xCount; x++)
            {
                for (int y = 0; y < yCount; y++)
                {
                    Rectangle subImageRect = new Rectangle(y * subImageLarge, x * subImageHaut, subImageLarge, subImageHaut);
                    Bitmap subImage = new Bitmap(subImageLarge, subImageHaut);

                    using (Graphics g = Graphics.FromImage(subImage))
                    {
                        g.DrawImage(img, new Rectangle(0, 0, subImageLarge, subImageHaut), subImageRect, GraphicsUnit.Pixel);
                    }

                    images.Add(subImage);
                }
            }

            return images;

        }

        public static Image GetSpecificImageFromTileSet(Image tileSet, int imgID, int nbColumn, int width, int height)
        {

            Rectangle subImageRect = new Rectangle((imgID%nbColumn)*width, ((int)(imgID/nbColumn))*height, width, height);
            
            Bitmap subImage = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(subImage))
            {
                g.DrawImage(tileSet, new Rectangle(0, 0, width, height), subImageRect, GraphicsUnit.Pixel);
            }

            return subImage;

        }
    }
}
