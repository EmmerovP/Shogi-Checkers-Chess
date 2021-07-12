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
            this.SelectShogiButton = new System.Windows.Forms.Button();
            this.SelectCustomGameButton = new System.Windows.Forms.Button();
            this.AboutGameButton = new System.Windows.Forms.Button();
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
            this.CustomGameChooseCombobox = new System.Windows.Forms.ComboBox();
            this.CustomGameChooseLabel = new System.Windows.Forms.Label();
            this.CustomGameChooseErrorLabel = new System.Windows.Forms.Label();
            this.CustomLabel = new System.Windows.Forms.Label();
            this.LoadGameButton = new System.Windows.Forms.Button();
            this.LoadCustomGameDialog = new System.Windows.Forms.OpenFileDialog();
            this.NewGameInstanceButton = new System.Windows.Forms.Button();
            this.SelectBlackHordeChessButton = new System.Windows.Forms.Button();
            this.SelectWhiteHordeChessButton = new System.Windows.Forms.Button();
            this.SelectChess960Button = new System.Windows.Forms.Button();
            this.SelectAlmostChessButton = new System.Windows.Forms.Button();
            this.SelectCrazyhouseButton = new System.Windows.Forms.Button();
            this.SelectInternationalCheckersButton = new System.Windows.Forms.Button();
            this.SelectMinishogiButton = new System.Windows.Forms.Button();
            this.AlgorithmTypePanel = new System.Windows.Forms.Panel();
            this.MCTSTimeLabel = new System.Windows.Forms.Label();
            this.MCTSTimeUpDown = new System.Windows.Forms.NumericUpDown();
            this.AlphabetaCheckBox = new System.Windows.Forms.CheckBox();
            this.DepthLabel = new System.Windows.Forms.Label();
            this.DepthUpDown = new System.Windows.Forms.NumericUpDown();
            this.MCTSRadioButton = new System.Windows.Forms.RadioButton();
            this.MinimaxRadioButton = new System.Windows.Forms.RadioButton();
            this.PlayerTypePanel = new System.Windows.Forms.Panel();
            this.OKbutton = new System.Windows.Forms.Button();
            this.SingleplayerRadioButton = new System.Windows.Forms.RadioButton();
            this.MultiplayerRadioButton = new System.Windows.Forms.RadioButton();
            this.AlgorithmTypePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MCTSTimeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepthUpDown)).BeginInit();
            this.PlayerTypePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectChessButton
            // 
            this.SelectChessButton.Location = new System.Drawing.Point(197, 118);
            this.SelectChessButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectChessButton.Name = "SelectChessButton";
            this.SelectChessButton.Size = new System.Drawing.Size(76, 44);
            this.SelectChessButton.TabIndex = 0;
            this.SelectChessButton.TabStop = false;
            this.SelectChessButton.Text = "Šachy";
            this.SelectChessButton.UseVisualStyleBackColor = true;
            this.SelectChessButton.Click += new System.EventHandler(this.SelectChessButton_Click);
            // 
            // SelectCheckersButton
            // 
            this.SelectCheckersButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SelectCheckersButton.Location = new System.Drawing.Point(254, 266);
            this.SelectCheckersButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectCheckersButton.Name = "SelectCheckersButton";
            this.SelectCheckersButton.Size = new System.Drawing.Size(79, 44);
            this.SelectCheckersButton.TabIndex = 1;
            this.SelectCheckersButton.TabStop = false;
            this.SelectCheckersButton.Text = "Česká dáma";
            this.SelectCheckersButton.UseVisualStyleBackColor = true;
            this.SelectCheckersButton.Click += new System.EventHandler(this.SelectCheckersButton_Click);
            // 
            // SelectShogiButton
            // 
            this.SelectShogiButton.Location = new System.Drawing.Point(258, 344);
            this.SelectShogiButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectShogiButton.Name = "SelectShogiButton";
            this.SelectShogiButton.Size = new System.Drawing.Size(79, 44);
            this.SelectShogiButton.TabIndex = 3;
            this.SelectShogiButton.TabStop = false;
            this.SelectShogiButton.Text = "Šogi";
            this.SelectShogiButton.UseVisualStyleBackColor = true;
            this.SelectShogiButton.Click += new System.EventHandler(this.SelectShogiButton_Click);
            // 
            // SelectCustomGameButton
            // 
            this.SelectCustomGameButton.Location = new System.Drawing.Point(259, 40);
            this.SelectCustomGameButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectCustomGameButton.Name = "SelectCustomGameButton";
            this.SelectCustomGameButton.Size = new System.Drawing.Size(79, 49);
            this.SelectCustomGameButton.TabIndex = 4;
            this.SelectCustomGameButton.TabStop = false;
            this.SelectCustomGameButton.Text = "Vlastní hra";
            this.SelectCustomGameButton.UseVisualStyleBackColor = true;
            this.SelectCustomGameButton.Click += new System.EventHandler(this.SelectCustomGameButton_Click);
            // 
            // AboutGameButton
            // 
            this.AboutGameButton.Location = new System.Drawing.Point(307, 523);
            this.AboutGameButton.Margin = new System.Windows.Forms.Padding(2);
            this.AboutGameButton.Name = "AboutGameButton";
            this.AboutGameButton.Size = new System.Drawing.Size(79, 43);
            this.AboutGameButton.TabIndex = 5;
            this.AboutGameButton.TabStop = false;
            this.AboutGameButton.Text = "O programu";
            this.AboutGameButton.UseVisualStyleBackColor = true;
            this.AboutGameButton.Click += new System.EventHandler(this.AboutGameButton_Click);
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
            this.GameStateLabel.Location = new System.Drawing.Point(563, 489);
            this.GameStateLabel.Name = "GameStateLabel";
            this.GameStateLabel.Size = new System.Drawing.Size(58, 13);
            this.GameStateLabel.TabIndex = 11;
            this.GameStateLabel.Text = "Konec hry.";
            this.GameStateLabel.Visible = false;
            // 
            // NewGameButton
            // 
            this.NewGameButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.NewGameButton.Location = new System.Drawing.Point(566, 505);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(99, 48);
            this.NewGameButton.TabIndex = 12;
            this.NewGameButton.TabStop = false;
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
            this.ChooseShogiBoxBottom.Location = new System.Drawing.Point(566, 361);
            this.ChooseShogiBoxBottom.Name = "ChooseShogiBoxBottom";
            this.ChooseShogiBoxBottom.Size = new System.Drawing.Size(121, 21);
            this.ChooseShogiBoxBottom.TabIndex = 13;
            this.ChooseShogiBoxBottom.Visible = false;
            // 
            // ChooseShogiLabelBottom
            // 
            this.ChooseShogiLabelBottom.AutoSize = true;
            this.ChooseShogiLabelBottom.Location = new System.Drawing.Point(563, 332);
            this.ChooseShogiLabelBottom.Name = "ChooseShogiLabelBottom";
            this.ChooseShogiLabelBottom.Size = new System.Drawing.Size(109, 13);
            this.ChooseShogiLabelBottom.TabIndex = 14;
            this.ChooseShogiLabelBottom.Text = "Nebo vyberte figurku:";
            this.ChooseShogiLabelBottom.Visible = false;
            // 
            // ChooseShogiButtonBottom
            // 
            this.ChooseShogiButtonBottom.Location = new System.Drawing.Point(566, 401);
            this.ChooseShogiButtonBottom.Name = "ChooseShogiButtonBottom";
            this.ChooseShogiButtonBottom.Size = new System.Drawing.Size(75, 23);
            this.ChooseShogiButtonBottom.TabIndex = 15;
            this.ChooseShogiButtonBottom.TabStop = false;
            this.ChooseShogiButtonBottom.Text = "Přidat";
            this.ChooseShogiButtonBottom.UseVisualStyleBackColor = true;
            this.ChooseShogiButtonBottom.Visible = false;
            this.ChooseShogiButtonBottom.Click += new System.EventHandler(this.ChooseShogiButtonBottom_Click);
            // 
            // PutShogiPieceLabelBottom
            // 
            this.PutShogiPieceLabelBottom.Location = new System.Drawing.Point(563, 441);
            this.PutShogiPieceLabelBottom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PutShogiPieceLabelBottom.Name = "PutShogiPieceLabelBottom";
            this.PutShogiPieceLabelBottom.Size = new System.Drawing.Size(118, 48);
            this.PutShogiPieceLabelBottom.TabIndex = 16;
            this.PutShogiPieceLabelBottom.Text = "Klikněte na pole, na které chcete figurku umístit.";
            this.PutShogiPieceLabelBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PutShogiPieceLabelBottom.Visible = false;
            // 
            // PutShogiPieceLabelUpper
            // 
            this.PutShogiPieceLabelUpper.Location = new System.Drawing.Point(607, 159);
            this.PutShogiPieceLabelUpper.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PutShogiPieceLabelUpper.Name = "PutShogiPieceLabelUpper";
            this.PutShogiPieceLabelUpper.Size = new System.Drawing.Size(118, 48);
            this.PutShogiPieceLabelUpper.TabIndex = 20;
            this.PutShogiPieceLabelUpper.Text = "Klikněte na pole, na které chcete figurku umístit.";
            this.PutShogiPieceLabelUpper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PutShogiPieceLabelUpper.Visible = false;
            // 
            // ChooseShogiButtonUpper
            // 
            this.ChooseShogiButtonUpper.Location = new System.Drawing.Point(576, 127);
            this.ChooseShogiButtonUpper.Name = "ChooseShogiButtonUpper";
            this.ChooseShogiButtonUpper.Size = new System.Drawing.Size(75, 23);
            this.ChooseShogiButtonUpper.TabIndex = 19;
            this.ChooseShogiButtonUpper.TabStop = false;
            this.ChooseShogiButtonUpper.Text = "Přidat";
            this.ChooseShogiButtonUpper.UseVisualStyleBackColor = true;
            this.ChooseShogiButtonUpper.Visible = false;
            this.ChooseShogiButtonUpper.Click += new System.EventHandler(this.ChooseShogiButtonUpper_Click);
            // 
            // ChooseShogiLabelUpper
            // 
            this.ChooseShogiLabelUpper.AutoSize = true;
            this.ChooseShogiLabelUpper.Location = new System.Drawing.Point(574, 58);
            this.ChooseShogiLabelUpper.Name = "ChooseShogiLabelUpper";
            this.ChooseShogiLabelUpper.Size = new System.Drawing.Size(109, 13);
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
            this.ChooseShogiBoxUpper.Location = new System.Drawing.Point(577, 87);
            this.ChooseShogiBoxUpper.Name = "ChooseShogiBoxUpper";
            this.ChooseShogiBoxUpper.Size = new System.Drawing.Size(121, 21);
            this.ChooseShogiBoxUpper.TabIndex = 17;
            this.ChooseShogiBoxUpper.Visible = false;
            // 
            // CustomGameSizeLabel
            // 
            this.CustomGameSizeLabel.AutoSize = true;
            this.CustomGameSizeLabel.Location = new System.Drawing.Point(30, 29);
            this.CustomGameSizeLabel.Name = "CustomGameSizeLabel";
            this.CustomGameSizeLabel.Size = new System.Drawing.Size(316, 13);
            this.CustomGameSizeLabel.TabIndex = 21;
            this.CustomGameSizeLabel.Text = "Nastavte si velikost šachovnice. Hodnotu zadejte jako celé číslo.";
            this.CustomGameSizeLabel.Visible = false;
            // 
            // CustomGameSizeXTextbox
            // 
            this.CustomGameSizeXTextbox.Location = new System.Drawing.Point(75, 55);
            this.CustomGameSizeXTextbox.Name = "CustomGameSizeXTextbox";
            this.CustomGameSizeXTextbox.Size = new System.Drawing.Size(100, 20);
            this.CustomGameSizeXTextbox.TabIndex = 22;
            this.CustomGameSizeXTextbox.Visible = false;
            // 
            // CustomGameSizeYTextbox
            // 
            this.CustomGameSizeYTextbox.Location = new System.Drawing.Point(75, 95);
            this.CustomGameSizeYTextbox.Name = "CustomGameSizeYTextbox";
            this.CustomGameSizeYTextbox.Size = new System.Drawing.Size(100, 20);
            this.CustomGameSizeYTextbox.TabIndex = 23;
            this.CustomGameSizeYTextbox.Visible = false;
            // 
            // CustomGameSizeXLabel
            // 
            this.CustomGameSizeXLabel.AutoSize = true;
            this.CustomGameSizeXLabel.Location = new System.Drawing.Point(30, 58);
            this.CustomGameSizeXLabel.Name = "CustomGameSizeXLabel";
            this.CustomGameSizeXLabel.Size = new System.Drawing.Size(39, 13);
            this.CustomGameSizeXLabel.TabIndex = 24;
            this.CustomGameSizeXLabel.Text = "Výška:";
            this.CustomGameSizeXLabel.Visible = false;
            // 
            // CustomGameSizeYLabel
            // 
            this.CustomGameSizeYLabel.AutoSize = true;
            this.CustomGameSizeYLabel.Location = new System.Drawing.Point(30, 95);
            this.CustomGameSizeYLabel.Name = "CustomGameSizeYLabel";
            this.CustomGameSizeYLabel.Size = new System.Drawing.Size(37, 13);
            this.CustomGameSizeYLabel.TabIndex = 25;
            this.CustomGameSizeYLabel.Text = "Šířka:";
            this.CustomGameSizeYLabel.Visible = false;
            // 
            // CustomGameSizeButton
            // 
            this.CustomGameSizeButton.Location = new System.Drawing.Point(86, 137);
            this.CustomGameSizeButton.Name = "CustomGameSizeButton";
            this.CustomGameSizeButton.Size = new System.Drawing.Size(75, 23);
            this.CustomGameSizeButton.TabIndex = 26;
            this.CustomGameSizeButton.TabStop = false;
            this.CustomGameSizeButton.Text = "OK";
            this.CustomGameSizeButton.UseVisualStyleBackColor = true;
            this.CustomGameSizeButton.Visible = false;
            this.CustomGameSizeButton.Click += new System.EventHandler(this.CustomGameSizeButton_Click);
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
            this.CustomGameChooseCombobox.Location = new System.Drawing.Point(565, 230);
            this.CustomGameChooseCombobox.Name = "CustomGameChooseCombobox";
            this.CustomGameChooseCombobox.Size = new System.Drawing.Size(121, 21);
            this.CustomGameChooseCombobox.TabIndex = 31;
            this.CustomGameChooseCombobox.Visible = false;
            // 
            // CustomGameChooseLabel
            // 
            this.CustomGameChooseLabel.AutoSize = true;
            this.CustomGameChooseLabel.Location = new System.Drawing.Point(563, 207);
            this.CustomGameChooseLabel.Name = "CustomGameChooseLabel";
            this.CustomGameChooseLabel.Size = new System.Drawing.Size(81, 13);
            this.CustomGameChooseLabel.TabIndex = 32;
            this.CustomGameChooseLabel.Text = "Vyberte figurku:";
            this.CustomGameChooseLabel.Visible = false;
            // 
            // CustomGameChooseErrorLabel
            // 
            this.CustomGameChooseErrorLabel.Location = new System.Drawing.Point(563, 266);
            this.CustomGameChooseErrorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CustomGameChooseErrorLabel.Name = "CustomGameChooseErrorLabel";
            this.CustomGameChooseErrorLabel.Size = new System.Drawing.Size(118, 48);
            this.CustomGameChooseErrorLabel.TabIndex = 34;
            this.CustomGameChooseErrorLabel.Text = "Klikněte na pole, na které chcete figurku umístit.";
            this.CustomGameChooseErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CustomGameChooseErrorLabel.Visible = false;
            // 
            // CustomLabel
            // 
            this.CustomLabel.AutoSize = true;
            this.CustomLabel.Location = new System.Drawing.Point(562, 565);
            this.CustomLabel.Name = "CustomLabel";
            this.CustomLabel.Size = new System.Drawing.Size(105, 13);
            this.CustomLabel.TabIndex = 35;
            this.CustomLabel.Text = "Popis se bude měnit.";
            this.CustomLabel.Visible = false;
            // 
            // LoadGameButton
            // 
            this.LoadGameButton.Location = new System.Drawing.Point(365, 40);
            this.LoadGameButton.Margin = new System.Windows.Forms.Padding(2);
            this.LoadGameButton.Name = "LoadGameButton";
            this.LoadGameButton.Size = new System.Drawing.Size(79, 49);
            this.LoadGameButton.TabIndex = 36;
            this.LoadGameButton.TabStop = false;
            this.LoadGameButton.Text = "Načíst hru";
            this.LoadGameButton.UseVisualStyleBackColor = true;
            this.LoadGameButton.Click += new System.EventHandler(this.LoadGameButton_Click);
            // 
            // NewGameInstanceButton
            // 
            this.NewGameInstanceButton.Location = new System.Drawing.Point(627, 9);
            this.NewGameInstanceButton.Name = "NewGameInstanceButton";
            this.NewGameInstanceButton.Size = new System.Drawing.Size(106, 32);
            this.NewGameInstanceButton.TabIndex = 40;
            this.NewGameInstanceButton.TabStop = false;
            this.NewGameInstanceButton.Text = "Nová hra";
            this.NewGameInstanceButton.UseVisualStyleBackColor = true;
            this.NewGameInstanceButton.Visible = false;
            this.NewGameInstanceButton.Click += new System.EventHandler(this.NewGameInstanceButton_Click);
            // 
            // SelectBlackHordeChessButton
            // 
            this.SelectBlackHordeChessButton.Location = new System.Drawing.Point(429, 118);
            this.SelectBlackHordeChessButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectBlackHordeChessButton.Name = "SelectBlackHordeChessButton";
            this.SelectBlackHordeChessButton.Size = new System.Drawing.Size(79, 44);
            this.SelectBlackHordeChessButton.TabIndex = 43;
            this.SelectBlackHordeChessButton.TabStop = false;
            this.SelectBlackHordeChessButton.Text = "Horde šachy (černá horda)";
            this.SelectBlackHordeChessButton.UseVisualStyleBackColor = true;
            this.SelectBlackHordeChessButton.Click += new System.EventHandler(this.SelectBlackHordeChessButton_Click);
            // 
            // SelectWhiteHordeChessButton
            // 
            this.SelectWhiteHordeChessButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SelectWhiteHordeChessButton.Location = new System.Drawing.Point(311, 118);
            this.SelectWhiteHordeChessButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectWhiteHordeChessButton.Name = "SelectWhiteHordeChessButton";
            this.SelectWhiteHordeChessButton.Size = new System.Drawing.Size(79, 44);
            this.SelectWhiteHordeChessButton.TabIndex = 42;
            this.SelectWhiteHordeChessButton.TabStop = false;
            this.SelectWhiteHordeChessButton.Text = "Horde šachy (bílá horda)";
            this.SelectWhiteHordeChessButton.UseVisualStyleBackColor = true;
            this.SelectWhiteHordeChessButton.Click += new System.EventHandler(this.SelectWhiteHordeChessButton_Click);
            // 
            // SelectChess960Button
            // 
            this.SelectChess960Button.Location = new System.Drawing.Point(197, 195);
            this.SelectChess960Button.Margin = new System.Windows.Forms.Padding(2);
            this.SelectChess960Button.Name = "SelectChess960Button";
            this.SelectChess960Button.Size = new System.Drawing.Size(76, 44);
            this.SelectChess960Button.TabIndex = 41;
            this.SelectChess960Button.TabStop = false;
            this.SelectChess960Button.Text = "Chess960";
            this.SelectChess960Button.UseVisualStyleBackColor = true;
            this.SelectChess960Button.Click += new System.EventHandler(this.SelectChess960Button_Click);
            // 
            // SelectAlmostChessButton
            // 
            this.SelectAlmostChessButton.Location = new System.Drawing.Point(429, 195);
            this.SelectAlmostChessButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectAlmostChessButton.Name = "SelectAlmostChessButton";
            this.SelectAlmostChessButton.Size = new System.Drawing.Size(79, 44);
            this.SelectAlmostChessButton.TabIndex = 46;
            this.SelectAlmostChessButton.TabStop = false;
            this.SelectAlmostChessButton.Text = "Skorošachy";
            this.SelectAlmostChessButton.UseVisualStyleBackColor = true;
            this.SelectAlmostChessButton.Click += new System.EventHandler(this.SelectAlmostChessButton_Click);
            // 
            // SelectCrazyhouseButton
            // 
            this.SelectCrazyhouseButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SelectCrazyhouseButton.Location = new System.Drawing.Point(311, 195);
            this.SelectCrazyhouseButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectCrazyhouseButton.Name = "SelectCrazyhouseButton";
            this.SelectCrazyhouseButton.Size = new System.Drawing.Size(79, 44);
            this.SelectCrazyhouseButton.TabIndex = 45;
            this.SelectCrazyhouseButton.TabStop = false;
            this.SelectCrazyhouseButton.Text = "Crazyhouse";
            this.SelectCrazyhouseButton.UseVisualStyleBackColor = true;
            this.SelectCrazyhouseButton.Click += new System.EventHandler(this.SelectCrazyhouseButton_Click);
            // 
            // SelectInternationalCheckersButton
            // 
            this.SelectInternationalCheckersButton.Location = new System.Drawing.Point(372, 266);
            this.SelectInternationalCheckersButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectInternationalCheckersButton.Name = "SelectInternationalCheckersButton";
            this.SelectInternationalCheckersButton.Size = new System.Drawing.Size(76, 44);
            this.SelectInternationalCheckersButton.TabIndex = 44;
            this.SelectInternationalCheckersButton.TabStop = false;
            this.SelectInternationalCheckersButton.Text = "Mezinárodní Dáma";
            this.SelectInternationalCheckersButton.UseVisualStyleBackColor = true;
            // 
            // SelectMinishogiButton
            // 
            this.SelectMinishogiButton.Location = new System.Drawing.Point(372, 344);
            this.SelectMinishogiButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectMinishogiButton.Name = "SelectMinishogiButton";
            this.SelectMinishogiButton.Size = new System.Drawing.Size(79, 44);
            this.SelectMinishogiButton.TabIndex = 47;
            this.SelectMinishogiButton.TabStop = false;
            this.SelectMinishogiButton.Text = "Minišogi";
            this.SelectMinishogiButton.UseVisualStyleBackColor = true;
            this.SelectMinishogiButton.Click += new System.EventHandler(this.SelectMinishogiButton_Click);
            // 
            // AlgorithmTypePanel
            // 
            this.AlgorithmTypePanel.Controls.Add(this.MCTSTimeLabel);
            this.AlgorithmTypePanel.Controls.Add(this.MCTSTimeUpDown);
            this.AlgorithmTypePanel.Controls.Add(this.AlphabetaCheckBox);
            this.AlgorithmTypePanel.Controls.Add(this.DepthLabel);
            this.AlgorithmTypePanel.Controls.Add(this.DepthUpDown);
            this.AlgorithmTypePanel.Controls.Add(this.MCTSRadioButton);
            this.AlgorithmTypePanel.Controls.Add(this.MinimaxRadioButton);
            this.AlgorithmTypePanel.Location = new System.Drawing.Point(337, 49);
            this.AlgorithmTypePanel.Name = "AlgorithmTypePanel";
            this.AlgorithmTypePanel.Size = new System.Drawing.Size(216, 121);
            this.AlgorithmTypePanel.TabIndex = 48;
            this.AlgorithmTypePanel.Visible = false;
            // 
            // MCTSTimeLabel
            // 
            this.MCTSTimeLabel.AutoSize = true;
            this.MCTSTimeLabel.Location = new System.Drawing.Point(10, 91);
            this.MCTSTimeLabel.Name = "MCTSTimeLabel";
            this.MCTSTimeLabel.Size = new System.Drawing.Size(128, 13);
            this.MCTSTimeLabel.TabIndex = 52;
            this.MCTSTimeLabel.Text = "Čas prohledávání stromu:";
            this.MCTSTimeLabel.Visible = false;
            // 
            // MCTSTimeUpDown
            // 
            this.MCTSTimeUpDown.Location = new System.Drawing.Point(141, 89);
            this.MCTSTimeUpDown.Name = "MCTSTimeUpDown";
            this.MCTSTimeUpDown.Size = new System.Drawing.Size(32, 20);
            this.MCTSTimeUpDown.TabIndex = 50;
            this.MCTSTimeUpDown.Visible = false;
            // 
            // AlphabetaCheckBox
            // 
            this.AlphabetaCheckBox.AutoSize = true;
            this.AlphabetaCheckBox.Location = new System.Drawing.Point(12, 42);
            this.AlphabetaCheckBox.Name = "AlphabetaCheckBox";
            this.AlphabetaCheckBox.Size = new System.Drawing.Size(138, 17);
            this.AlphabetaCheckBox.TabIndex = 51;
            this.AlphabetaCheckBox.Text = "Alpha-beta prořezávání";
            this.AlphabetaCheckBox.UseVisualStyleBackColor = true;
            // 
            // DepthLabel
            // 
            this.DepthLabel.AutoSize = true;
            this.DepthLabel.Location = new System.Drawing.Point(9, 23);
            this.DepthLabel.Name = "DepthLabel";
            this.DepthLabel.Size = new System.Drawing.Size(162, 13);
            this.DepthLabel.TabIndex = 50;
            this.DepthLabel.Text = "Hloubka prohledávacího stromu:";
            // 
            // DepthUpDown
            // 
            this.DepthUpDown.Location = new System.Drawing.Point(179, 21);
            this.DepthUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.DepthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DepthUpDown.Name = "DepthUpDown";
            this.DepthUpDown.Size = new System.Drawing.Size(29, 20);
            this.DepthUpDown.TabIndex = 50;
            this.DepthUpDown.TabStop = false;
            this.DepthUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MCTSRadioButton
            // 
            this.MCTSRadioButton.AutoSize = true;
            this.MCTSRadioButton.Location = new System.Drawing.Point(0, 68);
            this.MCTSRadioButton.Name = "MCTSRadioButton";
            this.MCTSRadioButton.Size = new System.Drawing.Size(144, 17);
            this.MCTSRadioButton.TabIndex = 1;
            this.MCTSRadioButton.Text = "Monte Carlo Tree Search";
            this.MCTSRadioButton.UseVisualStyleBackColor = true;
            this.MCTSRadioButton.CheckedChanged += new System.EventHandler(this.MCTSRadioButton_CheckedChanged);
            // 
            // MinimaxRadioButton
            // 
            this.MinimaxRadioButton.AutoSize = true;
            this.MinimaxRadioButton.Checked = true;
            this.MinimaxRadioButton.Location = new System.Drawing.Point(0, 3);
            this.MinimaxRadioButton.Name = "MinimaxRadioButton";
            this.MinimaxRadioButton.Size = new System.Drawing.Size(63, 17);
            this.MinimaxRadioButton.TabIndex = 0;
            this.MinimaxRadioButton.TabStop = true;
            this.MinimaxRadioButton.Text = "Minimax";
            this.MinimaxRadioButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MinimaxRadioButton.UseVisualStyleBackColor = true;
            this.MinimaxRadioButton.CheckedChanged += new System.EventHandler(this.MinimaxRadioButton_CheckedChanged);
            // 
            // PlayerTypePanel
            // 
            this.PlayerTypePanel.Controls.Add(this.OKbutton);
            this.PlayerTypePanel.Controls.Add(this.AlgorithmTypePanel);
            this.PlayerTypePanel.Controls.Add(this.SingleplayerRadioButton);
            this.PlayerTypePanel.Controls.Add(this.MultiplayerRadioButton);
            this.PlayerTypePanel.Location = new System.Drawing.Point(49, 111);
            this.PlayerTypePanel.Name = "PlayerTypePanel";
            this.PlayerTypePanel.Size = new System.Drawing.Size(616, 228);
            this.PlayerTypePanel.TabIndex = 49;
            this.PlayerTypePanel.Visible = false;
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(262, 175);
            this.OKbutton.Margin = new System.Windows.Forms.Padding(2);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(79, 44);
            this.OKbutton.TabIndex = 50;
            this.OKbutton.TabStop = false;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Visible = false;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // SingleplayerRadioButton
            // 
            this.SingleplayerRadioButton.AutoSize = true;
            this.SingleplayerRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SingleplayerRadioButton.Location = new System.Drawing.Point(337, 26);
            this.SingleplayerRadioButton.Name = "SingleplayerRadioButton";
            this.SingleplayerRadioButton.Size = new System.Drawing.Size(95, 17);
            this.SingleplayerRadioButton.TabIndex = 1;
            this.SingleplayerRadioButton.Text = "SinglePlayer";
            this.SingleplayerRadioButton.UseVisualStyleBackColor = true;
            this.SingleplayerRadioButton.CheckedChanged += new System.EventHandler(this.SingleplayerRadioButton_CheckedChanged);
            // 
            // MultiplayerRadioButton
            // 
            this.MultiplayerRadioButton.AutoSize = true;
            this.MultiplayerRadioButton.Checked = true;
            this.MultiplayerRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MultiplayerRadioButton.Location = new System.Drawing.Point(26, 21);
            this.MultiplayerRadioButton.Name = "MultiplayerRadioButton";
            this.MultiplayerRadioButton.Size = new System.Drawing.Size(86, 17);
            this.MultiplayerRadioButton.TabIndex = 0;
            this.MultiplayerRadioButton.TabStop = true;
            this.MultiplayerRadioButton.Text = "Multiplayer";
            this.MultiplayerRadioButton.UseVisualStyleBackColor = true;
            this.MultiplayerRadioButton.CheckedChanged += new System.EventHandler(this.MultiplayerRadioButton_CheckedChanged);
            // 
            // MainGameWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(745, 596);
            this.Controls.Add(this.SelectMinishogiButton);
            this.Controls.Add(this.SelectAlmostChessButton);
            this.Controls.Add(this.SelectCrazyhouseButton);
            this.Controls.Add(this.SelectInternationalCheckersButton);
            this.Controls.Add(this.SelectBlackHordeChessButton);
            this.Controls.Add(this.SelectWhiteHordeChessButton);
            this.Controls.Add(this.SelectChess960Button);
            this.Controls.Add(this.NewGameInstanceButton);
            this.Controls.Add(this.LoadGameButton);
            this.Controls.Add(this.CustomLabel);
            this.Controls.Add(this.CustomGameChooseErrorLabel);
            this.Controls.Add(this.CustomGameChooseLabel);
            this.Controls.Add(this.CustomGameChooseCombobox);
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
            this.Controls.Add(this.AboutGameButton);
            this.Controls.Add(this.SelectCustomGameButton);
            this.Controls.Add(this.SelectShogiButton);
            this.Controls.Add(this.SelectCheckersButton);
            this.Controls.Add(this.SelectChessButton);
            this.Controls.Add(this.PlayerTypePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainGameWindow";
            this.Text = "Obecné hry na šachovnici";
            this.AlgorithmTypePanel.ResumeLayout(false);
            this.AlgorithmTypePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MCTSTimeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepthUpDown)).EndInit();
            this.PlayerTypePanel.ResumeLayout(false);
            this.PlayerTypePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectChessButton;
        private System.Windows.Forms.Button SelectCheckersButton;
        private System.Windows.Forms.Button SelectShogiButton;
        private System.Windows.Forms.Button SelectCustomGameButton;
        private System.Windows.Forms.Button AboutGameButton;
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
        private System.Windows.Forms.ComboBox CustomGameChooseCombobox;
        private System.Windows.Forms.Label CustomGameChooseLabel;
        private System.Windows.Forms.Label CustomGameChooseErrorLabel;
        private System.Windows.Forms.Label CustomLabel;
        private System.Windows.Forms.Button LoadGameButton;
        private System.Windows.Forms.OpenFileDialog LoadCustomGameDialog;
        private System.Windows.Forms.Button NewGameInstanceButton;
        private System.Windows.Forms.Button SelectBlackHordeChessButton;
        private System.Windows.Forms.Button SelectWhiteHordeChessButton;
        private System.Windows.Forms.Button SelectChess960Button;
        private System.Windows.Forms.Button SelectAlmostChessButton;
        private System.Windows.Forms.Button SelectCrazyhouseButton;
        private System.Windows.Forms.Button SelectInternationalCheckersButton;
        private System.Windows.Forms.Button SelectMinishogiButton;
        private System.Windows.Forms.Panel AlgorithmTypePanel;
        private System.Windows.Forms.RadioButton MCTSRadioButton;
        private System.Windows.Forms.RadioButton MinimaxRadioButton;
        private System.Windows.Forms.Panel PlayerTypePanel;
        private System.Windows.Forms.RadioButton SingleplayerRadioButton;
        private System.Windows.Forms.RadioButton MultiplayerRadioButton;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.NumericUpDown DepthUpDown;
        private System.Windows.Forms.Label DepthLabel;
        private System.Windows.Forms.CheckBox AlphabetaCheckBox;
        private System.Windows.Forms.Label MCTSTimeLabel;
        private System.Windows.Forms.NumericUpDown MCTSTimeUpDown;
    }
}

