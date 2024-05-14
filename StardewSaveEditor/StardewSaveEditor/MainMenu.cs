using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StardewSaveEditor
{
    public partial class MainMenu : Form
    {

        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnOpenSaveFolder_Click(object sender, EventArgs e)
        {
            Folder saveFolder = fbdSaveFolder.ShowDialog();
        }
    }
}
