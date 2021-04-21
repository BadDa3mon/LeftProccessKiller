
namespace LeftProccessKiller
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.killall_fromtime_checkbox = new System.Windows.Forms.CheckBox();
            this.min_textbox = new System.Windows.Forms.TextBox();
            this.min_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // killall_fromtime_checkbox
            // 
            this.killall_fromtime_checkbox.AutoSize = true;
            this.killall_fromtime_checkbox.Location = new System.Drawing.Point(12, 12);
            this.killall_fromtime_checkbox.Name = "killall_fromtime_checkbox";
            this.killall_fromtime_checkbox.Size = new System.Drawing.Size(250, 21);
            this.killall_fromtime_checkbox.TabIndex = 2;
            this.killall_fromtime_checkbox.Text = "Убить все каждый через каждые:";
            this.killall_fromtime_checkbox.UseVisualStyleBackColor = true;
            this.killall_fromtime_checkbox.CheckedChanged += new System.EventHandler(this.killall_fromtime_checkbox_CheckedChanged);
            // 
            // min_textbox
            // 
            this.min_textbox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.min_textbox.Location = new System.Drawing.Point(274, 10);
            this.min_textbox.Name = "min_textbox";
            this.min_textbox.Size = new System.Drawing.Size(120, 22);
            this.min_textbox.TabIndex = 3;
            this.min_textbox.TextChanged += new System.EventHandler(this.min_textbox_TextChanged);
            this.min_textbox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.min_textbox_KeyUp);
            // 
            // min_label
            // 
            this.min_label.AutoSize = true;
            this.min_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.min_label.Location = new System.Drawing.Point(398, 15);
            this.min_label.Name = "min_label";
            this.min_label.Size = new System.Drawing.Size(33, 17);
            this.min_label.TabIndex = 4;
            this.min_label.Text = "мин";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 50);
            this.Controls.Add(this.min_label);
            this.Controls.Add(this.min_textbox);
            this.Controls.Add(this.killall_fromtime_checkbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "LeftProcessKiller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox killall_fromtime_checkbox;
        private System.Windows.Forms.TextBox min_textbox;
        private System.Windows.Forms.Label min_label;
    }
}