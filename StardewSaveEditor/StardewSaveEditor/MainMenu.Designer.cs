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
            this.fbdSaveFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.btnOpenSaveFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenSaveFolder
            // 
            this.btnOpenSaveFolder.Location = new System.Drawing.Point(270, 193);
            this.btnOpenSaveFolder.Name = "btnOpenSaveFolder";
            this.btnOpenSaveFolder.Size = new System.Drawing.Size(75, 23);
            this.btnOpenSaveFolder.TabIndex = 0;
            this.btnOpenSaveFolder.Text = "Save Folder";
            this.btnOpenSaveFolder.UseVisualStyleBackColor = true;
            this.btnOpenSaveFolder.Click += new System.EventHandler(this.btnOpenSaveFolder_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 410);
            this.Controls.Add(this.btnOpenSaveFolder);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbdSaveFolder;
        private System.Windows.Forms.Button btnOpenSaveFolder;
    }
}

