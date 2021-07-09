﻿namespace ShogiCheckersChess
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
            this.SelectShogiButton = new System.Windows.Forms.Button();
            this.SelectCustomGameButton = new System.Windows.Forms.Button();
            this.AboutGameButton = new System.Windows.Forms.Button();
            this.SelectSingleplayerButton = new System.Windows.Forms.Button();
            this.SelectLocMultiButton = new System.Windows.Forms.Button();
            this.GamePieces = new System.Windows.Forms.ImageList(this.components);
            this.GameStateLabel = new System.Windows.Forms.Label();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.ChooseShogiBoxBottom = new System.Windows.Forms.ComboBox();
            this.ChooseShogiLabelBottom = new System.Windows.Forms.Label();
            this.ChooseShogiButtonBottom = new System.Windows.Forms.Button();
            this.PutShogiPieceLabelBottom = new System.Windows.Forms.Label();
            this.PutShogiPieceLabelUpper = new System.Windows.Forms.Label();
            this.ChooseShogiButtonUpper = new System.Windows.Forms.Button();
            this.ChooseShogiLabelUpper = new System.Windows.Forms.Label();
            this.ChooseShogiBoxUpper = new System.Windows.Forms.ComboBox();
            this.CustomGameSizeLabel = new System.Windows.Forms.Label();
            this.CustomGameSizeXTextbox = new System.Windows.Forms.TextBox();
            this.CustomGameSizeYTextbox = new System.Windows.Forms.TextBox();
            this.CustomGameSizeXLabel = new System.Windows.Forms.Label();
            this.CustomGameSizeYLabel = new System.Windows.Forms.Label();
            this.CustomGameSizeButton = new System.Windows.Forms.Button();
            this.CustomGameSizeErrorLabel = new System.Windows.Forms.Label();
            this.CustomGameChooseCombobox = new System.Windows.Forms.ComboBox();
            this.CustomGameChooseLabel = new System.Windows.Forms.Label();
            this.CustomGameChooseErrorLabel = new System.Windows.Forms.Label();
            this.CustomLabel = new System.Windows.Forms.Label();
            this.LoadGameButton = new System.Windows.Forms.Button();
            this.LoadCustomGameDialog = new System.Windows.Forms.OpenFileDialog();
            this.MinimaxButton = new System.Windows.Forms.Button();
            this.MonteCarloButton = new System.Windows.Forms.Button();
            this.ChooseAlgorithmLabel = new System.Windows.Forms.Label();
            this.NewGameInstanceButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectChessButton
            // 
            this.SelectChessButton.Location = new System.Drawing.Point(257, 188);
            this.SelectChessButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectChessButton.Name = "SelectChessButton";
            this.SelectChessButton.Size = new System.Drawing.Size(101, 54);
            this.SelectChessButton.TabIndex = 0;
            this.SelectChessButton.Text = "Šachy";
            this.SelectChessButton.UseVisualStyleBackColor = true;
            this.SelectChessButton.Click += new System.EventHandler(this.SelectChessButton_Click);
            // 
            // SelectCheckersButton
            // 
            this.SelectCheckersButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SelectCheckersButton.Location = new System.Drawing.Point(409, 188);
            this.SelectCheckersButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectCheckersButton.Name = "SelectCheckersButton";
            this.SelectCheckersButton.Size = new System.Drawing.Size(105, 54);
            this.SelectCheckersButton.TabIndex = 1;
            this.SelectCheckersButton.Text = "Dáma";
            this.SelectCheckersButton.UseVisualStyleBackColor = true;
            this.SelectCheckersButton.Click += new System.EventHandler(this.SelectCheckersButton_Click);
            // 
            // SelectShogiButton
            // 
            this.SelectShogiButton.Location = new System.Drawing.Point(567, 188);
            this.SelectShogiButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectShogiButton.Name = "SelectShogiButton";
            this.SelectShogiButton.Size = new System.Drawing.Size(105, 54);
            this.SelectShogiButton.TabIndex = 3;
            this.SelectShogiButton.Text = "Shogi";
            this.SelectShogiButton.UseVisualStyleBackColor = true;
            this.SelectShogiButton.Click += new System.EventHandler(this.SelectShogiButton_Click);
            // 
            // SelectCustomGameButton
            // 
            this.SelectCustomGameButton.Location = new System.Drawing.Point(345, 49);
            this.SelectCustomGameButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectCustomGameButton.Name = "SelectCustomGameButton";
            this.SelectCustomGameButton.Size = new System.Drawing.Size(105, 60);
            this.SelectCustomGameButton.TabIndex = 4;
            this.SelectCustomGameButton.Text = "Vlastní hra";
            this.SelectCustomGameButton.UseVisualStyleBackColor = true;
            this.SelectCustomGameButton.Click += new System.EventHandler(this.SelectCustomGameButton_Click);
            // 
            // AboutGameButton
            // 
            this.AboutGameButton.Location = new System.Drawing.Point(409, 602);
            this.AboutGameButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AboutGameButton.Name = "AboutGameButton";
            this.AboutGameButton.Size = new System.Drawing.Size(105, 53);
            this.AboutGameButton.TabIndex = 5;
            this.AboutGameButton.Text = "O programu";
            this.AboutGameButton.UseVisualStyleBackColor = true;
            this.AboutGameButton.Click += new System.EventHandler(this.AboutGameButton_Click);
            // 
            // SelectSingleplayerButton
            // 
            this.SelectSingleplayerButton.Location = new System.Drawing.Point(333, 349);
            this.SelectSingleplayerButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectSingleplayerButton.Name = "SelectSingleplayerButton";
            this.SelectSingleplayerButton.Size = new System.Drawing.Size(101, 57);
            this.SelectSingleplayerButton.TabIndex = 8;
            this.SelectSingleplayerButton.Text = "Singleplayer";
            this.SelectSingleplayerButton.UseVisualStyleBackColor = true;
            this.SelectSingleplayerButton.Visible = false;
            this.SelectSingleplayerButton.Click += new System.EventHandler(this.SelectSingleplayerButton_Click);
            // 
            // SelectLocMultiButton
            // 
            this.SelectLocMultiButton.Location = new System.Drawing.Point(487, 349);
            this.SelectLocMultiButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectLocMultiButton.Name = "SelectLocMultiButton";
            this.SelectLocMultiButton.Size = new System.Drawing.Size(107, 57);
            this.SelectLocMultiButton.TabIndex = 9;
            this.SelectLocMultiButton.Text = "Lokální multiplayer";
            this.SelectLocMultiButton.UseVisualStyleBackColor = true;
            this.SelectLocMultiButton.Visible = false;
            this.SelectLocMultiButton.Click += new System.EventHandler(this.SelectLocMultiButton_Click);
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
            this.GamePieces.Images.SetKeyName(42, "43.gif");
            this.GamePieces.Images.SetKeyName(43, "44.gif");
            // 
            // GameStateLabel
            // 
            this.GameStateLabel.AutoSize = true;
            this.GameStateLabel.Location = new System.Drawing.Point(751, 602);
            this.GameStateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GameStateLabel.Name = "GameStateLabel";
            this.GameStateLabel.Size = new System.Drawing.Size(70, 16);
            this.GameStateLabel.TabIndex = 11;
            this.GameStateLabel.Text = "Konec hry.";
            this.GameStateLabel.Visible = false;
            // 
            // NewGameButton
            // 
            this.NewGameButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.NewGameButton.Location = new System.Drawing.Point(755, 622);
            this.NewGameButton.Margin = new System.Windows.Forms.Padding(4);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(132, 59);
            this.NewGameButton.TabIndex = 12;
            this.NewGameButton.Text = "Hrát";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.Visible = false;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // ChooseShogiBoxBottom
            // 
            this.ChooseShogiBoxBottom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChooseShogiBoxBottom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChooseShogiBoxBottom.FormattingEnabled = true;
            this.ChooseShogiBoxBottom.Location = new System.Drawing.Point(755, 444);
            this.ChooseShogiBoxBottom.Margin = new System.Windows.Forms.Padding(4);
            this.ChooseShogiBoxBottom.Name = "ChooseShogiBoxBottom";
            this.ChooseShogiBoxBottom.Size = new System.Drawing.Size(160, 24);
            this.ChooseShogiBoxBottom.TabIndex = 13;
            this.ChooseShogiBoxBottom.Visible = false;
            // 
            // ChooseShogiLabelBottom
            // 
            this.ChooseShogiLabelBottom.AutoSize = true;
            this.ChooseShogiLabelBottom.Location = new System.Drawing.Point(751, 409);
            this.ChooseShogiLabelBottom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ChooseShogiLabelBottom.Name = "ChooseShogiLabelBottom";
            this.ChooseShogiLabelBottom.Size = new System.Drawing.Size(135, 16);
            this.ChooseShogiLabelBottom.TabIndex = 14;
            this.ChooseShogiLabelBottom.Text = "Nebo vyberte figurku:";
            this.ChooseShogiLabelBottom.Visible = false;
            // 
            // ChooseShogiButtonBottom
            // 
            this.ChooseShogiButtonBottom.Location = new System.Drawing.Point(755, 494);
            this.ChooseShogiButtonBottom.Margin = new System.Windows.Forms.Padding(4);
            this.ChooseShogiButtonBottom.Name = "ChooseShogiButtonBottom";
            this.ChooseShogiButtonBottom.Size = new System.Drawing.Size(100, 28);
            this.ChooseShogiButtonBottom.TabIndex = 15;
            this.ChooseShogiButtonBottom.Text = "Přidat";
            this.ChooseShogiButtonBottom.UseVisualStyleBackColor = true;
            this.ChooseShogiButtonBottom.Visible = false;
            this.ChooseShogiButtonBottom.Click += new System.EventHandler(this.ChooseShogiButtonBottom_Click);
            // 
            // PutShogiPieceLabelBottom
            // 
            this.PutShogiPieceLabelBottom.Location = new System.Drawing.Point(751, 543);
            this.PutShogiPieceLabelBottom.Name = "PutShogiPieceLabelBottom";
            this.PutShogiPieceLabelBottom.Size = new System.Drawing.Size(157, 59);
            this.PutShogiPieceLabelBottom.TabIndex = 16;
            this.PutShogiPieceLabelBottom.Text = "Klikněte na pole, na které chcete figurku umístit.";
            this.PutShogiPieceLabelBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PutShogiPieceLabelBottom.Visible = false;
            // 
            // PutShogiPieceLabelUpper
            // 
            this.PutShogiPieceLabelUpper.Location = new System.Drawing.Point(751, 188);
            this.PutShogiPieceLabelUpper.Name = "PutShogiPieceLabelUpper";
            this.PutShogiPieceLabelUpper.Size = new System.Drawing.Size(157, 59);
            this.PutShogiPieceLabelUpper.TabIndex = 20;
            this.PutShogiPieceLabelUpper.Text = "Klikněte na pole, na které chcete figurku umístit.";
            this.PutShogiPieceLabelUpper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PutShogiPieceLabelUpper.Visible = false;
            // 
            // ChooseShogiButtonUpper
            // 
            this.ChooseShogiButtonUpper.Location = new System.Drawing.Point(768, 156);
            this.ChooseShogiButtonUpper.Margin = new System.Windows.Forms.Padding(4);
            this.ChooseShogiButtonUpper.Name = "ChooseShogiButtonUpper";
            this.ChooseShogiButtonUpper.Size = new System.Drawing.Size(100, 28);
            this.ChooseShogiButtonUpper.TabIndex = 19;
            this.ChooseShogiButtonUpper.Text = "Přidat";
            this.ChooseShogiButtonUpper.UseVisualStyleBackColor = true;
            this.ChooseShogiButtonUpper.Visible = false;
            this.ChooseShogiButtonUpper.Click += new System.EventHandler(this.ChooseShogiButtonUpper_Click);
            // 
            // ChooseShogiLabelUpper
            // 
            this.ChooseShogiLabelUpper.AutoSize = true;
            this.ChooseShogiLabelUpper.Location = new System.Drawing.Point(765, 71);
            this.ChooseShogiLabelUpper.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ChooseShogiLabelUpper.Name = "ChooseShogiLabelUpper";
            this.ChooseShogiLabelUpper.Size = new System.Drawing.Size(135, 16);
            this.ChooseShogiLabelUpper.TabIndex = 18;
            this.ChooseShogiLabelUpper.Text = "Nebo vyberte figurku:";
            this.ChooseShogiLabelUpper.Visible = false;
            // 
            // ChooseShogiBoxUpper
            // 
            this.ChooseShogiBoxUpper.BackColor = System.Drawing.Color.White;
            this.ChooseShogiBoxUpper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChooseShogiBoxUpper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChooseShogiBoxUpper.FormattingEnabled = true;
            this.ChooseShogiBoxUpper.Location = new System.Drawing.Point(769, 107);
            this.ChooseShogiBoxUpper.Margin = new System.Windows.Forms.Padding(4);
            this.ChooseShogiBoxUpper.Name = "ChooseShogiBoxUpper";
            this.ChooseShogiBoxUpper.Size = new System.Drawing.Size(160, 24);
            this.ChooseShogiBoxUpper.TabIndex = 17;
            this.ChooseShogiBoxUpper.Visible = false;
            // 
            // CustomGameSizeLabel
            // 
            this.CustomGameSizeLabel.AutoSize = true;
            this.CustomGameSizeLabel.Location = new System.Drawing.Point(40, 36);
            this.CustomGameSizeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CustomGameSizeLabel.Name = "CustomGameSizeLabel";
            this.CustomGameSizeLabel.Size = new System.Drawing.Size(392, 16);
            this.CustomGameSizeLabel.TabIndex = 21;
            this.CustomGameSizeLabel.Text = "Nastavte si velikost šachovnice. Hodnotu zadejte jako celé číslo.";
            this.CustomGameSizeLabel.Visible = false;
            // 
            // CustomGameSizeXTextbox
            // 
            this.CustomGameSizeXTextbox.Location = new System.Drawing.Point(100, 68);
            this.CustomGameSizeXTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.CustomGameSizeXTextbox.Name = "CustomGameSizeXTextbox";
            this.CustomGameSizeXTextbox.Size = new System.Drawing.Size(132, 22);
            this.CustomGameSizeXTextbox.TabIndex = 22;
            this.CustomGameSizeXTextbox.Visible = false;
            // 
            // CustomGameSizeYTextbox
            // 
            this.CustomGameSizeYTextbox.Location = new System.Drawing.Point(100, 117);
            this.CustomGameSizeYTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.CustomGameSizeYTextbox.Name = "CustomGameSizeYTextbox";
            this.CustomGameSizeYTextbox.Size = new System.Drawing.Size(132, 22);
            this.CustomGameSizeYTextbox.TabIndex = 23;
            this.CustomGameSizeYTextbox.Visible = false;
            // 
            // CustomGameSizeXLabel
            // 
            this.CustomGameSizeXLabel.AutoSize = true;
            this.CustomGameSizeXLabel.Location = new System.Drawing.Point(40, 71);
            this.CustomGameSizeXLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CustomGameSizeXLabel.Name = "CustomGameSizeXLabel";
            this.CustomGameSizeXLabel.Size = new System.Drawing.Size(49, 16);
            this.CustomGameSizeXLabel.TabIndex = 24;
            this.CustomGameSizeXLabel.Text = "Výška:";
            this.CustomGameSizeXLabel.Visible = false;
            // 
            // CustomGameSizeYLabel
            // 
            this.CustomGameSizeYLabel.AutoSize = true;
            this.CustomGameSizeYLabel.Location = new System.Drawing.Point(40, 117);
            this.CustomGameSizeYLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CustomGameSizeYLabel.Name = "CustomGameSizeYLabel";
            this.CustomGameSizeYLabel.Size = new System.Drawing.Size(42, 16);
            this.CustomGameSizeYLabel.TabIndex = 25;
            this.CustomGameSizeYLabel.Text = "Šířka:";
            this.CustomGameSizeYLabel.Visible = false;
            // 
            // CustomGameSizeButton
            // 
            this.CustomGameSizeButton.Location = new System.Drawing.Point(115, 169);
            this.CustomGameSizeButton.Margin = new System.Windows.Forms.Padding(4);
            this.CustomGameSizeButton.Name = "CustomGameSizeButton";
            this.CustomGameSizeButton.Size = new System.Drawing.Size(100, 28);
            this.CustomGameSizeButton.TabIndex = 26;
            this.CustomGameSizeButton.Text = "OK";
            this.CustomGameSizeButton.UseVisualStyleBackColor = true;
            this.CustomGameSizeButton.Visible = false;
            this.CustomGameSizeButton.Click += new System.EventHandler(this.CustomGameSizeButton_Click);
            // 
            // CustomGameSizeErrorLabel
            // 
            this.CustomGameSizeErrorLabel.AutoSize = true;
            this.CustomGameSizeErrorLabel.Location = new System.Drawing.Point(64, 217);
            this.CustomGameSizeErrorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CustomGameSizeErrorLabel.Name = "CustomGameSizeErrorLabel";
            this.CustomGameSizeErrorLabel.Size = new System.Drawing.Size(220, 16);
            this.CustomGameSizeErrorLabel.TabIndex = 27;
            this.CustomGameSizeErrorLabel.Text = "Chyba - nebylo zadáno platné číslo.";
            this.CustomGameSizeErrorLabel.Visible = false;
            // 
            // CustomGameChooseCombobox
            // 
            this.CustomGameChooseCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CustomGameChooseCombobox.FormattingEnabled = true;
            this.CustomGameChooseCombobox.Items.AddRange(new object[] {
            "Bílý král",
            "Bílá královna",
            "Bílá věž",
            "Bílý kůň",
            "Bílý střelec",
            "Bílý pěšec",
            "Bílý kámen",
            "Spodní shogi král",
            "Spodní shogi věž",
            "Spodní shogi střelec",
            "Spodní zlatý generál",
            "Spodní stříbrný generál",
            "Spodní shogi kůň",
            "Spodní kopiník",
            "Spodní shogi pěšák",
            "Černý král",
            "Černá královna",
            "Černá věž",
            "Černý kůň",
            "Černý střelec",
            "Černý pěšec",
            "Černý kámen",
            "Vrchní shogi král",
            "Vrchní shogi věž",
            "Vrchní shogi střelec",
            "Vrchní zlatý generál",
            "Vrchní stříbrný generál",
            "Vrchní shogi kůň",
            "Vrchní kopiník",
            "Vrchní shogi pěšák"});
            this.CustomGameChooseCombobox.Location = new System.Drawing.Point(753, 283);
            this.CustomGameChooseCombobox.Margin = new System.Windows.Forms.Padding(4);
            this.CustomGameChooseCombobox.Name = "CustomGameChooseCombobox";
            this.CustomGameChooseCombobox.Size = new System.Drawing.Size(160, 24);
            this.CustomGameChooseCombobox.TabIndex = 31;
            this.CustomGameChooseCombobox.Visible = false;
            // 
            // CustomGameChooseLabel
            // 
            this.CustomGameChooseLabel.AutoSize = true;
            this.CustomGameChooseLabel.Location = new System.Drawing.Point(751, 255);
            this.CustomGameChooseLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CustomGameChooseLabel.Name = "CustomGameChooseLabel";
            this.CustomGameChooseLabel.Size = new System.Drawing.Size(100, 16);
            this.CustomGameChooseLabel.TabIndex = 32;
            this.CustomGameChooseLabel.Text = "Vyberte figurku:";
            this.CustomGameChooseLabel.Visible = false;
            // 
            // CustomGameChooseErrorLabel
            // 
            this.CustomGameChooseErrorLabel.Location = new System.Drawing.Point(751, 327);
            this.CustomGameChooseErrorLabel.Name = "CustomGameChooseErrorLabel";
            this.CustomGameChooseErrorLabel.Size = new System.Drawing.Size(157, 59);
            this.CustomGameChooseErrorLabel.TabIndex = 34;
            this.CustomGameChooseErrorLabel.Text = "Klikněte na pole, na které chcete figurku umístit.";
            this.CustomGameChooseErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CustomGameChooseErrorLabel.Visible = false;
            // 
            // CustomLabel
            // 
            this.CustomLabel.AutoSize = true;
            this.CustomLabel.Location = new System.Drawing.Point(749, 695);
            this.CustomLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CustomLabel.Name = "CustomLabel";
            this.CustomLabel.Size = new System.Drawing.Size(133, 16);
            this.CustomLabel.TabIndex = 35;
            this.CustomLabel.Text = "Popis se bude měnit.";
            this.CustomLabel.Visible = false;
            // 
            // LoadGameButton
            // 
            this.LoadGameButton.Location = new System.Drawing.Point(487, 49);
            this.LoadGameButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadGameButton.Name = "LoadGameButton";
            this.LoadGameButton.Size = new System.Drawing.Size(105, 60);
            this.LoadGameButton.TabIndex = 36;
            this.LoadGameButton.Text = "Načíst hru";
            this.LoadGameButton.UseVisualStyleBackColor = true;
            this.LoadGameButton.Click += new System.EventHandler(this.LoadGameButton_Click);
            // 
            // MinimaxButton
            // 
            this.MinimaxButton.Location = new System.Drawing.Point(345, 267);
            this.MinimaxButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimaxButton.Name = "MinimaxButton";
            this.MinimaxButton.Size = new System.Drawing.Size(101, 54);
            this.MinimaxButton.TabIndex = 37;
            this.MinimaxButton.Text = "Minimax";
            this.MinimaxButton.UseVisualStyleBackColor = true;
            this.MinimaxButton.Visible = false;
            this.MinimaxButton.Click += new System.EventHandler(this.MinimaxButton_Click);
            // 
            // MonteCarloButton
            // 
            this.MonteCarloButton.Location = new System.Drawing.Point(487, 267);
            this.MonteCarloButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MonteCarloButton.Name = "MonteCarloButton";
            this.MonteCarloButton.Size = new System.Drawing.Size(101, 54);
            this.MonteCarloButton.TabIndex = 38;
            this.MonteCarloButton.Text = "MonteCarlo";
            this.MonteCarloButton.UseVisualStyleBackColor = true;
            this.MonteCarloButton.Visible = false;
            this.MonteCarloButton.Click += new System.EventHandler(this.MonteCarloButton_Click);
            // 
            // ChooseAlgorithmLabel
            // 
            this.ChooseAlgorithmLabel.AutoSize = true;
            this.ChooseAlgorithmLabel.Location = new System.Drawing.Point(408, 217);
            this.ChooseAlgorithmLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ChooseAlgorithmLabel.Name = "ChooseAlgorithmLabel";
            this.ChooseAlgorithmLabel.Size = new System.Drawing.Size(123, 16);
            this.ChooseAlgorithmLabel.TabIndex = 39;
            this.ChooseAlgorithmLabel.Text = "Vyberte algoritmus.";
            this.ChooseAlgorithmLabel.Visible = false;
            // 
            // NewGameInstanceButton
            // 
            this.NewGameInstanceButton.Location = new System.Drawing.Point(836, 11);
            this.NewGameInstanceButton.Margin = new System.Windows.Forms.Padding(4);
            this.NewGameInstanceButton.Name = "NewGameInstanceButton";
            this.NewGameInstanceButton.Size = new System.Drawing.Size(141, 39);
            this.NewGameInstanceButton.TabIndex = 40;
            this.NewGameInstanceButton.Text = "Nová hra";
            this.NewGameInstanceButton.UseVisualStyleBackColor = true;
            this.NewGameInstanceButton.Visible = false;
            this.NewGameInstanceButton.Click += new System.EventHandler(this.NewGameInstanceButton_Click);
            // 
            // MainGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(993, 734);
            this.Controls.Add(this.NewGameInstanceButton);
            this.Controls.Add(this.ChooseAlgorithmLabel);
            this.Controls.Add(this.MonteCarloButton);
            this.Controls.Add(this.MinimaxButton);
            this.Controls.Add(this.LoadGameButton);
            this.Controls.Add(this.CustomLabel);
            this.Controls.Add(this.CustomGameChooseErrorLabel);
            this.Controls.Add(this.CustomGameChooseLabel);
            this.Controls.Add(this.CustomGameChooseCombobox);
            this.Controls.Add(this.CustomGameSizeErrorLabel);
            this.Controls.Add(this.CustomGameSizeButton);
            this.Controls.Add(this.CustomGameSizeYLabel);
            this.Controls.Add(this.CustomGameSizeXLabel);
            this.Controls.Add(this.CustomGameSizeYTextbox);
            this.Controls.Add(this.CustomGameSizeXTextbox);
            this.Controls.Add(this.CustomGameSizeLabel);
            this.Controls.Add(this.PutShogiPieceLabelUpper);
            this.Controls.Add(this.ChooseShogiButtonUpper);
            this.Controls.Add(this.ChooseShogiLabelUpper);
            this.Controls.Add(this.ChooseShogiBoxUpper);
            this.Controls.Add(this.PutShogiPieceLabelBottom);
            this.Controls.Add(this.ChooseShogiButtonBottom);
            this.Controls.Add(this.ChooseShogiLabelBottom);
            this.Controls.Add(this.ChooseShogiBoxBottom);
            this.Controls.Add(this.NewGameButton);
            this.Controls.Add(this.GameStateLabel);
            this.Controls.Add(this.SelectLocMultiButton);
            this.Controls.Add(this.SelectSingleplayerButton);
            this.Controls.Add(this.AboutGameButton);
            this.Controls.Add(this.SelectCustomGameButton);
            this.Controls.Add(this.SelectShogiButton);
            this.Controls.Add(this.SelectCheckersButton);
            this.Controls.Add(this.SelectChessButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainGameWindow";
            this.Text = "Šachy, shogi, dáma";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectChessButton;
        private System.Windows.Forms.Button SelectCheckersButton;
        private System.Windows.Forms.Button SelectShogiButton;
        private System.Windows.Forms.Button SelectCustomGameButton;
        private System.Windows.Forms.Button AboutGameButton;
        private System.Windows.Forms.Button SelectSingleplayerButton;
        private System.Windows.Forms.Button SelectLocMultiButton;
        private System.Windows.Forms.ImageList GamePieces;
        private System.Windows.Forms.Label GameStateLabel;
        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.ComboBox ChooseShogiBoxBottom;
        private System.Windows.Forms.Label ChooseShogiLabelBottom;
        private System.Windows.Forms.Button ChooseShogiButtonBottom;
        private System.Windows.Forms.Label PutShogiPieceLabelBottom;
        private System.Windows.Forms.Label PutShogiPieceLabelUpper;
        private System.Windows.Forms.Button ChooseShogiButtonUpper;
        private System.Windows.Forms.Label ChooseShogiLabelUpper;
        private System.Windows.Forms.ComboBox ChooseShogiBoxUpper;
        private System.Windows.Forms.Label CustomGameSizeLabel;
        private System.Windows.Forms.TextBox CustomGameSizeXTextbox;
        private System.Windows.Forms.TextBox CustomGameSizeYTextbox;
        private System.Windows.Forms.Label CustomGameSizeXLabel;
        private System.Windows.Forms.Label CustomGameSizeYLabel;
        private System.Windows.Forms.Button CustomGameSizeButton;
        private System.Windows.Forms.Label CustomGameSizeErrorLabel;
        private System.Windows.Forms.ComboBox CustomGameChooseCombobox;
        private System.Windows.Forms.Label CustomGameChooseLabel;
        private System.Windows.Forms.Label CustomGameChooseErrorLabel;
        private System.Windows.Forms.Label CustomLabel;
        private System.Windows.Forms.Button LoadGameButton;
        private System.Windows.Forms.OpenFileDialog LoadCustomGameDialog;
        private System.Windows.Forms.Button MinimaxButton;
        private System.Windows.Forms.Button MonteCarloButton;
        private System.Windows.Forms.Label ChooseAlgorithmLabel;
        private System.Windows.Forms.Button NewGameInstanceButton;
    }
}

