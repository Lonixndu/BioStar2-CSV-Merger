using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BioStarCSVMerger
{
    public partial class bioStarAccesLogMerger : Form
    {
        public bioStarAccesLogMerger()
        {
            InitializeComponent();

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            txtOutputPath.Text = Path.Combine(documentsPath, "Merged_Access_Report.csv");
        }

        //Invoke merge process
        private async void btnMerge_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInputPath.Text))
            {
                MessageBox.Show("Please select a folder or ZIP file.");
                return;
            }

            btnMerge.Enabled = false;
            lblStatus.Text = "Processing...";
            progressBar.Value = 0;

            await Task.Run(() =>
            {
                ProcessFiles(txtInputPath.Text, txtOutputPath.Text);
            });

            lblStatus.Text = "Done!";
            btnMerge.Enabled = true;
            btnOpen.Enabled = true;

            MessageBox.Show("Merge Completed!");
        }

        //Merge the files together
        private void ProcessFiles(string inputPath, string outputFile)
        {
            string workingDirectory = inputPath;

            // If ZIP → extract
            if (Path.GetExtension(inputPath).ToLower() == ".zip")
            {
                workingDirectory = Path.Combine(
                    Path.GetDirectoryName(inputPath),
                    "Extracted_" + DateTime.Now.Ticks);

                ZipFile.ExtractToDirectory(inputPath, workingDirectory);
            }

            var csvFiles = Directory.GetFiles(workingDirectory, "*.csv");

            int totalFiles = csvFiles.Length;
            int currentFile = 0;

            using (var writer = new StreamWriter(outputFile, false))
            {
                bool headerWritten = false;

                foreach (var file in csvFiles)
                {
                    using (var reader = new StreamReader(file))
                    {
                        string line;
                        bool isFirstLine = true;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (isFirstLine)
                            {
                                if (!headerWritten)
                                {
                                    writer.WriteLine(line);
                                    headerWritten = true;
                                }

                                isFirstLine = false;
                                continue;
                            }

                            writer.WriteLine(line);
                        }
                    }

                    currentFile++;

                    Invoke(new Action(() =>
                    {
                        progressBar.Value = (int)((double)currentFile / totalFiles * 100);
                    }));
                }
            }
        }

        //Open Folder
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtInputPath.Text = dialog.SelectedPath;
                }
            }
        }

        //Open ZIP
        private void btnSelectZip_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "ZIP Files (*.zip)|*.zip";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtInputPath.Text = dialog.FileName;
                }
            }
        }

        //Open the merged file
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtOutputPath.Text))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = txtOutputPath.Text,
                    UseShellExecute = true
                });
            }
        }


        private void btnSelectOutput_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV Files (*.csv)|*.csv";
                dialog.FileName = "Merged_Access_Report.csv";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtOutputPath.Text = dialog.FileName;
                }
            }
        }

        private void linkVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/Lonixndu/BioStar2-CSV-Merger/",
                UseShellExecute = true
            });
        }
    }
}
