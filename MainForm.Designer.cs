namespace BatchFileRenamer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            selectFilesButton = new Button();
            fileNamingPatternTextBoxLabel = new Label();
            fileNamingPatternTextBox = new TextBox();
            delimiterSelectionComboBox = new ComboBox();
            keepOriginalFileNameCheckBox = new CheckBox();
            renameFilesButton = new Button();
            fileListDataGridView = new DataGridView();
            originalFileNameTextBoxCol = new DataGridViewTextBoxColumn();
            newFileNameTextBoxCol = new DataGridViewTextBoxColumn();
            deleteLineButtonCol = new DataGridViewButtonColumn();
            exitButton = new Button();
            startOverButton = new Button();
            openFileDialog_AddFiles = new OpenFileDialog();
            startingFileNumberTextBoxLabel = new Label();
            startingFileNumberTextBox = new TextBox();
            fileNamingPatternTextBoxToolTip = new ToolTip(components);
            keepOriginalFileExtensionCheckBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)fileListDataGridView).BeginInit();
            SuspendLayout();
            // 
            // selectFilesButton
            // 
            selectFilesButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            selectFilesButton.Location = new Point(1186, 19);
            selectFilesButton.Name = "selectFilesButton";
            selectFilesButton.Size = new Size(150, 54);
            selectFilesButton.TabIndex = 0;
            selectFilesButton.Text = "Add Files ...";
            selectFilesButton.UseVisualStyleBackColor = true;
            selectFilesButton.Click += selectFilesButton_Click;
            // 
            // fileNamingPatternTextBoxLabel
            // 
            fileNamingPatternTextBoxLabel.AutoSize = true;
            fileNamingPatternTextBoxLabel.Location = new Point(6, 19);
            fileNamingPatternTextBoxLabel.Name = "fileNamingPatternTextBoxLabel";
            fileNamingPatternTextBoxLabel.Size = new Size(142, 20);
            fileNamingPatternTextBoxLabel.TabIndex = 1;
            fileNamingPatternTextBoxLabel.Text = "File Naming Pattern:";
            // 
            // fileNamingPatternTextBox
            // 
            fileNamingPatternTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            fileNamingPatternTextBox.Location = new Point(10, 45);
            fileNamingPatternTextBox.Name = "fileNamingPatternTextBox";
            fileNamingPatternTextBox.Size = new Size(664, 27);
            fileNamingPatternTextBox.TabIndex = 2;
            // 
            // delimiterSelectionComboBox
            // 
            delimiterSelectionComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            delimiterSelectionComboBox.Enabled = false;
            delimiterSelectionComboBox.FormattingEnabled = true;
            delimiterSelectionComboBox.Items.AddRange(new object[] { "Dot - \" . \"", "Dash - \" - \"", "Space" });
            delimiterSelectionComboBox.Location = new Point(992, 44);
            delimiterSelectionComboBox.Name = "delimiterSelectionComboBox";
            delimiterSelectionComboBox.Size = new Size(184, 28);
            delimiterSelectionComboBox.TabIndex = 4;
            delimiterSelectionComboBox.Text = "Select a Delimiter";
            // 
            // keepOriginalFileNameCheckBox
            // 
            keepOriginalFileNameCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            keepOriginalFileNameCheckBox.AutoSize = true;
            keepOriginalFileNameCheckBox.Location = new Point(992, 18);
            keepOriginalFileNameCheckBox.Name = "keepOriginalFileNameCheckBox";
            keepOriginalFileNameCheckBox.Size = new Size(193, 24);
            keepOriginalFileNameCheckBox.TabIndex = 6;
            keepOriginalFileNameCheckBox.Text = "Keep Original File Name";
            keepOriginalFileNameCheckBox.UseVisualStyleBackColor = true;
            keepOriginalFileNameCheckBox.CheckedChanged += keepOriginalFileNameCheckBox_CheckedChanged;
            // 
            // renameFilesButton
            // 
            renameFilesButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            renameFilesButton.Enabled = false;
            renameFilesButton.Location = new Point(1030, 662);
            renameFilesButton.Name = "renameFilesButton";
            renameFilesButton.Size = new Size(150, 29);
            renameFilesButton.TabIndex = 7;
            renameFilesButton.Text = "Rename Files";
            renameFilesButton.UseVisualStyleBackColor = true;
            renameFilesButton.Click += renameFilesButton_Click;
            // 
            // fileListDataGridView
            // 
            fileListDataGridView.AllowUserToAddRows = false;
            fileListDataGridView.AllowUserToDeleteRows = false;
            fileListDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            fileListDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            fileListDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            fileListDataGridView.Columns.AddRange(new DataGridViewColumn[] { originalFileNameTextBoxCol, newFileNameTextBoxCol, deleteLineButtonCol });
            fileListDataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
            fileListDataGridView.Location = new Point(10, 89);
            fileListDataGridView.Name = "fileListDataGridView";
            fileListDataGridView.RowHeadersVisible = false;
            fileListDataGridView.RowHeadersWidth = 51;
            fileListDataGridView.RowTemplate.Height = 29;
            fileListDataGridView.ShowCellToolTips = false;
            fileListDataGridView.Size = new Size(1326, 567);
            fileListDataGridView.TabIndex = 8;
            // 
            // originalFileNameTextBoxCol
            // 
            originalFileNameTextBoxCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            originalFileNameTextBoxCol.HeaderText = "Original File Name";
            originalFileNameTextBoxCol.MinimumWidth = 6;
            originalFileNameTextBoxCol.Name = "originalFileNameTextBoxCol";
            originalFileNameTextBoxCol.ReadOnly = true;
            // 
            // newFileNameTextBoxCol
            // 
            newFileNameTextBoxCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            newFileNameTextBoxCol.HeaderText = "New File Name";
            newFileNameTextBoxCol.MinimumWidth = 6;
            newFileNameTextBoxCol.Name = "newFileNameTextBoxCol";
            // 
            // deleteLineButtonCol
            // 
            deleteLineButtonCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Padding = new Padding(1);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            deleteLineButtonCol.DefaultCellStyle = dataGridViewCellStyle2;
            deleteLineButtonCol.HeaderText = "Delete Line";
            deleteLineButtonCol.MinimumWidth = 6;
            deleteLineButtonCol.Name = "deleteLineButtonCol";
            deleteLineButtonCol.Text = "";
            deleteLineButtonCol.UseColumnTextForButtonValue = true;
            deleteLineButtonCol.Width = 90;
            // 
            // exitButton
            // 
            exitButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            exitButton.Location = new Point(1186, 662);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(150, 29);
            exitButton.TabIndex = 9;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // startOverButton
            // 
            startOverButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            startOverButton.Location = new Point(874, 662);
            startOverButton.Name = "startOverButton";
            startOverButton.Size = new Size(150, 29);
            startOverButton.TabIndex = 10;
            startOverButton.Text = "Start Over";
            startOverButton.UseVisualStyleBackColor = true;
            startOverButton.Click += startOverButton_Click;
            // 
            // openFileDialog_AddFiles
            // 
            openFileDialog_AddFiles.FileName = "openFileDialog_AddFiles";
            openFileDialog_AddFiles.Multiselect = true;
            // 
            // startingFileNumberTextBoxLabel
            // 
            startingFileNumberTextBoxLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            startingFileNumberTextBoxLabel.AutoSize = true;
            startingFileNumberTextBoxLabel.Location = new Point(676, 19);
            startingFileNumberTextBoxLabel.Name = "startingFileNumberTextBoxLabel";
            startingFileNumberTextBoxLabel.Size = new Size(233, 20);
            startingFileNumberTextBoxLabel.TabIndex = 11;
            startingFileNumberTextBoxLabel.Text = "Starting File Number: ( default: 1 )";
            // 
            // startingFileNumberTextBox
            // 
            startingFileNumberTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            startingFileNumberTextBox.Location = new Point(680, 45);
            startingFileNumberTextBox.Name = "startingFileNumberTextBox";
            startingFileNumberTextBox.Size = new Size(306, 27);
            startingFileNumberTextBox.TabIndex = 12;
            startingFileNumberTextBox.Text = "1";
            // 
            // keepOriginalFileExtensionCheckBox
            // 
            keepOriginalFileExtensionCheckBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            keepOriginalFileExtensionCheckBox.AutoSize = true;
            keepOriginalFileExtensionCheckBox.Location = new Point(10, 662);
            keepOriginalFileExtensionCheckBox.Name = "keepOriginalFileExtensionCheckBox";
            keepOriginalFileExtensionCheckBox.Size = new Size(216, 24);
            keepOriginalFileExtensionCheckBox.TabIndex = 13;
            keepOriginalFileExtensionCheckBox.Text = "Keep Original File Extension";
            keepOriginalFileExtensionCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1348, 703);
            Controls.Add(keepOriginalFileExtensionCheckBox);
            Controls.Add(startingFileNumberTextBox);
            Controls.Add(startingFileNumberTextBoxLabel);
            Controls.Add(startOverButton);
            Controls.Add(exitButton);
            Controls.Add(fileListDataGridView);
            Controls.Add(renameFilesButton);
            Controls.Add(keepOriginalFileNameCheckBox);
            Controls.Add(delimiterSelectionComboBox);
            Controls.Add(fileNamingPatternTextBox);
            Controls.Add(fileNamingPatternTextBoxLabel);
            Controls.Add(selectFilesButton);
            MinimumSize = new Size(1366, 750);
            Name = "MainForm";
            Text = "Batch File Renamer";
            ((System.ComponentModel.ISupportInitialize)fileListDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        #region My custom initializations

        private string fileNamingPatternRegex = @"^[a-zA-Z0-9\._\s\(\)\[\]-]+((#[#]*[a-zA-Z0-9\._\s\(\)\[\]-]*)+)?$";
        private string fileNameSplittingRegex = @"(#+|[a-zA-Z0-9\._\s\(\)\[\]-]+)";
        private string deleteLineButtonText = "Delete Line";
        private List<FileNameSegments> fileNameSegments = new List<FileNameSegments>();
        private string parsedDelimiter = System.String.Empty;
        private int startingFileNumber = 1;
        private void CustomInitializations()
        {
            openFileDialog_AddFiles.FileName = String.Empty;
            deleteLineButtonCol.Text = deleteLineButtonText;

            fileListDataGridView.CellClick += fileListDataGridView_CellClick;
            fileListDataGridView.MouseDown += fileListDataGridView_MouseDown;
            fileNamingPatternTextBox.MouseEnter += fileNamingPatternTextBox_ShowTip;
            fileNamingPatternTextBox.MouseLeave += fileNamingPatternTextBox_HideTip;
            fileNamingPatternTextBox.TextChanged += fileNamingPatternTextBox_TextChanged;
            startingFileNumberTextBox.TextChanged += startingFileNumberTextBox_TextChanged;
            delimiterSelectionComboBox.SelectedIndexChanged += delimiterSelectionComboBox_SelectedIndexChanged;
            keepOriginalFileExtensionCheckBox.CheckedChanged += keepOriginalFileExtensionCheckBox_CheckedChanged;

            keepOriginalFileExtensionCheckBox.Checked = true;
        }

        #endregion

        private Button selectFilesButton;
        private Label fileNamingPatternTextBoxLabel;
        private TextBox fileNamingPatternTextBox;
        private ComboBox delimiterSelectionComboBox;
        private CheckBox keepOriginalFileNameCheckBox;
        private Button renameFilesButton;
        private DataGridView fileListDataGridView;
        private Button exitButton;
        private Button startOverButton;
        private OpenFileDialog openFileDialog_AddFiles;
        private Label startingFileNumberTextBoxLabel;
        private TextBox startingFileNumberTextBox;
        private ToolTip fileNamingPatternTextBoxToolTip;
        private DataGridViewTextBoxColumn originalFileNameTextBoxCol;
        private DataGridViewTextBoxColumn newFileNameTextBoxCol;
        private DataGridViewButtonColumn deleteLineButtonCol;
        private CheckBox keepOriginalFileExtensionCheckBox;
    }
}