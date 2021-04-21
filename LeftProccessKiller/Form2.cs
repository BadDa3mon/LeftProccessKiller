using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeftProccessKiller
{
    public partial class Form2 : Form
    {
        public bool killAllCheckbox, showInfo;
        public int killAllCheckboxTime;
        public Form1 based;
        public Form2()
        {
            InitializeComponent();
            Form1 form1 = new Form1();
            based = form1;
            showInfo = form1.showAddInfo;
            killAllCheckboxTime = form1.killAllCheckedTime;
            killAllCheckbox = form1.killAllChecked;
            UpdateElements();
        }

        public void UpdateElements()
        {
            if (killAllCheckboxTime != -1)
            {
                min_textbox.Text = killAllCheckboxTime.ToString();
                killAllCheckbox = true;
            }
            else { killAllCheckbox = false; }
            min_textbox.Enabled = killAllCheckbox;
            min_label.Visible = killAllCheckbox;
            killall_fromtime_checkbox.Checked = killAllCheckbox;
        }

        private void killall_fromtime_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateElements();
        }

        private void min_textbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private bool CheckFormatMinutes(string input)
        {
            try
            {
                int min = int.Parse(min_textbox.Text);
                min_textbox.ForeColor = Color.FromArgb(255, 0, 0, 0);
                killAllCheckboxTime = min;
                if (showInfo) { MessageBox.Show($"Info! Saved minutes!", "Info!", MessageBoxButtons.OK); }
                return false;
            }
            catch (FormatException)
            {
                if (killall_fromtime_checkbox.Checked)
                {
                    MessageBox.Show($"Error! Check your input minutes!", "Error!", MessageBoxButtons.OK);
                    min_textbox.ForeColor = Color.FromArgb(255, 255, 0, 0);
                    killAllCheckboxTime = -1;
                    return true;
                }
                else { return false; }
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e != null) 
            { 
                e.Cancel = CheckFormatMinutes(min_textbox.Text); 
            }
        }

        private void UpdateValues()
        {
            killAllCheckbox = killall_fromtime_checkbox.Checked;
            killAllCheckboxTime = int.Parse(min_textbox.Text);
            based.UpdateSettings();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateValues();
        }

        private void min_textbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { CheckFormatMinutes(min_textbox.Text); UpdateValues(); }
        }
    }
}
