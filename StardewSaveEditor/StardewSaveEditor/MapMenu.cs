using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StardewSaveEditor.StardewValley.Map;

namespace StardewSaveEditor
{
    public partial class MapMenu : Form
    {
        public MapMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Invalidate();

        }

        private void MapMenu_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font drawFont = new Font("Arial", 8);

            Image imageToSplit = Image.FromFile("StardewValleyRessources\\spring_outdoorTileSheet_extra.png");

            for (int i = 0; i < 20; i++)
            {
                g.FillRectangle(Brushes.Red, new Rectangle((i + 1) * 20, 20, 20, 20));
                g.DrawImage(Map.GetSpecificImageFromTileSet(imageToSplit,i,8,16,16), new Point(((i+1)*20)+2,22));
                g.DrawString($"{i}", drawFont , Brushes.Green, new Point(((i + 1) * 20) + 2, 44));
            }
        }
    }
}
