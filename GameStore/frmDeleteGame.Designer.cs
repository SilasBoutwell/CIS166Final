namespace GameStore
{
    partial class frmDeleteGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPrice = new System.Windows.Forms.Label();
            this.cboRegion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPlatform = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.lblDeveloper = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cboTitle = new System.Windows.Forms.ComboBox();
            this.cboDeveloper = new System.Windows.Forms.ComboBox();
            this.cboPublisher = new System.Windows.Forms.ComboBox();
            this.cboGenre = new System.Windows.Forms.ComboBox();
            this.cboPlatform = new System.Windows.Forms.ComboBox();
            this.cboPrice = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(28, 214);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(41, 16);
            this.lblPrice.TabIndex = 30;
            this.lblPrice.Text = "Price:";
            // 
            // cboRegion
            // 
            this.cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegion.FormattingEnabled = true;
            this.cboRegion.Location = new System.Drawing.Point(122, 181);
            this.cboRegion.Name = "cboRegion";
            this.cboRegion.Size = new System.Drawing.Size(162, 24);
            this.cboRegion.TabIndex = 29;
            this.cboRegion.SelectedIndexChanged += new System.EventHandler(this.cboRegion_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "Region:";
            // 
            // lblPlatform
            // 
            this.lblPlatform.AutoSize = true;
            this.lblPlatform.Location = new System.Drawing.Point(28, 156);
            this.lblPlatform.Name = "lblPlatform";
            this.lblPlatform.Size = new System.Drawing.Size(59, 16);
            this.lblPlatform.TabIndex = 26;
            this.lblPlatform.Text = "Platform:";
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(204, 255);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 26);
            this.btnExit.TabIndex = 25;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(92, 255);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 26);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(28, 128);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(47, 16);
            this.lblGenre.TabIndex = 19;
            this.lblGenre.Text = "Genre:";
            // 
            // lblPublisher
            // 
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.Location = new System.Drawing.Point(28, 101);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Size = new System.Drawing.Size(66, 16);
            this.lblPublisher.TabIndex = 18;
            this.lblPublisher.Text = "Publisher:";
            // 
            // lblDeveloper
            // 
            this.lblDeveloper.AutoSize = true;
            this.lblDeveloper.Location = new System.Drawing.Point(28, 73);
            this.lblDeveloper.Name = "lblDeveloper";
            this.lblDeveloper.Size = new System.Drawing.Size(74, 16);
            this.lblDeveloper.TabIndex = 17;
            this.lblDeveloper.Text = "Developer:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(28, 45);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(36, 16);
            this.lblTitle.TabIndex = 16;
            this.lblTitle.Text = "Title:";
            // 
            // cboTitle
            // 
            this.cboTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTitle.FormattingEnabled = true;
            this.cboTitle.Location = new System.Drawing.Point(122, 42);
            this.cboTitle.Name = "cboTitle";
            this.cboTitle.Size = new System.Drawing.Size(162, 24);
            this.cboTitle.TabIndex = 32;
            this.cboTitle.SelectedIndexChanged += new System.EventHandler(this.cboTitle_SelectedIndexChanged);
            // 
            // cboDeveloper
            // 
            this.cboDeveloper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeveloper.FormattingEnabled = true;
            this.cboDeveloper.Location = new System.Drawing.Point(122, 70);
            this.cboDeveloper.Name = "cboDeveloper";
            this.cboDeveloper.Size = new System.Drawing.Size(162, 24);
            this.cboDeveloper.TabIndex = 33;
            this.cboDeveloper.SelectedIndexChanged += new System.EventHandler(this.cboDeveloper_SelectedIndexChanged);
            // 
            // cboPublisher
            // 
            this.cboPublisher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPublisher.FormattingEnabled = true;
            this.cboPublisher.Location = new System.Drawing.Point(122, 98);
            this.cboPublisher.Name = "cboPublisher";
            this.cboPublisher.Size = new System.Drawing.Size(162, 24);
            this.cboPublisher.TabIndex = 34;
            this.cboPublisher.SelectedIndexChanged += new System.EventHandler(this.cboPublisher_SelectedIndexChanged);
            // 
            // cboGenre
            // 
            this.cboGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGenre.FormattingEnabled = true;
            this.cboGenre.Location = new System.Drawing.Point(122, 125);
            this.cboGenre.Name = "cboGenre";
            this.cboGenre.Size = new System.Drawing.Size(162, 24);
            this.cboGenre.TabIndex = 35;
            this.cboGenre.SelectedIndexChanged += new System.EventHandler(this.cboGenre_SelectedIndexChanged);
            // 
            // cboPlatform
            // 
            this.cboPlatform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlatform.FormattingEnabled = true;
            this.cboPlatform.Location = new System.Drawing.Point(122, 153);
            this.cboPlatform.Name = "cboPlatform";
            this.cboPlatform.Size = new System.Drawing.Size(162, 24);
            this.cboPlatform.TabIndex = 36;
            this.cboPlatform.SelectedIndexChanged += new System.EventHandler(this.cboPlatform_SelectedIndexChanged);
            // 
            // cboPrice
            // 
            this.cboPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrice.FormattingEnabled = true;
            this.cboPrice.Location = new System.Drawing.Point(122, 211);
            this.cboPrice.Name = "cboPrice";
            this.cboPrice.Size = new System.Drawing.Size(162, 24);
            this.cboPrice.TabIndex = 37;
            // 
            // frmDeleteGame
            // 
            this.AcceptButton = this.btnDelete;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(332, 318);
            this.Controls.Add(this.cboPrice);
            this.Controls.Add(this.cboPlatform);
            this.Controls.Add(this.cboGenre);
            this.Controls.Add(this.cboPublisher);
            this.Controls.Add(this.cboDeveloper);
            this.Controls.Add(this.cboTitle);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.cboRegion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPlatform);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblPublisher);
            this.Controls.Add(this.lblDeveloper);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmDeleteGame";
            this.Text = "DeleteGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.ComboBox cboRegion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPlatform;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.Label lblDeveloper;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cboTitle;
        private System.Windows.Forms.ComboBox cboDeveloper;
        private System.Windows.Forms.ComboBox cboPublisher;
        private System.Windows.Forms.ComboBox cboGenre;
        private System.Windows.Forms.ComboBox cboPlatform;
        private System.Windows.Forms.ComboBox cboPrice;
    }
}