namespace GameStore
{
    partial class frmGameStore
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
            this.rchGameInventory = new System.Windows.Forms.RichTextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblFilter = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cboPriceFilter = new System.Windows.Forms.ComboBox();
            this.btnComments = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rchGameInventory
            // 
            this.rchGameInventory.Location = new System.Drawing.Point(51, 78);
            this.rchGameInventory.Name = "rchGameInventory";
            this.rchGameInventory.ReadOnly = true;
            this.rchGameInventory.Size = new System.Drawing.Size(352, 251);
            this.rchGameInventory.TabIndex = 0;
            this.rchGameInventory.TabStop = false;
            this.rchGameInventory.Text = "";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(426, 302);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 27);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(426, 150);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 27);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(48, 51);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(39, 16);
            this.lblFilter.TabIndex = 3;
            this.lblFilter.Text = "Filter:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(426, 226);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(83, 27);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnViewAll
            // 
            this.btnViewAll.Location = new System.Drawing.Point(426, 188);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(83, 27);
            this.btnViewAll.TabIndex = 1;
            this.btnViewAll.Text = "View All";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(93, 45);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(171, 22);
            this.txtFilter.TabIndex = 5;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // cboPriceFilter
            // 
            this.cboPriceFilter.FormattingEnabled = true;
            this.cboPriceFilter.Items.AddRange(new object[] {
            "Price Filter",
            "Free",
            "$1-$19",
            "$20-$49",
            "$50-$99",
            "$100+"});
            this.cboPriceFilter.Location = new System.Drawing.Point(270, 43);
            this.cboPriceFilter.Name = "cboPriceFilter";
            this.cboPriceFilter.Size = new System.Drawing.Size(133, 24);
            this.cboPriceFilter.TabIndex = 6;
            this.cboPriceFilter.SelectedIndexChanged += new System.EventHandler(this.cboPriceFilter_SelectedIndexChanged);
            // 
            // btnComments
            // 
            this.btnComments.Location = new System.Drawing.Point(426, 264);
            this.btnComments.Name = "btnComments";
            this.btnComments.Size = new System.Drawing.Size(83, 27);
            this.btnComments.TabIndex = 3;
            this.btnComments.Text = "Comments";
            this.btnComments.UseVisualStyleBackColor = true;
            this.btnComments.Click += new System.EventHandler(this.btnComments_Click);
            // 
            // frmGameStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 371);
            this.Controls.Add(this.btnComments);
            this.Controls.Add(this.cboPriceFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btnViewAll);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.rchGameInventory);
            this.Name = "frmGameStore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Infinite Bits Game Store";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchGameInventory;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ComboBox cboPriceFilter;
        private System.Windows.Forms.Button btnComments;
    }
}

