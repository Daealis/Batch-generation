namespace Batch_generation
{
    partial class echo_parameters
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
            this.echoLabel = new System.Windows.Forms.Label();
            this.echoTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.filenamesComboBox = new System.Windows.Forms.ComboBox();
            this.fileWriteCheckBox = new System.Windows.Forms.CheckBox();
            this.appendCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // echoLabel
            // 
            this.echoLabel.AutoSize = true;
            this.echoLabel.Location = new System.Drawing.Point(13, 13);
            this.echoLabel.Name = "echoLabel";
            this.echoLabel.Size = new System.Drawing.Size(210, 13);
            this.echoLabel.TabIndex = 0;
            this.echoLabel.Text = "What you wish to echo (Can be left empty):";
            // 
            // echoTextBox
            // 
            this.echoTextBox.Location = new System.Drawing.Point(16, 40);
            this.echoTextBox.Name = "echoTextBox";
            this.echoTextBox.Size = new System.Drawing.Size(240, 20);
            this.echoTextBox.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(16, 89);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(148, 89);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // filenamesComboBox
            // 
            this.filenamesComboBox.FormattingEnabled = true;
            this.filenamesComboBox.Location = new System.Drawing.Point(16, 89);
            this.filenamesComboBox.Name = "filenamesComboBox";
            this.filenamesComboBox.Size = new System.Drawing.Size(185, 21);
            this.filenamesComboBox.TabIndex = 4;
            this.filenamesComboBox.Visible = false;
            // 
            // fileWriteCheckBox
            // 
            this.fileWriteCheckBox.AutoSize = true;
            this.fileWriteCheckBox.Location = new System.Drawing.Point(16, 66);
            this.fileWriteCheckBox.Name = "fileWriteCheckBox";
            this.fileWriteCheckBox.Size = new System.Drawing.Size(88, 17);
            this.fileWriteCheckBox.TabIndex = 2;
            this.fileWriteCheckBox.Text = "Write to a file";
            this.fileWriteCheckBox.UseVisualStyleBackColor = true;
            this.fileWriteCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // appendCheckBox
            // 
            this.appendCheckBox.AutoSize = true;
            this.appendCheckBox.Location = new System.Drawing.Point(111, 66);
            this.appendCheckBox.Name = "appendCheckBox";
            this.appendCheckBox.Size = new System.Drawing.Size(158, 17);
            this.appendCheckBox.TabIndex = 3;
            this.appendCheckBox.Text = "Append instead of overwrite";
            this.appendCheckBox.UseVisualStyleBackColor = true;
            this.appendCheckBox.Visible = false;
            // 
            // echo_parameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 124);
            this.Controls.Add(this.appendCheckBox);
            this.Controls.Add(this.fileWriteCheckBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.echoTextBox);
            this.Controls.Add(this.echoLabel);
            this.Controls.Add(this.filenamesComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "echo_parameters";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Define Echo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label echoLabel;
        private System.Windows.Forms.TextBox echoTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ComboBox filenamesComboBox;
        private System.Windows.Forms.CheckBox fileWriteCheckBox;
        private System.Windows.Forms.CheckBox appendCheckBox;
    }
}