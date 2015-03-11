namespace Batch_generation
{
    partial class query_build
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
            this.treeviewButton = new System.Windows.Forms.Button();
            this.textviewButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Would you like to build the patch from the treeview,\r\nor from the text editor vie" +
    "w?";
            // 
            // treeviewButton
            // 
            this.treeviewButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.treeviewButton.Location = new System.Drawing.Point(16, 55);
            this.treeviewButton.Name = "treeviewButton";
            this.treeviewButton.Size = new System.Drawing.Size(75, 25);
            this.treeviewButton.TabIndex = 1;
            this.treeviewButton.Text = "Treeview";
            this.treeviewButton.UseVisualStyleBackColor = true;
            this.treeviewButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // textviewButton
            // 
            this.textviewButton.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.textviewButton.Location = new System.Drawing.Point(97, 55);
            this.textviewButton.Name = "textviewButton";
            this.textviewButton.Size = new System.Drawing.Size(75, 25);
            this.textviewButton.TabIndex = 2;
            this.textviewButton.Text = "Text editor";
            this.textviewButton.UseVisualStyleBackColor = true;
            this.textviewButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(178, 55);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // buildquery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 97);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.textviewButton);
            this.Controls.Add(this.treeviewButton);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "buildquery";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Which version you would like to build?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button treeviewButton;
        private System.Windows.Forms.Button textviewButton;
        private System.Windows.Forms.Button cancelButton;
    }
}