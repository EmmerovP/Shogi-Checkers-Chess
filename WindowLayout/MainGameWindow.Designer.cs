namespace WindowLayout
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
            this.SelectChess = new System.Windows.Forms.Button();
            this.SelectCheckers = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectShogi = new System.Windows.Forms.Button();
            this.SelectCustomGame = new System.Windows.Forms.Button();
            this.AboutGame = new System.Windows.Forms.Button();
            this.AboutAuthor = new System.Windows.Forms.Button();
            this.Credits = new System.Windows.Forms.Button();
            this.SelectSingleplayer = new System.Windows.Forms.Button();
            this.SelectLocMulti = new System.Windows.Forms.Button();
            this.SelectWebMulti = new System.Windows.Forms.Button();
            this.GamePieces = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SelectChess
            // 
            this.SelectChess.Location = new System.Drawing.Point(136, 145);
            this.SelectChess.Margin = new System.Windows.Forms.Padding(2);
            this.SelectChess.Name = "SelectChess";
            this.SelectChess.Size = new System.Drawing.Size(76, 44);
            this.SelectChess.TabIndex = 0;
            this.SelectChess.Text = "Šachy";
            this.SelectChess.UseVisualStyleBackColor = true;
            this.SelectChess.Click += new System.EventHandler(this.button1_Click);
            // 
            // SelectCheckers
            // 
            this.SelectCheckers.Location = new System.Drawing.Point(250, 145);
            this.SelectCheckers.Margin = new System.Windows.Forms.Padding(2);
            this.SelectCheckers.Name = "SelectCheckers";
            this.SelectCheckers.Size = new System.Drawing.Size(79, 44);
            this.SelectCheckers.TabIndex = 1;
            this.SelectCheckers.Text = "Dáma";
            this.SelectCheckers.UseVisualStyleBackColor = true;
            this.SelectCheckers.Click += new System.EventHandler(this.button2_Click);
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
            // SelectShogi
            // 
            this.SelectShogi.Location = new System.Drawing.Point(368, 145);
            this.SelectShogi.Margin = new System.Windows.Forms.Padding(2);
            this.SelectShogi.Name = "SelectShogi";
            this.SelectShogi.Size = new System.Drawing.Size(79, 44);
            this.SelectShogi.TabIndex = 3;
            this.SelectShogi.Text = "Shogi";
            this.SelectShogi.UseVisualStyleBackColor = true;
            this.SelectShogi.Click += new System.EventHandler(this.button3_Click);
            // 
            // SelectCustomGame
            // 
            this.SelectCustomGame.Location = new System.Drawing.Point(249, 203);
            this.SelectCustomGame.Margin = new System.Windows.Forms.Padding(2);
            this.SelectCustomGame.Name = "SelectCustomGame";
            this.SelectCustomGame.Size = new System.Drawing.Size(79, 49);
            this.SelectCustomGame.TabIndex = 4;
            this.SelectCustomGame.Text = "Vlastní hra";
            this.SelectCustomGame.UseVisualStyleBackColor = true;
            this.SelectCustomGame.Click += new System.EventHandler(this.button4_Click);
            // 
            // AboutGame
            // 
            this.AboutGame.Location = new System.Drawing.Point(249, 339);
            this.AboutGame.Margin = new System.Windows.Forms.Padding(2);
            this.AboutGame.Name = "AboutGame";
            this.AboutGame.Size = new System.Drawing.Size(79, 43);
            this.AboutGame.TabIndex = 5;
            this.AboutGame.Text = "O hře";
            this.AboutGame.UseVisualStyleBackColor = true;
            this.AboutGame.Click += new System.EventHandler(this.button5_Click);
            // 
            // AboutAuthor
            // 
            this.AboutAuthor.Location = new System.Drawing.Point(250, 404);
            this.AboutAuthor.Margin = new System.Windows.Forms.Padding(2);
            this.AboutAuthor.Name = "AboutAuthor";
            this.AboutAuthor.Size = new System.Drawing.Size(79, 43);
            this.AboutAuthor.TabIndex = 6;
            this.AboutAuthor.Text = "O autorce";
            this.AboutAuthor.UseVisualStyleBackColor = true;
            this.AboutAuthor.Click += new System.EventHandler(this.button6_Click);
            // 
            // Credits
            // 
            this.Credits.Location = new System.Drawing.Point(250, 468);
            this.Credits.Margin = new System.Windows.Forms.Padding(2);
            this.Credits.Name = "Credits";
            this.Credits.Size = new System.Drawing.Size(79, 43);
            this.Credits.TabIndex = 7;
            this.Credits.Text = "Credits";
            this.Credits.UseVisualStyleBackColor = true;
            this.Credits.Click += new System.EventHandler(this.button7_Click);
            // 
            // SelectSingleplayer
            // 
            this.SelectSingleplayer.Location = new System.Drawing.Point(136, 273);
            this.SelectSingleplayer.Margin = new System.Windows.Forms.Padding(2);
            this.SelectSingleplayer.Name = "SelectSingleplayer";
            this.SelectSingleplayer.Size = new System.Drawing.Size(76, 46);
            this.SelectSingleplayer.TabIndex = 8;
            this.SelectSingleplayer.Text = "Singleplayer";
            this.SelectSingleplayer.UseVisualStyleBackColor = true;
            this.SelectSingleplayer.Visible = false;
            this.SelectSingleplayer.Click += new System.EventHandler(this.button8_Click);
            // 
            // SelectLocMulti
            // 
            this.SelectLocMulti.Location = new System.Drawing.Point(249, 273);
            this.SelectLocMulti.Margin = new System.Windows.Forms.Padding(2);
            this.SelectLocMulti.Name = "SelectLocMulti";
            this.SelectLocMulti.Size = new System.Drawing.Size(80, 46);
            this.SelectLocMulti.TabIndex = 9;
            this.SelectLocMulti.Text = "Lokální multiplayer";
            this.SelectLocMulti.UseVisualStyleBackColor = true;
            this.SelectLocMulti.Visible = false;
            this.SelectLocMulti.Click += new System.EventHandler(this.button9_Click);
            // 
            // SelectWebMulti
            // 
            this.SelectWebMulti.Location = new System.Drawing.Point(370, 273);
            this.SelectWebMulti.Margin = new System.Windows.Forms.Padding(2);
            this.SelectWebMulti.Name = "SelectWebMulti";
            this.SelectWebMulti.Size = new System.Drawing.Size(76, 46);
            this.SelectWebMulti.TabIndex = 10;
            this.SelectWebMulti.Text = "Multiplayer po síti";
            this.SelectWebMulti.UseVisualStyleBackColor = true;
            this.SelectWebMulti.Visible = false;
            this.SelectWebMulti.Click += new System.EventHandler(this.button10_Click);
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
            this.label2.Location = new System.Drawing.Point(488, 516);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Konec hry.";
            this.label2.Visible = false;
            // 
            // MainGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 538);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectWebMulti);
            this.Controls.Add(this.SelectLocMulti);
            this.Controls.Add(this.SelectSingleplayer);
            this.Controls.Add(this.Credits);
            this.Controls.Add(this.AboutAuthor);
            this.Controls.Add(this.AboutGame);
            this.Controls.Add(this.SelectCustomGame);
            this.Controls.Add(this.SelectShogi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectCheckers);
            this.Controls.Add(this.SelectChess);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainGameWindow";
            this.Text = "Šachy, shogi, dáma";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectChess;
        private System.Windows.Forms.Button SelectCheckers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SelectShogi;
        private System.Windows.Forms.Button SelectCustomGame;
        private System.Windows.Forms.Button AboutGame;
        private System.Windows.Forms.Button AboutAuthor;
        private System.Windows.Forms.Button Credits;
        private System.Windows.Forms.Button SelectSingleplayer;
        private System.Windows.Forms.Button SelectLocMulti;
        private System.Windows.Forms.Button SelectWebMulti;
        private System.Windows.Forms.ImageList GamePieces;
        private System.Windows.Forms.Label label2;
    }
}

