using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;

namespace LeftProccessKiller
{
    public partial class Form1 : Form
    {
        public OpenFileDialog OFD;
        public SaveFileDialog SFD;
        public string fileName, configName;
        public bool ofConfig, showError, showAddInfo, fromFile, killAllChecked;
        public int killAllCheckedTime;
        public string[] processesForKill;
        public Form1()
        {
            InitializeComponent();
            OpenConfigurationIfNeeded();
            OFD = new OpenFileDialog();
            SFD = new SaveFileDialog();
            OFD.Filter = "Текстовые документы(*.txt)|*.txt|Все файлы(*.*)|*.*";
            SFD.Filter = "Текстовые документы(*.txt)|*.txt|Все файлы(*.*)|*.*";
        }

        public void OpenConfigurationIfNeeded()
        {
            configName = "da3mon_conf.cfg";
            ofConfig = System.IO.File.Exists(configName);
            if (ofConfig != true)
            {
                MessageBox.Show("Error! Check da3mon_conf.cfg in work folder!", "Error!", MessageBoxButtons.OK);
                this.Close();
            }
            else 
            {
                GetConfig();
                ofConfig = true;
                if (fromFile)
                {
                    System.IO.File.ReadAllText(fileName);
                    checkBox1.Checked = true;
                }
                else 
                {
                    checkBox1.Checked = false;
                }
                CreateItems();
            }
        }

        private void GetConfig()
        {
            string[] lines = System.IO.File.ReadAllLines(configName); int i = 1;
            int firstQuote = lines[i].IndexOf('"') + 1, length = lines[i].Length - firstQuote - 2;
            fromFile = bool.Parse(lines[i].Substring(firstQuote, length)); i++;
            firstQuote = lines[i].IndexOf('"') + 1; length = lines[i].Length - firstQuote - 2;
            fileName = lines[i].Substring(firstQuote, length); i++;
            firstQuote = lines[i].IndexOf('"') + 1; length = lines[i].Length - firstQuote - 2;
            showError = bool.Parse(lines[i].Substring(firstQuote, length)); i++;
            firstQuote = lines[i].IndexOf('"') + 1; length = lines[i].Length - firstQuote - 2;
            showAddInfo = bool.Parse(lines[i].Substring(firstQuote, length)); i++;
            firstQuote = lines[i].IndexOf('"') + 1; length = lines[i].Length - firstQuote - 2;
            killAllChecked = bool.Parse(lines[i].Substring(firstQuote, length)); i++;
            firstQuote = lines[i].IndexOf('"') + 1; length = lines[i].Length - firstQuote - 2;
            killAllCheckedTime = int.Parse(lines[i].Substring(firstQuote, length));
        }

        public void UpdateSettings()
        {
            Form2 sett = new Form2();
            killAllChecked = sett.killAllCheckbox;
            killAllCheckedTime = sett.killAllCheckboxTime;
        }

        private void ResetConfig()
        {
            string first = "#BadDa3mon CONF for ProcessKiller\n";
            string second = "fromFile=" + "\u0022" + $"{fromFile.ToString()}" + "\u0022;\n";
            string third = "filePath=" + "\u0022" + $"{fileName}" + "\u0022;\n";
            string fourth = "showError=" + "\u0022" + $"{showError.ToString()}" + "\u0022;\n";
            string fifth = "showAddInfo=" + "\u0022" + $"{showAddInfo.ToString()}" + "\u0022;\n";
            string sixth = "killAllChecked=" + "\u0022" + $"{killAllChecked.ToString()}" + "\u0022;\n";
            string seventh = "killAllCheckedTime=" + "\u0022" + $"{killAllCheckedTime}" + "\u0022;\n";
            string all = first + second + third + fourth + fifth + sixth + seventh;
            System.IO.File.WriteAllText(configName, all);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                select_file_button.Visible = true;
                update_process_button.Visible = false;
                fromFile = true;
            }
            else 
            {
                select_file_button.Visible = false;
                update_process_button.Visible = true;
                fromFile = false;
            }
            UpdateElements();
        }

