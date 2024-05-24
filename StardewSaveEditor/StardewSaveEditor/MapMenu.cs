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
        Map Map;
        public MapMenu()
        {
            InitializeComponent();
            Map = new Map();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Invalidate();

        }

        private void MapMenu_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.ScaleTransform(0.5f, 0.5f);
            Map.DrawMap(g);
            //Map.DrawDicImage(g);
            //Map.DrawAllInOne(g);
            //g.ResetTransform();
        }
    }
}
