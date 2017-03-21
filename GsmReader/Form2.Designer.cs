namespace GsmReader
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
            this.file1_location = new System.Windows.Forms.TextBox();
            this.file1_location_label = new System.Windows.Forms.Label();
            this.add_file1_location = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.file_2_location_label = new System.Windows.Forms.Label();
            this.file2_location = new System.Windows.Forms.TextBox();
            this.file3_location = new System.Windows.Forms.TextBox();
            this.file_3_location_label = new System.Windows.Forms.Label();
            this.add_file3_location = new System.Windows.Forms.Button();
            this.file_list_table = new System.Windows.Forms.DataGridView();
            this.mix_gsm_button = new System.Windows.Forms.Button();
            this.add_row = new System.Windows.Forms.Button();
            this.move_down = new System.Windows.Forms.Button();
            this.move_up = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.console_output = new System.Windows.Forms.TextBox();
            this.sel_file1 = new System.Windows.Forms.RadioButton();
            this.sel_file2 = new System.Windows.Forms.RadioButton();
            this.sel_file3 = new System.Windows.Forms.RadioButton();
            this.convert_to_gsm = new System.Windows.Forms.Button();
            this.choose_folder = new System.Windows.Forms.Button();
            this.folder_path_label = new System.Windows.Forms.Label();
            this.folder_path = new System.Windows.Forms.TextBox();
            this.mix_gsm_button2 = new System.Windows.Forms.Button();
            this.parameter_id = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.file_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type_list = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.material = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.delete_parameter = new System.Windows.Forms.DataGridViewButtonColumn();
            this.add_parameter = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.file_list_table)).BeginInit();
            this.SuspendLayout();
            // 
            // file1_location
            // 
            this.file1_location.Location = new System.Drawing.Point(143, 23);
            this.file1_location.Name = "file1_location";
            this.file1_location.Size = new System.Drawing.Size(324, 20);
            this.file1_location.TabIndex = 0;
            // 
            // file1_location_label
            // 
            this.file1_location_label.AutoSize = true;
            this.file1_location_label.Location = new System.Drawing.Point(30, 29);
            this.file1_location_label.Name = "file1_location_label";
            this.file1_location_label.Size = new System.Drawing.Size(76, 13);
            this.file1_location_label.TabIndex = 1;
            this.file1_location_label.Text = "File 1 Location";
            // 
            // add_file1_location
            // 
            this.add_file1_location.Location = new System.Drawing.Point(487, 23);
            this.add_file1_location.Name = "add_file1_location";
            this.add_file1_location.Size = new System.Drawing.Size(45, 23);
            this.add_file1_location.TabIndex = 2;
            this.add_file1_location.Text = "...";
            this.add_file1_location.UseVisualStyleBackColor = true;
            this.add_file1_location.Click += new System.EventHandler(this.add_file1_location_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(487, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // file_2_location_label
            // 
            this.file_2_location_label.AutoSize = true;
            this.file_2_location_label.Location = new System.Drawing.Point(30, 66);
            this.file_2_location_label.Name = "file_2_location_label";
            this.file_2_location_label.Size = new System.Drawing.Size(76, 13);
            this.file_2_location_label.TabIndex = 4;
            this.file_2_location_label.Text = "File 2 Location";
            // 
            // file2_location
            // 
            this.file2_location.Location = new System.Drawing.Point(143, 60);
            this.file2_location.Name = "file2_location";
            this.file2_location.Size = new System.Drawing.Size(324, 20);
            this.file2_location.TabIndex = 3;
            // 
            // file3_location
            // 
            this.file3_location.Location = new System.Drawing.Point(143, 100);
            this.file3_location.Name = "file3_location";
            this.file3_location.Size = new System.Drawing.Size(324, 20);
            this.file3_location.TabIndex = 3;
            // 
            // file_3_location_label
            // 
            this.file_3_location_label.AutoSize = true;
            this.file_3_location_label.Location = new System.Drawing.Point(30, 106);
            this.file_3_location_label.Name = "file_3_location_label";
            this.file_3_location_label.Size = new System.Drawing.Size(76, 13);
            this.file_3_location_label.TabIndex = 4;
            this.file_3_location_label.Text = "File 3 Location";
            // 
            // add_file3_location
            // 
            this.add_file3_location.Location = new System.Drawing.Point(487, 100);
            this.add_file3_location.Name = "add_file3_location";
            this.add_file3_location.Size = new System.Drawing.Size(45, 23);
            this.add_file3_location.TabIndex = 5;
            this.add_file3_location.Text = "...";
            this.add_file3_location.UseVisualStyleBackColor = true;
            this.add_file3_location.Click += new System.EventHandler(this.add_file3_location_Click);
            // 
            // file_list_table
            // 
            this.file_list_table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.file_list_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.file_list_table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.parameter_id,
            this.file_name,
            this.type_list,
            this.material,
            this.delete_parameter,
            this.add_parameter});
            this.file_list_table.Location = new System.Drawing.Point(33, 238);
            this.file_list_table.Name = "file_list_table";
            this.file_list_table.Size = new System.Drawing.Size(718, 265);
            this.file_list_table.TabIndex = 18;
            this.file_list_table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.parameter_mix_table_CellContentClick);
            // 
            // mix_gsm_button
            // 
            this.mix_gsm_button.Location = new System.Drawing.Point(457, 143);
            this.mix_gsm_button.Name = "mix_gsm_button";
            this.mix_gsm_button.Size = new System.Drawing.Size(75, 23);
            this.mix_gsm_button.TabIndex = 17;
            this.mix_gsm_button.Text = "Combine Gsm";
            this.mix_gsm_button.UseVisualStyleBackColor = true;
            this.mix_gsm_button.Click += new System.EventHandler(this.mix_gsm_button_Click);
            // 
            // add_row
            // 
            this.add_row.Location = new System.Drawing.Point(532, 509);
            this.add_row.Name = "add_row";
            this.add_row.Size = new System.Drawing.Size(75, 23);
            this.add_row.TabIndex = 24;
            this.add_row.Text = "Add Row";
            this.add_row.UseVisualStyleBackColor = true;
            // 
            // move_down
            // 
            this.move_down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.move_down.Location = new System.Drawing.Point(685, 509);
            this.move_down.Name = "move_down";
            this.move_down.Size = new System.Drawing.Size(56, 23);
            this.move_down.TabIndex = 23;
            this.move_down.Text = "Down";
            this.move_down.UseVisualStyleBackColor = true;
            // 
            // move_up
            // 
            this.move_up.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.move_up.Location = new System.Drawing.Point(613, 509);
            this.move_up.Name = "move_up";
            this.move_up.Size = new System.Drawing.Size(56, 23);
            this.move_up.TabIndex = 22;
            this.move_up.Text = "Up";
            this.move_up.UseVisualStyleBackColor = true;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(30, 514);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(45, 13);
            this.Label2.TabIndex = 21;
            this.Label2.Text = "Console";
            // 
            // console_output
            // 
            this.console_output.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.console_output.Location = new System.Drawing.Point(33, 550);
            this.console_output.Multiline = true;
            this.console_output.Name = "console_output";
            this.console_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.console_output.Size = new System.Drawing.Size(718, 78);
            this.console_output.TabIndex = 20;
            // 
            // sel_file1
            // 
            this.sel_file1.AutoSize = true;
            this.sel_file1.Location = new System.Drawing.Point(558, 25);
            this.sel_file1.Name = "sel_file1";
            this.sel_file1.Size = new System.Drawing.Size(95, 17);
            this.sel_file1.TabIndex = 25;
            this.sel_file1.TabStop = true;
            this.sel_file1.Text = "Select as Main";
            this.sel_file1.UseVisualStyleBackColor = true;
            // 
            // sel_file2
            // 
            this.sel_file2.AutoSize = true;
            this.sel_file2.Location = new System.Drawing.Point(558, 65);
            this.sel_file2.Name = "sel_file2";
            this.sel_file2.Size = new System.Drawing.Size(95, 17);
            this.sel_file2.TabIndex = 26;
            this.sel_file2.TabStop = true;
            this.sel_file2.Text = "Select as Main";
            this.sel_file2.UseVisualStyleBackColor = true;
            // 
            // sel_file3
            // 
            this.sel_file3.AutoSize = true;
            this.sel_file3.Location = new System.Drawing.Point(558, 100);
            this.sel_file3.Name = "sel_file3";
            this.sel_file3.Size = new System.Drawing.Size(95, 17);
            this.sel_file3.TabIndex = 27;
            this.sel_file3.TabStop = true;
            this.sel_file3.Text = "Select as Main";
            this.sel_file3.UseVisualStyleBackColor = true;
            // 
            // convert_to_gsm
            // 
            this.convert_to_gsm.Location = new System.Drawing.Point(558, 142);
            this.convert_to_gsm.Name = "convert_to_gsm";
            this.convert_to_gsm.Size = new System.Drawing.Size(111, 23);
            this.convert_to_gsm.TabIndex = 28;
            this.convert_to_gsm.Text = "Convert To Gsm";
            this.convert_to_gsm.UseVisualStyleBackColor = true;
            this.convert_to_gsm.Click += new System.EventHandler(this.convert_to_gsm_Click);
            // 
            // choose_folder
            // 
            this.choose_folder.Location = new System.Drawing.Point(487, 192);
            this.choose_folder.Name = "choose_folder";
            this.choose_folder.Size = new System.Drawing.Size(45, 23);
            this.choose_folder.TabIndex = 31;
            this.choose_folder.Text = "...";
            this.choose_folder.UseVisualStyleBackColor = true;
            this.choose_folder.Click += new System.EventHandler(this.choose_folder_Click);
            // 
            // folder_path_label
            // 
            this.folder_path_label.AutoSize = true;
            this.folder_path_label.Location = new System.Drawing.Point(30, 198);
            this.folder_path_label.Name = "folder_path_label";
            this.folder_path_label.Size = new System.Drawing.Size(36, 13);
            this.folder_path_label.TabIndex = 30;
            this.folder_path_label.Text = "Folder";
            // 
            // folder_path
            // 
            this.folder_path.Location = new System.Drawing.Point(143, 192);
            this.folder_path.Name = "folder_path";
            this.folder_path.Size = new System.Drawing.Size(324, 20);
            this.folder_path.TabIndex = 29;
            // 
            // mix_gsm_button2
            // 
            this.mix_gsm_button2.Location = new System.Drawing.Point(558, 193);
            this.mix_gsm_button2.Name = "mix_gsm_button2";
            this.mix_gsm_button2.Size = new System.Drawing.Size(111, 23);
            this.mix_gsm_button2.TabIndex = 32;
            this.mix_gsm_button2.Text = "Combine Gsm";
            this.mix_gsm_button2.UseVisualStyleBackColor = true;
            this.mix_gsm_button2.Click += new System.EventHandler(this.mix_gsm_button2_Click);
            // 
            // parameter_id
            // 
            this.parameter_id.FillWeight = 50F;
            this.parameter_id.HeaderText = "Id";
            this.parameter_id.Name = "parameter_id";
            this.parameter_id.Width = 50;
            // 
            // file_name
            // 
            this.file_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.file_name.FillWeight = 250F;
            this.file_name.HeaderText = "File Name";
            this.file_name.Name = "file_name";
            // 
            // type_list
            // 
            this.type_list.DataPropertyName = "type_list";
            this.type_list.HeaderText = "Type";
            this.type_list.Name = "type_list";
            // 
            // material
            // 
            this.material.HeaderText = "Material";
            this.material.Name = "material";
            // 
            // delete_parameter
            // 
            this.delete_parameter.FillWeight = 50F;
            this.delete_parameter.HeaderText = "delete";
            this.delete_parameter.Name = "delete_parameter";
            this.delete_parameter.Text = "X";
            this.delete_parameter.ToolTipText = "delete parameter";
            this.delete_parameter.UseColumnTextForButtonValue = true;
            this.delete_parameter.Width = 50;
            // 
            // add_parameter
            // 
            this.add_parameter.FillWeight = 50F;
            this.add_parameter.HeaderText = "add";
            this.add_parameter.Name = "add_parameter";
            this.add_parameter.Text = "add";
            this.add_parameter.ToolTipText = "insert parameter";
            this.add_parameter.UseColumnTextForButtonValue = true;
            this.add_parameter.Width = 50;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 638);
            this.Controls.Add(this.mix_gsm_button2);
            this.Controls.Add(this.choose_folder);
            this.Controls.Add(this.folder_path_label);
            this.Controls.Add(this.folder_path);
            this.Controls.Add(this.convert_to_gsm);
            this.Controls.Add(this.sel_file3);
            this.Controls.Add(this.sel_file2);
            this.Controls.Add(this.sel_file1);
            this.Controls.Add(this.add_row);
            this.Controls.Add(this.move_down);
            this.Controls.Add(this.move_up);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.console_output);
            this.Controls.Add(this.file_list_table);
            this.Controls.Add(this.mix_gsm_button);
            this.Controls.Add(this.add_file3_location);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.file_3_location_label);
            this.Controls.Add(this.file3_location);
            this.Controls.Add(this.file_2_location_label);
            this.Controls.Add(this.file2_location);
            this.Controls.Add(this.add_file1_location);
            this.Controls.Add(this.file1_location_label);
            this.Controls.Add(this.file1_location);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.file_list_table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox file1_location;
        private System.Windows.Forms.Label file1_location_label;
        private System.Windows.Forms.Button add_file1_location;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label file_2_location_label;
        private System.Windows.Forms.TextBox file2_location;
        private System.Windows.Forms.TextBox file3_location;
        private System.Windows.Forms.Label file_3_location_label;
        private System.Windows.Forms.Button add_file3_location;
        internal System.Windows.Forms.DataGridView file_list_table;
        internal System.Windows.Forms.Button mix_gsm_button;
        private System.Windows.Forms.Button add_row;
        private System.Windows.Forms.Button move_down;
        private System.Windows.Forms.Button move_up;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox console_output;
        private System.Windows.Forms.RadioButton sel_file1;
        private System.Windows.Forms.RadioButton sel_file2;
        private System.Windows.Forms.RadioButton sel_file3;
        private System.Windows.Forms.Button convert_to_gsm;
        private System.Windows.Forms.Button choose_folder;
        private System.Windows.Forms.Label folder_path_label;
        private System.Windows.Forms.TextBox folder_path;
        internal System.Windows.Forms.Button mix_gsm_button2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn parameter_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn file_name;
        private System.Windows.Forms.DataGridViewComboBoxColumn type_list;
        private System.Windows.Forms.DataGridViewComboBoxColumn material;
        private System.Windows.Forms.DataGridViewButtonColumn delete_parameter;
        private System.Windows.Forms.DataGridViewButtonColumn add_parameter;
    }
}