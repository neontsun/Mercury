namespace Mercury.CustomControls
{
    partial class CreateSafeForm
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
            this.logoLabel = new System.Windows.Forms.Label();
            this.saveButton = new pivyLab.Control.FlatEllButton();
            this.cancel = new pivyLab.Control.FlatEllButton();
            this.safeNameSeparator = new pivyLab.Control.Separator();
            this.safeName = new System.Windows.Forms.TextBox();
            this.addField = new System.Windows.Forms.Label();
            this.fieldText1 = new System.Windows.Forms.TextBox();
            this.fieldSeparator1 = new pivyLab.Control.Separator();
            this.fieldText2 = new System.Windows.Forms.TextBox();
            this.fieldSeparator2 = new pivyLab.Control.Separator();
            this.fieldText3 = new System.Windows.Forms.TextBox();
            this.fieldSeparator3 = new pivyLab.Control.Separator();
            this.fieldText4 = new System.Windows.Forms.TextBox();
            this.fieldSeparator4 = new pivyLab.Control.Separator();
            this.fieldText5 = new System.Windows.Forms.TextBox();
            this.fieldSeparator5 = new pivyLab.Control.Separator();
            this.fieldText6 = new System.Windows.Forms.TextBox();
            this.fieldSeparator6 = new pivyLab.Control.Separator();
            this.addFieldIcon = new System.Windows.Forms.PictureBox();
            this.removeField = new System.Windows.Forms.Label();
            this.removeFieldIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.addFieldIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeFieldIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // logoLabel
            // 
            this.logoLabel.AutoSize = true;
            this.logoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logoLabel.ForeColor = System.Drawing.Color.White;
            this.logoLabel.Location = new System.Drawing.Point(33, 33);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(207, 33);
            this.logoLabel.TabIndex = 0;
            this.logoLabel.Text = "Создать сейф";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Back = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(185)))), ((int)(((byte)(84)))));
            this.saveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(87, 217);
            this.saveButton.Name = "saveButton";
            this.saveButton.RoundRadius = 2;
            this.saveButton.Size = new System.Drawing.Size(145, 33);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Создать";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancel.Back = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(185)))), ((int)(((byte)(84)))));
            this.cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancel.ForeColor = System.Drawing.Color.White;
            this.cancel.Location = new System.Drawing.Point(248, 217);
            this.cancel.Name = "cancel";
            this.cancel.RoundRadius = 2;
            this.cancel.Size = new System.Drawing.Size(145, 33);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // safeNameSeparator
            // 
            this.safeNameSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.safeNameSeparator.Location = new System.Drawing.Point(88, 133);
            this.safeNameSeparator.Name = "safeNameSeparator";
            this.safeNameSeparator.Size = new System.Drawing.Size(310, 1);
            this.safeNameSeparator.TabIndex = 4;
            // 
            // safeName
            // 
            this.safeName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.safeName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.safeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.safeName.ForeColor = System.Drawing.Color.White;
            this.safeName.Location = new System.Drawing.Point(88, 107);
            this.safeName.MaxLength = 32;
            this.safeName.Name = "safeName";
            this.safeName.Size = new System.Drawing.Size(310, 19);
            this.safeName.TabIndex = 3;
            // 
            // addField
            // 
            this.addField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addField.AutoSize = true;
            this.addField.BackColor = System.Drawing.Color.Transparent;
            this.addField.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.addField.Location = new System.Drawing.Point(85, 158);
            this.addField.Name = "addField";
            this.addField.Size = new System.Drawing.Size(106, 16);
            this.addField.TabIndex = 6;
            this.addField.Text = "Добавить поле";
            // 
            // fieldText1
            // 
            this.fieldText1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.fieldText1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fieldText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fieldText1.ForeColor = System.Drawing.Color.White;
            this.fieldText1.Location = new System.Drawing.Point(87, 187);
            this.fieldText1.MaxLength = 32;
            this.fieldText1.Name = "fieldText1";
            this.fieldText1.Size = new System.Drawing.Size(310, 19);
            this.fieldText1.TabIndex = 3;
            this.fieldText1.Visible = false;
            // 
            // fieldSeparator1
            // 
            this.fieldSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.fieldSeparator1.Location = new System.Drawing.Point(87, 213);
            this.fieldSeparator1.Name = "fieldSeparator1";
            this.fieldSeparator1.Size = new System.Drawing.Size(310, 1);
            this.fieldSeparator1.TabIndex = 4;
            this.fieldSeparator1.Visible = false;
            // 
            // fieldText2
            // 
            this.fieldText2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.fieldText2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fieldText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fieldText2.ForeColor = System.Drawing.Color.White;
            this.fieldText2.Location = new System.Drawing.Point(87, 230);
            this.fieldText2.MaxLength = 32;
            this.fieldText2.Name = "fieldText2";
            this.fieldText2.Size = new System.Drawing.Size(310, 19);
            this.fieldText2.TabIndex = 3;
            this.fieldText2.Visible = false;
            // 
            // fieldSeparator2
            // 
            this.fieldSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.fieldSeparator2.Location = new System.Drawing.Point(87, 256);
            this.fieldSeparator2.Name = "fieldSeparator2";
            this.fieldSeparator2.Size = new System.Drawing.Size(310, 1);
            this.fieldSeparator2.TabIndex = 4;
            this.fieldSeparator2.Visible = false;
            // 
            // fieldText3
            // 
            this.fieldText3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.fieldText3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fieldText3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fieldText3.ForeColor = System.Drawing.Color.White;
            this.fieldText3.Location = new System.Drawing.Point(87, 273);
            this.fieldText3.MaxLength = 32;
            this.fieldText3.Name = "fieldText3";
            this.fieldText3.Size = new System.Drawing.Size(310, 19);
            this.fieldText3.TabIndex = 3;
            this.fieldText3.Visible = false;
            // 
            // fieldSeparator3
            // 
            this.fieldSeparator3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.fieldSeparator3.Location = new System.Drawing.Point(87, 299);
            this.fieldSeparator3.Name = "fieldSeparator3";
            this.fieldSeparator3.Size = new System.Drawing.Size(310, 1);
            this.fieldSeparator3.TabIndex = 4;
            this.fieldSeparator3.Visible = false;
            // 
            // fieldText4
            // 
            this.fieldText4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.fieldText4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fieldText4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fieldText4.ForeColor = System.Drawing.Color.White;
            this.fieldText4.Location = new System.Drawing.Point(88, 316);
            this.fieldText4.MaxLength = 32;
            this.fieldText4.Name = "fieldText4";
            this.fieldText4.Size = new System.Drawing.Size(310, 19);
            this.fieldText4.TabIndex = 3;
            this.fieldText4.Visible = false;
            // 
            // fieldSeparator4
            // 
            this.fieldSeparator4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.fieldSeparator4.Location = new System.Drawing.Point(88, 342);
            this.fieldSeparator4.Name = "fieldSeparator4";
            this.fieldSeparator4.Size = new System.Drawing.Size(310, 1);
            this.fieldSeparator4.TabIndex = 4;
            this.fieldSeparator4.Visible = false;
            // 
            // fieldText5
            // 
            this.fieldText5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.fieldText5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fieldText5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fieldText5.ForeColor = System.Drawing.Color.White;
            this.fieldText5.Location = new System.Drawing.Point(88, 359);
            this.fieldText5.MaxLength = 32;
            this.fieldText5.Name = "fieldText5";
            this.fieldText5.Size = new System.Drawing.Size(310, 19);
            this.fieldText5.TabIndex = 3;
            this.fieldText5.Visible = false;
            // 
            // fieldSeparator5
            // 
            this.fieldSeparator5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.fieldSeparator5.Location = new System.Drawing.Point(88, 385);
            this.fieldSeparator5.Name = "fieldSeparator5";
            this.fieldSeparator5.Size = new System.Drawing.Size(310, 1);
            this.fieldSeparator5.TabIndex = 4;
            this.fieldSeparator5.Visible = false;
            // 
            // fieldText6
            // 
            this.fieldText6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.fieldText6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fieldText6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fieldText6.ForeColor = System.Drawing.Color.White;
            this.fieldText6.Location = new System.Drawing.Point(88, 402);
            this.fieldText6.MaxLength = 32;
            this.fieldText6.Name = "fieldText6";
            this.fieldText6.Size = new System.Drawing.Size(310, 19);
            this.fieldText6.TabIndex = 3;
            this.fieldText6.Visible = false;
            // 
            // fieldSeparator6
            // 
            this.fieldSeparator6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.fieldSeparator6.Location = new System.Drawing.Point(88, 428);
            this.fieldSeparator6.Name = "fieldSeparator6";
            this.fieldSeparator6.Size = new System.Drawing.Size(310, 1);
            this.fieldSeparator6.TabIndex = 4;
            this.fieldSeparator6.Visible = false;
            // 
            // addFieldIcon
            // 
            this.addFieldIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addFieldIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addFieldIcon.Image = global::Mercury.Properties.Resources.addFieldGray;
            this.addFieldIcon.Location = new System.Drawing.Point(62, 155);
            this.addFieldIcon.Name = "addFieldIcon";
            this.addFieldIcon.Size = new System.Drawing.Size(21, 21);
            this.addFieldIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.addFieldIcon.TabIndex = 5;
            this.addFieldIcon.TabStop = false;
            // 
            // removeField
            // 
            this.removeField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeField.AutoSize = true;
            this.removeField.BackColor = System.Drawing.Color.Transparent;
            this.removeField.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.removeField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.removeField.Location = new System.Drawing.Point(225, 158);
            this.removeField.Name = "removeField";
            this.removeField.Size = new System.Drawing.Size(98, 16);
            this.removeField.TabIndex = 6;
            this.removeField.Text = "Удалить поле";
            this.removeField.Visible = false;
            // 
            // removeFieldIcon
            // 
            this.removeFieldIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeFieldIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeFieldIcon.Image = global::Mercury.Properties.Resources.removeFieldGray;
            this.removeFieldIcon.Location = new System.Drawing.Point(202, 155);
            this.removeFieldIcon.Name = "removeFieldIcon";
            this.removeFieldIcon.Size = new System.Drawing.Size(21, 21);
            this.removeFieldIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.removeFieldIcon.TabIndex = 5;
            this.removeFieldIcon.TabStop = false;
            this.removeFieldIcon.Visible = false;
            // 
            // CreateSafeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(487, 272);
            this.Controls.Add(this.removeFieldIcon);
            this.Controls.Add(this.removeField);
            this.Controls.Add(this.addFieldIcon);
            this.Controls.Add(this.addField);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.fieldSeparator6);
            this.Controls.Add(this.fieldSeparator5);
            this.Controls.Add(this.fieldSeparator4);
            this.Controls.Add(this.fieldSeparator3);
            this.Controls.Add(this.fieldSeparator2);
            this.Controls.Add(this.fieldSeparator1);
            this.Controls.Add(this.safeNameSeparator);
            this.Controls.Add(this.fieldText6);
            this.Controls.Add(this.fieldText5);
            this.Controls.Add(this.fieldText4);
            this.Controls.Add(this.fieldText3);
            this.Controls.Add(this.fieldText2);
            this.Controls.Add(this.fieldText1);
            this.Controls.Add(this.safeName);
            this.Controls.Add(this.logoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateSafeForm";
            this.Padding = new System.Windows.Forms.Padding(30, 30, 0, 0);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.CreateSafeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.addFieldIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeFieldIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label logoLabel;
        private pivyLab.Control.FlatEllButton saveButton;
        private pivyLab.Control.FlatEllButton cancel;
        private pivyLab.Control.Separator safeNameSeparator;
        private System.Windows.Forms.TextBox safeName;
        private System.Windows.Forms.PictureBox addFieldIcon;
        private System.Windows.Forms.Label addField;
        private System.Windows.Forms.TextBox fieldText1;
        private pivyLab.Control.Separator fieldSeparator1;
        private System.Windows.Forms.TextBox fieldText2;
        private pivyLab.Control.Separator fieldSeparator2;
        private System.Windows.Forms.TextBox fieldText3;
        private pivyLab.Control.Separator fieldSeparator3;
        private System.Windows.Forms.TextBox fieldText4;
        private pivyLab.Control.Separator fieldSeparator4;
        private System.Windows.Forms.TextBox fieldText5;
        private pivyLab.Control.Separator fieldSeparator5;
        private System.Windows.Forms.TextBox fieldText6;
        private pivyLab.Control.Separator fieldSeparator6;
        private System.Windows.Forms.Label removeField;
        private System.Windows.Forms.PictureBox removeFieldIcon;
    }
}