        private void select_file_button_Click(object sender, EventArgs e)
        {
            if (OFD.ShowDialog() == DialogResult.Cancel) { return; }
            if (fileName.Length == 0) { fileName = OFD.FileName; }
            UpdateElements();
        }

        private void CreateItems()
        {
            listview_process.Clear();
            if (fromFile)
            {
                string proccesses = System.IO.File.ReadAllText(fileName);
                processesForKill = proccesses.Split(';');
                for (int i = 0; i < processesForKill.Length; i++)
                {
                    try
                    {
                        Process proc = Process.GetProcessesByName(processesForKill[i])[0];
                        if (proc != null)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = processesForKill[i];
                            listview_process.Items.Add(item);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        if (showError) { MessageBox.Show($"Error! Proccess with name {processesForKill[i]} not exist!", "Error!", MessageBoxButtons.OK); }
                    }
                }
            }
            else
            {
                Process[] procs = Process.GetProcesses();
                if (procs != null)
                {
                    for (int i = 0; i < procs.Length; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = procs[i].ProcessName;
                        listview_process.Items.Add(item);
                    }
                }
            }
            k_proccesses.Text = listview_process.Items.Count.ToString();
        }

        private void UpdateElements()
        {
            if (fromFile) { processes_path_label.Text = $"Файл: {fileName}"; }
            else { processes_path_label.Text = $"Файл не выбран"; }
            CreateItems();
        }

        private void kill_button_Click(object sender, EventArgs e)
        {
            killSelectedProccesses(listview_process.SelectedItems);
            UpdateElements();
        }

        private void killSelectedProccesses(ListView.SelectedListViewItemCollection Selected)
        {
            if (Selected.Count != 0)
            {
                for (int i = 0; i < Selected.Count; i++)
                {
                    try 
                    { 
                        Process proc = Process.GetProcessesByName(Selected[0].Text)[0];
                        try { proc.Kill(); }
                        catch (Win32Exception) { if (showError) { MessageBox.Show($"Error! You don't have permission to kill {Selected[i].Text}!", "Error!", MessageBoxButtons.OK); } }
                    }
                    catch (IndexOutOfRangeException) { MessageBox.Show($"Error! Process with name {Selected[i].Text} not exist!", "Error!", MessageBoxButtons.OK); }
                    listview_process.Items.RemoveByKey(Selected[i].Text);
                    listview_process.Update();
                }
            }
            else { NoActiveProccess(); }
        }

        private void killall_button_Click(object sender, EventArgs e)
        {
            KillAllProccesses(listview_process.Items);
            UpdateElements();
        }

        private void settings_button_Click(object sender, EventArgs e)
        {
            Form2 sett = new Form2();
            sett.Show();
            killAllChecked = sett.killAllCheckbox;
            killAllCheckedTime = sett.killAllCheckboxTime;
        }

        private void update_process_button_Click(object sender, EventArgs e)
        {
            UpdateElements();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResetConfig();
        }

        private void KillAllProccesses(ListView.ListViewItemCollection allItems)
        {
            int N = allItems.Count;
            if (allItems.Count != 0)
            {
                for (int i = 0; i < N; i++)
                {
                    Process proc = Process.GetProcessesByName(allItems[0].Text)[0];
                    try { proc.Kill(); }
                    catch (Win32Exception) { if (showError) { MessageBox.Show($"Error! You don't have permission to kill {allItems[0].Text}!", "Error!", MessageBoxButtons.OK); } }
                    listview_process.Items.RemoveAt(0);
                    if (showAddInfo) { MessageBox.Show($"Proccess with name {allItems[0].Text} removed", "Info!", MessageBoxButtons.OK); }
                }
            }
            else { NoActiveProccess(); }
        }

        private void NoActiveProccess()
        {
            MessageBox.Show($"Error! No active processes!", "Error!", MessageBoxButtons.OK);
        }
    }
}
