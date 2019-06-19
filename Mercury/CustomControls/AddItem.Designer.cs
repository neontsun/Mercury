namespace Mercury.CustomControls
{
    partial class AddItem
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
            this.cancel = new pivyLab.Control.FlatEllButton();
            this.saveButton = new pivyLab.Control.FlatEllButton();
            this.logoLabel = new System.Windows.Forms.Label();
            this.separator2 = new pivyLab.Control.Separator();
            this.separator1 = new pivyLab.Control.Separator();
            this.fieldText2 = new System.Windows.Forms.TextBox();
            this.fieldText1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.Back = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(185)))), ((int)(((byte)(84)))));
            this.cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancel.ForeColor = System.Drawing.Color.White;
            this.cancel.Location = new System.Drawing.Point(248, 313);
            this.cancel.Name = "cancel";
            this.cancel.RoundRadius = 2;
            this.cancel.Size = new System.Drawing.Size(145, 33);
            this.cancel.TabIndex = 9;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Back = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(185)))), ((int)(((byte)(84)))));
            this.saveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(87, 313);
            this.saveButton.Name = "saveButton";
            this.saveButton.RoundRadius = 2;
            this.saveButton.Size = new System.Drawing.Size(145, 33);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Создать";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // logoLabel
            // 
            this.logoLabel.AutoSize = true;
            this.logoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logoLabel.ForeColor = System.Drawing.Color.White;
            this.logoLabel.Location = new System.Drawing.Point(33, 33);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(267, 33);
            this.logoLabel.TabIndex = 11;
            this.logoLabel.Text = "Добавить элемент";
            // 
            // separator2
            // 
            this.separator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.separator2.Location = new System.Drawing.Point(83, 211);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(310, 1);
            this.separator2.TabIndex = 14;
            // 
            // separator1
            // 
            this.separator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.separator1.Location = new System.Drawing.Point(83, 162);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(310, 1);
            this.separator1.TabIndex = 15;
            // 
            // fieldText2
            // 
            this.fieldText2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.fieldText2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fieldText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fieldText2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.fieldText2.Location = new System.Drawing.Point(83, 186);
            this.fieldText2.MaxLength = 32;
            this.fieldText2.Name = "fieldText2";
            this.fieldText2.Size = new System.Drawing.Size(310, 19);
            this.fieldText2.TabIndex = 13;
            this.fieldText2.Text = "Срок выдачи";
            // 
            // fieldText1
            // 
            this.fieldText1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.fieldText1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fieldText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fieldText1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.fieldText1.Location = new System.Drawing.Point(83, 137);
            this.fieldText1.MaxLength = 32;
            this.fieldText1.Name = "fieldText1";
            this.fieldText1.Size = new System.Drawing.Size(310, 19);
            this.fieldText1.TabIndex = 12;
            this.fieldText1.Text = "Наименование";
            // 
            // AddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(481, 388);
            this.Controls.Add(this.separator2);
            this.Controls.Add(this.separator1);
            this.Controls.Add(this.fieldText2);
            this.Controls.Add(this.fieldText1);
            this.Controls.Add(this.logoLabel);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddItem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private pivyLab.Control.FlatEllButton cancel;
        private pivyLab.Control.FlatEllButton saveButton;
        private System.Windows.Forms.Label logoLabel;
        private pivyLab.Control.Separator separator2;
        private pivyLab.Control.Separator separator1;
        private System.Windows.Forms.TextBox fieldText2;
        private System.Windows.Forms.TextBox fieldText1;
    }
}