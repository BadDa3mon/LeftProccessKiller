
namespace LeftProccessKiller
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.kill_button = new System.Windows.Forms.Button();
            this.process_title = new System.Windows.Forms.Label();
            this.listview_process = new System.Windows.Forms.ListView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.select_file_button = new System.Windows.Forms.Button();
            this.killall_button = new System.Windows.Forms.Button();
            this.processes_path_label = new System.Windows.Forms.Label();
            this.k_proccesses = new System.Windows.Forms.Label();
            this.update_process_button = new System.Windows.Forms.Button();
            this.settings_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // kill_button
            // 
            this.kill_button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kill_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kill_button.Location = new System.Drawing.Point(375, 117);
            this.kill_button.Name = "kill_button";
            this.kill_button.Size = new System.Drawing.Size(125, 36);
            this.kill_button.TabIndex = 0;
            this.kill_button.Text = "Убить";
            this.kill_button.UseVisualStyleBackColor = true;
            this.kill_button.Click += new System.EventHandler(this.kill_button_Click);
            // 
            // process_title
            // 
            this.process_title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.process_title.AutoSize = true;
            this.process_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.process_title.Location = new System.Drawing.Point(12, 9);
            this.process_title.Name = "process_title";
            this.process_title.Size = new System.Drawing.Size(134, 29);
            this.process_title.TabIndex = 1;
            this.process_title.Text = "Процессы:";
            // 
            // listview_process
            // 
            this.listview_process.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listview_process.HideSelection = false;
            this.listview_process.Location = new System.Drawing.Point(17, 42);
            this.listview_process.Name = "listview_process";
            this.listview_process.Size = new System.Drawing.Size(352, 153);
            this.listview_process.TabIndex = 2;
            this.listview_process.UseCompatibleStateImageBehavior = false;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(17, 220);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(146, 21);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Импорт из файла";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // select_file_button
            // 
            this.select_file_button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.select_file_button.BackColor = System.Drawing.Color.Transparent;
            this.select_file_button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.select_file_button.FlatAppearance.BorderSize = 0;
            this.select_file_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.select_file_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.select_file_button.Location = new System.Drawing.Point(162, 206);
            this.select_file_button.Margin = new System.Windows.Forms.Padding(0);
            this.select_file_button.Name = "select_file_button";
            this.select_file_button.Size = new System.Drawing.Size(40, 45);
            this.select_file_button.TabIndex = 4;
            this.select_file_button.Text = "✓";
            this.select_file_button.UseVisualStyleBackColor = false;
            this.select_file_button.Visible = false;
            this.select_file_button.Click += new System.EventHandler(this.select_file_button_Click);
            // 
            // killall_button
            // 
            this.killall_button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.killall_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.killall_button.Location = new System.Drawing.Point(375, 159);
            this.killall_button.Name = "killall_button";
            this.killall_button.Size = new System.Drawing.Size(125, 36);
            this.killall_button.TabIndex = 6;
            this.killall_button.Text = "Убить все";
            this.killall_button.UseVisualStyleBackColor = true;
            this.killall_button.Click += new System.EventHandler(this.killall_button_Click);
            // 
            // processes_path_label
            // 
            this.processes_path_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processes_path_label.AutoSize = true;
            this.processes_path_label.Location = new System.Drawing.Point(14, 198);
            this.processes_path_label.Name = "processes_path_label";
            this.processes_path_label.Size = new System.Drawing.Size(78, 17);
            this.processes_path_label.TabIndex = 7;
            this.processes_path_label.Text = "Процессы:";
            // 
            // k_proccesses
            // 
            this.k_proccesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.k_proccesses.AutoSize = true;
            this.k_proccesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.k_proccesses.Location = new System.Drawing.Point(145, 9);
            this.k_proccesses.Name = "k_proccesses";
            this.k_proccesses.Size = new System.Drawing.Size(26, 29);
            this.k_proccesses.TabIndex = 8;
            this.k_proccesses.Text = "0";
            // 
            // update_process_button
            // 
            this.update_process_button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.update_process_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.update_process_button.Location = new System.Drawing.Point(375, 75);
            this.update_process_button.Name = "update_process_button";
            this.update_process_button.Size = new System.Drawing.Size(125, 36);
            this.update_process_button.TabIndex = 9;
            this.update_process_button.Text = "Обновить";
            this.update_process_button.UseVisualStyleBackColor = true;
            this.update_process_button.Click += new System.EventHandler(this.update_process_button_Click);
            // 
            // settings_button
            // 
            this.settings_button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settings_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settings_button.Location = new System.Drawing.Point(375, 33);
            this.settings_button.Name = "settings_button";
            this.settings_button.Size = new System.Drawing.Size(125, 36);
            this.settings_button.TabIndex = 10;
            this.settings_button.Text = "Настройки";
            this.settings_button.UseVisualStyleBackColor = true;
            this.settings_button.Click += new System.EventHandler(this.settings_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 255);
            this.Controls.Add(this.settings_button);
            this.Controls.Add(this.update_process_button);
            this.Controls.Add(this.k_proccesses);
            this.Controls.Add(this.processes_path_label);
            this.Controls.Add(this.killall_button);
            this.Controls.Add(this.select_file_button);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.listview_process);
            this.Controls.Add(this.process_title);
            this.Controls.Add(this.kill_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "LeftProccessKiller";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kill_button;
        private System.Windows.Forms.Label process_title;
        private System.Windows.Forms.ListView listview_process;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button select_file_button;
        private System.Windows.Forms.Button killall_button;
        private System.Windows.Forms.Label processes_path_label;
        private System.Windows.Forms.Label k_proccesses;
        private System.Windows.Forms.Button update_process_button;
        private System.Windows.Forms.Button settings_button;
    }
}

