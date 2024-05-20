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
        string saveFolderPath;
        public MainMenu()
        {
            InitializeComponent();
        }

        #region Load Save
        private void tsbLoadSave_Click(object sender, EventArgs e)
        {
            fbdStardewSave.ShowDialog();
            saveFolderPath = fbdStardewSave.SelectedPath;
            LoadSave(saveFolderPath);
        }
        private void MainMenu_DragDrop(object sender, DragEventArgs e)
        {
            string[] folderPath = (string[])e.Data.GetData(DataFormats.FileDrop);
            saveFolderPath = folderPath[0];
            LoadSave(saveFolderPath);
        }

        private void LoadSave(string path)
        {
            xsse = new XmlStardewSaveEditor(path);

            DirectoryInfo dirInfo = new DirectoryInfo(path);

            tvSaveLoaded.Nodes.Clear();
            TreeNode tnDir = tvSaveLoaded.Nodes.Add(dirInfo.Name);
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                tnDir.Nodes.Add(file.Name);
            }

            tvSaveLoaded.ExpandAll();

            LoadData();
        }

        #endregion

        #region Save
        private void tsbSave_Click(object sender, EventArgs e)
        {
            xsse.Save(saveFolderPath);
        }

        private void tsbSaveAs_Click(object sender, EventArgs e)
        {
            fbdNewSave.ShowDialog();
            string saveAsFolderPath = Path.Combine(fbdNewSave.SelectedPath, xsse.getSaveName());
            if (!Directory.Exists(saveAsFolderPath)) Directory.CreateDirectory(saveAsFolderPath);
            xsse.Save(saveAsFolderPath);

            saveFolderPath = saveAsFolderPath;
        }

        #endregion

        public void LoadData()
        {
            setOwnerName();
            setFarmersListBox();
        }


        public void setOwnerName()
        {
            tbxOwnName.Text = xsse.getOwnerName();
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

                LoadData();
            }
        }

        private void MainMenu_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void tbxOwnName_Validated(object sender, EventArgs e)
        {
            xsse.seOwnerName(tbxOwnName.Text);
        }
    }
}
