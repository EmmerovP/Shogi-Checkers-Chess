namespace ShogiCheckersChess
{
    partial class AboutAuthor
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
            this.AuthorOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 117);
            this.label1.TabIndex = 0;
            this.label1.Text = "Projekt je ročníková/bakalářská práce pro MFF UK, kde autorka Péťa studuje inform" +
    "atiku.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AuthorOk
            // 
            this.AuthorOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.AuthorOk.Location = new System.Drawing.Point(87, 129);
            this.AuthorOk.Name = "AuthorOk";
            this.AuthorOk.Size = new System.Drawing.Size(105, 60);
            this.AuthorOk.TabIndex = 1;
            this.AuthorOk.Text = "OK";
            this.AuthorOk.UseVisualStyleBackColor = true;
            // 
            // AboutAuthor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 231);
            this.Controls.Add(this.AuthorOk);
            this.Controls.Add(this.label1);
            this.Name = "AboutAuthor";
            this.Text = "O Autorce";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AuthorOk;
    }
}