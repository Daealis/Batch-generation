namespace Batch_generation
{
    partial class query_multiEcho
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
            this.label1 = new System.Windows.Forms.Label();
            this.multiechoRichTextBox = new System.Windows.Forms.RichTextBox();
            this.framingCheckBox = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.fileWriteCheckBox = new System.Windows.Forms.CheckBox();
            this.filenamesComboBox = new System.Windows.Forms.ComboBox();
            this.appendCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Write the text you wish to add:";
            // 
            // multiechoRichTextBox
            // 
            this.multiechoRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.multiechoRichTextBox.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiechoRichTextBox.Location = new System.Drawing.Point(12, 29);
            this.multiechoRichTextBox.Name = "multiechoRichTextBox";
            this.multiechoRichTextBox.Size = new System.Drawing.Size(444, 269);
            this.multiechoRichTextBox.TabIndex = 1;
            this.multiechoRichTextBox.Text = "";
            // 
            // framingCheckBox
            // 
            this.framingCheckBox.AutoSize = true;
            this.framingCheckBox.Location = new System.Drawing.Point(16, 305);
            this.framingCheckBox.Name = "framingCheckBox";
            this.framingCheckBox.Size = new System.Drawing.Size(116, 17);
            this.framingCheckBox.TabIndex = 2;
            this.framingCheckBox.Text = "Wrap with a border";
            this.framingCheckBox.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(16, 353);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(110, 353);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // fileWriteCheckBox
            // 
            this.fileWriteCheckBox.AutoSize = true;
            this.fileWriteCheckBox.Location = new System.Drawing.Point(16, 328);
            this.fileWriteCheckBox.Name = "fileWriteCheckBox";
            this.fileWriteCheckBox.Size = new System.Drawing.Size(88, 17);
            this.fileWriteCheckBox.TabIndex = 3;
            this.fileWriteCheckBox.Text = "Write to a file";
            this.fileWriteCheckBox.UseVisualStyleBackColor = true;
            this.fileWriteCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // filenamesComboBox
            // 
            this.filenamesComboBox.FormattingEnabled = true;
            this.filenamesComboBox.Location = new System.Drawing.Point(16, 351);
            this.filenamesComboBox.Name = "filenamesComboBox";
            this.filenamesComboBox.Size = new System.Drawing.Size(196, 21);
            this.filenamesComboBox.TabIndex = 5;
            this.filenamesComboBox.Visible = false;
            // 
            // appendCheckBox
            // 
            this.appendCheckBox.AutoSize = true;
            this.appendCheckBox.Location = new System.Drawing.Point(132, 330);
            this.appendCheckBox.Name = "appendCheckBox";
            this.appendCheckBox.Size = new System.Drawing.Size(166, 17);
            this.appendCheckBox.TabIndex = 4;
            this.appendCheckBox.Text = "Append instead of overwriting";
            this.appendCheckBox.UseVisualStyleBackColor = true;
            this.appendCheckBox.Visible = false;
            // 
            // query_multiEcho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 388);
            this.Controls.Add(this.appendCheckBox);
            this.Controls.Add(this.fileWriteCheckBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.framingCheckBox);
            this.Controls.Add(this.multiechoRichTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filenamesComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "query_multiEcho";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Echo multiple lines";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox multiechoRichTextBox;
        private System.Windows.Forms.CheckBox framingCheckBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox fileWriteCheckBox;
        private System.Windows.Forms.ComboBox filenamesComboBox;
        private System.Windows.Forms.CheckBox appendCheckBox;
    }
}