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
            this.btnOpenSaveFile = new System.Windows.Forms.Button();
            this.tbxXml = new System.Windows.Forms.TextBox();
            this.tbxOwnName = new System.Windows.Forms.TextBox();
            this.lblOwner = new System.Windows.Forms.Label();
            this.lblFarmers = new System.Windows.Forms.Label();
            this.lbxFarmers = new System.Windows.Forms.ListBox();
            this.btnSwapOwner = new System.Windows.Forms.Button();
            this.fbdStardewSave = new System.Windows.Forms.FolderBrowserDialog();
            this.fbdNewSave = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenSaveFile
            // 
            this.btnOpenSaveFile.Location = new System.Drawing.Point(13, 18);
            this.btnOpenSaveFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOpenSaveFile.Name = "btnOpenSaveFile";
            this.btnOpenSaveFile.Size = new System.Drawing.Size(112, 35);
            this.btnOpenSaveFile.TabIndex = 0;
            this.btnOpenSaveFile.Text = "Open Save File";
            this.btnOpenSaveFile.UseVisualStyleBackColor = true;
            this.btnOpenSaveFile.Click += new System.EventHandler(this.btnOpenSaveFolder_Click);
            // 
            // tbxXml
            // 
            this.tbxXml.Location = new System.Drawing.Point(581, 18);
            this.tbxXml.Multiline = true;
            this.tbxXml.Name = "tbxXml";
            this.tbxXml.Size = new System.Drawing.Size(443, 601);
            this.tbxXml.TabIndex = 2;
            // 
            // tbxOwnName
            // 
            this.tbxOwnName.Enabled = false;
            this.tbxOwnName.Location = new System.Drawing.Point(223, 32);
            this.tbxOwnName.Name = "tbxOwnName";
            this.tbxOwnName.Size = new System.Drawing.Size(247, 26);
            this.tbxOwnName.TabIndex = 3;
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = true;
            this.lblOwner.Location = new System.Drawing.Point(150, 32);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(67, 20);
            this.lblOwner.TabIndex = 5;
            this.lblOwner.Text = "Owner : ";
            // 
            // lblFarmers
            // 
            this.lblFarmers.AutoSize = true;
            this.lblFarmers.Location = new System.Drawing.Point(137, 77);
            this.lblFarmers.Name = "lblFarmers";
            this.lblFarmers.Size = new System.Drawing.Size(80, 20);
            this.lblFarmers.TabIndex = 6;
            this.lblFarmers.Text = "Farmers : ";
            // 
            // lbxFarmers
            // 
            this.lbxFarmers.FormattingEnabled = true;
            this.lbxFarmers.ItemHeight = 20;
            this.lbxFarmers.Location = new System.Drawing.Point(223, 77);
            this.lbxFarmers.Name = "lbxFarmers";
            this.lbxFarmers.Size = new System.Drawing.Size(247, 284);
            this.lbxFarmers.TabIndex = 7;
            // 
            // btnSwapOwner
            // 
            this.btnSwapOwner.Location = new System.Drawing.Point(12, 69);
            this.btnSwapOwner.Name = "btnSwapOwner";
            this.btnSwapOwner.Size = new System.Drawing.Size(113, 36);
            this.btnSwapOwner.TabIndex = 8;
            this.btnSwapOwner.Text = "Swap Owner";
            this.btnSwapOwner.UseVisualStyleBackColor = true;
            this.btnSwapOwner.Click += new System.EventHandler(this.btnSwapOwner_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(13, 590);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 631);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSwapOwner);
            this.Controls.Add(this.lbxFarmers);
            this.Controls.Add(this.lblFarmers);
            this.Controls.Add(this.lblOwner);
            this.Controls.Add(this.tbxOwnName);
            this.Controls.Add(this.tbxXml);
            this.Controls.Add(this.btnOpenSaveFile);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOpenSaveFile;
        private System.Windows.Forms.TextBox tbxXml;
        private System.Windows.Forms.TextBox tbxOwnName;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.Label lblFarmers;
        private System.Windows.Forms.ListBox lbxFarmers;
        private System.Windows.Forms.Button btnSwapOwner;
        private System.Windows.Forms.FolderBrowserDialog fbdStardewSave;
        private System.Windows.Forms.FolderBrowserDialog fbdNewSave;
        private System.Windows.Forms.Button btnSave;
    }
}

