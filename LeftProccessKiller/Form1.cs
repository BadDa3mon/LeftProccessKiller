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
        public bool ofConfig, showError, showAddInfo, fromFile;
        public string[] processesForKill;
        public Form1()
        {
            InitializeComponent();
            openConfigurationIfNeeded();
            OFD = new OpenFileDialog();
            SFD = new SaveFileDialog();
            OFD.Filter = "Текстовые документы(*.txt)|*.txt|Все файлы(*.*)|*.*";
            SFD.Filter = "Текстовые документы(*.txt)|*.txt|Все файлы(*.*)|*.*";
        }

        public void openConfigurationIfNeeded()
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
                getConfig();
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
                createItems();
            }
        }

        private void getConfig()
        {
            string[] lines = System.IO.File.ReadAllLines(configName); int i = 1;
            int firstQuote = lines[i].IndexOf('"') + 1, length = lines[i].Length - firstQuote - 2;
            fromFile = bool.Parse(lines[i].Substring(firstQuote, length)); i++;
            firstQuote = lines[i].IndexOf('"') + 1; length = lines[i].Length - firstQuote - 2;
            fileName = lines[i].Substring(firstQuote, length); i++;
            firstQuote = lines[i].IndexOf('"') + 1; length = lines[i].Length - firstQuote - 2;
            showError = bool.Parse(lines[i].Substring(firstQuote, length)); i++;
            firstQuote = lines[i].IndexOf('"') + 1; length = lines[i].Length - firstQuote - 2;
            showAddInfo = bool.Parse(lines[i].Substring(firstQuote, length));
        }

        private void resetConfig()
        {
            string first = "#BadDa3mon CONF for ProcessKiller\n";
            string second = "fromFile=" + "\u0022" + $"{fromFile.ToString()}" + "\u0022;\n";
            string third = "filePath=" + "\u0022" + $"{fileName}" + "\u0022;\n";
            string fourth = "showError=" + "\u0022" + $"{showError.ToString()}" + "\u0022;\n";
            string fifth = "showAddInfo=" + "\u0022" + $"{showAddInfo.ToString()}" + "\u0022;";
            string all = first + second + third + fourth + fifth;
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
            updateElements();
        }

        private void select_file_button_Click(object sender, EventArgs e)
        {
            if (OFD.ShowDialog() == DialogResult.Cancel) { return; }
            if (fileName.Length == 0) { fileName = OFD.FileName; }
            updateElements();
        }

        private void createItems()
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
                    catch (IndexOutOfRangeException IndexEx)
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

        private void updateElements()
        {
            if (fromFile) { processes_path_label.Text = $"Файл: {fileName}"; }
            else { processes_path_label.Text = $"Файл не выбран"; }
            createItems();
        }

        private void kill_button_Click(object sender, EventArgs e)
        {
            killSelectedProccesses(listview_process.SelectedItems);
            updateElements();
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
                        catch (Win32Exception e) { MessageBox.Show($"Error! You don't have permission to kill {Selected[i].Text}!", "Error!", MessageBoxButtons.OK); }
                    }
                    catch (IndexOutOfRangeException e) { MessageBox.Show($"Error! Process with name {Selected[i].Text} not exist!", "Error!", MessageBoxButtons.OK); }
                    listview_process.Items.RemoveByKey(Selected[i].Text);
                    listview_process.Update();
                }
            }
            else { noActiveProccess(); }
        }

        private void killall_button_Click(object sender, EventArgs e)
        {
            killAllProccesses(listview_process.Items);
            updateElements();
        }

        private void update_process_button_Click(object sender, EventArgs e)
        {
            updateElements();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            resetConfig();
        }

        private void killAllProccesses(ListView.ListViewItemCollection allItems)
        {
            int N = allItems.Count;
            if (allItems.Count != 0)
            {
                for (int i = 0; i < N; i++)
                {
                    Process proc = Process.GetProcessesByName(allItems[0].Text)[0];
                    try { proc.Kill(); }
                    catch (Win32Exception e) { MessageBox.Show($"Error! You don't have permission to kill {allItems[0].Text}!", "Error!", MessageBoxButtons.OK); }
                    listview_process.Items.RemoveAt(0);
                    if (showAddInfo) { MessageBox.Show($"Proccess with name {allItems[0].Text} removed", "Info!", MessageBoxButtons.OK); }
                }
            }
            else { noActiveProccess(); }
        }

        private void noActiveProccess()
        {
            MessageBox.Show($"Error! No active processes!", "Error!", MessageBoxButtons.OK);
        }
    }
}
