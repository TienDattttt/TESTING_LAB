namespace BaiTapApDung
{
        partial class DirectorForm
        {
            private System.ComponentModel.IContainer components = null;

            private System.Windows.Forms.Label lblTitle;
            private System.Windows.Forms.Label lblOrgNameLabel;
            private System.Windows.Forms.Label lblOrgNameValue;

            private System.Windows.Forms.Label lblDirectorName;
            private System.Windows.Forms.Label lblDirectorPhone;
            private System.Windows.Forms.Label lblDirectorEmail;

            private System.Windows.Forms.TextBox txtDirectorName;
            private System.Windows.Forms.TextBox txtDirectorPhone;
            private System.Windows.Forms.TextBox txtDirectorEmail;

            private System.Windows.Forms.Button btnAddDirector;
            private System.Windows.Forms.Button btnClose;

            private System.Windows.Forms.DataGridView dgvDirectors;
            private System.Windows.Forms.Label lblStatusDirector;
            private System.Windows.Forms.ErrorProvider errorProvider1;

            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region Windows Form Designer generated code

            private void InitializeComponent()
            {
                this.components = new System.ComponentModel.Container();
                this.lblTitle = new System.Windows.Forms.Label();
                this.lblOrgNameLabel = new System.Windows.Forms.Label();
                this.lblOrgNameValue = new System.Windows.Forms.Label();
                this.lblDirectorName = new System.Windows.Forms.Label();
                this.lblDirectorPhone = new System.Windows.Forms.Label();
                this.lblDirectorEmail = new System.Windows.Forms.Label();
                this.txtDirectorName = new System.Windows.Forms.TextBox();
                this.txtDirectorPhone = new System.Windows.Forms.TextBox();
                this.txtDirectorEmail = new System.Windows.Forms.TextBox();
                this.btnAddDirector = new System.Windows.Forms.Button();
                this.btnClose = new System.Windows.Forms.Button();
                this.dgvDirectors = new System.Windows.Forms.DataGridView();
                this.lblStatusDirector = new System.Windows.Forms.Label();
                this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
                ((System.ComponentModel.ISupportInitialize)(this.dgvDirectors)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
                this.SuspendLayout();
                // 
                // lblTitle
                // 
                this.lblTitle.AutoSize = true;
                this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                this.lblTitle.Location = new System.Drawing.Point(20, 15);
                this.lblTitle.Name = "lblTitle";
                this.lblTitle.Size = new System.Drawing.Size(137, 19);
                this.lblTitle.TabIndex = 0;
                this.lblTitle.Text = "Director Management";
                // 
                // lblOrgNameLabel
                // 
                this.lblOrgNameLabel.AutoSize = true;
                this.lblOrgNameLabel.Location = new System.Drawing.Point(20, 45);
                this.lblOrgNameLabel.Name = "lblOrgNameLabel";
                this.lblOrgNameLabel.Size = new System.Drawing.Size(103, 15);
                this.lblOrgNameLabel.TabIndex = 1;
                this.lblOrgNameLabel.Text = "Organization Name:";
                // 
                // lblOrgNameValue
                // 
                this.lblOrgNameValue.AutoSize = true;
                this.lblOrgNameValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
                this.lblOrgNameValue.Location = new System.Drawing.Point(140, 45);
                this.lblOrgNameValue.Name = "lblOrgNameValue";
                this.lblOrgNameValue.Size = new System.Drawing.Size(12, 15);
                this.lblOrgNameValue.TabIndex = 2;
                this.lblOrgNameValue.Text = "-";
                // 
                // lblDirectorName
                // 
                this.lblDirectorName.AutoSize = true;
                this.lblDirectorName.Location = new System.Drawing.Point(20, 80);
                this.lblDirectorName.Name = "lblDirectorName";
                this.lblDirectorName.Size = new System.Drawing.Size(87, 15);
                this.lblDirectorName.TabIndex = 3;
                this.lblDirectorName.Text = "Director Name*";
                // 
                // txtDirectorName
                // 
                this.txtDirectorName.Location = new System.Drawing.Point(140, 77);
                this.txtDirectorName.Name = "txtDirectorName";
                this.txtDirectorName.Size = new System.Drawing.Size(250, 23);
                this.txtDirectorName.TabIndex = 4;
                // 
                // lblDirectorPhone
                // 
                this.lblDirectorPhone.AutoSize = true;
                this.lblDirectorPhone.Location = new System.Drawing.Point(20, 115);
                this.lblDirectorPhone.Name = "lblDirectorPhone";
                this.lblDirectorPhone.Size = new System.Drawing.Size(88, 15);
                this.lblDirectorPhone.TabIndex = 5;
                this.lblDirectorPhone.Text = "Director Phone";
                // 
                // txtDirectorPhone
                // 
                this.txtDirectorPhone.Location = new System.Drawing.Point(140, 112);
                this.txtDirectorPhone.Name = "txtDirectorPhone";
                this.txtDirectorPhone.Size = new System.Drawing.Size(250, 23);
                this.txtDirectorPhone.TabIndex = 6;
                // 
                // lblDirectorEmail
                // 
                this.lblDirectorEmail.AutoSize = true;
                this.lblDirectorEmail.Location = new System.Drawing.Point(20, 150);
                this.lblDirectorEmail.Name = "lblDirectorEmail";
                this.lblDirectorEmail.Size = new System.Drawing.Size(80, 15);
                this.lblDirectorEmail.TabIndex = 7;
                this.lblDirectorEmail.Text = "Director Email";
                // 
                // txtDirectorEmail
                // 
                this.txtDirectorEmail.Location = new System.Drawing.Point(140, 147);
                this.txtDirectorEmail.Name = "txtDirectorEmail";
                this.txtDirectorEmail.Size = new System.Drawing.Size(250, 23);
                this.txtDirectorEmail.TabIndex = 8;
                // 
                // btnAddDirector
                // 
                this.btnAddDirector.Location = new System.Drawing.Point(140, 185);
                this.btnAddDirector.Name = "btnAddDirector";
                this.btnAddDirector.Size = new System.Drawing.Size(90, 27);
                this.btnAddDirector.TabIndex = 9;
                this.btnAddDirector.Text = "Add Director";
                this.btnAddDirector.UseVisualStyleBackColor = true;
                this.btnAddDirector.Click += new System.EventHandler(this.btnAddDirector_Click);
                // 
                // btnClose
                // 
                this.btnClose.Location = new System.Drawing.Point(240, 185);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(75, 27);
                this.btnClose.TabIndex = 10;
                this.btnClose.Text = "Close";
                this.btnClose.UseVisualStyleBackColor = true;
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // dgvDirectors
                // 
                this.dgvDirectors.AllowUserToAddRows = false;
                this.dgvDirectors.AllowUserToDeleteRows = false;
                this.dgvDirectors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dgvDirectors.Location = new System.Drawing.Point(20, 230);
                this.dgvDirectors.Name = "dgvDirectors";
                this.dgvDirectors.ReadOnly = true;
                this.dgvDirectors.RowTemplate.Height = 25;
                this.dgvDirectors.Size = new System.Drawing.Size(500, 200);
                this.dgvDirectors.TabIndex = 11;
                // 
                // lblStatusDirector
                // 
                this.lblStatusDirector.AutoSize = true;
                this.lblStatusDirector.ForeColor = System.Drawing.Color.Red;
                this.lblStatusDirector.Location = new System.Drawing.Point(20, 445);
                this.lblStatusDirector.Name = "lblStatusDirector";
                this.lblStatusDirector.Size = new System.Drawing.Size(0, 15);
                this.lblStatusDirector.TabIndex = 12;
                // 
                // errorProvider1
                // 
                this.errorProvider1.ContainerControl = this;
                // 
                // DirectorForm
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(550, 480);
                this.Controls.Add(this.lblStatusDirector);
                this.Controls.Add(this.dgvDirectors);
                this.Controls.Add(this.btnClose);
                this.Controls.Add(this.btnAddDirector);
                this.Controls.Add(this.txtDirectorEmail);
                this.Controls.Add(this.lblDirectorEmail);
                this.Controls.Add(this.txtDirectorPhone);
                this.Controls.Add(this.lblDirectorPhone);
                this.Controls.Add(this.txtDirectorName);
                this.Controls.Add(this.lblDirectorName);
                this.Controls.Add(this.lblOrgNameValue);
                this.Controls.Add(this.lblOrgNameLabel);
                this.Controls.Add(this.lblTitle);
                this.Name = "DirectorForm";
                this.Text = "Director Management";
                this.Load += new System.EventHandler(this.DirectorForm_Load);
                ((System.ComponentModel.ISupportInitialize)(this.dgvDirectors)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();
            }

            #endregion
        }

}