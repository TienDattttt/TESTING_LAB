namespace BaiTapApDung
{
        partial class Form1
        {
            /// <summary>
            ///  Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            private System.Windows.Forms.Label lblOrgName;
            private System.Windows.Forms.Label lblAddress;
            private System.Windows.Forms.Label lblPhone;
            private System.Windows.Forms.Label lblEmail;

            private System.Windows.Forms.TextBox txtOrgName;
            private System.Windows.Forms.TextBox txtAddress;
            private System.Windows.Forms.TextBox txtPhone;
            private System.Windows.Forms.TextBox txtEmail;

            private System.Windows.Forms.Button btnSave;
            private System.Windows.Forms.Button btnBack;
            private System.Windows.Forms.Button btnDirector;

            private System.Windows.Forms.Label lblStatus;
            private System.Windows.Forms.ErrorProvider errorProvider1;

            /// <summary>
            ///  Clean up any resources being used.
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
                this.lblOrgName = new System.Windows.Forms.Label();
                this.lblAddress = new System.Windows.Forms.Label();
                this.lblPhone = new System.Windows.Forms.Label();
                this.lblEmail = new System.Windows.Forms.Label();
                this.txtOrgName = new System.Windows.Forms.TextBox();
                this.txtAddress = new System.Windows.Forms.TextBox();
                this.txtPhone = new System.Windows.Forms.TextBox();
                this.txtEmail = new System.Windows.Forms.TextBox();
                this.btnSave = new System.Windows.Forms.Button();
                this.btnBack = new System.Windows.Forms.Button();
                this.btnDirector = new System.Windows.Forms.Button();
                this.lblStatus = new System.Windows.Forms.Label();
                this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
                ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
                this.SuspendLayout();
                // 
                // lblOrgName
                // 
                this.lblOrgName.AutoSize = true;
                this.lblOrgName.Location = new System.Drawing.Point(30, 30);
                this.lblOrgName.Name = "lblOrgName";
                this.lblOrgName.Size = new System.Drawing.Size(128, 15);
                this.lblOrgName.TabIndex = 0;
                this.lblOrgName.Text = "Organization Name (*)";
                // 
                // txtOrgName
                // 
                this.txtOrgName.Location = new System.Drawing.Point(180, 27);
                this.txtOrgName.Name = "txtOrgName";
                this.txtOrgName.Size = new System.Drawing.Size(250, 23);
                this.txtOrgName.TabIndex = 1;
                // 
                // lblAddress
                // 
                this.lblAddress.AutoSize = true;
                this.lblAddress.Location = new System.Drawing.Point(30, 70);
                this.lblAddress.Name = "lblAddress";
                this.lblAddress.Size = new System.Drawing.Size(49, 15);
                this.lblAddress.TabIndex = 2;
                this.lblAddress.Text = "Address";
                // 
                // txtAddress
                // 
                this.txtAddress.Location = new System.Drawing.Point(180, 67);
                this.txtAddress.Name = "txtAddress";
                this.txtAddress.Size = new System.Drawing.Size(250, 23);
                this.txtAddress.TabIndex = 3;
                // 
                // lblPhone
                // 
                this.lblPhone.AutoSize = true;
                this.lblPhone.Location = new System.Drawing.Point(30, 110);
                this.lblPhone.Name = "lblPhone";
                this.lblPhone.Size = new System.Drawing.Size(43, 15);
                this.lblPhone.TabIndex = 4;
                this.lblPhone.Text = "Phone";
                // 
                // txtPhone
                // 
                this.txtPhone.Location = new System.Drawing.Point(180, 107);
                this.txtPhone.Name = "txtPhone";
                this.txtPhone.Size = new System.Drawing.Size(250, 23);
                this.txtPhone.TabIndex = 5;
                // 
                // lblEmail
                // 
                this.lblEmail.AutoSize = true;
                this.lblEmail.Location = new System.Drawing.Point(30, 150);
                this.lblEmail.Name = "lblEmail";
                this.lblEmail.Size = new System.Drawing.Size(36, 15);
                this.lblEmail.TabIndex = 6;
                this.lblEmail.Text = "Email";
                // 
                // txtEmail
                // 
                this.txtEmail.Location = new System.Drawing.Point(180, 147);
                this.txtEmail.Name = "txtEmail";
                this.txtEmail.Size = new System.Drawing.Size(250, 23);
                this.txtEmail.TabIndex = 7;
                // 
                // btnSave
                // 
                this.btnSave.Location = new System.Drawing.Point(180, 200);
                this.btnSave.Name = "btnSave";
                this.btnSave.Size = new System.Drawing.Size(75, 27);
                this.btnSave.TabIndex = 8;
                this.btnSave.Text = "Save";
                this.btnSave.UseVisualStyleBackColor = true;
                this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
                // 
                // btnBack
                // 
                this.btnBack.Location = new System.Drawing.Point(270, 200);
                this.btnBack.Name = "btnBack";
                this.btnBack.Size = new System.Drawing.Size(75, 27);
                this.btnBack.TabIndex = 9;
                this.btnBack.Text = "Back";
                this.btnBack.UseVisualStyleBackColor = true;
                this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
                // 
                // btnDirector
                // 
                this.btnDirector.Enabled = false;
                this.btnDirector.Location = new System.Drawing.Point(360, 200);
                this.btnDirector.Name = "btnDirector";
                this.btnDirector.Size = new System.Drawing.Size(75, 27);
                this.btnDirector.TabIndex = 10;
                this.btnDirector.Text = "Director";
                this.btnDirector.UseVisualStyleBackColor = true;
                this.btnDirector.Click += new System.EventHandler(this.btnDirector_Click);
                // 
                // lblStatus
                // 
                this.lblStatus.AutoSize = true;
                this.lblStatus.ForeColor = System.Drawing.Color.Red;
                this.lblStatus.Location = new System.Drawing.Point(30, 245);
                this.lblStatus.Name = "lblStatus";
                this.lblStatus.Size = new System.Drawing.Size(0, 15);
                this.lblStatus.TabIndex = 11;
                // 
                // errorProvider1
                // 
                this.errorProvider1.ContainerControl = this;
                // 
                // Form1
                // 
                this.AcceptButton = this.btnSave;
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(480, 280);
                this.Controls.Add(this.lblStatus);
                this.Controls.Add(this.btnDirector);
                this.Controls.Add(this.btnBack);
                this.Controls.Add(this.btnSave);
                this.Controls.Add(this.txtEmail);
                this.Controls.Add(this.lblEmail);
                this.Controls.Add(this.txtPhone);
                this.Controls.Add(this.lblPhone);
                this.Controls.Add(this.txtAddress);
                this.Controls.Add(this.lblAddress);
                this.Controls.Add(this.txtOrgName);
                this.Controls.Add(this.lblOrgName);
                this.Name = "Form1";
                this.Text = "Organization Details";
                ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();
            }

            #endregion
        }

}

