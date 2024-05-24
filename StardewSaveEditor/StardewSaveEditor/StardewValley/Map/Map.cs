using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace StardewSaveEditor.StardewValley.Map
{
    internal class Map
    {
        Tile[,] tileMap;
        XmlDocument xmlMapDoc;
        Dictionary<int,Image> dicImage;

        const string RESPATH = "StardewValleyRessources/";

        #region XML map
        public Map()
        {

            // TODO : Faire en sorte qu'il charge une map passer en paramettre
            xmlMapDoc = XmlTools.GetXmlDock(RESPATH + "Farm_Island.tmx");

            XmlNode xmlMap = xmlMapDoc.SelectSingleNode("map");

            // Create and populate image dictionary
            dicImage = new Dictionary<int, Image>();
            CreatImageDicMap(xmlMap.SelectNodes("tileset"));

            //Creat and populate mapTile
            InitMap(xmlMap);

            CreatMapFromLayer(xmlMap.SelectNodes("layer"));

        }
        #region Creation of Image Dictionary from tilSet
        private void CreatImageDicMap(XmlNodeList tileSetNodes)
        {
            foreach (XmlNode tileSetNode in tileSetNodes)
            {
                int nbColumns = Convert.ToInt32(tileSetNode.Attributes["columns"].Value);
                int startId = Convert.ToInt32(tileSetNode.Attributes["firstgid"].Value);
                string imagePath = RESPATH + tileSetNode.SelectSingleNode("image").Attributes["source"].Value+ ".png";
                CreatImageDicFromTileset(Image.FromFile(imagePath),startId,nbColumns);
            }
        }

        private void CreatImageDicFromTileset(Image image, int startId, int nbCol)
        {
            int width = image.Width;
            int height = image.Height;
            int subDim = width/nbCol;
            int nbLine = height / subDim;

            int idImage = 0;
            for(int y =  0; y < nbLine; y++)
            {
                for(int x = 0; x < nbCol; x++)
                {

                    Bitmap subImage = new Bitmap(subDim, subDim);
                    Rectangle subRect = new Rectangle(x * subDim, y * subDim, subDim, subDim);
                    using (Graphics g = Graphics.FromImage(subImage))
                    {
                        g.DrawImage(image, new Rectangle(0, 0, subDim, subDim), subRect, GraphicsUnit.Pixel);
                    }
                    dicImage.Add(idImage + startId, subImage);
                    idImage++;
                }
            }

        }
        #endregion
        #region Creat Tile From layer csv
        private void CreatMapFromLayer(XmlNodeList xmlLayersNodes)
        {
            foreach (XmlNode xmlLayerNode in xmlLayersNodes)
            {
                //get data
                if (xmlLayerNode.Attributes["name"].Value != "Paths")
                {
                    int width = Convert.ToInt32(xmlLayerNode.Attributes["width"].Value);
                    string csv = xmlLayerNode.SelectSingleNode("data").InnerText;

                    CreatLayerFromCsv(csv, width);
                }
            }
            //XmlNode xmlLayerNode = xmlLayersNodes[0];

            //int width = Convert.ToInt32(xmlLayerNode.Attributes["width"].Value);
            //string csv = xmlLayerNode.SelectSingleNode("data").InnerText;

            //CreatLayerFromCsv(csv, width);
        }
        private void CreatLayerFromCsv(string csv,int width)
        {
            //Creat Table of csv
            csv = csv.Trim();
            string[] imagesIndex = csv.Split(',');

            //Insert Image of index into tile
            for (int i = 0; i < imagesIndex.Length; i++)
            {
                int key = Convert.ToInt32(imagesIndex[i]);
                if (dicImage.ContainsKey(key))
                {
                    tileMap[i % width, (int)i / width].addImage(dicImage[key]);
                }
            }
        }
        #endregion
        private bool ImageIsOnlyTransparent(Image img)
        {
            // Convert the Image to a Bitmap
            Bitmap bitmap = new Bitmap(img);

            // Loop through each pixel in the image
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    // Get the pixel at (x, y)
                    Color pixel = bitmap.GetPixel(x, y);

                    // Check if the alpha component is not zero
                    if (pixel.A != 0)
                    {
                        return false; // The image is not completely transparent
                    }
                }
            }

            return true;
        }
        private void InitMap(XmlNode mapNode)
        {
            int width = Convert.ToInt32(mapNode.Attributes["width"].Value);
            int height = Convert.ToInt32(mapNode.Attributes["height"].Value);

            tileMap = new Tile[width,height];

            for(int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    tileMap[x, y] = new Tile();
                }
            }
        }
        #endregion
        public void DrawMap(Graphics g)
        {
            for(int x = 0; x < tileMap.GetLength(0); x++)
            {
                for(int y = 0; y < tileMap.GetLength(1); y++)
                {
                    g.DrawImage(tileMap[x, y].getImage(), new Point(x * 16, y * 16));
                    //foreach (Image image in tileMap[x, y].getImages())
                    //{
                    //    g.DrawImage(image, new Point(x * 16, y * 16));
                    //}
                }
            }
        }
    }
}
