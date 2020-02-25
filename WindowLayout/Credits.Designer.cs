namespace ShogiCheckersChess
{
    partial class Credits
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
            this.CreditsOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 89);
            this.label1.TabIndex = 0;
            this.label1.Text = "Poděkování patří všem, kteří se mnou na projektu spolupracovali... Teprve uvidíme" +
    ", kdo tu bude. :)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CreditsOk
            // 
            this.CreditsOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CreditsOk.Location = new System.Drawing.Point(76, 106);
            this.CreditsOk.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CreditsOk.Name = "CreditsOk";
            this.CreditsOk.Size = new System.Drawing.Size(76, 37);
            this.CreditsOk.TabIndex = 1;
            this.CreditsOk.Text = "OK";
            this.CreditsOk.UseVisualStyleBackColor = true;
            this.CreditsOk.Click += new System.EventHandler(this.CreditsOk_Click);
            // 
            // Credits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 176);
            this.Controls.Add(this.CreditsOk);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Credits";
            this.Text = "Poděkování";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CreditsOk;
    }
}