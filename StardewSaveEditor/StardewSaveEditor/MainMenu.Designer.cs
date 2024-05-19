namespace StardewSaveEditor
{
    partial class MainMenu
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxOwnName = new System.Windows.Forms.TextBox();
            this.lblOwner = new System.Windows.Forms.Label();
            this.lblFarmers = new System.Windows.Forms.Label();
            this.lbxFarmers = new System.Windows.Forms.ListBox();
            this.btnSwapOwner = new System.Windows.Forms.Button();
            this.fbdStardewSave = new System.Windows.Forms.FolderBrowserDialog();
            this.fbdNewSave = new System.Windows.Forms.FolderBrowserDialog();
            this.tvSaveLoaded = new System.Windows.Forms.TreeView();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbLoadSave = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveAs = new System.Windows.Forms.ToolStripButton();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxOwnName
            // 
            this.tbxOwnName.Location = new System.Drawing.Point(659, 216);
            this.tbxOwnName.Name = "tbxOwnName";
            this.tbxOwnName.Size = new System.Drawing.Size(247, 26);
            this.tbxOwnName.TabIndex = 3;
            this.tbxOwnName.Validated += new System.EventHandler(this.tbxOwnName_Validated);
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = true;
            this.lblOwner.Location = new System.Drawing.Point(586, 216);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(67, 20);
            this.lblOwner.TabIndex = 5;
            this.lblOwner.Text = "Owner : ";
            // 
            // lblFarmers
            // 
            this.lblFarmers.AutoSize = true;
            this.lblFarmers.Location = new System.Drawing.Point(573, 261);
            this.lblFarmers.Name = "lblFarmers";
            this.lblFarmers.Size = new System.Drawing.Size(80, 20);
            this.lblFarmers.TabIndex = 6;
            this.lblFarmers.Text = "Farmers : ";
            // 
            // lbxFarmers
            // 
            this.lbxFarmers.FormattingEnabled = true;
            this.lbxFarmers.ItemHeight = 20;
            this.lbxFarmers.Location = new System.Drawing.Point(659, 261);
            this.lbxFarmers.Name = "lbxFarmers";
            this.lbxFarmers.Size = new System.Drawing.Size(247, 284);
            this.lbxFarmers.TabIndex = 7;
            // 
            // btnSwapOwner
            // 
            this.btnSwapOwner.Location = new System.Drawing.Point(793, 551);
            this.btnSwapOwner.Name = "btnSwapOwner";
            this.btnSwapOwner.Size = new System.Drawing.Size(113, 36);
            this.btnSwapOwner.TabIndex = 8;
            this.btnSwapOwner.Text = "Swap Owner";
            this.btnSwapOwner.UseVisualStyleBackColor = true;
            this.btnSwapOwner.Click += new System.EventHandler(this.btnSwapOwner_Click);
            // 
            // tvSaveLoaded
            // 
            this.tvSaveLoaded.Location = new System.Drawing.Point(12, 157);
            this.tvSaveLoaded.Name = "tvSaveLoaded";
            this.tvSaveLoaded.Size = new System.Drawing.Size(283, 306);
            this.tvSaveLoaded.TabIndex = 10;
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLoadSave,
            this.tsbSave,
            this.tsbSaveAs});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1037, 33);
            this.tsMain.TabIndex = 11;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbLoadSave
            // 
            this.tsbLoadSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLoadSave.Image = global::StardewSaveEditor.Properties.Resources.FolderIcone;
            this.tsbLoadSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadSave.Name = "tsbLoadSave";
            this.tsbLoadSave.Size = new System.Drawing.Size(34, 28);
            this.tsbLoadSave.Text = "Load Save";
            this.tsbLoadSave.Click += new System.EventHandler(this.tsbLoadSave_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = global::StardewSaveEditor.Properties.Resources.SaveIcone;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(34, 28);
            this.tsbSave.Text = "toolStripButton1";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbSaveAs
            // 
            this.tsbSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveAs.Image = global::StardewSaveEditor.Properties.Resources.SavePlusIcone;
            this.tsbSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveAs.Name = "tsbSaveAs";
            this.tsbSaveAs.Size = new System.Drawing.Size(34, 28);
            this.tsbSaveAs.Text = "toolStripButton1";
            this.tsbSaveAs.Click += new System.EventHandler(this.tsbSaveAs_Click);
            // 
            // MainMenu
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 631);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.tvSaveLoaded);
            this.Controls.Add(this.btnSwapOwner);
            this.Controls.Add(this.lbxFarmers);
            this.Controls.Add(this.lblFarmers);
            this.Controls.Add(this.lblOwner);
            this.Controls.Add(this.tbxOwnName);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainMenu_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainMenu_DragEnter);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbxOwnName;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.Label lblFarmers;
        private System.Windows.Forms.ListBox lbxFarmers;
        private System.Windows.Forms.Button btnSwapOwner;
        private System.Windows.Forms.FolderBrowserDialog fbdStardewSave;
        private System.Windows.Forms.FolderBrowserDialog fbdNewSave;
        private System.Windows.Forms.TreeView tvSaveLoaded;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbLoadSave;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbSaveAs;
    }
}

