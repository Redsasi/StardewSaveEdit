using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardewSaveEditor.StardewValley.Map
{
    internal class Tile
    {
        int id;
        Image image;

        public Tile(int id, Image image)
        {
            this.id = id;
            this.image = image;
        }

    }
}
