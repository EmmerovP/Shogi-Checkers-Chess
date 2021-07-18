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
            this.ChooseShogiBottomBox = new System.Windows.Forms.ComboBox();
            this.ChooseShogiBottomLabel = new System.Windows.Forms.Label();
            this.ChooseShogiBottomButton = new System.Windows.Forms.Button();
            this.PutShogiPieceBottomLabel = new System.Windows.Forms.Label();
            this.PutShogiPieceUpperLabel = new System.Windows.Forms.Label();
            this.ChooseShogiUpperButton = new System.Windows.Forms.Button();
            this.ChooseShogiUpperLabel = new System.Windows.Forms.Label();
            this.ChooseShogiBoxUpper = new System.Windows.Forms.ComboBox();
            this.CustomGameSizeLabel = new System.Windows.Forms.Label();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.CustomGameSizeXLabel = new System.Windows.Forms.Label();
            this.CustomGameSizeYLabel = new System.Windows.Forms.Label();
            this.CustomGameSizeButton = new System.Windows.Forms.Button();
            this.CustomGameChooseCombobox = new System.Windows.Forms.ComboBox();
            this.CustomGameChooseLabel = new System.Windows.Forms.Label();
            this.CustomGameChooseErrorLabel = new System.Windows.Forms.Label();
            this.LoadGameButton = new System.Windows.Forms.Button();
            this.LoadCustomGameDialog = new System.Windows.Forms.OpenFileDialog();
            this.NewGameInstanceButton = new System.Windows.Forms.Button();
            this.SelectBlackHordeChessButton = new System.Windows.Forms.Button();
            this.SelectWhiteHordeChessButton = new System.Windows.Forms.Button();
            this.SelectChess960Button = new System.Windows.Forms.Button();
            this.SelectAlmostChessButton = new System.Windows.Forms.Button();
            this.SelectCrazyhouseButton = new System.Windows.Forms.Button();
            this.SelectReallyBadChessButton = new System.Windows.Forms.Button();
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
            this.AboutGamesButton = new System.Windows.Forms.Button();
            this.SetGamePropertiesPanel = new System.Windows.Forms.Panel();
            this.GameParametersButton = new System.Windows.Forms.Button();
            this.BottomSpecialActionsLabel = new System.Windows.Forms.Label();
            this.BottomEndGameLabel = new System.Windows.Forms.Label();
            this.UpperSpecialActionsLabel = new System.Windows.Forms.Label();
            this.UpperEndGameLabel = new System.Windows.Forms.Label();
            this.WhiteBottomLabel = new System.Windows.Forms.Label();
            this.BaclUpperLabel = new System.Windows.Forms.Label();
            this.SelectRulesLabel = new System.Windows.Forms.Label();
            this.BottomSpecialActionsComboBox = new System.Windows.Forms.ComboBox();
            this.BottomEndgameComboBox = new System.Windows.Forms.ComboBox();
            this.UpperSpecialActionsComboBox = new System.Windows.Forms.ComboBox();
            this.UpperEndgameComboBox = new System.Windows.Forms.ComboBox();
            this.AlgorithmTypePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MCTSTimeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepthUpDown)).BeginInit();
            this.PlayerTypePanel.SuspendLayout();
            this.SetGamePropertiesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectChessButton
            // 
            this.SelectChessButton.Location = new System.Drawing.Point(181, 106);
            this.SelectChessButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectChessButton.Name = "SelectChessButton";
            this.SelectChessButton.Size = new System.Drawing.Size(76, 44);
            this.SelectChessButton.TabIndex = 3;
            this.SelectChessButton.Text = "Šachy";
            this.SelectChessButton.UseVisualStyleBackColor = true;
            this.SelectChessButton.Click += new System.EventHandler(this.SelectChessButton_Click);
            // 
            // SelectCheckersButton
            // 
            this.SelectCheckersButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SelectCheckersButton.Location = new System.Drawing.Point(238, 254);
            this.SelectCheckersButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectCheckersButton.Name = "SelectCheckersButton";
            this.SelectCheckersButton.Size = new System.Drawing.Size(79, 44);
            this.SelectCheckersButton.TabIndex = 9;
            this.SelectCheckersButton.Text = "Česká dáma";
            this.SelectCheckersButton.UseVisualStyleBackColor = true;
            this.SelectCheckersButton.Click += new System.EventHandler(this.SelectCheckersButton_Click);
            // 
            // SelectShogiButton
            // 
            this.SelectShogiButton.Location = new System.Drawing.Point(242, 332);
            this.SelectShogiButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectShogiButton.Name = "SelectShogiButton";
            this.SelectShogiButton.Size = new System.Drawing.Size(79, 44);
            this.SelectShogiButton.TabIndex = 11;
            this.SelectShogiButton.Text = "Šogi";
            this.SelectShogiButton.UseVisualStyleBackColor = true;
            this.SelectShogiButton.Click += new System.EventHandler(this.SelectShogiButton_Click);
            // 
            // SelectCustomGameButton
            // 
            this.SelectCustomGameButton.Location = new System.Drawing.Point(243, 28);
            this.SelectCustomGameButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectCustomGameButton.Name = "SelectCustomGameButton";
            this.SelectCustomGameButton.Size = new System.Drawing.Size(79, 49);
            this.SelectCustomGameButton.TabIndex = 1;
            this.SelectCustomGameButton.Text = "Vlastní hra";
            this.SelectCustomGameButton.UseVisualStyleBackColor = true;
            this.SelectCustomGameButton.Click += new System.EventHandler(this.SelectCustomGameButton_Click);
            // 
            // AboutGameButton
            // 
            this.AboutGameButton.Location = new System.Drawing.Point(295, 415);
            this.AboutGameButton.Margin = new System.Windows.Forms.Padding(2);
            this.AboutGameButton.Name = "AboutGameButton";
            this.AboutGameButton.Size = new System.Drawing.Size(79, 43);
            this.AboutGameButton.TabIndex = 13;
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
            this.NewGameButton.Location = new System.Drawing.Point(580, 62);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(99, 48);
            this.NewGameButton.TabIndex = 12;
            this.NewGameButton.TabStop = false;
            this.NewGameButton.Text = "Hrát";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.Visible = false;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // ChooseShogiBottomBox
            // 
            this.ChooseShogiBottomBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChooseShogiBottomBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChooseShogiBottomBox.FormattingEnabled = true;
            this.ChooseShogiBottomBox.Location = new System.Drawing.Point(579, 248);
            this.ChooseShogiBottomBox.Name = "ChooseShogiBottomBox";
            this.ChooseShogiBottomBox.Size = new System.Drawing.Size(120, 21);
            this.ChooseShogiBottomBox.TabIndex = 13;
            this.ChooseShogiBottomBox.Visible = false;
            // 
            // ChooseShogiBottomLabel
            // 
            this.ChooseShogiBottomLabel.AutoSize = true;
            this.ChooseShogiBottomLabel.Location = new System.Drawing.Point(576, 219);
            this.ChooseShogiBottomLabel.Name = "ChooseShogiBottomLabel";
            this.ChooseShogiBottomLabel.Size = new System.Drawing.Size(109, 13);
            this.ChooseShogiBottomLabel.TabIndex = 14;
            this.ChooseShogiBottomLabel.Text = "Nebo vyberte figurku:";
            this.ChooseShogiBottomLabel.Visible = false;
            // 
            // ChooseShogiBottomButton
            // 
            this.ChooseShogiBottomButton.Location = new System.Drawing.Point(579, 288);
            this.ChooseShogiBottomButton.Name = "ChooseShogiBottomButton";
            this.ChooseShogiBottomButton.Size = new System.Drawing.Size(75, 23);
            this.ChooseShogiBottomButton.TabIndex = 15;
            this.ChooseShogiBottomButton.TabStop = false;
            this.ChooseShogiBottomButton.Text = "Přidat";
            this.ChooseShogiBottomButton.UseVisualStyleBackColor = true;
            this.ChooseShogiBottomButton.Visible = false;
            this.ChooseShogiBottomButton.Click += new System.EventHandler(this.ChooseShogiButtonBottom_Click);
            // 
            // PutShogiPieceBottomLabel
            // 
            this.PutShogiPieceBottomLabel.Location = new System.Drawing.Point(576, 328);
            this.PutShogiPieceBottomLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PutShogiPieceBottomLabel.Name = "PutShogiPieceBottomLabel";
            this.PutShogiPieceBottomLabel.Size = new System.Drawing.Size(118, 48);
            this.PutShogiPieceBottomLabel.TabIndex = 16;
            this.PutShogiPieceBottomLabel.Text = "Klikněte na pole, na které chcete figurku umístit.";
            this.PutShogiPieceBottomLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PutShogiPieceBottomLabel.Visible = false;
            // 
            // PutShogiPieceUpperLabel
            // 
            this.PutShogiPieceUpperLabel.Location = new System.Drawing.Point(574, 157);
            this.PutShogiPieceUpperLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PutShogiPieceUpperLabel.Name = "PutShogiPieceUpperLabel";
            this.PutShogiPieceUpperLabel.Size = new System.Drawing.Size(118, 48);
            this.PutShogiPieceUpperLabel.TabIndex = 20;
            this.PutShogiPieceUpperLabel.Text = "Klikněte na pole, na které chcete figurku umístit.";
            this.PutShogiPieceUpperLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PutShogiPieceUpperLabel.Visible = false;
            // 
            // ChooseShogiUpperButton
            // 
            this.ChooseShogiUpperButton.Location = new System.Drawing.Point(576, 125);
            this.ChooseShogiUpperButton.Name = "ChooseShogiUpperButton";
            this.ChooseShogiUpperButton.Size = new System.Drawing.Size(75, 23);
            this.ChooseShogiUpperButton.TabIndex = 19;
            this.ChooseShogiUpperButton.TabStop = false;
            this.ChooseShogiUpperButton.Text = "Přidat";
            this.ChooseShogiUpperButton.UseVisualStyleBackColor = true;
            this.ChooseShogiUpperButton.Visible = false;
            this.ChooseShogiUpperButton.Click += new System.EventHandler(this.ChooseShogiButtonUpper_Click);
            // 
            // ChooseShogiUpperLabel
            // 
            this.ChooseShogiUpperLabel.AutoSize = true;
            this.ChooseShogiUpperLabel.Location = new System.Drawing.Point(573, 50);
            this.ChooseShogiUpperLabel.Name = "ChooseShogiUpperLabel";
            this.ChooseShogiUpperLabel.Size = new System.Drawing.Size(109, 13);
            this.ChooseShogiUpperLabel.TabIndex = 18;
            this.ChooseShogiUpperLabel.Text = "Nebo vyberte figurku:";
            this.ChooseShogiUpperLabel.Visible = false;
            // 
            // ChooseShogiBoxUpper
            // 
            this.ChooseShogiBoxUpper.BackColor = System.Drawing.Color.White;
            this.ChooseShogiBoxUpper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChooseShogiBoxUpper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChooseShogiBoxUpper.FormattingEnabled = true;
            this.ChooseShogiBoxUpper.Location = new System.Drawing.Point(577, 87);
            this.ChooseShogiBoxUpper.Name = "ChooseShogiBoxUpper";
            this.ChooseShogiBoxUpper.Size = new System.Drawing.Size(120, 21);
            this.ChooseShogiBoxUpper.TabIndex = 17;
            this.ChooseShogiBoxUpper.Visible = false;
            // 
            // CustomGameSizeLabel
            // 
            this.CustomGameSizeLabel.AutoSize = true;
            this.CustomGameSizeLabel.Location = new System.Drawing.Point(14, 17);
            this.CustomGameSizeLabel.Name = "CustomGameSizeLabel";
            this.CustomGameSizeLabel.Size = new System.Drawing.Size(316, 13);
            this.CustomGameSizeLabel.TabIndex = 21;
            this.CustomGameSizeLabel.Text = "Nastavte si velikost šachovnice. Hodnotu zadejte jako celé číslo.";
            this.CustomGameSizeLabel.Visible = false;
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(59, 43);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.HeightTextBox.TabIndex = 22;
            this.HeightTextBox.Visible = false;
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(59, 83);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(100, 20);
            this.WidthTextBox.TabIndex = 23;
            this.WidthTextBox.Visible = false;
            // 
            // CustomGameSizeXLabel
            // 
            this.CustomGameSizeXLabel.AutoSize = true;
            this.CustomGameSizeXLabel.Location = new System.Drawing.Point(14, 46);
            this.CustomGameSizeXLabel.Name = "CustomGameSizeXLabel";
            this.CustomGameSizeXLabel.Size = new System.Drawing.Size(39, 13);
            this.CustomGameSizeXLabel.TabIndex = 24;
            this.CustomGameSizeXLabel.Text = "Výška:";
            this.CustomGameSizeXLabel.Visible = false;
            // 
            // CustomGameSizeYLabel
            // 
            this.CustomGameSizeYLabel.AutoSize = true;
            this.CustomGameSizeYLabel.Location = new System.Drawing.Point(14, 83);
            this.CustomGameSizeYLabel.Name = "CustomGameSizeYLabel";
            this.CustomGameSizeYLabel.Size = new System.Drawing.Size(37, 13);
            this.CustomGameSizeYLabel.TabIndex = 25;
            this.CustomGameSizeYLabel.Text = "Šířka:";
            this.CustomGameSizeYLabel.Visible = false;
            // 
            // CustomGameSizeButton
            // 
            this.CustomGameSizeButton.Location = new System.Drawing.Point(70, 125);
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
            this.CustomGameChooseCombobox.DropDownWidth = 120;
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
            this.CustomGameChooseCombobox.Location = new System.Drawing.Point(579, 29);
            this.CustomGameChooseCombobox.Name = "CustomGameChooseCombobox";
            this.CustomGameChooseCombobox.Size = new System.Drawing.Size(121, 21);
            this.CustomGameChooseCombobox.TabIndex = 31;
            this.CustomGameChooseCombobox.Visible = false;
            // 
            // CustomGameChooseLabel
            // 
            this.CustomGameChooseLabel.AutoSize = true;
            this.CustomGameChooseLabel.Location = new System.Drawing.Point(577, 6);
            this.CustomGameChooseLabel.Name = "CustomGameChooseLabel";
            this.CustomGameChooseLabel.Size = new System.Drawing.Size(81, 13);
            this.CustomGameChooseLabel.TabIndex = 32;
            this.CustomGameChooseLabel.Text = "Vyberte figurku:";
            this.CustomGameChooseLabel.Visible = false;
            // 
            // CustomGameChooseErrorLabel
            // 
            this.CustomGameChooseErrorLabel.Location = new System.Drawing.Point(577, 65);
            this.CustomGameChooseErrorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CustomGameChooseErrorLabel.Name = "CustomGameChooseErrorLabel";
            this.CustomGameChooseErrorLabel.Size = new System.Drawing.Size(118, 48);
            this.CustomGameChooseErrorLabel.TabIndex = 34;
            this.CustomGameChooseErrorLabel.Text = "Klikněte na pole, na které chcete figurku umístit.";
            this.CustomGameChooseErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CustomGameChooseErrorLabel.Visible = false;
            // 
            // LoadGameButton
            // 
            this.LoadGameButton.Location = new System.Drawing.Point(349, 28);
            this.LoadGameButton.Margin = new System.Windows.Forms.Padding(2);
            this.LoadGameButton.Name = "LoadGameButton";
            this.LoadGameButton.Size = new System.Drawing.Size(79, 49);
            this.LoadGameButton.TabIndex = 2;
            this.LoadGameButton.Text = "Načíst hru";
            this.LoadGameButton.UseVisualStyleBackColor = true;
            this.LoadGameButton.Click += new System.EventHandler(this.LoadGameButton_Click);
            // 
            // NewGameInstanceButton
            // 
            this.NewGameInstanceButton.Location = new System.Drawing.Point(580, 7);
            this.NewGameInstanceButton.Name = "NewGameInstanceButton";
            this.NewGameInstanceButton.Size = new System.Drawing.Size(106, 32);
            this.NewGameInstanceButton.TabIndex = 50;
            this.NewGameInstanceButton.TabStop = false;
            this.NewGameInstanceButton.Text = "Nová hra";
            this.NewGameInstanceButton.UseVisualStyleBackColor = true;
            this.NewGameInstanceButton.Visible = false;
            this.NewGameInstanceButton.Click += new System.EventHandler(this.NewGameInstanceButton_Click);
            // 
            // SelectBlackHordeChessButton
            // 
            this.SelectBlackHordeChessButton.Location = new System.Drawing.Point(413, 106);
            this.SelectBlackHordeChessButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectBlackHordeChessButton.Name = "SelectBlackHordeChessButton";
            this.SelectBlackHordeChessButton.Size = new System.Drawing.Size(79, 44);
            this.SelectBlackHordeChessButton.TabIndex = 5;
            this.SelectBlackHordeChessButton.Text = "Horde šachy (černá horda)";
            this.SelectBlackHordeChessButton.UseVisualStyleBackColor = true;
            this.SelectBlackHordeChessButton.Click += new System.EventHandler(this.SelectBlackHordeChessButton_Click);
            // 
            // SelectWhiteHordeChessButton
            // 
            this.SelectWhiteHordeChessButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SelectWhiteHordeChessButton.Location = new System.Drawing.Point(295, 106);
            this.SelectWhiteHordeChessButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectWhiteHordeChessButton.Name = "SelectWhiteHordeChessButton";
            this.SelectWhiteHordeChessButton.Size = new System.Drawing.Size(79, 44);
            this.SelectWhiteHordeChessButton.TabIndex = 4;
            this.SelectWhiteHordeChessButton.Text = "Horde šachy (bílá horda)";
            this.SelectWhiteHordeChessButton.UseVisualStyleBackColor = true;
            this.SelectWhiteHordeChessButton.Click += new System.EventHandler(this.SelectWhiteHordeChessButton_Click);
            // 
            // SelectChess960Button
            // 
            this.SelectChess960Button.Location = new System.Drawing.Point(181, 183);
            this.SelectChess960Button.Margin = new System.Windows.Forms.Padding(2);
            this.SelectChess960Button.Name = "SelectChess960Button";
            this.SelectChess960Button.Size = new System.Drawing.Size(76, 44);
            this.SelectChess960Button.TabIndex = 6;
            this.SelectChess960Button.Text = "Chess960";
            this.SelectChess960Button.UseVisualStyleBackColor = true;
            this.SelectChess960Button.Click += new System.EventHandler(this.SelectChess960Button_Click);
            // 
            // SelectAlmostChessButton
            // 
            this.SelectAlmostChessButton.Location = new System.Drawing.Point(413, 183);
            this.SelectAlmostChessButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectAlmostChessButton.Name = "SelectAlmostChessButton";
            this.SelectAlmostChessButton.Size = new System.Drawing.Size(79, 44);
            this.SelectAlmostChessButton.TabIndex = 8;
            this.SelectAlmostChessButton.Text = "Skorošachy";
            this.SelectAlmostChessButton.UseVisualStyleBackColor = true;
            this.SelectAlmostChessButton.Click += new System.EventHandler(this.SelectAlmostChessButton_Click);
            // 
            // SelectCrazyhouseButton
            // 
            this.SelectCrazyhouseButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SelectCrazyhouseButton.Location = new System.Drawing.Point(295, 183);
            this.SelectCrazyhouseButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectCrazyhouseButton.Name = "SelectCrazyhouseButton";
            this.SelectCrazyhouseButton.Size = new System.Drawing.Size(79, 44);
            this.SelectCrazyhouseButton.TabIndex = 7;
            this.SelectCrazyhouseButton.Text = "Crazyhouse";
            this.SelectCrazyhouseButton.UseVisualStyleBackColor = true;
            this.SelectCrazyhouseButton.Click += new System.EventHandler(this.SelectCrazyhouseButton_Click);
            // 
            // SelectReallyBadChessButton
            // 
            this.SelectReallyBadChessButton.Location = new System.Drawing.Point(356, 254);
            this.SelectReallyBadChessButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectReallyBadChessButton.Name = "SelectReallyBadChessButton";
            this.SelectReallyBadChessButton.Size = new System.Drawing.Size(76, 44);
            this.SelectReallyBadChessButton.TabIndex = 10;
            this.SelectReallyBadChessButton.Text = "Fakt špatné šachy";
            this.SelectReallyBadChessButton.UseVisualStyleBackColor = true;
            this.SelectReallyBadChessButton.Click += new System.EventHandler(this.SelectReallyBadChessButton_Click);
            // 
            // SelectMinishogiButton
            // 
            this.SelectMinishogiButton.Location = new System.Drawing.Point(356, 332);
            this.SelectMinishogiButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectMinishogiButton.Name = "SelectMinishogiButton";
            this.SelectMinishogiButton.Size = new System.Drawing.Size(79, 44);
            this.SelectMinishogiButton.TabIndex = 12;
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
            this.AlgorithmTypePanel.Location = new System.Drawing.Point(5, 53);
            this.AlgorithmTypePanel.Name = "AlgorithmTypePanel";
            this.AlgorithmTypePanel.Size = new System.Drawing.Size(295, 121);
            this.AlgorithmTypePanel.TabIndex = 48;
            this.AlgorithmTypePanel.Visible = false;
            // 
            // MCTSTimeLabel
            // 
            this.MCTSTimeLabel.AutoSize = true;
            this.MCTSTimeLabel.Location = new System.Drawing.Point(9, 91);
            this.MCTSTimeLabel.Name = "MCTSTimeLabel";
            this.MCTSTimeLabel.Size = new System.Drawing.Size(193, 13);
            this.MCTSTimeLabel.TabIndex = 52;
            this.MCTSTimeLabel.Text = "Čas prohledávání stromu v sekundách:";
            this.MCTSTimeLabel.Visible = false;
            // 
            // MCTSTimeUpDown
            // 
            this.MCTSTimeUpDown.Location = new System.Drawing.Point(208, 89);
            this.MCTSTimeUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.MCTSTimeUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MCTSTimeUpDown.Name = "MCTSTimeUpDown";
            this.MCTSTimeUpDown.Size = new System.Drawing.Size(32, 20);
            this.MCTSTimeUpDown.TabIndex = 50;
            this.MCTSTimeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.DepthUpDown.Location = new System.Drawing.Point(173, 21);
            this.DepthUpDown.Maximum = new decimal(new int[] {
            5,
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
            this.PlayerTypePanel.Location = new System.Drawing.Point(219, 117);
            this.PlayerTypePanel.Name = "PlayerTypePanel";
            this.PlayerTypePanel.Size = new System.Drawing.Size(305, 228);
            this.PlayerTypePanel.TabIndex = 49;
            this.PlayerTypePanel.Visible = false;
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(76, 179);
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
            this.SingleplayerRadioButton.Location = new System.Drawing.Point(5, 30);
            this.SingleplayerRadioButton.Name = "SingleplayerRadioButton";
            this.SingleplayerRadioButton.Size = new System.Drawing.Size(95, 17);
            this.SingleplayerRadioButton.TabIndex = 1;
            this.SingleplayerRadioButton.TabStop = true;
            this.SingleplayerRadioButton.Text = "SinglePlayer";
            this.SingleplayerRadioButton.UseVisualStyleBackColor = true;
            this.SingleplayerRadioButton.CheckedChanged += new System.EventHandler(this.SingleplayerRadioButton_CheckedChanged);
            // 
            // MultiplayerRadioButton
            // 
            this.MultiplayerRadioButton.AutoSize = true;
            this.MultiplayerRadioButton.Checked = true;
            this.MultiplayerRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MultiplayerRadioButton.Location = new System.Drawing.Point(5, 9);
            this.MultiplayerRadioButton.Name = "MultiplayerRadioButton";
            this.MultiplayerRadioButton.Size = new System.Drawing.Size(86, 17);
            this.MultiplayerRadioButton.TabIndex = 0;
            this.MultiplayerRadioButton.TabStop = true;
            this.MultiplayerRadioButton.Text = "Multiplayer";
            this.MultiplayerRadioButton.UseVisualStyleBackColor = true;
            this.MultiplayerRadioButton.CheckedChanged += new System.EventHandler(this.MultiplayerRadioButton_CheckedChanged);
            // 
            // AboutGamesButton
            // 
            this.AboutGamesButton.Location = new System.Drawing.Point(295, 489);
            this.AboutGamesButton.Margin = new System.Windows.Forms.Padding(2);
            this.AboutGamesButton.Name = "AboutGamesButton";
            this.AboutGamesButton.Size = new System.Drawing.Size(79, 43);
            this.AboutGamesButton.TabIndex = 14;
            this.AboutGamesButton.Text = "O hrách";
            this.AboutGamesButton.UseVisualStyleBackColor = true;
            this.AboutGamesButton.Click += new System.EventHandler(this.AboutGamesButton_Click);
            // 
            // SetGamePropertiesPanel
            // 
            this.SetGamePropertiesPanel.Controls.Add(this.GameParametersButton);
            this.SetGamePropertiesPanel.Controls.Add(this.BottomSpecialActionsLabel);
            this.SetGamePropertiesPanel.Controls.Add(this.BottomEndGameLabel);
            this.SetGamePropertiesPanel.Controls.Add(this.UpperSpecialActionsLabel);
            this.SetGamePropertiesPanel.Controls.Add(this.UpperEndGameLabel);
            this.SetGamePropertiesPanel.Controls.Add(this.WhiteBottomLabel);
            this.SetGamePropertiesPanel.Controls.Add(this.BaclUpperLabel);
            this.SetGamePropertiesPanel.Controls.Add(this.SelectRulesLabel);
            this.SetGamePropertiesPanel.Controls.Add(this.BottomSpecialActionsComboBox);
            this.SetGamePropertiesPanel.Controls.Add(this.BottomEndgameComboBox);
            this.SetGamePropertiesPanel.Controls.Add(this.UpperSpecialActionsComboBox);
            this.SetGamePropertiesPanel.Controls.Add(this.UpperEndgameComboBox);
            this.SetGamePropertiesPanel.Location = new System.Drawing.Point(12, 7);
            this.SetGamePropertiesPanel.Name = "SetGamePropertiesPanel";
            this.SetGamePropertiesPanel.Size = new System.Drawing.Size(218, 323);
            this.SetGamePropertiesPanel.TabIndex = 51;
            this.SetGamePropertiesPanel.Visible = false;
            // 
            // GameParametersButton
            // 
            this.GameParametersButton.Location = new System.Drawing.Point(47, 279);
            this.GameParametersButton.Name = "GameParametersButton";
            this.GameParametersButton.Size = new System.Drawing.Size(75, 23);
            this.GameParametersButton.TabIndex = 52;
            this.GameParametersButton.TabStop = false;
            this.GameParametersButton.Text = "OK";
            this.GameParametersButton.UseVisualStyleBackColor = true;
            this.GameParametersButton.Click += new System.EventHandler(this.GameParametersButton_Click);
            // 
            // BottomSpecialActionsLabel
            // 
            this.BottomSpecialActionsLabel.AutoSize = true;
            this.BottomSpecialActionsLabel.Location = new System.Drawing.Point(12, 222);
            this.BottomSpecialActionsLabel.Name = "BottomSpecialActionsLabel";
            this.BottomSpecialActionsLabel.Size = new System.Drawing.Size(82, 13);
            this.BottomSpecialActionsLabel.TabIndex = 60;
            this.BottomSpecialActionsLabel.Text = "Speciální akce:";
            // 
            // BottomEndGameLabel
            // 
            this.BottomEndGameLabel.AutoSize = true;
            this.BottomEndGameLabel.Location = new System.Drawing.Point(12, 177);
            this.BottomEndGameLabel.Name = "BottomEndGameLabel";
            this.BottomEndGameLabel.Size = new System.Drawing.Size(58, 13);
            this.BottomEndGameLabel.TabIndex = 59;
            this.BottomEndGameLabel.Text = "Konec hry:";
            // 
            // UpperSpecialActionsLabel
            // 
            this.UpperSpecialActionsLabel.AutoSize = true;
            this.UpperSpecialActionsLabel.Location = new System.Drawing.Point(12, 102);
            this.UpperSpecialActionsLabel.Name = "UpperSpecialActionsLabel";
            this.UpperSpecialActionsLabel.Size = new System.Drawing.Size(82, 13);
            this.UpperSpecialActionsLabel.TabIndex = 58;
            this.UpperSpecialActionsLabel.Text = "Speciální akce:";
            // 
            // UpperEndGameLabel
            // 
            this.UpperEndGameLabel.AutoSize = true;
            this.UpperEndGameLabel.Location = new System.Drawing.Point(11, 55);
            this.UpperEndGameLabel.Name = "UpperEndGameLabel";
            this.UpperEndGameLabel.Size = new System.Drawing.Size(58, 13);
            this.UpperEndGameLabel.TabIndex = 57;
            this.UpperEndGameLabel.Text = "Konec hry:";
            // 
            // WhiteBottomLabel
            // 
            this.WhiteBottomLabel.AutoSize = true;
            this.WhiteBottomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhiteBottomLabel.Location = new System.Drawing.Point(12, 158);
            this.WhiteBottomLabel.Name = "WhiteBottomLabel";
            this.WhiteBottomLabel.Size = new System.Drawing.Size(122, 13);
            this.WhiteBottomLabel.TabIndex = 56;
            this.WhiteBottomLabel.Text = "Bílá/spodní strana::";
            // 
            // BaclUpperLabel
            // 
            this.BaclUpperLabel.AutoSize = true;
            this.BaclUpperLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaclUpperLabel.Location = new System.Drawing.Point(12, 42);
            this.BaclUpperLabel.Name = "BaclUpperLabel";
            this.BaclUpperLabel.Size = new System.Drawing.Size(126, 13);
            this.BaclUpperLabel.TabIndex = 52;
            this.BaclUpperLabel.Text = "Černá/vrchní strana:";
            // 
            // SelectRulesLabel
            // 
            this.SelectRulesLabel.AutoSize = true;
            this.SelectRulesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectRulesLabel.Location = new System.Drawing.Point(30, 12);
            this.SelectRulesLabel.Name = "SelectRulesLabel";
            this.SelectRulesLabel.Size = new System.Drawing.Size(117, 13);
            this.SelectRulesLabel.TabIndex = 52;
            this.SelectRulesLabel.Text = "Zvolte pravidla hry:";
            // 
            // BottomSpecialActionsComboBox
            // 
            this.BottomSpecialActionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BottomSpecialActionsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BottomSpecialActionsComboBox.FormattingEnabled = true;
            this.BottomSpecialActionsComboBox.Items.AddRange(new object[] {
            "Žádná",
            "Přidávání vyhozených figur zpět do hry",
            "Nutnost sebrat figurku, je-li to možné"});
            this.BottomSpecialActionsComboBox.Location = new System.Drawing.Point(14, 238);
            this.BottomSpecialActionsComboBox.Name = "BottomSpecialActionsComboBox";
            this.BottomSpecialActionsComboBox.Size = new System.Drawing.Size(191, 21);
            this.BottomSpecialActionsComboBox.TabIndex = 55;
            // 
            // BottomEndgameComboBox
            // 
            this.BottomEndgameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BottomEndgameComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BottomEndgameComboBox.FormattingEnabled = true;
            this.BottomEndgameComboBox.Items.AddRange(new object[] {
            "Šach mat krále (šachy)",
            "Sebrání krále (shogi)",
            "Nemožnost tahu"});
            this.BottomEndgameComboBox.Location = new System.Drawing.Point(14, 193);
            this.BottomEndgameComboBox.Name = "BottomEndgameComboBox";
            this.BottomEndgameComboBox.Size = new System.Drawing.Size(191, 21);
            this.BottomEndgameComboBox.TabIndex = 54;
            // 
            // UpperSpecialActionsComboBox
            // 
            this.UpperSpecialActionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UpperSpecialActionsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpperSpecialActionsComboBox.FormattingEnabled = true;
            this.UpperSpecialActionsComboBox.Items.AddRange(new object[] {
            "Žádná",
            "Přidávání vyhozených figur zpět do hry",
            "Nutnost sebrat figurku, je-li to možné"});
            this.UpperSpecialActionsComboBox.Location = new System.Drawing.Point(14, 118);
            this.UpperSpecialActionsComboBox.Name = "UpperSpecialActionsComboBox";
            this.UpperSpecialActionsComboBox.Size = new System.Drawing.Size(191, 21);
            this.UpperSpecialActionsComboBox.TabIndex = 53;
            // 
            // UpperEndgameComboBox
            // 
            this.UpperEndgameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UpperEndgameComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpperEndgameComboBox.FormattingEnabled = true;
            this.UpperEndgameComboBox.Items.AddRange(new object[] {
            "Šach mat krále (šachy)",
            "Sebrání krále (shogi)",
            "Nemožnost tahu"});
            this.UpperEndgameComboBox.Location = new System.Drawing.Point(14, 73);
            this.UpperEndgameComboBox.Name = "UpperEndgameComboBox";
            this.UpperEndgameComboBox.Size = new System.Drawing.Size(191, 21);
            this.UpperEndgameComboBox.TabIndex = 52;
            // 
            // MainGameWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.Controls.Add(this.SetGamePropertiesPanel);
            this.Controls.Add(this.AboutGamesButton);
            this.Controls.Add(this.SelectMinishogiButton);
            this.Controls.Add(this.SelectAlmostChessButton);
            this.Controls.Add(this.SelectCrazyhouseButton);
            this.Controls.Add(this.SelectReallyBadChessButton);
            this.Controls.Add(this.SelectBlackHordeChessButton);
            this.Controls.Add(this.SelectWhiteHordeChessButton);
            this.Controls.Add(this.SelectChess960Button);
            this.Controls.Add(this.NewGameInstanceButton);
            this.Controls.Add(this.LoadGameButton);
            this.Controls.Add(this.CustomGameChooseErrorLabel);
            this.Controls.Add(this.CustomGameChooseLabel);
            this.Controls.Add(this.CustomGameChooseCombobox);
            this.Controls.Add(this.CustomGameSizeButton);
            this.Controls.Add(this.CustomGameSizeYLabel);
            this.Controls.Add(this.CustomGameSizeXLabel);
            this.Controls.Add(this.WidthTextBox);
            this.Controls.Add(this.HeightTextBox);
            this.Controls.Add(this.CustomGameSizeLabel);
            this.Controls.Add(this.PutShogiPieceUpperLabel);
            this.Controls.Add(this.ChooseShogiUpperButton);
            this.Controls.Add(this.ChooseShogiUpperLabel);
            this.Controls.Add(this.ChooseShogiBoxUpper);
            this.Controls.Add(this.PutShogiPieceBottomLabel);
            this.Controls.Add(this.ChooseShogiBottomButton);
            this.Controls.Add(this.ChooseShogiBottomLabel);
            this.Controls.Add(this.ChooseShogiBottomBox);
            this.Controls.Add(this.NewGameButton);
            this.Controls.Add(this.GameStateLabel);
            this.Controls.Add(this.AboutGameButton);
            this.Controls.Add(this.SelectCustomGameButton);
            this.Controls.Add(this.SelectShogiButton);
            this.Controls.Add(this.SelectCheckersButton);
            this.Controls.Add(this.SelectChessButton);
            this.Controls.Add(this.PlayerTypePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainGameWindow";
            this.Text = "Obecné hry na šachovnici";
            this.AlgorithmTypePanel.ResumeLayout(false);
            this.AlgorithmTypePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MCTSTimeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepthUpDown)).EndInit();
            this.PlayerTypePanel.ResumeLayout(false);
            this.PlayerTypePanel.PerformLayout();
            this.SetGamePropertiesPanel.ResumeLayout(false);
            this.SetGamePropertiesPanel.PerformLayout();
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
        private System.Windows.Forms.ComboBox ChooseShogiBottomBox;
        private System.Windows.Forms.Label ChooseShogiBottomLabel;
        private System.Windows.Forms.Button ChooseShogiBottomButton;
        private System.Windows.Forms.Label PutShogiPieceBottomLabel;
        private System.Windows.Forms.Label PutShogiPieceUpperLabel;
        private System.Windows.Forms.Button ChooseShogiUpperButton;
        private System.Windows.Forms.Label ChooseShogiUpperLabel;
        private System.Windows.Forms.ComboBox ChooseShogiBoxUpper;
        private System.Windows.Forms.Label CustomGameSizeLabel;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.Label CustomGameSizeXLabel;
        private System.Windows.Forms.Label CustomGameSizeYLabel;
        private System.Windows.Forms.Button CustomGameSizeButton;
        private System.Windows.Forms.ComboBox CustomGameChooseCombobox;
        private System.Windows.Forms.Label CustomGameChooseLabel;
        private System.Windows.Forms.Label CustomGameChooseErrorLabel;
        private System.Windows.Forms.Button LoadGameButton;
        private System.Windows.Forms.OpenFileDialog LoadCustomGameDialog;
        private System.Windows.Forms.Button NewGameInstanceButton;
        private System.Windows.Forms.Button SelectBlackHordeChessButton;
        private System.Windows.Forms.Button SelectWhiteHordeChessButton;
        private System.Windows.Forms.Button SelectChess960Button;
        private System.Windows.Forms.Button SelectAlmostChessButton;
        private System.Windows.Forms.Button SelectCrazyhouseButton;
        private System.Windows.Forms.Button SelectReallyBadChessButton;
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
        private System.Windows.Forms.Button AboutGamesButton;
        private System.Windows.Forms.Panel SetGamePropertiesPanel;
        private System.Windows.Forms.ComboBox UpperEndgameComboBox;
        private System.Windows.Forms.Label BottomSpecialActionsLabel;
        private System.Windows.Forms.Label BottomEndGameLabel;
        private System.Windows.Forms.Label UpperSpecialActionsLabel;
        private System.Windows.Forms.Label UpperEndGameLabel;
        private System.Windows.Forms.Label WhiteBottomLabel;
        private System.Windows.Forms.Label BaclUpperLabel;
        private System.Windows.Forms.Label SelectRulesLabel;
        private System.Windows.Forms.ComboBox BottomSpecialActionsComboBox;
        private System.Windows.Forms.ComboBox BottomEndgameComboBox;
        private System.Windows.Forms.ComboBox UpperSpecialActionsComboBox;
        private System.Windows.Forms.Button GameParametersButton;
    }
}

