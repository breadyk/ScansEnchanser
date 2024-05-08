using System.Diagnostics;
using System;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using System.IO;
using Newtonsoft.Json;
using System.Xml;
using Formatting = System.Xml.Formatting;

namespace EasyUpscaler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public int FileCount = new int();

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog diag = new FolderBrowserDialog();
            if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FolderBox.Text = diag.SelectedPath;
            }
            else
            { FolderBox.Text = "�� ������ �� �������!"; }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FolderBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        public int Lang = 1;
        private void LanguageButton_Click(object sender, EventArgs e)
        {
            if (Lang == 1)
            {
                Lang = 0;
                LanguageButton.Text = "�������";
                LaunchButton.Text = "Launch";
                FolderSelection.Text = "Select folder with pages";
                OutputFolderSelection.Text = "Select output folder";
                OpenButton.Text = "Open...";
                OpenButton2.Text = "Open...";
                Description1.Text = "4x Upscale + denoiser. Only for color.";
                Description2.Text = "4x Upscaler b/w. Recomended for speed.\r\nUse without other models.";
                Description3.Text = "4� Upscaler b/w. Recomended for quality.";
                Description4.Text = "Adds halftone dots. Only for b/w.";
                Description5.Text = "1x Denoiser. For damaged scans(breaks screentones).";
                Description6.Text = "1x Denoiser b/w. For almost not damaged scans.";
                Description7.Text = "1x Denoiser b/w. For slightly damaged scans.";
                Des�ription8.Text = "1x Denoiser b/w. For very damaged scans.";
                Description9.Text = "2x Upscaler b/w. Recomended for speed.\r\nUse without other models.";
                JaNaiCheck.Text = "Use";
                DigiCheck.Text = "Use";
                DWTPcheck.Text = "Use";
                ScreentoneCheck.Text = "Use";
                SaiyajinCheck.Text = "Use";
                MJHQcheck.Text = "Use";
                MJHQPcheck.Text = "Use";
                MJLQcheck.Text = "Use";
                MScaleCheck.Text = "Use";
                GeneralModels.Text = "Models";
                groupBox1.Text = "High value";
                groupBox2.Text = "Low value";
                groupBox3.Text = "White diapason";
                groupBox4.Text = "Black diapason";
                groupBox5.Text = "Launch menu";
                label2.Text = "Attention!";
                label1.Text = "After pressing \"Launch\" do NOT close the program\r\nuntil completion window wouldn't appear.\r\n";

            }
            else
            {
                Lang = 1;
                LanguageButton.Text = "English";
                LaunchButton.Text = "������";
                FolderSelection.Text = "�������� ����� � ������� ����������";
                OutputFolderSelection.Text = "�������� ����� ��� ������";
                OpenButton.Text = "�������...";
                OpenButton2.Text = "�������...";
                Description1.Text = "4x ������� + �������. ������ ��� �����.";
                Description2.Text = "4x ��������� �/�. ������������� ��� ��������.\r\n������������ ��� ������ �������.";
                Description3.Text = "4� ������� �/�. ������������� ��� ��������.";
                Description4.Text = "��������� ���������. ������ ��� �/�.";
                Description5.Text = "1x �������. ��� ������ ������(������ ���������).";
                Description6.Text = "1x ������� �/�. ��� ����� �� ������ ������.";
                Description7.Text = "1x ������� �/�. ��� ������ ������ ������.";
                Des�ription8.Text = "1x ������� �/�. ��� ������ ������ ������.";
                Description9.Text = "2x ��������� �/�. ������������� ��� ��������.\r\n������������ ��� ������ �������.";
                JaNaiCheck.Text = "������������";
                DigiCheck.Text = "������������";
                DWTPcheck.Text = "������������";
                ScreentoneCheck.Text = "������������";
                SaiyajinCheck.Text = "������������";
                MJHQcheck.Text = "������������";
                MJHQPcheck.Text = "������������";
                MJLQcheck.Text = "������������";
                MScaleCheck.Text = "������������";
                GeneralModels.Text = "������";
                groupBox1.Text = "������� �������";
                groupBox2.Text = "������ �������";
                groupBox3.Text = "�������� ������";
                groupBox4.Text = "�������� �������";
                groupBox5.Text = "���� �������";
                label2.Text = "�����!";
                label1.Text = "����� ������� \"������\", �� ���������� ���������,\r\n���� �� �������� ���� � ���������� ��������.\r\n";
            }
        }

        private void Description2_Click(object sender, EventArgs e)
        {
            
        }

        private void Description3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private async void LaunchButton_Click(object sender, EventArgs e)
        {
            if ((FolderBox.Text != "" && FolderBox2.Text != "") && (MJHQcheck.Checked || MJHQPcheck.Checked || MJLQcheck.Checked || SaiyajinCheck.Checked || JaNaiCheck.Checked || DWTPcheck.Checked || DigiCheck.Checked || MScaleCheck.Checked))
            {
                LaunchButton.Hide();

                string InputFolder = FolderBox.Text;
                string OutputFolder = FolderBox2.Text;

                List<string> modelsList = new List<string>();
                if (MJHQcheck.Checked) { modelsList.Add("1x-MangaJPEGHQ.pth"); }
                if (MJHQPcheck.Checked) { modelsList.Add("1x-MangaJPEGHQPlus.pth"); }
                if (MJLQcheck.Checked) { modelsList.Add("1x-MangaJPEGLQ.pth"); }
                if (SaiyajinCheck.Checked) { modelsList.Add("1x-SaiyaJin-DeJpeg.pth"); }
                if (JaNaiCheck.Checked) { modelsList.Add("4x_IllustrationJaNai_V1_DAT2_190k.pth"); }
                if (DWTPcheck.Checked) { modelsList.Add("4x_DWTP_DS_ATDl.pth"); }
                if (DigiCheck.Checked) { modelsList.Add("4x-eula-digimanga-bw-v2-nc1.pth"); }
                if (MScaleCheck.Checked) { modelsList.Add("2x_MangaScaleV3.pth"); }

                for (int i = 0; i < modelsList.Count; i++)
                {
                    string ModelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "srcore", "models", modelsList[i]);
                    var data = new
                    {
                        modelPath = ModelPath,
                        inputFolder = InputFolder,
                        outputFolder = OutputFolder,
                    };
                    string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data1.json");
                    string jsonData = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(jsonFilePath, jsonData);
                    string pythonScriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "srcore", "api.py");
                    string pythonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "python", "Python312", "python"); //���������

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    //startInfo.FileName = "python";
                    startInfo.FileName = pythonPath; //���������
                    startInfo.Arguments = pythonScriptPath;
                    startInfo.RedirectStandardOutput = true;
                    startInfo.UseShellExecute = false;
                    startInfo.CreateNoWindow = false;

                    using (Process process = Process.Start(startInfo))
                    {
                        process.WaitForExit();
                    }
                }
                if (ScreentoneCheck.Checked)
                {
                    var processed = new List<object>
                    {
                        new
                        {
                            type = "sharp",
                            diapason_white = DiaWhiteBar.Value,
                            diapason_black = DiaBlackBar.Value,
                            high_input = highBar.Value,
                            low_input = lowBar.Value,
                            gamma = 1.0,
                            cenny = true
                        },
                        new
                        {
                            type = "screentone",
                            dot_size = 7
                        }
                    };

                    var JSONconfig = new
                    {
                        in_folder = FolderBox2.Text,
                        out_folder = FolderBox2.Text,
                        paralel = false,
                        processed
                    };

                    string json = JsonConvert.SerializeObject(JSONconfig, Newtonsoft.Json.Formatting.Indented);

                    // ���������� JSON � ����
                    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
                    File.WriteAllText(filePath, json);

                    string screentoneScriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "mangautils", "main.py");
                    string pythonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "python", "Python312", "python"); //���������

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    //startInfo.FileName = "python";
                    startInfo.FileName = pythonPath; //���������
                    startInfo.Arguments = screentoneScriptPath;
                    startInfo.RedirectStandardOutput = true;
                    startInfo.UseShellExecute = false;
                    startInfo.CreateNoWindow = false;

                    using (Process process = Process.Start(startInfo))
                    {
                        process.WaitForExit();
                    }
                }
                MessageBox.Show("��������� ���������");
                LaunchButton.Show();
                Process.Start("explorer.exe", OutputFolder);
            }
            else if ((FolderBox.Text != "" && FolderBox2.Text != "") && (ScreentoneCheck.Checked))
            {
                var processed = new List<object>
                    {
                        new
                        {
                            type = "sharp",
                            diapason_white = DiaWhiteBar.Value,
                            diapason_black = DiaBlackBar.Value,
                            high_input = highBar.Value,
                            low_input = lowBar.Value,
                            gamma = 1.0,
                            cenny = true
                        },
                        new
                        {
                            type = "screentone",
                            dot_size = 7
                        }
                    };

                var JSONconfig = new
                {
                    in_folder = FolderBox.Text,
                    out_folder = FolderBox2.Text,
                    paralel = false,
                    processed
                };

                string json = JsonConvert.SerializeObject(JSONconfig, Newtonsoft.Json.Formatting.Indented);

                // ���������� JSON � ����
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
                File.WriteAllText(filePath, json);

                string screentoneScriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "mangautils", "main.py");

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "python";
                startInfo.Arguments = screentoneScriptPath;
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = false;

                using (Process process = Process.Start(startInfo))
                {
                    process.WaitForExit();
                }
                MessageBox.Show("��������� ���������");
                LaunchButton.Show();
                Process.Start("explorer.exe", FolderBox2.Text);
            }
            else if ((FolderBox.Text == "" || FolderBox2.Text == ""))
            {
                if (Lang == 1)
                {
                    if (FolderBox.Text == "")
                    {
                        MessageBox.Show("�� �� ������� ����� �� ����������!");
                    }
                    else
                    {
                        MessageBox.Show("�� �� ������� ����� ��� ������!");
                    }
                }
                else
                {
                    if (FolderBox.Text == "")
                    {
                        MessageBox.Show("You haven't selected a folder with pages!");
                    }
                    else
                    {
                        MessageBox.Show("You haven't selected an output folder!");
                    }
                }

            }
            else
            {
                if (Lang == 1)
                {
                    MessageBox.Show("�� �� ������� �� ����� ������!");
                }
                else
                {
                    MessageBox.Show("You haven't selected any model!");
                }
            }
            
        }

        private void OpenButton2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog diag = new FolderBrowserDialog();
            if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FolderBox2.Text = diag.SelectedPath;
            }
            else
            { FolderBox.Text = "�� ������ �� �������!"; }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Procces_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
 
        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            highInput.Text = highBar.Value.ToString();
        }

        private void highInput_TextChanged(object sender, EventArgs e)
        {
            if ((int.TryParse(highInput.Text, out int value) == true) && (int.Parse(highInput.Text) >= 0) && (int.Parse(highInput.Text) <= 255))
            {
                highBar.Value = int.Parse(highInput.Text);
            }
        }

        private void lowBar_Scroll(object sender, EventArgs e)
        {
            lowInput.Text = lowBar.Value.ToString();
        }

        private void lowInput_TextChanged(object sender, EventArgs e)
        {
            if ((int.TryParse(lowInput.Text, out int value) == true) && (int.Parse(lowInput.Text) >= 0) && (int.Parse(lowInput.Text) <= 255))
            {
                lowBar.Value = int.Parse(lowInput.Text);
            }
        }

        private void DiaWhiteBar_Scroll(object sender, EventArgs e)
        {
            DiaWhite.Text = DiaWhiteBar.Value.ToString();
        }

        private void DiaWhite_TextChanged(object sender, EventArgs e)
        {
            if ((int.TryParse(DiaWhite.Text, out int value) == true) && (int.Parse(DiaWhite.Text) >= -1) && (int.Parse(DiaWhite.Text) <= 10))
            {
                DiaWhiteBar.Value = int.Parse(DiaWhite.Text);
            }
        }

        private void DiaBlackBar_Scroll(object sender, EventArgs e)
        {
            DiaBlack.Text = DiaBlackBar.Value.ToString();
        }

        private void DiaBlack_TextChanged(object sender, EventArgs e)
        {
            if ((int.TryParse(DiaBlack.Text, out int value) == true) && (int.Parse(DiaBlack.Text) >= -1) && (int.Parse(DiaBlack.Text) <= 10))
            {
                DiaBlackBar.Value = int.Parse(DiaBlack.Text);
            }
        }
    }
}
