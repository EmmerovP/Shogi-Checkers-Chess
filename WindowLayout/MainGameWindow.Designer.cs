namespace ShogiCheckersChess
{
    partial class MainGameWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGameWindow));
            this.SelectChessButton = new System.Windows.Forms.Button();
            this.SelectCheckersButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectShogiButton = new System.Windows.Forms.Button();
            this.SelectCustomGameButton = new System.Windows.Forms.Button();
            this.AboutGameButton = new System.Windows.Forms.Button();
            this.AboutAuthorButton = new System.Windows.Forms.Button();
            this.CreditsButton = new System.Windows.Forms.Button();
            this.SelectSingleplayerButton = new System.Windows.Forms.Button();
            this.SelectLocMultiButton = new System.Windows.Forms.Button();
            this.SelectWebMultiButton = new System.Windows.Forms.Button();
            this.GamePieces = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectChessButton
            // 
            this.SelectChessButton.Location = new System.Drawing.Point(136, 145);
            this.SelectChessButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectChessButton.Name = "SelectChessButton";
            this.SelectChessButton.Size = new System.Drawing.Size(76, 44);
            this.SelectChessButton.TabIndex = 0;
            this.SelectChessButton.Text = "Šachy";
            this.SelectChessButton.UseVisualStyleBackColor = true;
            this.SelectChessButton.Click += new System.EventHandler(this.SelectChessButton_Click);
            // 
            // SelectCheckersButton
            // 
            this.SelectCheckersButton.Location = new System.Drawing.Point(250, 145);
            this.SelectCheckersButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectCheckersButton.Name = "SelectCheckersButton";
            this.SelectCheckersButton.Size = new System.Drawing.Size(79, 44);
            this.SelectCheckersButton.TabIndex = 1;
            this.SelectCheckersButton.Text = "Dáma";
            this.SelectCheckersButton.UseVisualStyleBackColor = true;
            this.SelectCheckersButton.Click += new System.EventHandler(this.SelectCheckersButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(176, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 78);
            this.label1.TabIndex = 2;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectShogiButton
            // 
            this.SelectShogiButton.Location = new System.Drawing.Point(368, 145);
            this.SelectShogiButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectShogiButton.Name = "SelectShogiButton";
            this.SelectShogiButton.Size = new System.Drawing.Size(79, 44);
            this.SelectShogiButton.TabIndex = 3;
            this.SelectShogiButton.Text = "Shogi";
            this.SelectShogiButton.UseVisualStyleBackColor = true;
            this.SelectShogiButton.Click += new System.EventHandler(this.SelectShogiButton_Click);
            // 
            // SelectCustomGameButton
            // 
            this.SelectCustomGameButton.Location = new System.Drawing.Point(249, 203);
            this.SelectCustomGameButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectCustomGameButton.Name = "SelectCustomGameButton";
            this.SelectCustomGameButton.Size = new System.Drawing.Size(79, 49);
            this.SelectCustomGameButton.TabIndex = 4;
            this.SelectCustomGameButton.Text = "Vlastní hra";
            this.SelectCustomGameButton.UseVisualStyleBackColor = true;
            this.SelectCustomGameButton.Click += new System.EventHandler(this.SelectCustomGameButton_Click);
            // 
            // AboutGameButton
            // 
            this.AboutGameButton.Location = new System.Drawing.Point(249, 339);
            this.AboutGameButton.Margin = new System.Windows.Forms.Padding(2);
            this.AboutGameButton.Name = "AboutGameButton";
            this.AboutGameButton.Size = new System.Drawing.Size(79, 43);
            this.AboutGameButton.TabIndex = 5;
            this.AboutGameButton.Text = "O hře";
            this.AboutGameButton.UseVisualStyleBackColor = true;
            this.AboutGameButton.Click += new System.EventHandler(this.AboutGameButton_Click);
            // 
            // AboutAuthorButton
            // 
            this.AboutAuthorButton.Location = new System.Drawing.Point(250, 404);
            this.AboutAuthorButton.Margin = new System.Windows.Forms.Padding(2);
            this.AboutAuthorButton.Name = "AboutAuthorButton";
            this.AboutAuthorButton.Size = new System.Drawing.Size(79, 43);
            this.AboutAuthorButton.TabIndex = 6;
            this.AboutAuthorButton.Text = "O autorce";
            this.AboutAuthorButton.UseVisualStyleBackColor = true;
            this.AboutAuthorButton.Click += new System.EventHandler(this.AboutAuthorButton_Click);
            // 
            // CreditsButton
            // 
            this.CreditsButton.Location = new System.Drawing.Point(250, 468);
            this.CreditsButton.Margin = new System.Windows.Forms.Padding(2);
            this.CreditsButton.Name = "CreditsButton";
            this.CreditsButton.Size = new System.Drawing.Size(79, 43);
            this.CreditsButton.TabIndex = 7;
            this.CreditsButton.Text = "Credits";
            this.CreditsButton.UseVisualStyleBackColor = true;
            this.CreditsButton.Click += new System.EventHandler(this.CreditsButton_Click);
            // 
            // SelectSingleplayerButton
            // 
            this.SelectSingleplayerButton.Location = new System.Drawing.Point(136, 273);
            this.SelectSingleplayerButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectSingleplayerButton.Name = "SelectSingleplayerButton";
            this.SelectSingleplayerButton.Size = new System.Drawing.Size(76, 46);
            this.SelectSingleplayerButton.TabIndex = 8;
            this.SelectSingleplayerButton.Text = "Singleplayer";
            this.SelectSingleplayerButton.UseVisualStyleBackColor = true;
            this.SelectSingleplayerButton.Visible = false;
            this.SelectSingleplayerButton.Click += new System.EventHandler(this.SelectSingleplayerButton_Click);
            // 
            // SelectLocMultiButton
            // 
            this.SelectLocMultiButton.Location = new System.Drawing.Point(249, 273);
            this.SelectLocMultiButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectLocMultiButton.Name = "SelectLocMultiButton";
            this.SelectLocMultiButton.Size = new System.Drawing.Size(80, 46);
            this.SelectLocMultiButton.TabIndex = 9;
            this.SelectLocMultiButton.Text = "Lokální multiplayer";
            this.SelectLocMultiButton.UseVisualStyleBackColor = true;
            this.SelectLocMultiButton.Visible = false;
            this.SelectLocMultiButton.Click += new System.EventHandler(this.SelectLocMultiButton_Click);
            // 
            // SelectWebMultiButton
            // 
            this.SelectWebMultiButton.Location = new System.Drawing.Point(370, 273);
            this.SelectWebMultiButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectWebMultiButton.Name = "SelectWebMultiButton";
            this.SelectWebMultiButton.Size = new System.Drawing.Size(76, 46);
            this.SelectWebMultiButton.TabIndex = 10;
            this.SelectWebMultiButton.Text = "Multiplayer po síti";
            this.SelectWebMultiButton.UseVisualStyleBackColor = true;
            this.SelectWebMultiButton.Visible = false;
            this.SelectWebMultiButton.Click += new System.EventHandler(this.SelectWebMultiButton_Click);
            // 
            // GamePieces
            // 
            this.GamePieces.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("GamePieces.ImageStream")));
            this.GamePieces.TransparentColor = System.Drawing.Color.Transparent;
            this.GamePieces.Images.SetKeyName(0, "01.gif");
            this.GamePieces.Images.SetKeyName(1, "02.gif");
            this.GamePieces.Images.SetKeyName(2, "03.gif");
            this.GamePieces.Images.SetKeyName(3, "04.gif");
            this.GamePieces.Images.SetKeyName(4, "05.gif");
            this.GamePieces.Images.SetKeyName(5, "06.gif");
            this.GamePieces.Images.SetKeyName(6, "07.gif");
            this.GamePieces.Images.SetKeyName(7, "08.gif");
            this.GamePieces.Images.SetKeyName(8, "09.gif");
            this.GamePieces.Images.SetKeyName(9, "10.gif");
            this.GamePieces.Images.SetKeyName(10, "11.gif");
            this.GamePieces.Images.SetKeyName(11, "12.gif");
            this.GamePieces.Images.SetKeyName(12, "13.gif");
            this.GamePieces.Images.SetKeyName(13, "14.gif");
            this.GamePieces.Images.SetKeyName(14, "15.gif");
            this.GamePieces.Images.SetKeyName(15, "16.gif");
            this.GamePieces.Images.SetKeyName(16, "17.gif");
            this.GamePieces.Images.SetKeyName(17, "18.gif");
            this.GamePieces.Images.SetKeyName(18, "19.gif");
            this.GamePieces.Images.SetKeyName(19, "20.gif");
            this.GamePieces.Images.SetKeyName(20, "21.gif");
            this.GamePieces.Images.SetKeyName(21, "22.gif");
            this.GamePieces.Images.SetKeyName(22, "23.gif");
            this.GamePieces.Images.SetKeyName(23, "24.gif");
            this.GamePieces.Images.SetKeyName(24, "25.gif");
            this.GamePieces.Images.SetKeyName(25, "26.gif");
            this.GamePieces.Images.SetKeyName(26, "27.gif");
            this.GamePieces.Images.SetKeyName(27, "28.gif");
            this.GamePieces.Images.SetKeyName(28, "29.gif");
            this.GamePieces.Images.SetKeyName(29, "30.gif");
            this.GamePieces.Images.SetKeyName(30, "31.gif");
            this.GamePieces.Images.SetKeyName(31, "32.gif");
            this.GamePieces.Images.SetKeyName(32, "33.gif");
            this.GamePieces.Images.SetKeyName(33, "34.gif");
            this.GamePieces.Images.SetKeyName(34, "35.gif");
            this.GamePieces.Images.SetKeyName(35, "36.gif");
            this.GamePieces.Images.SetKeyName(36, "37.gif");
            this.GamePieces.Images.SetKeyName(37, "38.gif");
            this.GamePieces.Images.SetKeyName(38, "39.gif");
            this.GamePieces.Images.SetKeyName(39, "40.gif");
            this.GamePieces.Images.SetKeyName(40, "41.gif");
            this.GamePieces.Images.SetKeyName(41, "42.gif");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(449, 462);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Konec hry.";
            this.label2.Visible = false;
            // 
            // NewGameButton
            // 
            this.NewGameButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.NewGameButton.Location = new System.Drawing.Point(452, 478);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(99, 48);
            this.NewGameButton.TabIndex = 12;
            this.NewGameButton.Text = "Nová hra";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.Visible = false;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // MainGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 538);
            this.Controls.Add(this.NewGameButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectWebMultiButton);
            this.Controls.Add(this.SelectLocMultiButton);
            this.Controls.Add(this.SelectSingleplayerButton);
            this.Controls.Add(this.CreditsButton);
            this.Controls.Add(this.AboutAuthorButton);
            this.Controls.Add(this.AboutGameButton);
            this.Controls.Add(this.SelectCustomGameButton);
            this.Controls.Add(this.SelectShogiButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectCheckersButton);
            this.Controls.Add(this.SelectChessButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainGameWindow";
            this.Text = "Šachy, shogi, dáma";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectChessButton;
        private System.Windows.Forms.Button SelectCheckersButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SelectShogiButton;
        private System.Windows.Forms.Button SelectCustomGameButton;
        private System.Windows.Forms.Button AboutGameButton;
        private System.Windows.Forms.Button AboutAuthorButton;
        private System.Windows.Forms.Button CreditsButton;
        private System.Windows.Forms.Button SelectSingleplayerButton;
        private System.Windows.Forms.Button SelectLocMultiButton;
        private System.Windows.Forms.Button SelectWebMultiButton;
        private System.Windows.Forms.ImageList GamePieces;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button NewGameButton;
    }
}

