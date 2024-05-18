using StardewSaveEditor.StardewValley;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace StardewSaveEditor
{
    public partial class MainMenu : Form
    {
        XmlStardewSaveEditor xsse;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnOpenSaveFolder_Click(object sender, EventArgs e)
        {
            fbdStardewSave.ShowDialog();

            LoadSave(fbdStardewSave.SelectedPath);
        }

        private void LoadSave(string path)
        {
            xsse = new XmlStardewSaveEditor(path);

            setData();
        }

        public void setData()
        {
            setOwnerName();
            setFarmersListBox();
        }
        public void setOwnerName()
        {
            tbxOwnName.Text = xsse.getPlayerName();
        }

        public void setFarmersListBox()
        {
            lbxFarmers.Items.Clear();

            XmlNodeList nodeFarmers = xsse.getFarmers();

            foreach (XmlNode nodeFarmer in nodeFarmers)
            {
                lbxFarmers.Items.Add(nodeFarmer.SelectSingleNode("name").InnerText);
            }
        }

        private void btnSwapOwner_Click(object sender, EventArgs e)
        {
            int idFarmer = lbxFarmers.SelectedIndex;
            if(idFarmer != -1)
            {
                xsse.ChangeSaveOwner(idFarmer);

                setData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            fbdNewSave.ShowDialog();

            xsse.Save(fbdNewSave.SelectedPath);
        }

        private void MainMenu_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void MainMenu_DragDrop(object sender, DragEventArgs e)
        {
            string[] folderPath = (string[])e.Data.GetData(DataFormats.FileDrop);
            LoadSave(folderPath[0]);
        }
    }
}
