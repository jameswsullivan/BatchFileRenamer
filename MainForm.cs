using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BatchFileRenamer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CustomInitializations();
        }

        #region Custom functions
        private bool validateFileNamingPattern(string fileNamingPattern)
        {
            //string fileNamingPattern = fileNamingPatternTextBox.Text;
            return Regex.IsMatch(fileNamingPattern, fileNamingPatternRegex);
        }

        private bool isFileAlreadyAdded(string fileFullName)
        {
            foreach (DataGridViewRow row in fileListDataGridView.Rows)
            {
                if (row.Cells[originalFileNameTextBoxCol.Index].Value.ToString() == fileFullName)
                {
                    return true;
                }
            }
            return false;
        }

        private void highlightFileAlreadyAdded(string fileFullName)
        {
            foreach (DataGridViewRow row in fileListDataGridView.Rows)
            {
                if (row.Cells[originalFileNameTextBoxCol.Index].Value.ToString() == fileFullName)
                {
                    row.Cells[originalFileNameTextBoxCol.Index].Selected = true;
                    return;
                }
            }
        }

        private void parseFileNamingPattern(string fileNamingPattern)
        {
            fileNameSegments.Clear();

            MatchCollection matchesFound = Regex.Matches(fileNamingPattern, fileNameSplittingRegex);

            foreach (Match match in matchesFound)
            {
                if (match.Value.StartsWith("#"))
                {
                    fileNameSegments.Add(new FileNameSegments(match.Value, true));
                }
                else
                {
                    fileNameSegments.Add(new FileNameSegments(match.Value, false));
                }
            }
        }

        private string generateNewFileName(int number)
        {
            StringBuilder newFileName = new StringBuilder();

            foreach (FileNameSegments segment in fileNameSegments)
            {
                if (segment._isPlaceholder)
                {
                    int length = segment._content.Length;
                    newFileName.Append(number.ToString().PadLeft(length, '0'));
                }
                else
                {
                    newFileName.Append(segment._content);
                }
            }

            return newFileName.ToString();
        }

        private void parseStartingFileNumber()
        {
            if (!int.TryParse(startingFileNumberTextBox.Text, out startingFileNumber))
            {
                MessageBox.Show("Invalid starting number. Starting file number will be defaulted to 1.", "Invalid Starting Number!");
                startingFileNumber = 1;
            }
        }

        private void parseKeepOriginalFileNameDelimiter()
        {
            if (keepOriginalFileNameCheckBox.Checked)
            {
                switch (delimiterSelectionComboBox.SelectedIndex)
                {
                    case 0:
                        parsedDelimiter = ".";
                        break;
                    case 1:
                        parsedDelimiter = "-";
                        break;
                    case 2:
                        parsedDelimiter = " ";
                        break;
                    default:
                        parsedDelimiter = "";
                        break;
                }
            }
        }

        private void updateNewFileNames()
        {
            parseKeepOriginalFileNameDelimiter();
            StringBuilder newFileName = new StringBuilder();

            //keepOriginalFileNameCheckBox IS checked.
            if (keepOriginalFileNameCheckBox.Checked)
            {
                if (fileNamingPatternTextBox.Text != System.String.Empty)
                {
                    if (!validateFileNamingPattern(fileNamingPatternTextBox.Text))
                    {
                        MessageBox.Show("File name contains invalid characters.", "Invalid Characters in File Name!");
                    }
                    else if (validateFileNamingPattern(fileNamingPatternTextBox.Text) && !fileNamingPatternTextBox.Text.Contains('#'))
                    {
                        foreach (DataGridViewRow row in fileListDataGridView.Rows)
                        {
                            newFileName.Append(Path.GetFileNameWithoutExtension(row.Cells[originalFileNameTextBoxCol.Index].Value.ToString()));
                            newFileName.Append(parsedDelimiter);
                            newFileName.Append(fileNamingPatternTextBox.Text);
                            newFileName.Append(Path.GetExtension(row.Cells[originalFileNameTextBoxCol.Index].Value.ToString()));
                            row.Cells[newFileNameTextBoxCol.Index].Value = newFileName.ToString();
                            newFileName.Clear();
                        }
                    }
                    else if (validateFileNamingPattern(fileNamingPatternTextBox.Text) && fileNamingPatternTextBox.Text.Contains('#'))
                    {
                        parseStartingFileNumber();
                        parseFileNamingPattern(fileNamingPatternTextBox.Text);

                        int fileNumbering = startingFileNumber;
                        foreach (DataGridViewRow row in fileListDataGridView.Rows)
                        {
                            newFileName.Append(Path.GetFileNameWithoutExtension(row.Cells[originalFileNameTextBoxCol.Index].Value.ToString()));
                            newFileName.Append(parsedDelimiter);
                            newFileName.Append(generateNewFileName(fileNumbering));
                            newFileName.Append(Path.GetExtension(row.Cells[originalFileNameTextBoxCol.Index].Value.ToString()));
                            row.Cells[newFileNameTextBoxCol.Index].Value = newFileName.ToString();

                            newFileName.Clear();
                            fileNumbering++;
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in fileListDataGridView.Rows)
                    {
                        newFileName.Append(Path.GetFileNameWithoutExtension(row.Cells[originalFileNameTextBoxCol.Index].Value.ToString()));
                        newFileName.Append(parsedDelimiter);
                        newFileName.Append(Path.GetExtension(row.Cells[originalFileNameTextBoxCol.Index].Value.ToString()));
                        row.Cells[newFileNameTextBoxCol.Index].Value = newFileName.ToString();
                        newFileName.Clear();
                    }
                }

                renameFilesButton.Enabled = true;
            }
            //keepOriginalFileNameCheckBox is NOT checked.
            else
            {
                if (fileNamingPatternTextBox.Text != System.String.Empty)
                {
                    if (!validateFileNamingPattern(fileNamingPatternTextBox.Text))
                    {
                        MessageBox.Show("File name contains invalid characters.", "Invalid Characters in File Name!");
                    }
                    else if (validateFileNamingPattern(fileNamingPatternTextBox.Text) && !fileNamingPatternTextBox.Text.Contains('#'))
                    {
                        foreach (DataGridViewRow row in fileListDataGridView.Rows)
                        {
                            newFileName.Append(fileNamingPatternTextBox.Text);
                            if (keepOriginalFileExtensionCheckBox.Checked == true)
                            {
                                newFileName.Append(Path.GetExtension(row.Cells[originalFileNameTextBoxCol.Index].Value.ToString()));
                            }
                            row.Cells[newFileNameTextBoxCol.Index].Value = newFileName.ToString();
                            newFileName.Clear();
                        }
                    }
                    else if (validateFileNamingPattern(fileNamingPatternTextBox.Text) && fileNamingPatternTextBox.Text.Contains('#'))
                    {
                        parseStartingFileNumber();
                        parseFileNamingPattern(fileNamingPatternTextBox.Text);

                        int fileNumbering = startingFileNumber;
                        foreach (DataGridViewRow row in fileListDataGridView.Rows)
                        {
                            newFileName.Append(generateNewFileName(fileNumbering));
                            if (keepOriginalFileExtensionCheckBox.Checked == true)
                            {
                                newFileName.Append(Path.GetExtension(row.Cells[originalFileNameTextBoxCol.Index].Value.ToString()));
                            }
                            row.Cells[newFileNameTextBoxCol.Index].Value = newFileName.ToString();
                            fileNumbering++;
                            newFileName.Clear();
                        }
                    }

                    renameFilesButton.Enabled = true;
                }
                else
                {
                    renameFilesButton.Enabled = false;
                    foreach (DataGridViewRow row in fileListDataGridView.Rows)
                    {
                        row.Cells[newFileNameTextBoxCol.Index].Value = System.String.Empty;
                    }
                }
            }
        }

        private void startOver()
        {
            fileNamingPatternTextBox.Clear();
            startingFileNumberTextBox.Text = "1";
            fileListDataGridView.Rows.Clear();

            delimiterSelectionComboBox.Enabled = false;
            renameFilesButton.Enabled = false;
            keepOriginalFileNameCheckBox.Checked = false;

            keepOriginalFileExtensionCheckBox.Checked = true;
        }

        private void createLogFile()
        {
            string logDirectory = "logs";
            string logFileName = $"{DateTime.Now:yyyy-MM-dd}.log";
            string logFilePath = Path.Combine(logDirectory, logFileName);

            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            if (!File.Exists(logFilePath))
            {
                File.Create(logFilePath).Close();
            }
        }

        #endregion Custom functions

        private void keepOriginalFileNameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!keepOriginalFileNameCheckBox.Checked)
            {
                delimiterSelectionComboBox.Enabled = false;
            }
            else if (keepOriginalFileNameCheckBox.Checked)
            {
                delimiterSelectionComboBox.Enabled = true;
            }

            updateNewFileNames();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startOverButton_Click(object sender, EventArgs e)
        {
            startOver();
        }

        private void selectFilesButton_Click(object sender, EventArgs e)
        {
            //Clear the File Name field when the OpenFileDialog window opens:
            openFileDialog_AddFiles.FileName = System.String.Empty;

            //DialogResult.OK - Files selected, proceed to add the files.
            if (openFileDialog_AddFiles.ShowDialog() == DialogResult.OK)
            {
                fileListDataGridView.ClearSelection();

                //When file list is empty, add files to lists.
                if (fileListDataGridView.Rows.Count == 0)
                {
                    foreach (string originalFileName in openFileDialog_AddFiles.FileNames)
                    {
                        FileInfo fileInfo = new FileInfo(originalFileName);
                        int rowId = fileListDataGridView.Rows.Add();

                        fileListDataGridView.Rows[rowId].Cells[originalFileNameTextBoxCol.Index].Value = fileInfo.FullName;
                    }

                    fileListDataGridView.ClearSelection();
                }
                //When file list is not empty, only add the ones that are not in the list, and highlight the ones that
                //are already added.
                else if (fileListDataGridView.Rows.Count > 0)
                {
                    foreach (string originalFileName in openFileDialog_AddFiles.FileNames)
                    {
                        FileInfo fileInfo = new FileInfo(originalFileName);
                        if (isFileAlreadyAdded(fileInfo.FullName))
                        {
                            highlightFileAlreadyAdded(fileInfo.FullName);
                            continue;
                        }
                        else
                        {
                            int rowId = fileListDataGridView.Rows.Add();
                            fileListDataGridView.Rows[rowId].Cells[originalFileNameTextBoxCol.Index].Value = fileInfo.FullName;
                        }
                    }
                }

                //After the files've been added, proceed with checking if fileNamingPatternTextBox.Text is empty or not,
                //and update the new file names fields if fileNamingPatternTextBox.Text is not empty.
                updateNewFileNames();
            }
            //DialogResult.Cancel - File selection cancelled.
            else
            {
                renameFilesButton.Enabled = false;
            }
        }

        private void fileListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == fileListDataGridView.Columns["deleteLineButtonCol"].Index)
            {
                fileListDataGridView.Rows.RemoveAt(e.RowIndex);
                fileListDataGridView.ClearSelection();
            }
            else if (e.ColumnIndex == fileListDataGridView.Columns["originalFileNameTextBoxCol"].Index)
            {
                fileListDataGridView.CurrentCell = fileListDataGridView[e.ColumnIndex, e.RowIndex];
            }
        }

        private void renameFilesButton_Click(object sender, EventArgs e)
        {
            string newFileName = "";
            string logFilePath = Path.Combine("logs", $"{DateTime.Now:yyyy-MM-dd}.log");
            StringBuilder logMessage = new StringBuilder();

            if (fileListDataGridView.Rows.Count > 0)
            {
                if (keepLogFileCheckBox.Checked)
                {
                    createLogFile();

                    foreach (DataGridViewRow row in fileListDataGridView.Rows)
                    {
                        if (File.Exists(logFilePath))
                        {
                            logMessage.Append("File: ");
                            logMessage.Append($"\"{row.Cells[originalFileNameTextBoxCol.Index].Value.ToString()}\"");
                            logMessage.Append(" has been renamed to: ");
                            logMessage.Append($"\"{row.Cells[newFileNameTextBoxCol.Index].Value.ToString()}\"");
                            logMessage.Append(Environment.NewLine);

                            File.AppendAllText(logFilePath, logMessage.ToString());
                            logMessage.Clear();
                        }

                        newFileName = Path.Combine(Path.GetDirectoryName(row.Cells[originalFileNameTextBoxCol.Index].Value.ToString()), row.Cells[newFileNameTextBoxCol.Index].Value.ToString());
                        File.Move(row.Cells[originalFileNameTextBoxCol.Index].Value.ToString(), newFileName);
                        row.Cells[originalFileNameTextBoxCol.Index].Value = newFileName;
                        newFileName = "";
                    }

                    File.AppendAllText(logFilePath, Environment.NewLine);
                }
                else
                {
                    foreach (DataGridViewRow row in fileListDataGridView.Rows)
                    {
                        newFileName = Path.Combine(Path.GetDirectoryName(row.Cells[originalFileNameTextBoxCol.Index].Value.ToString()), row.Cells[newFileNameTextBoxCol.Index].Value.ToString());
                        File.Move(row.Cells[originalFileNameTextBoxCol.Index].Value.ToString(), newFileName);
                        row.Cells[originalFileNameTextBoxCol.Index].Value = newFileName;
                        newFileName = "";
                    }
                }
            }

            MessageBox.Show("All files have been renamed successfully.", "Renaming Successful!");
        }

        private void fileNamingPatternTextBox_ShowTip(object sender, EventArgs e)
        {
            fileNamingPatternTextBoxToolTip.Show(
                "Only a-z, A-Z, 0-9, dot (\" . \"), dash (\" - \"), underscore (\" _ \"), parenthesis ( ( , ) ), and square brackets ( [ , ] ) are allowed.\nPound ( # ) is used for specifying the numbering pattern.\ne.g.: My_New-File.name-01-###\nMaximum file name length is 64 characters.",
                fileNamingPatternTextBox,
                0,
                fileNamingPatternTextBox.Height + 3
                );
        }

        private void fileNamingPatternTextBox_HideTip(object sender, EventArgs e)
        {
            fileNamingPatternTextBoxToolTip.Hide(fileNamingPatternTextBox);
        }

        private void startingFileNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            parseStartingFileNumber();
            updateNewFileNames();
        }
        private void fileNamingPatternTextBox_TextChanged(object sender, EventArgs e)
        {
            updateNewFileNames();
        }

        private void fileListDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Get the current cell under the mouse pointer
                DataGridView.HitTestInfo hitTestInfo = fileListDataGridView.HitTest(e.X, e.Y);

                // Check if the click occurred outside of any cells
                if (hitTestInfo.Type == DataGridViewHitTestType.None)
                {
                    // Clear the selection
                    fileListDataGridView.ClearSelection();
                }
            }
        }

        private void delimiterSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateNewFileNames();
        }

        private void keepOriginalFileExtensionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fileListDataGridView.Rows.Count > 0)
            {
                if (!keepOriginalFileExtensionCheckBox.Checked)
                {
                    foreach (DataGridViewRow row in fileListDataGridView.Rows)
                    {
                        row.Cells[newFileNameTextBoxCol.Index].Value = Path.GetFileNameWithoutExtension(row.Cells[newFileNameTextBoxCol.Index].Value.ToString());
                    }
                }
                else if (keepOriginalFileExtensionCheckBox.Checked)
                {
                    foreach (DataGridViewRow row in fileListDataGridView.Rows)
                    {
                        if (Path.GetExtension(row.Cells[newFileNameTextBoxCol.Index].Value.ToString()) == "")
                        {
                            row.Cells[newFileNameTextBoxCol.Index].Value += Path.GetExtension(row.Cells[originalFileNameTextBoxCol.Index].Value.ToString());
                        }
                    }
                }
            }
        }
    }
}